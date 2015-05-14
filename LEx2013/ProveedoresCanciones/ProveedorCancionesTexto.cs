using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using MewZik.Nucleo;
using MewZik.Utils;

namespace MewZik.ProveedoresCanciones
{
    public class ProveedorCancionesTexto : IProveedorCanciones
    {
        readonly DatosProveedorTexto _datosProveedor;
        readonly ReadOnlyCollection<TiposFuentesProveedor> _fuentes;
        TiposFuentesProveedor _fuenteSeleccionada;
        const string ExtensionArchivosCanciones = "txt";
        static readonly string CadenaBusquedaPredeterminada = string.Format("*.{0}", ExtensionArchivosCanciones);
        public ProveedorCancionesTexto(DatosProveedorTexto datosProveedor)
        {
            _datosProveedor = datosProveedor;
            _fuentes = new ReadOnlyCollection<TiposFuentesProveedor>(datosProveedor.Fuentes.Select(x => x.Key).ToArray());
            _fuenteSeleccionada = _fuentes[0];
        }

        public IList<TiposFuentesProveedor> Fuentes
        {
            get { return _fuentes; }
        }

        public void SeleccionarFuente(TiposFuentesProveedor fuente)
        {
            _fuenteSeleccionada = fuente;
        }

        static readonly Func<string, ProtoCancion> FuncCreacionProtoCancion = x => new ProtoCancion(x, Path.GetFileName(x));
        static IList<ProtoCancion> ObtenerArchivosDirectorio(string directorio, string filtro)
        {
            var filtroSinDiacriticos = string.IsNullOrEmpty(filtro) ? filtro : filtro.ToLowerInvariant().RemoveDiacritics();

            return Directory
                .GetFiles(directorio, CadenaBusquedaPredeterminada)
                .Where(x => string.IsNullOrEmpty(filtroSinDiacriticos) ||
                    x.ToLowerInvariant().RemoveDiacritics().Contains(filtroSinDiacriticos))
                .Select(FuncCreacionProtoCancion)
                .ToArray();
        }


        public IList<ProtoCancion> ObtenerArchivos(string filtro)
        {
            return ObtenerArchivosDirectorio(_datosProveedor.Fuentes[_fuenteSeleccionada], filtro);
        }

        public string LeerCancion(ProtoCancion protoCancion)
        {
            if (protoCancion == null || protoCancion.Identificacion == null) return null;

            if (!File.Exists(protoCancion.Identificacion))
                throw new Exception(string.Format("No se consiguió la canción leída desde {0}",
                    protoCancion.Identificacion));

            return File.ReadAllText(protoCancion.Identificacion, Encoding.UTF7);
        }


        public void EliminarCancion(ProtoCancion cancion)
        {
            if (cancion != null && !string.IsNullOrWhiteSpace(cancion.Identificacion) && File.Exists(cancion.Identificacion))
                File.Delete(cancion.Identificacion);
        }

        public void GuardarCancion(ProtoCancion cancionLeida, string contenido)
        {
            if (cancionLeida == null) return;

            File.WriteAllText(cancionLeida.Identificacion, contenido ?? string.Empty, Encoding.UTF7);
        }


        public ProtoCancion AgregarCancion(string nombre, string contenido = null)
        {
            var cancion = FuncCreacionProtoCancion(
                Path.Combine(_datosProveedor.Fuentes[_fuenteSeleccionada],
                Path.ChangeExtension(nombre, ExtensionArchivosCanciones)));

            if (!File.Exists(cancion.Identificacion))
                GuardarCancion(cancion, contenido);

            return cancion;
        }

        public ProtoCancion RenombrarCancion(ProtoCancion cancionSeleccionada, string nombreCancionNueva)
        {
            var cancion = FuncCreacionProtoCancion(
                Path.Combine(Path.GetDirectoryName(cancionSeleccionada.Identificacion),
                Path.ChangeExtension(nombreCancionNueva, ExtensionArchivosCanciones)));

            if (File.Exists(cancion.Identificacion))
                throw new Exception("Ya existe la misma canción. No puede ser sobreescrita.");

            File.Move(cancionSeleccionada.Identificacion, cancion.Identificacion);

            return cancion;
        }

        public string ObtenerNombreDuplicado(ProtoCancion cancionSeleccionada)
        {
            var num = 1;
            var nuevoArchivo = cancionSeleccionada.Identificacion;
            var nombreOriginal = Path.GetFileNameWithoutExtension(cancionSeleccionada.Identificacion);
            var directorioOriginal = Path.GetDirectoryName(nuevoArchivo);

            while (File.Exists(nuevoArchivo))
                nuevoArchivo = Path.ChangeExtension(
                    Path.Combine(directorioOriginal, string.Format("{0} ({1})", nombreOriginal, (++num))),
                    Path.GetExtension(nuevoArchivo));

            return Path.GetFileName(nuevoArchivo);
        }



    }
}
