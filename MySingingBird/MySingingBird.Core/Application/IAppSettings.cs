using System;

namespace MySingingBird.Core.Application
{
    public interface IAppSettings
    {
        string ConsumerKey { get; }
        string ConsumerSecret { get; }
        string RequestTokenUrl { get; }
        string AthorizeUrl { get; }
        string AccessTokenUrl { get; }
        string TwitterBaseUrl { get; }
        string OathNonce { get; }
        string OathSignatureMethod { get; }
        string OathVersion { get; }
        string OathTimeStamp { get; }
        string CallbackUrl { get; }
    }
}