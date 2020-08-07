using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MiraiiCore.Controllers
{
    public class Review : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Read/Review/Index.cshtml");
        }

        public IActionResult DrRomantic()
        {
            return View("~/Views/Read/Review/DrRomantic.cshtml");
        }


    }
}