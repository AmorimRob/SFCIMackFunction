using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace SCFIFunction
{
    public static class SCIFunction
    {
        [FunctionName("SCIFunction")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var datetime = DateTime.Now.ToString();

            var mensagem = $"SCFI Mackenzie 2018 - {datetime}";

            if (mensagem == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                mensagem = data?.mensagem;
            }

            return mensagem == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                : req.CreateResponse(HttpStatusCode.OK, mensagem);
        }
    }
}
