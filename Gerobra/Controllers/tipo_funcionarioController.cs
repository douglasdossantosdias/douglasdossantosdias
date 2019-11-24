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
    public class tipo_funcionarioController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: tipo_funcionario
        public ActionResult Index()
        {
            return View(db.tipo_funcionario.ToList());
        }

        // GET: tipo_funcionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_funcionario tipo_funcionario = db.tipo_funcionario.Find(id);
            if (tipo_funcionario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_funcionario);
        }

        // GET: tipo_funcionario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_funcionario/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_funcionario,nome,sin_ativo")] tipo_funcionario tipo_funcionario)
        {
            if (ModelState.IsValid)
            {
                db.tipo_funcionario.Add(tipo_funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_funcionario);
        }

        // GET: tipo_funcionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_funcionario tipo_funcionario = db.tipo_funcionario.Find(id);
            if (tipo_funcionario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_funcionario);
        }

        // POST: tipo_funcionario/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_funcionario,nome,sin_ativo")] tipo_funcionario tipo_funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_funcionario);
        }

        // GET: tipo_funcionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_funcionario tipo_funcionario = db.tipo_funcionario.Find(id);
            if (tipo_funcionario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_funcionario);
        }

        // POST: tipo_funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_funcionario tipo_funcionario = db.tipo_funcionario.Find(id);
            db.tipo_funcionario.Remove(tipo_funcionario);
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
