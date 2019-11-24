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
    public class caixaController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: caixa
        public ActionResult Index()
        {
            var caixa = db.caixa.Include(c => c.documento_fiscal).Include(c => c.obra).Include(c => c.usuario);
            return View(caixa.ToList());
        }

        // GET: caixa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            caixa caixa = db.caixa.Find(id);
            if (caixa == null)
            {
                return HttpNotFound();
            }
            return View(caixa);
        }

        // GET: caixa/Create
        public ActionResult Create()
        {
            ViewBag.id_documento_fiscal = new SelectList(db.documento_fiscal, "id_documento_fiscal", "descricao");
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra");
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario");
            return View();
        }

        // POST: caixa/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_caixa,dta_movimento,tipo_movimento,valor,id_documento_fiscal,id_usuario,id_obra")] caixa caixa)
        {
            if (ModelState.IsValid)
            {
                db.caixa.Add(caixa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_documento_fiscal = new SelectList(db.documento_fiscal, "id_documento_fiscal", "descricao", caixa.id_documento_fiscal);
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", caixa.id_obra);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", caixa.id_usuario);
            return View(caixa);
        }

        // GET: caixa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            caixa caixa = db.caixa.Find(id);
            if (caixa == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_documento_fiscal = new SelectList(db.documento_fiscal, "id_documento_fiscal", "descricao", caixa.id_documento_fiscal);
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", caixa.id_obra);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", caixa.id_usuario);
            return View(caixa);
        }

        // POST: caixa/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_caixa,dta_movimento,tipo_movimento,valor,id_documento_fiscal,id_usuario,id_obra")] caixa caixa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caixa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_documento_fiscal = new SelectList(db.documento_fiscal, "id_documento_fiscal", "descricao", caixa.id_documento_fiscal);
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", caixa.id_obra);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", caixa.id_usuario);
            return View(caixa);
        }

        // GET: caixa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            caixa caixa = db.caixa.Find(id);
            if (caixa == null)
            {
                return HttpNotFound();
            }
            return View(caixa);
        }

        // POST: caixa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            caixa caixa = db.caixa.Find(id);
            db.caixa.Remove(caixa);
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
