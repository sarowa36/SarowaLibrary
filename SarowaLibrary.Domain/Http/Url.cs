using Microsoft.AspNetCore.Http;

namespace SarowaLibrary.ToolsLayer.Http
{
    public static class Url
    {
        public static string GetOriginUrl(this HttpContext context)
        {
            var req = context.Request;
            return $"{req.Scheme}://{req.Host}";
        }
    }
}
