using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PhamaMicroCrm.Api.Interfaces;
using PhamaMicroCrm.Business.Interfaces;
using PhamaMicroCrm.Business.Notifications;
using System.Linq;

namespace PhamaMicroCrm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotifier _notifier;
        public readonly IUser AppUser;
        public MainController(INotifier notifier,
                              IUser appUser)
        {
            _notifier = notifier;
            AppUser = appUser;
        }

        protected bool OperacaoValida()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected void NotifyErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }
    }
}
