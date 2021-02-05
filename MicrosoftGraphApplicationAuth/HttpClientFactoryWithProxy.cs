using System;
using System.Net;
using System.Net.Http;
using Microsoft.Identity.Client;

namespace MicrosoftGraphApplicationAuth
{
    internal class HttpClientFactoryWithProxy: IMsalHttpClientFactory, IDisposable
    {
        private readonly HttpClient _httpClient;

        public HttpClientFactoryWithProxy(string proxyHost, int proxyPort)
        {
            _httpClient = new HttpClient(CreateHttpClientHandler(proxyHost, proxyPort), true);
        }

        ~HttpClientFactoryWithProxy()
        {
            Dispose();
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
            GC.SuppressFinalize(true);
        }

        public HttpClient GetHttpClient()
        {
            return _httpClient;
        }

        public static HttpClientHandler CreateHttpClientHandler(string proxyHost, int proxyPort)
        {
            return new HttpClientHandler
            {
                AllowAutoRedirect = false,
                AutomaticDecompression = DecompressionMethods.None,
                Proxy = new WebProxy(proxyHost, proxyPort)
            };
        }
    }
}