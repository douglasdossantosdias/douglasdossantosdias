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
    public class senhaController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: senha
        public ActionResult Index()
        {
            var senha = db.senha.Include(s => s.usuario);
            return View(senha.ToList());
        }

        // GET: senha/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            senha senha = db.senha.Find(id);
            if (senha == null)
            {
                return HttpNotFound();
            }
            return View(senha);
        }

        // GET: senha/Create
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario");
            return View();
        }

        // POST: senha/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_senha,senha1,id_usuario,sin_ativo")] senha senha)
        {
            if (ModelState.IsValid)
            {
                db.senha.Add(senha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", senha.id_usuario);
            return View(senha);
        }

        // GET: senha/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            senha senha = db.senha.Find(id);
            if (senha == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", senha.id_usuario);
            return View(senha);
        }

        // POST: senha/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_senha,senha1,id_usuario,sin_ativo")] senha senha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(senha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", senha.id_usuario);
            return View(senha);
        }

        // GET: senha/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            senha senha = db.senha.Find(id);
            if (senha == null)
            {
                return HttpNotFound();
            }
            return View(senha);
        }

        // POST: senha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            senha senha = db.senha.Find(id);
            db.senha.Remove(senha);
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
