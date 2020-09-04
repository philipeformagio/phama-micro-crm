using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Business.Interfaces;

namespace PhamaMicroCrm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotifier _notifier;
        public MainController(INotifier notifier)
        {
            _notifier = notifier;
        }
    }
}
