using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MiraiiCore.Controllers
{
    public class Story : Controller
    {
 
        public IActionResult Index()
        {
            return View("~/Views/Read/Story/Index.cshtml");
        }


    }
}