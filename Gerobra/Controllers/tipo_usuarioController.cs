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
    public class tipo_usuarioController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: tipo_usuario
        public ActionResult Index()
        {
            return View(db.tipo_usuario.ToList());
        }

        // GET: tipo_usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_usuario tipo_usuario = db.tipo_usuario.Find(id);
            if (tipo_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_usuario);
        }

        // GET: tipo_usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_usuario/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_usuario,descricao,sin_ativo")] tipo_usuario tipo_usuario)
        {
            if (ModelState.IsValid)
            {
                db.tipo_usuario.Add(tipo_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_usuario);
        }

        // GET: tipo_usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_usuario tipo_usuario = db.tipo_usuario.Find(id);
            if (tipo_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_usuario);
        }

        // POST: tipo_usuario/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_usuario,descricao,sin_ativo")] tipo_usuario tipo_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_usuario);
        }

        // GET: tipo_usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_usuario tipo_usuario = db.tipo_usuario.Find(id);
            if (tipo_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_usuario);
        }

        // POST: tipo_usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_usuario tipo_usuario = db.tipo_usuario.Find(id);
            db.tipo_usuario.Remove(tipo_usuario);
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
