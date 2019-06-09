using RCEMRS.Entites;
using RCEMRS.Web.DAL;
using RCEMRS.Web.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RCEMRS.Web.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

    }
}