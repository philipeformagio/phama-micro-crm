using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Business.Interfaces;

namespace PhamaMicroCrm.Web.Controllers
{
    public class CompanyUnitsController : BaseController
    {
        public CompanyUnitsController(INotifier notifier) : base(notifier)
        {

        }
    }
}
