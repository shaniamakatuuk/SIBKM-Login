﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApp.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Unautorize()
        {
            return View();
        }
    }
}
