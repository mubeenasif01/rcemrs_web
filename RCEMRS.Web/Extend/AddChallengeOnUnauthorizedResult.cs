using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace RCEMRS.Web.Extend
{
    internal class AddChallengeOnUnauthorizedResult : IHttpActionResult
    {
        private AuthenticationHeaderValue authenticationHeaderValue;
        private IHttpActionResult result;

        public AddChallengeOnUnauthorizedResult(AuthenticationHeaderValue authenticationHeaderValue, IHttpActionResult result)
        {
            this.authenticationHeaderValue = authenticationHeaderValue;
            this.result = result;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}