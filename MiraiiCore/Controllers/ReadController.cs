using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MiraiiCore.Controllers
{
    public class ReadController : Controller
    {
        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Review()
        {
            return View();
        }
    }
}