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
    public class historico_clienteController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: historico_cliente
        public ActionResult Index()
        {
            var historico_cliente = db.historico_cliente.Include(h => h.cliente);
            return View(historico_cliente.ToList());
        }

        // GET: historico_cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historico_cliente historico_cliente = db.historico_cliente.Find(id);
            if (historico_cliente == null)
            {
                return HttpNotFound();
            }
            return View(historico_cliente);
        }

        // GET: historico_cliente/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.cliente, "id_cliente", "id_cliente");
            return View();
        }

        // POST: historico_cliente/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_historico_cliente,descricao,dta_historico,sin_ativo,id_cliente")] historico_cliente historico_cliente)
        {
            if (ModelState.IsValid)
            {
                db.historico_cliente.Add(historico_cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.cliente, "id_cliente", "id_cliente", historico_cliente.id_cliente);
            return View(historico_cliente);
        }

        // GET: historico_cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historico_cliente historico_cliente = db.historico_cliente.Find(id);
            if (historico_cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.cliente, "id_cliente", "id_cliente", historico_cliente.id_cliente);
            return View(historico_cliente);
        }

        // POST: historico_cliente/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_historico_cliente,descricao,dta_historico,sin_ativo,id_cliente")] historico_cliente historico_cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historico_cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.cliente, "id_cliente", "id_cliente", historico_cliente.id_cliente);
            return View(historico_cliente);
        }

        // GET: historico_cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historico_cliente historico_cliente = db.historico_cliente.Find(id);
            if (historico_cliente == null)
            {
                return HttpNotFound();
            }
            return View(historico_cliente);
        }

        // POST: historico_cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            historico_cliente historico_cliente = db.historico_cliente.Find(id);
            db.historico_cliente.Remove(historico_cliente);
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
