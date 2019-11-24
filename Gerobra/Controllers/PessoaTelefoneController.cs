using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gerobra.Models;

namespace Gerobra.Controllers
{
    public class PessoaTelefoneController : Controller
    {
        Models.DataSetPessoaTelefone ds = Models.DataSetPessoaTelefone.ObterPessoaTelefoneDoBanco();

        private GerobraDbContext db = new GerobraDbContext();

        // GET: PessoaTelefone
        public ActionResult ListarTelefone()
        {
            var telefone = db.telefone.Include(t => t.pessoa);
            var telefoneCelular = telefone.Where(t => t.sta_tipo.Contains("Celular"));
            return View(telefoneCelular.ToList());
        }




    }
}