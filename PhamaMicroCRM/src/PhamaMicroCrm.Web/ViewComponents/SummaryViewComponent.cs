using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Business.Interfaces;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Web.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotifier _notifier;
        public SummaryViewComponent(INotifier notify)
        {
            _notifier = notify;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notifier.GetNotifications());

            notificacoes.ForEach(x => ViewData.ModelState.AddModelError(string.Empty, x.Message));

            return View();
        }
    }
}
