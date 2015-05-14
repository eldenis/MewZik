using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MewZik.Nucleo
{
    [DataContract, KnownType(typeof(DatosProveedorTexto))]

    public class DatosConfiguracion
    {
        [DataMember]
        public object DatosProveedor { get; set; }
        [DataMember]
        public TiposProveedores TipoProveedor { get; set; }
    }

    [DataContract]
    public class DatosProveedorTexto
    {
        [DataMember]
        public Dictionary<TiposFuentesProveedor, string> Fuentes { get; set; }
    }

    public enum TiposProveedores
    {
        Ruta = 1,
        BaseDatos = 2,
    }
}
