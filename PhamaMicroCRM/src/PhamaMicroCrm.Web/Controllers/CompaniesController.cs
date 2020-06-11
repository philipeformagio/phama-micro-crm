using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Data.Context;
using PhamaMicroCrm.Data.Interfaces;

namespace PhamaMicroCrm.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public IActionResult Index()
        {
            _companyRepository.GetAll();
            return View();
        }
    }
}
