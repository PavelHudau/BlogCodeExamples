using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;

namespace MicrosoftGraphApplicationAuth
{
    public class GraphServiceClientFactory
    {
        public IGraphServiceClient Create(IGraphConfig graphConfig)
        {
            var builder = ConfidentialClientApplicationBuilder
                .Create(graphConfig.ClientId)
                .WithClientSecret(graphConfig.ClientSecret)
                .WithAuthority(graphConfig.Authority);

            var scope = $"{graphConfig.ApiUri}.default";

            if (!string.IsNullOrEmpty(graphConfig.HttpProxyHost) && graphConfig.HttpProxyPort.HasValue)
            {
                // Using proxy
                builder.WithHttpClientFactory(new HttpClientFactoryWithProxy(graphConfig.HttpProxyHost, graphConfig.HttpProxyPort.Value));
                var clientApp = builder.Build();
                var httpProvider = new HttpProvider(
                    HttpClientFactoryWithProxy.CreateHttpClientHandler(
                    graphConfig.HttpProxyHost, graphConfig.HttpProxyPort.Value),
                    true);
                return new GraphServiceClient(new ClientCredentialProvider(clientApp, scope), httpProvider);

            }
            else
            {
                var clientApp = builder.Build();
                return new GraphServiceClient(new ClientCredentialProvider(clientApp, scope));
            }
        }
    }
}