using System.Web.Http;
using Transformers.Bank.Data.Context;

namespace Transformers.Bank.WebApi.Controllers
{
    [CustomAuthorize]
    public class BaseApiController : ApiController
    {
        public IDataWorker DataWorker { get; set; }

        public BaseApiController(IDataWorker dataWorker)
        {
            DataWorker = dataWorker;
        }
    }
}