﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Mvc.Controllers
{
    public class MovieController : Controller
    {
        [HttpGet] //verb Get: retrieve data
        public ActionResult Index()
        {
            return View(); //= return View("Index");  parameter = name of action 
        }
    }
}