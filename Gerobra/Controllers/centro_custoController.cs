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
    public class centro_custoController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: centro_custo
        public ActionResult Index()
        {
            return View(db.centro_custo.ToList());
        }

        // GET: centro_custo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            centro_custo centro_custo = db.centro_custo.Find(id);
            if (centro_custo == null)
            {
                return HttpNotFound();
            }
            return View(centro_custo);
        }

        // GET: centro_custo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: centro_custo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_centro_custo,codigo,descricao,ativo,sintetico,sin_ativo")] centro_custo centro_custo)
        {
            if (ModelState.IsValid)
            {
                db.centro_custo.Add(centro_custo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centro_custo);
        }

        // GET: centro_custo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            centro_custo centro_custo = db.centro_custo.Find(id);
            if (centro_custo == null)
            {
                return HttpNotFound();
            }
            return View(centro_custo);
        }

        // POST: centro_custo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_centro_custo,codigo,descricao,ativo,sintetico,sin_ativo")] centro_custo centro_custo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centro_custo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centro_custo);
        }

        // GET: centro_custo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            centro_custo centro_custo = db.centro_custo.Find(id);
            if (centro_custo == null)
            {
                return HttpNotFound();
            }
            return View(centro_custo);
        }

        // POST: centro_custo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            centro_custo centro_custo = db.centro_custo.Find(id);
            db.centro_custo.Remove(centro_custo);
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
