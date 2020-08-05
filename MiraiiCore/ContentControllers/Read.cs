using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MiraiiCore.Controllers
{
    public class Read : Controller
    {
        public IActionResult DrRomactic()
        {
            return View();
        }


    }
}