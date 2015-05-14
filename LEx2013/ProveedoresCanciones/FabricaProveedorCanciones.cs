using System;
using MewZik.Nucleo;

namespace MewZik.ProveedoresCanciones
{
    public static class FabricaProveedorCanciones
    {
        public static IProveedorCanciones ObtenerLector()
        {
            var config = Configuracion.ObtenerConfiguracion();
            switch (config.TipoProveedor)
            {
                case TiposProveedores.Ruta:
                    return new ProveedorCancionesTexto(config.DatosProveedor as DatosProveedorTexto);
                case TiposProveedores.BaseDatos:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


    }
}
