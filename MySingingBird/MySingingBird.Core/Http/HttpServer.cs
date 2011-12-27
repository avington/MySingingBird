using System.Web;

namespace MySingingBird.Core.Http
{
    public class HttpServer : IHttpServer
    {
        public string UrlEncode(string input)
        {
            return HttpContext.Current.Server.UrlEncode(input);
        }
    }
}