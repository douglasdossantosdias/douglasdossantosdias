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
    public class tipo_fornecedorController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: tipo_fornecedor
        public ActionResult Index()
        {
            return View(db.tipo_fornecedor.ToList());
        }

        // GET: tipo_fornecedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_fornecedor tipo_fornecedor = db.tipo_fornecedor.Find(id);
            if (tipo_fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(tipo_fornecedor);
        }

        // GET: tipo_fornecedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_fornecedor/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_fornecedor,nome,sin_ativo")] tipo_fornecedor tipo_fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.tipo_fornecedor.Add(tipo_fornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_fornecedor);
        }

        // GET: tipo_fornecedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_fornecedor tipo_fornecedor = db.tipo_fornecedor.Find(id);
            if (tipo_fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(tipo_fornecedor);
        }

        // POST: tipo_fornecedor/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_fornecedor,nome,sin_ativo")] tipo_fornecedor tipo_fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_fornecedor);
        }

        // GET: tipo_fornecedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_fornecedor tipo_fornecedor = db.tipo_fornecedor.Find(id);
            if (tipo_fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(tipo_fornecedor);
        }

        // POST: tipo_fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_fornecedor tipo_fornecedor = db.tipo_fornecedor.Find(id);
            db.tipo_fornecedor.Remove(tipo_fornecedor);
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
