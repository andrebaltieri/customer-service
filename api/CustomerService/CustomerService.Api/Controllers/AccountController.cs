using CustomerService.Domain;
using CustomerService.Domain.Contracts;
using CustomerService.Utils.Security;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CustomerService.Api.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        IUserRepository _repository;

        public AccountController(IUserRepository repository)
        {
            _repository = repository;
        }

        // POST api/account/register
        [AllowAnonymous]
        [Route("register")]
        public Task<HttpResponseMessage> Register(User user)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                user.Password = EncryptHelper.Encrypt(user.Password);
                _repository.SaveOrUpdate(user);
                user.Password = "";
                response = Request.CreateResponse(HttpStatusCode.Created, user);
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao registrar o usuário");
                throw;
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
        }
    }
}
