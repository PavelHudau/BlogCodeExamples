using System;
using System.Globalization;

namespace MicrosoftGraphApplicationAuth
{
    public class GraphConfig : IGraphConfig
    {
        private const string InstanceTemplate = "https://login.microsoftonline.com/{0}";

        public string ApiUri => "https://graph.microsoft.com";

        public string ApplicationId => "TODO: PUT APPLICATION ID HERE";

        public string Tenant => "TODO: PUT TENANT ID HERE";

        public string ClientId => "TODO: PUT CLIENT ID HERE";

        public string ClientSecret => "TODO: RETURN SECRET FROM HERE";

        public Uri Authority => new Uri(string.Format(CultureInfo.InvariantCulture, InstanceTemplate, Tenant));

        public string HttpProxyHost => string.Empty;

        public int? HttpProxyPort => 0;
    }
}