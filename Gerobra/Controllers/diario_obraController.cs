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
    public class diario_obraController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: diario_obra
        public ActionResult Index()
        {
            var diario_obra = db.diario_obra.Include(d => d.obra);
            return View(diario_obra.ToList());
        }

        // GET: diario_obra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            diario_obra diario_obra = db.diario_obra.Find(id);
            if (diario_obra == null)
            {
                return HttpNotFound();
            }
            return View(diario_obra);
        }

        // GET: diario_obra/Create
        public ActionResult Create()
        {
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra");
            return View();
        }

        // POST: diario_obra/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_diario_obra,descricao,dta_diario,id_obra,sin_ativo")] diario_obra diario_obra)
        {
            if (ModelState.IsValid)
            {
                db.diario_obra.Add(diario_obra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", diario_obra.id_obra);
            return View(diario_obra);
        }

        // GET: diario_obra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            diario_obra diario_obra = db.diario_obra.Find(id);
            if (diario_obra == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", diario_obra.id_obra);
            return View(diario_obra);
        }

        // POST: diario_obra/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_diario_obra,descricao,dta_diario,id_obra,sin_ativo")] diario_obra diario_obra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diario_obra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", diario_obra.id_obra);
            return View(diario_obra);
        }

        // GET: diario_obra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            diario_obra diario_obra = db.diario_obra.Find(id);
            if (diario_obra == null)
            {
                return HttpNotFound();
            }
            return View(diario_obra);
        }

        // POST: diario_obra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            diario_obra diario_obra = db.diario_obra.Find(id);
            db.diario_obra.Remove(diario_obra);
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
