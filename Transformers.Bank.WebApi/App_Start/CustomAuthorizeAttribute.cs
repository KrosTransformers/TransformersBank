using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Transformers.Bank.WebApi
{
    public class CustomAuthorizeAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization?.Parameter;

            if (token != "1LNpW9SHT1Yb7IqU5KWg")
            {
                HttpResponseMessage response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                response.Headers.WwwAuthenticate.Add(new System.Net.Http.Headers.AuthenticationHeaderValue("custom", "realm=\"api\""));
                actionContext.Response = response;
            }
        }
    }
}