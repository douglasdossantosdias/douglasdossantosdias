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
    public class materialController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: material
        public ActionResult Index()
        {
            var material = db.material.Include(m => m.tipo_material);
            return View(material.ToList());
        }

        // GET: material/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            material material = db.material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // GET: material/Create
        public ActionResult Create()
        {
            ViewBag.id_tipo_material = new SelectList(db.tipo_material, "id_tipo_material", "nome");
            return View();
        }

        // POST: material/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_material,id_tipo_material,nome,sin_ativo")] material material)
        {
            if (ModelState.IsValid)
            {
                db.material.Add(material);
                db.SaveChanges();
                return RedirectToAction("Create", "rel_material_fornecedor");
            }

            ViewBag.id_tipo_material = new SelectList(db.tipo_material, "id_tipo_material", "nome", material.id_tipo_material);
            return View(material);
        }

        // GET: material/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            material material = db.material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tipo_material = new SelectList(db.tipo_material, "id_tipo_material", "nome", material.id_tipo_material);
            return View(material);
        }

        // POST: material/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_material,id_tipo_material,nome,sin_ativo")] material material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipo_material = new SelectList(db.tipo_material, "id_tipo_material", "nome", material.id_tipo_material);
            return View(material);
        }

        // GET: material/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            material material = db.material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // POST: material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            material material = db.material.Find(id);
            db.material.Remove(material);
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
