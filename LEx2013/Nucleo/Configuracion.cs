using System;
using System.Collections.Generic;
using System.IO;
using MewZik.Utils;

namespace MewZik.Nucleo
{
    public static class Configuracion
    {
        const string NombreArchivoConfiguracion = "MewZik.config";

        public static DatosConfiguracion ObtenerConfiguracion()
        {
            var nombreArchivo = Path.Combine(Environment.GetFolderPath(
                           Environment.SpecialFolder.CommonApplicationData),
                           NombreArchivoConfiguracion);

            if (File.Exists(nombreArchivo))
            {
                var datosConfiguracion = Utilitarios.Deserializar<DatosConfiguracion>(File.ReadAllText(nombreArchivo));
                return datosConfiguracion;
            }

            File.WriteAllText(nombreArchivo,
                Utilitarios.Serializar(ObtenerDatosConfiguracionDefault()));

            throw new Exception(string.Format("No está configurado el archivo de conexión {0}", nombreArchivo));
        }



        private static DatosConfiguracion ObtenerDatosConfiguracionDefault()
        {
            return new DatosConfiguracion
            {
                TipoProveedor = TiposProveedores.Ruta,
                DatosProveedor = new DatosProveedorTexto
                {
                    Fuentes = new Dictionary<TiposFuentesProveedor, string>{
                        {TiposFuentesProveedor.Letras, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)},
                        {TiposFuentesProveedor.Acordes, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}
                    }
                }
            };
        }
    }




}
