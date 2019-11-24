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
    public class documentoController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: documento
        public ActionResult Index()
        {
            var documento = db.documento.Include(d => d.obra).Include(d => d.tipo_documento);
            return View(documento.ToList());
        }

        // GET: documento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            documento documento = db.documento.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // GET: documento/Create
        public ActionResult Create()
        {
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra");
            ViewBag.id_tipo_documento = new SelectList(db.tipo_documento, "id_tipo_documento", "nome");
            return View();
        }

        // POST: documento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_documento,id_obra,id_tipo_documento,numero,dta_documento,sin_ativo,endereco_arquivo,extensao_arquivo,nome_arquivo")] documento documento)
        {
            if (ModelState.IsValid)
            {
                db.documento.Add(documento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", documento.id_obra);
            ViewBag.id_tipo_documento = new SelectList(db.tipo_documento, "id_tipo_documento", "nome", documento.id_tipo_documento);
            return View(documento);
        }

        // GET: documento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            documento documento = db.documento.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", documento.id_obra);
            ViewBag.id_tipo_documento = new SelectList(db.tipo_documento, "id_tipo_documento", "nome", documento.id_tipo_documento);
            return View(documento);
        }

        // POST: documento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_documento,id_obra,id_tipo_documento,numero,dta_documento,sin_ativo,endereco_arquivo,extensao_arquivo,nome_arquivo")] documento documento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", documento.id_obra);
            ViewBag.id_tipo_documento = new SelectList(db.tipo_documento, "id_tipo_documento", "nome", documento.id_tipo_documento);
            return View(documento);
        }

        // GET: documento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            documento documento = db.documento.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // POST: documento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            documento documento = db.documento.Find(id);
            db.documento.Remove(documento);
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
