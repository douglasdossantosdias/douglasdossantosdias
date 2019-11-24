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
    public class fornecedorController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: fornecedor
        public ActionResult Index(string searchString)
        {
            var fornecedor = db.fornecedor.Include(f => f.pessoa).Include(f => f.tipo_fornecedor);

            if (!String.IsNullOrEmpty(searchString))
            {
                var fornec = fornecedor.Where(name => name.pessoa.nome.ToUpper().Contains(searchString.ToUpper()));
                return View(fornec.ToList());

            }


            return View(fornecedor.ToList());
        }

        // GET: fornecedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fornecedor fornecedor = db.fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // GET: fornecedor/Create
        public ActionResult Create()
        {
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome");
            ViewBag.id_tipo_fornecedor = new SelectList(db.tipo_fornecedor, "id_tipo_fornecedor", "nome");
            return View();
        }

        // POST: fornecedor/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_fornecedor,id_tipo_fornecedor,id_pessoa,sin_ativo")] fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.fornecedor.Add(fornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", fornecedor.id_pessoa);
            ViewBag.id_tipo_fornecedor = new SelectList(db.tipo_fornecedor, "id_tipo_fornecedor", "nome", fornecedor.id_tipo_fornecedor);
            return View(fornecedor);
        }

        // GET: fornecedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fornecedor fornecedor = db.fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", fornecedor.id_pessoa);
            ViewBag.id_tipo_fornecedor = new SelectList(db.tipo_fornecedor, "id_tipo_fornecedor", "nome", fornecedor.id_tipo_fornecedor);
            return View(fornecedor);
        }

        // POST: fornecedor/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_fornecedor,id_tipo_fornecedor,id_pessoa,sin_ativo")] fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pessoa = new SelectList(db.pessoa, "id_pessoa", "nome", fornecedor.id_pessoa);
            ViewBag.id_tipo_fornecedor = new SelectList(db.tipo_fornecedor, "id_tipo_fornecedor", "nome", fornecedor.id_tipo_fornecedor);
            return View(fornecedor);
        }

        // GET: fornecedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fornecedor fornecedor = db.fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fornecedor fornecedor = db.fornecedor.Find(id);
            db.fornecedor.Remove(fornecedor);
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
