using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Business.Interfaces;
using PhamaMicroCrm.Web.ViewModels;

namespace PhamaMicroCrm.Web.Controllers
{
    public class CompanyUnitsController : BaseController
    {
        public CompanyUnitsController(INotifier notifier) : base(notifier)
        {

        }

        [HttpPut]
        [Route("nova-unidade")]
        public async Task<IActionResult> CreateUnits(CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid) return View(companyViewModel);

            return View();
        }
    }
}
