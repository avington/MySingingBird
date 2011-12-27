using System.Net;

namespace MySingingBird.Core.Http
{
    public interface IHttpRequestResponse
    {
        string GetResponse(HttpWebRequest request);
        HttpWebRequest GetRequest(string fullUrl, string authorizationHeaderParams, string method);
    }
}