using System;
using System.IO;
using System.Net.Http;

namespace DotNetLiberty.Http.Sync
{
    public static class HttpClientExtensions
    {
        public static HttpResponseMessage Delete(this HttpClient client, string requestUri)
        {
            return client.DeleteAsync(requestUri)
                .AwaitResultOrUnwrapException();
        }

        public static HttpResponseMessage Delete(this HttpClient client, Uri requestUri)
        {
            return client.DeleteAsync(requestUri)
                .AwaitResultOrUnwrapException();
        }

        public static HttpResponseMessage Get(this HttpClient client, string requestUri)
        {
            return client.GetAsync(requestUri)
                .AwaitResultOrUnwrapException();
        }

        public static HttpResponseMessage Get(this HttpClient client, Uri requestUri)
        {
            return client.GetAsync(requestUri)
                .AwaitResultOrUnwrapException();
        }

        public static HttpResponseMessage Get(this HttpClient client, string requestUri, HttpCompletionOption completionOption)
        {
            return client.GetAsync(requestUri, completionOption)
                .AwaitResultOrUnwrapException();
        }

        public static HttpResponseMessage Get(this HttpClient client, Uri requestUri, HttpCompletionOption completionOption)
        {
            return client.GetAsync(requestUri, completionOption)
                .AwaitResultOrUnwrapException();
        }

        public static byte[] GetByteArray(this HttpClient client, string requestUri)
        {
            return client.GetByteArrayAsync(requestUri)
                .AwaitResultOrUnwrapException();
        }

        public static byte[] GetByteArray(this HttpClient client, Uri requestUri)
        {
            return client.GetByteArrayAsync(requestUri)
                .AwaitResultOrUnwrapException();
        }

        public static Stream GetStream(this HttpClient client, string requestUri)
        {
            return client.GetStreamAsync(requestUri)
                .AwaitResultOrUnwrapException();
        }

        public static Stream GetStream(this HttpClient client, Uri requestUri)
        {
            return client.GetStreamAsync(requestUri)
                .AwaitResultOrUnwrapException();
        }

        public static string GetString(this HttpClient client, string requestUri)
        {
            return client.GetStringAsync(requestUri)
                .AwaitResultOrUnwrapException();
        }

        public static string GetString(this HttpClient client, Uri requestUri)
        {
            return client.GetStringAsync(requestUri)
                .AwaitResultOrUnwrapException();
        }

        public static HttpResponseMessage Post(this HttpClient client, string requestUri, HttpContent content)
        {
            return client.PostAsync(requestUri, content)
                .AwaitResultOrUnwrapException();
        }

        public static HttpResponseMessage Post(this HttpClient client, Uri requestUri, HttpContent content)
        {
            return client.PostAsync(requestUri, content)
                .AwaitResultOrUnwrapException();
        }

        public static HttpResponseMessage Put(this HttpClient client, string requestUri, HttpContent content)
        {
            return client.PutAsync(requestUri, content)
                .AwaitResultOrUnwrapException();
        }

        public static HttpResponseMessage Put(this HttpClient client, Uri requestUri, HttpContent content)
        {
            return client.PutAsync(requestUri, content)
                .AwaitResultOrUnwrapException();
        }

        public static HttpResponseMessage Send(this HttpClient client, HttpRequestMessage request)
        {
            return client.SendAsync(request)
                .AwaitResultOrUnwrapException();
        }

        public static HttpResponseMessage Send(this HttpClient client, HttpRequestMessage request, HttpCompletionOption completionOption)
        {
            return client.SendAsync(request, completionOption)
                .AwaitResultOrUnwrapException();
        }
    }
}
