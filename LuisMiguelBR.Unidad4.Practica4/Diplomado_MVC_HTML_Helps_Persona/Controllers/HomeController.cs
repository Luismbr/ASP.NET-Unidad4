using Diplomado_MVC_HTML_Helps_Persona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplomado_MVC_HTML_Helps_Persona.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection coleccion)
        {
            MantenimientoPersona m = new MantenimientoPersona();
            Persona per = m.Retornar(int.Parse(coleccion["codigo"].ToString()));
            if (per != null)
                return View("EditarPersona", per);
            else
                return RedirectToAction("Index");
        }
    }
}