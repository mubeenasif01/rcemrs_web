using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace RCEMRS.Web.Extend
{
    internal class AuthenticationFailureResult :IHttpActionResult
    {
        private HttpRequestMessage request;
        private string v;

        public AuthenticationFailureResult(string v, HttpRequestMessage request)
        {
            this.v = v;
            this.request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.RequestMessage = request;
            response.ReasonPhrase = v;
            return response;
        }

    }
}