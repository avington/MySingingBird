namespace MySingingBird.Core.Services
{
    public interface IOAuthCreationService
    {
        string OauthSignatureMethod { get; }
        string OauthConsumerKey { get; }
        string OauthToken { get; }
        string OathVersion { get; }
        string OAuthNonce { get; }
        string OAuthTimeStamp { get; }
        string CreateSignature(string url);
        string CreateAuthorizationHeaderParameter(string signature, string timeStamp);
    }
}