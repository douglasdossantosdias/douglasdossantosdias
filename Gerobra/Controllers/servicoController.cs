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
    public class servicoController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: servico
        public ActionResult Index()
        {
            var servico = db.servico.Include(s => s.tipo_servico);
            return View(servico.ToList());
        }

        // GET: servico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servico servico = db.servico.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        // GET: servico/Create
        public ActionResult Create()
        {
            ViewBag.id_tipo_servico = new SelectList(db.tipo_servico, "id_tipo_servico", "nome");
            return View();
        }

        // POST: servico/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_servico,id_tipo_servico,nome,sin_ativo")] servico servico)
        {
            if (ModelState.IsValid)
            {
                db.servico.Add(servico);
                db.SaveChanges();
                return RedirectToAction("Create","rel_servico_fornecedor");
            }

            ViewBag.id_tipo_servico = new SelectList(db.tipo_servico, "id_tipo_servico", "nome", servico.id_tipo_servico);
            return View(servico);
        }

        // GET: servico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servico servico = db.servico.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tipo_servico = new SelectList(db.tipo_servico, "id_tipo_servico", "nome", servico.id_tipo_servico);
            return View(servico);
        }

        // POST: servico/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_servico,id_tipo_servico,nome,sin_ativo")] servico servico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipo_servico = new SelectList(db.tipo_servico, "id_tipo_servico", "nome", servico.id_tipo_servico);
            return View(servico);
        }

        // GET: servico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servico servico = db.servico.Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        // POST: servico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            servico servico = db.servico.Find(id);
            db.servico.Remove(servico);
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
