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
    public class relatorioController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: relatorio
        public ActionResult Index()
        {
            var relatorio = db.relatorio.Include(r => r.modulo);
            return View(relatorio.ToList());
        }

        // GET: relatorio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            relatorio relatorio = db.relatorio.Find(id);
            if (relatorio == null)
            {
                return HttpNotFound();
            }
            return View(relatorio);
        }

        // GET: relatorio/Create
        public ActionResult Create()
        {
            ViewBag.id_modulo = new SelectList(db.modulo, "id_modulo", "nome");
            return View();
        }

        // POST: relatorio/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_relatorio,dta_relatorio,dta_ultima_atualizacao,nome_view,id_modulo")] relatorio relatorio)
        {
            if (ModelState.IsValid)
            {
                db.relatorio.Add(relatorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_modulo = new SelectList(db.modulo, "id_modulo", "nome", relatorio.id_modulo);
            return View(relatorio);
        }

        // GET: relatorio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            relatorio relatorio = db.relatorio.Find(id);
            if (relatorio == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_modulo = new SelectList(db.modulo, "id_modulo", "nome", relatorio.id_modulo);
            return View(relatorio);
        }

        // POST: relatorio/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_relatorio,dta_relatorio,dta_ultima_atualizacao,nome_view,id_modulo")] relatorio relatorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relatorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_modulo = new SelectList(db.modulo, "id_modulo", "nome", relatorio.id_modulo);
            return View(relatorio);
        }

        // GET: relatorio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            relatorio relatorio = db.relatorio.Find(id);
            if (relatorio == null)
            {
                return HttpNotFound();
            }
            return View(relatorio);
        }

        // POST: relatorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            relatorio relatorio = db.relatorio.Find(id);
            db.relatorio.Remove(relatorio);
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
