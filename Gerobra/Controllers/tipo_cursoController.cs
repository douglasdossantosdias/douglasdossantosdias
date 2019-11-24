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
    public class tipo_cursoController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: tipo_curso
        public ActionResult Index()
        {
            return View(db.tipo_curso.ToList());
        }

        // GET: tipo_curso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_curso tipo_curso = db.tipo_curso.Find(id);
            if (tipo_curso == null)
            {
                return HttpNotFound();
            }
            return View(tipo_curso);
        }

        // GET: tipo_curso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_curso/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_curso,nome,sin_ativo")] tipo_curso tipo_curso)
        {
            if (ModelState.IsValid)
            {
                db.tipo_curso.Add(tipo_curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_curso);
        }

        // GET: tipo_curso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_curso tipo_curso = db.tipo_curso.Find(id);
            if (tipo_curso == null)
            {
                return HttpNotFound();
            }
            return View(tipo_curso);
        }

        // POST: tipo_curso/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_curso,nome,sin_ativo")] tipo_curso tipo_curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_curso);
        }

        // GET: tipo_curso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_curso tipo_curso = db.tipo_curso.Find(id);
            if (tipo_curso == null)
            {
                return HttpNotFound();
            }
            return View(tipo_curso);
        }

        // POST: tipo_curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_curso tipo_curso = db.tipo_curso.Find(id);
            db.tipo_curso.Remove(tipo_curso);
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
