using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca_eCommerce.Controllers
{
    public class AdmHomeController : Controller
    {
        // GET: AdmHome
        [Authorize(Roles = "Administrador, Empleado")]
        public ActionResult Index()
        {
            return View();
        }
    }
}