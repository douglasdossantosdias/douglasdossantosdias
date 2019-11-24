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
    public class tipo_pessoaController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: tipo_pessoa
        public ActionResult Index()
        {
            return View(db.tipo_pessoa.ToList());
        }

        // GET: tipo_pessoa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_pessoa tipo_pessoa = db.tipo_pessoa.Find(id);
            if (tipo_pessoa == null)
            {
                return HttpNotFound();
            }
            return View(tipo_pessoa);
        }

        // GET: tipo_pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_pessoa/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_pessoa,nome,sin_ativo")] tipo_pessoa tipo_pessoa)
        {
            if (ModelState.IsValid)
            {
                db.tipo_pessoa.Add(tipo_pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_pessoa);
        }

        // GET: tipo_pessoa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_pessoa tipo_pessoa = db.tipo_pessoa.Find(id);
            if (tipo_pessoa == null)
            {
                return HttpNotFound();
            }
            return View(tipo_pessoa);
        }

        // POST: tipo_pessoa/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_pessoa,nome,sin_ativo")] tipo_pessoa tipo_pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_pessoa);
        }

        // GET: tipo_pessoa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_pessoa tipo_pessoa = db.tipo_pessoa.Find(id);
            if (tipo_pessoa == null)
            {
                return HttpNotFound();
            }
            return View(tipo_pessoa);
        }

        // POST: tipo_pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_pessoa tipo_pessoa = db.tipo_pessoa.Find(id);
            db.tipo_pessoa.Remove(tipo_pessoa);
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
