using System.Collections.Generic;
using MewZik.Nucleo;

namespace MewZik.ProveedoresCanciones
{
    public interface IProveedorCanciones
    {
        IList<TiposFuentesProveedor> Fuentes { get; }
        void SeleccionarFuente(TiposFuentesProveedor fuente);
        IList<ProtoCancion> ObtenerArchivos(string filtro);
        string LeerCancion(ProtoCancion protoCancion);
        void EliminarCancion(ProtoCancion seleccionada);
        ProtoCancion AgregarCancion(string nombre, string contenido = null);

        ProtoCancion RenombrarCancion(ProtoCancion cancionSeleccionada, string nombreCancionNueva);

        string ObtenerNombreDuplicado(ProtoCancion cancionSeleccionada);

        void GuardarCancion(ProtoCancion cancionLeida, string contenido);
    }


}
