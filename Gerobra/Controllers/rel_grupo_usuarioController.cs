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
    public class rel_grupo_usuarioController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: rel_grupo_usuario
        public ActionResult Index()
        {
            var rel_grupo_usuario = db.rel_grupo_usuario.Include(r => r.grupo).Include(r => r.usuario);
            return View(rel_grupo_usuario.ToList());
        }

        // GET: rel_grupo_usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rel_grupo_usuario rel_grupo_usuario = db.rel_grupo_usuario.Find(id);
            if (rel_grupo_usuario == null)
            {
                return HttpNotFound();
            }
            return View(rel_grupo_usuario);
        }

        // GET: rel_grupo_usuario/Create
        public ActionResult Create()
        {
            ViewBag.id_grupo = new SelectList(db.grupo, "id_grupo", "nome");
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario");
            return View();
        }

        // POST: rel_grupo_usuario/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_rel_grupo_usuario,id_grupo,id_usuario")] rel_grupo_usuario rel_grupo_usuario)
        {
            if (ModelState.IsValid)
            {
                db.rel_grupo_usuario.Add(rel_grupo_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_grupo = new SelectList(db.grupo, "id_grupo", "nome", rel_grupo_usuario.id_grupo);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", rel_grupo_usuario.id_usuario);
            return View(rel_grupo_usuario);
        }

        // GET: rel_grupo_usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rel_grupo_usuario rel_grupo_usuario = db.rel_grupo_usuario.Find(id);
            if (rel_grupo_usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_grupo = new SelectList(db.grupo, "id_grupo", "nome", rel_grupo_usuario.id_grupo);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", rel_grupo_usuario.id_usuario);
            return View(rel_grupo_usuario);
        }

        // POST: rel_grupo_usuario/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_rel_grupo_usuario,id_grupo,id_usuario")] rel_grupo_usuario rel_grupo_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rel_grupo_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_grupo = new SelectList(db.grupo, "id_grupo", "nome", rel_grupo_usuario.id_grupo);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", rel_grupo_usuario.id_usuario);
            return View(rel_grupo_usuario);
        }

        // GET: rel_grupo_usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rel_grupo_usuario rel_grupo_usuario = db.rel_grupo_usuario.Find(id);
            if (rel_grupo_usuario == null)
            {
                return HttpNotFound();
            }
            return View(rel_grupo_usuario);
        }

        // POST: rel_grupo_usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rel_grupo_usuario rel_grupo_usuario = db.rel_grupo_usuario.Find(id);
            db.rel_grupo_usuario.Remove(rel_grupo_usuario);
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
