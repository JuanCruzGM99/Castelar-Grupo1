﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Art_Shop_Data;
using Art_Shop_Data.Model;

namespace Art_shop_Website.Controllers
{
    public class ABMController : Controller
    {
        // GET: ABM
        [Authorize(Roles = "Admin")]
        public ActionResult AltaArtistasView()
        {
            var model = new Artist();
            return View(model);
        }
    }
}