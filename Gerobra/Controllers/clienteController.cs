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
    public class clienteController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: cliente
        //public ActionResult Index()
        //{
        //    var cliente = db.cliente.Include(c => c.pessoa).Include(c => c.tipo_cliente);
        //    return View(cliente.ToList());
        //}

        public ActionResult Index(string searchString, string searchString2)
        {
            var cliente = db.cliente.Include(c => c.pessoa).Include(c => c.tipo_cliente);

            if (!String.IsNullOrEmpty(searchString))
            {
                var cli2 = cliente.Where(name => name.pessoa.nome.ToUpper().Contains(searchString.ToUpper()));
                return View(cli2.ToList());

            }
            else if (!String.IsNullOrEmpty(searchString2))
            {
                var tipo = cliente.Where(xx => xx.tipo_cliente.descricao.ToUpper().Contains(searchString2.ToUpper()));
                return View(tipo.ToList());
            }
            return View(cliente.ToList());
        }

        // GET: cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: cliente/Create
        public ActionResult Create()
        {
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome");
            ViewBag.id_tipo_cliente = new SelectList(db.tipo_cliente, "id_tipo_cliente", "descricao");
            return View();
        }

        // POST: cliente/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cliente,id_tipo_cliente,id_pessoa,sin_ativo")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", cliente.id_pessoa);
            ViewBag.id_tipo_cliente = new SelectList(db.tipo_cliente, "id_tipo_cliente", "descricao", cliente.id_tipo_cliente);
            return View(cliente);
        }

        // GET: cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", cliente.id_pessoa);
            ViewBag.id_tipo_cliente = new SelectList(db.tipo_cliente, "id_tipo_cliente", "descricao", cliente.id_tipo_cliente);
            return View(cliente);
        }

        // POST: cliente/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cliente,id_tipo_cliente,id_pessoa,sin_ativo")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", cliente.id_pessoa);
            ViewBag.id_tipo_cliente = new SelectList(db.tipo_cliente, "id_tipo_cliente", "descricao", cliente.id_tipo_cliente);
            return View(cliente);
        }

        // GET: cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cliente cliente = db.cliente.Find(id);
            db.cliente.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
