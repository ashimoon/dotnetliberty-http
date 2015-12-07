using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace DotNetLiberty.Http
{
    public static class HttpResponseMessageExtensions
    {
        public static void ThrowIfUnsuccessful(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Status code: {(int)response.StatusCode}: {response.ReasonPhrase}");
            }
        }

        public static async Task<IEnumerable<TEntity>> ReadEntities<TEntity>(this HttpResponseMessage response)
        {
            var stream = await response.Content.ReadAsStreamAsync();
            if (stream.Length == 0) return new List<TEntity>();
            var serializer = new DataContractJsonSerializer(typeof (List<TEntity>));
            return (IEnumerable<TEntity>) serializer.ReadObject(stream);
        }

        public static async Task<TEntity> ReadEntity<TEntity>(this HttpResponseMessage response)
        {
            var stream = await response.Content.ReadAsStreamAsync();
            if (stream.Length == 0) return default(TEntity);
            var serializer = new DataContractJsonSerializer(typeof (TEntity));
            return (TEntity) serializer.ReadObject(stream);
        }
    }
}