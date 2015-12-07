using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DotNetLiberty.Http
{
    public static class HttpClientExtensions
    {
        public static async Task<IEnumerable<TEntity>> GetManyAsync<TEntity>(this HttpClient client)
        {
            return await client.GetManyAsync<TEntity>((Uri)null);
        }

        public static async Task<IEnumerable<TEntity>> GetManyAsync<TEntity>(this HttpClient client, string requestUri)
        {
            return await client.GetManyAsync<TEntity>(new Uri(requestUri));
        }

        public static async Task<IEnumerable<TEntity>> GetManyAsync<TEntity>(this HttpClient client, Uri requestUri)
        {
            var result = await client.GetAsync(requestUri);
            result.ThrowIfUnsuccessful();
            return await result.ReadEntities<TEntity>();
        }

        public static async Task<TEntity> GetSingleAsync<TEntity>(this HttpClient client, object id)
        {
            return await client.GetSingleAsync<TEntity>(id.ToString());
        }

        public static async Task<TEntity> GetSingleAsync<TEntity>(this HttpClient client, string requestUri)
        {
            var result = await client.GetAsync(requestUri);
            result.ThrowIfUnsuccessful();
            return await result.ReadEntity<TEntity>();
        }

        public static async Task<TEntity> GetSingleAsync<TEntity>(this HttpClient client, Uri requestUri)
        {
            var result = await client.GetAsync(requestUri);
            result.ThrowIfUnsuccessful();
            return await result.ReadEntity<TEntity>();
        }

        public static async Task<TEntity> PostAsync<TEntity>(this HttpClient client, TEntity entity)
        {
            return await client.PostAsync((Uri)null, entity);
        }

        public static async Task<TEntity> PostAsync<TEntity>(this HttpClient client, string requestUri, TEntity entity)
        {
            return await client.PostAsync(new Uri(requestUri), entity);
        }

        public static async Task<TEntity> PostAsync<TEntity>(this HttpClient client, Uri requestUri, TEntity entity)
        {
            var result = await client.PostAsync(requestUri, JsonContent(entity));
            result.ThrowIfUnsuccessful();
            return await result.ReadEntity<TEntity>();
        }

        public static async Task<TEntity> PutAsync<TEntity>(this HttpClient client, object id, TEntity entity)
        {
            return await client.PutAsync(id.ToString(), entity);
        }

        public static async Task<TEntity> PutAsync<TEntity>(this HttpClient client, string requestUri, TEntity entity)
        {
            var result = await client.PutAsync(requestUri, JsonContent(entity));
            result.ThrowIfUnsuccessful();
            return await result.ReadEntity<TEntity>();
        }

        public static async Task<TEntity> PutAsync<TEntity>(this HttpClient client, Uri requestUri, TEntity entity)
        {
            var result = await client.PutAsync(requestUri, JsonContent(entity));
            result.ThrowIfUnsuccessful();
            return await result.ReadEntity<TEntity>();
        }

        public static async Task DeleteAsync(this HttpClient client, object id)
        {
            await client.DeleteAsync(id.ToString());
        }

        public static async Task DeleteAsync(this HttpClient client, string requestUri)
        {
            var result = await client.DeleteAsync(requestUri);
            result.ThrowIfUnsuccessful();
        }

        public static async Task DeleteAsync(this HttpClient client, Uri requestUri)
        {
            var result = await client.DeleteAsync(requestUri);
            result.ThrowIfUnsuccessful();
        }

        public static HttpClient WithBaseUri(this HttpClient client, Uri baseUri)
        {
            client.BaseAddress = baseUri;
            return client;
        }

        public static HttpClient AcceptJson(this HttpClient client)
        {
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private static JsonContent JsonContent<TEntity>(TEntity entity)
        {
            return new JsonContent<TEntity>(entity);
        }
    }
}
