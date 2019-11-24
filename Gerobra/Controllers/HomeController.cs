using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gerobra.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // exemplo 1
        //[HttpPost]
        //public ActionResult Index(FormCollection formCollection)
        //{

        //    string nome = formCollection["nome"];
        //    ViewBag.Mensagem = nome;

        //    return View("Saudacao");
        //}
        // exemplo 2
        //[HttpPost]
        //public ActionResult Index(string nome)
        //{

        //    ViewBag.Mensagem = nome;
        //    return View("Saudacao");
        //}

        [HttpPost]
        public ActionResult Index(string nome)
        {

            ViewBag.Mensagem = nome;
            return View("Saudacao");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}