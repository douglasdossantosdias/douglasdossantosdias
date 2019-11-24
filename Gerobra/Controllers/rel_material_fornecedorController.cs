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
    public class rel_material_fornecedorController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: rel_material_fornecedor
        public ActionResult Index()
        {
            var rel_material_fornecedor = db.rel_material_fornecedor.Include(r => r.fornecedor).Include(r => r.material);
            return View(rel_material_fornecedor.ToList());
        }

        // GET: rel_material_fornecedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rel_material_fornecedor rel_material_fornecedor = db.rel_material_fornecedor.Find(id);
            if (rel_material_fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(rel_material_fornecedor);
        }

        // GET: rel_material_fornecedor/Create
        public ActionResult Create()
        {
            ViewBag.id_fornecedor = new SelectList(db.fornecedor, "id_fornecedor", "id_fornecedor");
            ViewBag.id_material = new SelectList(db.material, "id_material", "nome");
            return View();
        }

        // POST: rel_material_fornecedor/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_rel_material_fornecedor,id_fornecedor,id_material,unidade,preco_unitario,marca,modelo,cor,peso,textura,altura,largura,profundidade")] rel_material_fornecedor rel_material_fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.rel_material_fornecedor.Add(rel_material_fornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_fornecedor = new SelectList(db.fornecedor, "id_fornecedor", "id_fornecedor", rel_material_fornecedor.id_fornecedor);
            ViewBag.id_material = new SelectList(db.material, "id_material", "nome", rel_material_fornecedor.id_material);
            return View(rel_material_fornecedor);
        }

        // GET: rel_material_fornecedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rel_material_fornecedor rel_material_fornecedor = db.rel_material_fornecedor.Find(id);
            if (rel_material_fornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_fornecedor = new SelectList(db.fornecedor, "id_fornecedor", "id_fornecedor", rel_material_fornecedor.id_fornecedor);
            ViewBag.id_material = new SelectList(db.material, "id_material", "nome", rel_material_fornecedor.id_material);
            return View(rel_material_fornecedor);
        }

        // POST: rel_material_fornecedor/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_rel_material_fornecedor,id_fornecedor,id_material,unidade,preco_unitario,marca,modelo,cor,peso,textura,altura,largura,profundidade")] rel_material_fornecedor rel_material_fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rel_material_fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_fornecedor = new SelectList(db.fornecedor, "id_fornecedor", "id_fornecedor", rel_material_fornecedor.id_fornecedor);
            ViewBag.id_material = new SelectList(db.material, "id_material", "nome", rel_material_fornecedor.id_material);
            return View(rel_material_fornecedor);
        }

        // GET: rel_material_fornecedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rel_material_fornecedor rel_material_fornecedor = db.rel_material_fornecedor.Find(id);
            if (rel_material_fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(rel_material_fornecedor);
        }

        // POST: rel_material_fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rel_material_fornecedor rel_material_fornecedor = db.rel_material_fornecedor.Find(id);
            db.rel_material_fornecedor.Remove(rel_material_fornecedor);
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
