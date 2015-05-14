using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace MewZik.Utils
{
    public static class Utilitarios
    {
        public static string Serializar<T>(T objeto)
        {
            var dcs = new DataContractSerializer(typeof(T));
            using (var s = new MemoryStream())
            {
                dcs.WriteObject(s, objeto);
                s.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(s)) return reader.ReadToEnd();
            }
        }

        public static T? EnumNullableTryParse<T>(string valor) where T : struct
        {
            T tipoFuenteInicial;

            return Enum.TryParse(valor, out tipoFuenteInicial) ?
                tipoFuenteInicial : (T?)null;
        }


        public static void PersistirSerializado<T>(this T objeto, string ruta)
        {
            File.WriteAllText(ruta, Serializar(objeto));
        }

        public static T Deserializar<T>(string data, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;

            using (var stream = new MemoryStream(encoding.GetBytes(data)))
                return Deserializar<T>(stream);
        }

        public static T Deserializar<T>(Stream data)
        {
            return (T)(new DataContractSerializer(typeof(T))).ReadObject(data);
        }

    }
}
