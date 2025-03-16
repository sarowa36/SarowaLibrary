using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarowaLibrary.ToolsLayer.Http
{
    public static class RequestGetAsSeriableObject
    {
        public static async Task<Dictionary<string, object>> GetAsSeriableObjectAsync(this HttpRequest Request, object? model)
        {
            Dictionary<string, object> request = new();
            request.Add("headers", Request.Headers);
            request.Add("route", Request.RouteValues);
            request.Add("method", Request.Method);
            request.Add("model", model);
            if (Request.HasFormContentType)
                request.Add("form", Request.Form);
            else
            {
                var memoryStream = new MemoryStream();
                await Request.Body.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                byte[] bytes = new byte[memoryStream.Length];
                memoryStream.Read(bytes, 0, bytes.Length);
                memoryStream.Dispose();
                request.Add("body", JsonConvert.DeserializeObject(Encoding.UTF8.GetString(bytes)));
            }
            return request;
        }
    }
}
