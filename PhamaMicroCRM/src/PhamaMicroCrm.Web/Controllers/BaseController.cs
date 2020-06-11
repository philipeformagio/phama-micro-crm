using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Business.Interfaces;

namespace PhamaMicroCrm.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotifier _notifier;

        protected BaseController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool IsValidOperation()
        {
            return !_notifier.HasNotification();
        }
    }
}
