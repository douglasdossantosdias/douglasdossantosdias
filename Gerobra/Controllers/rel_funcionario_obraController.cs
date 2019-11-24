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
    public class rel_funcionario_obraController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: rel_funcionario_obra
        public ActionResult Index()
        {
            var rel_funcionario_obra = db.rel_funcionario_obra.Include(r => r.funcionario).Include(r => r.obra);
            return View(rel_funcionario_obra.ToList());
        }

        // GET: rel_funcionario_obra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rel_funcionario_obra rel_funcionario_obra = db.rel_funcionario_obra.Find(id);
            if (rel_funcionario_obra == null)
            {
                return HttpNotFound();
            }
            return View(rel_funcionario_obra);
        }

        // GET: rel_funcionario_obra/Create
        public ActionResult Create()
        {
            ViewBag.id_funcionario = new SelectList(db.funcionario, "id_funcionario", "id_funcionario");
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra");
            return View();
        }

        // POST: rel_funcionario_obra/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_rel_funcionario_obra,id_funcionario,id_obra")] rel_funcionario_obra rel_funcionario_obra)
        {
            if (ModelState.IsValid)
            {
                db.rel_funcionario_obra.Add(rel_funcionario_obra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_funcionario = new SelectList(db.funcionario, "id_funcionario", "id_funcionario", rel_funcionario_obra.id_funcionario);
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", rel_funcionario_obra.id_obra);
            return View(rel_funcionario_obra);
        }

        // GET: rel_funcionario_obra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rel_funcionario_obra rel_funcionario_obra = db.rel_funcionario_obra.Find(id);
            if (rel_funcionario_obra == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_funcionario = new SelectList(db.funcionario, "id_funcionario", "id_funcionario", rel_funcionario_obra.id_funcionario);
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", rel_funcionario_obra.id_obra);
            return View(rel_funcionario_obra);
        }

        // POST: rel_funcionario_obra/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_rel_funcionario_obra,id_funcionario,id_obra")] rel_funcionario_obra rel_funcionario_obra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rel_funcionario_obra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_funcionario = new SelectList(db.funcionario, "id_funcionario", "id_funcionario", rel_funcionario_obra.id_funcionario);
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", rel_funcionario_obra.id_obra);
            return View(rel_funcionario_obra);
        }

        // GET: rel_funcionario_obra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rel_funcionario_obra rel_funcionario_obra = db.rel_funcionario_obra.Find(id);
            if (rel_funcionario_obra == null)
            {
                return HttpNotFound();
            }
            return View(rel_funcionario_obra);
        }

        // POST: rel_funcionario_obra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rel_funcionario_obra rel_funcionario_obra = db.rel_funcionario_obra.Find(id);
            db.rel_funcionario_obra.Remove(rel_funcionario_obra);
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
