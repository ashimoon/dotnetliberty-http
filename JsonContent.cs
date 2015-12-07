using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;

namespace DotNetLiberty.Http
{
    public class JsonContent<TEntity> : JsonContent
    {
        public JsonContent(TEntity entity)
            : base(Serialize(entity))
        {

        }

        protected static byte[] Serialize(TEntity entity)
        {
            if (null == entity)
            {
                return new byte[0];
            }
            var serializer = new DataContractJsonSerializer(typeof(TEntity));
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, entity);
                return stream.ToArray();
            }
        }
    }

    public class JsonContent : StringContent
    {
        private const string ApplicationJson = "application/json";

        public JsonContent(MemoryStream stream)
            : this(stream.ToArray())
        { }

        public JsonContent(byte[] bytes)
            : base(ToUtf8(bytes), Encoding.UTF8, ApplicationJson)
        { }

        private static string ToUtf8(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
    }
}