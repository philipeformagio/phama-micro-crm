using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Web.ViewModels;

namespace PhamaMicroCrm.Web.Controllers
{
    public class NotesController : Controller
    {
        [Route("anotacoes")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("nova-anotacao")]
        public IActionResult Create()
        {
            return View();
        }

        //[Route("nova-anotacao")]
        //[HttpPost]
        //public async Task<IActionResult> Create(NotesViewModel notesViewModel)
        //{

        //}
    }
}
