using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNetLiberty.Http
{
    public class WebApiClient<TEntity, TKey> : HttpClient
    {
        public WebApiClient(Uri baseAddress)
        {
            this.WithBaseUri(baseAddress);
            this.AcceptJson();
        }

        public void Delete(TKey id)
        {
            this.DeleteAsync(id)
                .WaitOrUnwrapException();
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync()
        {
            return await this.GetManyAsync<TEntity>();
        }

        public IEnumerable<TEntity> GetMany()
        {
            return Get();
        }

        public IEnumerable<TEntity> Get()
        {
            return this.GetManyAsync<TEntity>()
                .AwaitResultOrUnwrapException();
        }

        public async Task<TEntity> GetSingleAsync(TKey id)
        {
            return await this.GetSingleAsync<TEntity>(id);
        }

        public TEntity GetSingle(TKey id)
        {
            return Get(id);
        }

        public TEntity Get(TKey id)
        {
            return this.GetSingleAsync<TEntity>(id)
                .AwaitResultOrUnwrapException();
        }

        public TEntity Post(TEntity value)
        {
            return this.PostAsync(value)
                .AwaitResultOrUnwrapException();
        }

        public TEntity Put(TKey id, TEntity value)
        {
            return this.PutAsync(id, value)
                .AwaitResultOrUnwrapException();
        }
    }
}