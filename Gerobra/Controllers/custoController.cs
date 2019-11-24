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
    public class custoController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: custo
        public ActionResult Index()
        {
            var custo = db.custo.Include(c => c.centro_custo).Include(c => c.documento_fiscal).Include(c => c.obra).Include(c => c.rel_material_fornecedor).Include(c => c.rel_servico_fornecedor).Include(c => c.usuario);
            return View(custo.ToList());
        }

        // GET: custo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            custo custo = db.custo.Find(id);
            if (custo == null)
            {
                return HttpNotFound();
            }
            return View(custo);
        }

        // GET: custo/Create
        public ActionResult Create()
        {
            ViewBag.id_centro_custo = new SelectList(db.centro_custo, "id_centro_custo", "codigo");
            ViewBag.id_documento_fiscal = new SelectList(db.documento_fiscal, "id_documento_fiscal", "descricao");
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra");
            ViewBag.id_rel_material_fornecedor = new SelectList(db.rel_material_fornecedor, "id_rel_material_fornecedor", "unidade");
            ViewBag.id_rel_servico_fornecedor = new SelectList(db.rel_servico_fornecedor, "id_rel_servico_fornecedor", "unidade");
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario");
            return View();
        }

        // POST: custo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_custo,id_obra,id_centro_custo,quantidade,id_rel_material_fornecedor,id_rel_servico_fornecedor,id_documento_fiscal,id_usuario")] custo custo)
        {
            if (ModelState.IsValid)
            {
                db.custo.Add(custo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_centro_custo = new SelectList(db.centro_custo, "id_centro_custo", "codigo", custo.id_centro_custo);
            ViewBag.id_documento_fiscal = new SelectList(db.documento_fiscal, "id_documento_fiscal", "descricao", custo.id_documento_fiscal);
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", custo.id_obra);
            ViewBag.id_rel_material_fornecedor = new SelectList(db.rel_material_fornecedor, "id_rel_material_fornecedor", "unidade", custo.id_rel_material_fornecedor);
            ViewBag.id_rel_servico_fornecedor = new SelectList(db.rel_servico_fornecedor, "id_rel_servico_fornecedor", "unidade", custo.id_rel_servico_fornecedor);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", custo.id_usuario);
            return View(custo);
        }

        // GET: custo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            custo custo = db.custo.Find(id);
            if (custo == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_centro_custo = new SelectList(db.centro_custo, "id_centro_custo", "codigo", custo.id_centro_custo);
            ViewBag.id_documento_fiscal = new SelectList(db.documento_fiscal, "id_documento_fiscal", "descricao", custo.id_documento_fiscal);
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", custo.id_obra);
            ViewBag.id_rel_material_fornecedor = new SelectList(db.rel_material_fornecedor, "id_rel_material_fornecedor", "unidade", custo.id_rel_material_fornecedor);
            ViewBag.id_rel_servico_fornecedor = new SelectList(db.rel_servico_fornecedor, "id_rel_servico_fornecedor", "unidade", custo.id_rel_servico_fornecedor);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", custo.id_usuario);
            return View(custo);
        }

        // POST: custo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_custo,id_obra,id_centro_custo,quantidade,id_rel_material_fornecedor,id_rel_servico_fornecedor,id_documento_fiscal,id_usuario")] custo custo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(custo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_centro_custo = new SelectList(db.centro_custo, "id_centro_custo", "codigo", custo.id_centro_custo);
            ViewBag.id_documento_fiscal = new SelectList(db.documento_fiscal, "id_documento_fiscal", "descricao", custo.id_documento_fiscal);
            ViewBag.id_obra = new SelectList(db.obra, "id_obra", "cod_obra", custo.id_obra);
            ViewBag.id_rel_material_fornecedor = new SelectList(db.rel_material_fornecedor, "id_rel_material_fornecedor", "unidade", custo.id_rel_material_fornecedor);
            ViewBag.id_rel_servico_fornecedor = new SelectList(db.rel_servico_fornecedor, "id_rel_servico_fornecedor", "unidade", custo.id_rel_servico_fornecedor);
            ViewBag.id_usuario = new SelectList(db.usuario, "id_usuario", "id_usuario", custo.id_usuario);
            return View(custo);
        }

        // GET: custo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            custo custo = db.custo.Find(id);
            if (custo == null)
            {
                return HttpNotFound();
            }
            return View(custo);
        }

        // POST: custo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            custo custo = db.custo.Find(id);
            db.custo.Remove(custo);
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
