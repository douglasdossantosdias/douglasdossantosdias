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
    public class tipo_servicoController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: tipo_servico
        public ActionResult Index()
        {
            return View(db.tipo_servico.ToList());
        }

        // GET: tipo_servico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_servico tipo_servico = db.tipo_servico.Find(id);
            if (tipo_servico == null)
            {
                return HttpNotFound();
            }
            return View(tipo_servico);
        }

        // GET: tipo_servico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_servico/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_servico,nome")] tipo_servico tipo_servico)
        {
            if (ModelState.IsValid)
            {
                db.tipo_servico.Add(tipo_servico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_servico);
        }

        // GET: tipo_servico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_servico tipo_servico = db.tipo_servico.Find(id);
            if (tipo_servico == null)
            {
                return HttpNotFound();
            }
            return View(tipo_servico);
        }

        // POST: tipo_servico/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_servico,nome")] tipo_servico tipo_servico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_servico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_servico);
        }

        // GET: tipo_servico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_servico tipo_servico = db.tipo_servico.Find(id);
            if (tipo_servico == null)
            {
                return HttpNotFound();
            }
            return View(tipo_servico);
        }

        // POST: tipo_servico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_servico tipo_servico = db.tipo_servico.Find(id);
            db.tipo_servico.Remove(tipo_servico);
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
