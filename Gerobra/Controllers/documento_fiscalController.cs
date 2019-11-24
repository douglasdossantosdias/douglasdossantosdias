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
    public class documento_fiscalController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: documento_fiscal
        public ActionResult Index()
        {
            var documento_fiscal = db.documento_fiscal.Include(d => d.tipo_documento_fiscal);
            return View(documento_fiscal.ToList());
        }

        // GET: documento_fiscal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            documento_fiscal documento_fiscal = db.documento_fiscal.Find(id);
            if (documento_fiscal == null)
            {
                return HttpNotFound();
            }
            return View(documento_fiscal);
        }

        // GET: documento_fiscal/Create
        public ActionResult Create()
        {
            ViewBag.id_tipo_documento_fiscal = new SelectList(db.tipo_documento_fiscal, "id_tipo_documento_fiscal", "nome");
            return View();
        }

        // POST: documento_fiscal/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_documento_fiscal,descricao,numero,serie,dta_doc_fiscal,id_tipo_documento_fiscal")] documento_fiscal documento_fiscal)
        {
            if (ModelState.IsValid)
            {
                db.documento_fiscal.Add(documento_fiscal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tipo_documento_fiscal = new SelectList(db.tipo_documento_fiscal, "id_tipo_documento_fiscal", "nome", documento_fiscal.id_tipo_documento_fiscal);
            return View(documento_fiscal);
        }

        // GET: documento_fiscal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            documento_fiscal documento_fiscal = db.documento_fiscal.Find(id);
            if (documento_fiscal == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tipo_documento_fiscal = new SelectList(db.tipo_documento_fiscal, "id_tipo_documento_fiscal", "nome", documento_fiscal.id_tipo_documento_fiscal);
            return View(documento_fiscal);
        }

        // POST: documento_fiscal/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_documento_fiscal,descricao,numero,serie,dta_doc_fiscal,id_tipo_documento_fiscal")] documento_fiscal documento_fiscal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documento_fiscal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipo_documento_fiscal = new SelectList(db.tipo_documento_fiscal, "id_tipo_documento_fiscal", "nome", documento_fiscal.id_tipo_documento_fiscal);
            return View(documento_fiscal);
        }

        // GET: documento_fiscal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            documento_fiscal documento_fiscal = db.documento_fiscal.Find(id);
            if (documento_fiscal == null)
            {
                return HttpNotFound();
            }
            return View(documento_fiscal);
        }

        // POST: documento_fiscal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            documento_fiscal documento_fiscal = db.documento_fiscal.Find(id);
            db.documento_fiscal.Remove(documento_fiscal);
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
