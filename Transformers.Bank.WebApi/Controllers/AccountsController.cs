using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Transformers.Bank.Core;
using Transformers.Bank.Data.Context;
using Transformers.Bank.Entities;

namespace Transformers.Bank.WebApi.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseApiController
    {
        AccountService _accountService;

        public AccountsController(IDataWorker dataWorker, AccountService accountService) : base(dataWorker)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route]
        public List<Account> GetAll()
        {
            return _accountService.GetAll();
        }

        [HttpPost]
        [Route]
        public async Task<HttpResponseMessage> CreateAccountAsync(Account account)
        {
            try
            {
                account.CreatedAt = DateTimeOffset.Now;
                DataWorker.Accounts.Add(account);
                await DataWorker.SaveChangesAsync();

                return Request.CreateResponse<Account>(HttpStatusCode.Created, account);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route]
        public async Task<HttpResponseMessage> UpdateAccountAsync(Account account)
        {
            account.ChangedAt = DateTimeOffset.Now;
            DataWorker.Accounts.Update(account);

            if (await DataWorker.SaveChangesAsync() == 1)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<HttpResponseMessage> DeleteAccountAsync(long id)
        {
            DataWorker.Accounts.Delete(id);

            if (await DataWorker.SaveChangesAsync() == 1)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
