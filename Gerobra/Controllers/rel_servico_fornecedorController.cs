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
    public class rel_servico_fornecedorController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: rel_servico_fornecedor
        public ActionResult Index()
        {
            var rel_servico_fornecedor = db.rel_servico_fornecedor.Include(r => r.fornecedor).Include(r => r.servico);
            return View(rel_servico_fornecedor.ToList());
        }

        // GET: rel_servico_fornecedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rel_servico_fornecedor rel_servico_fornecedor = db.rel_servico_fornecedor.Find(id);
            if (rel_servico_fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(rel_servico_fornecedor);
        }

        // GET: rel_servico_fornecedor/Create
        public ActionResult Create()
        {
            ViewBag.id_fornecedor = new SelectList(db.fornecedor, "id_fornecedor", "id_fornecedor");
            ViewBag.id_servico = new SelectList(db.servico, "id_servico", "nome");
            return View();
        }

        // POST: rel_servico_fornecedor/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_rel_servico_fornecedor,id_fornecedor,id_servico,unidade,preco_unitario,C_default_")] rel_servico_fornecedor rel_servico_fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.rel_servico_fornecedor.Add(rel_servico_fornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_fornecedor = new SelectList(db.fornecedor, "id_fornecedor", "id_fornecedor", rel_servico_fornecedor.id_fornecedor);
            ViewBag.id_servico = new SelectList(db.servico, "id_servico", "nome", rel_servico_fornecedor.id_servico);
            return View(rel_servico_fornecedor);
        }

        // GET: rel_servico_fornecedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rel_servico_fornecedor rel_servico_fornecedor = db.rel_servico_fornecedor.Find(id);
            if (rel_servico_fornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_fornecedor = new SelectList(db.fornecedor, "id_fornecedor", "id_fornecedor", rel_servico_fornecedor.id_fornecedor);
            ViewBag.id_servico = new SelectList(db.servico, "id_servico", "nome", rel_servico_fornecedor.id_servico);
            return View(rel_servico_fornecedor);
        }

        // POST: rel_servico_fornecedor/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_rel_servico_fornecedor,id_fornecedor,id_servico,unidade,preco_unitario,C_default_")] rel_servico_fornecedor rel_servico_fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rel_servico_fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_fornecedor = new SelectList(db.fornecedor, "id_fornecedor", "id_fornecedor", rel_servico_fornecedor.id_fornecedor);
            ViewBag.id_servico = new SelectList(db.servico, "id_servico", "nome", rel_servico_fornecedor.id_servico);
            return View(rel_servico_fornecedor);
        }

        // GET: rel_servico_fornecedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rel_servico_fornecedor rel_servico_fornecedor = db.rel_servico_fornecedor.Find(id);
            if (rel_servico_fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(rel_servico_fornecedor);
        }

        // POST: rel_servico_fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rel_servico_fornecedor rel_servico_fornecedor = db.rel_servico_fornecedor.Find(id);
            db.rel_servico_fornecedor.Remove(rel_servico_fornecedor);
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
