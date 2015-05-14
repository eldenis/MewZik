namespace MewZik.Nucleo
{
    public class ProtoCancion
    {
        public ProtoCancion(string identificacion, string nombre)
        {
            Identificacion = identificacion;
            Nombre = nombre;
        }

        public string Identificacion { get; private set; }
        public string Nombre { get; private set; }

    }
}
