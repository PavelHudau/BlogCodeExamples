using System;

namespace MicrosoftGraphApplicationAuth
{
    public interface IGraphConfig
    {
        string ApiUri { get; }
        string ApplicationId { get; }
        string Tenant { get; }
        string ClientId { get; }
        Uri Authority { get; }
        string ClientSecret { get; }
        string HttpProxyHost { get; }
        int? HttpProxyPort { get; }
    }
}