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
    public class pessoaController : Controller
    {
        private GerobraDbContext db = new GerobraDbContext();

        // GET: pessoa
        public ActionResult Index()
        {
            var pessoa = db.pessoa.Include(p => p.cargo).Include(p => p.cor_raca).Include(p => p.estado_civil).Include(p => p.grau_instrucao).Include(p => p.nacionalidade).Include(p => p.pessoa2).Include(p => p.tipo_sanguineo).Include(p => p.tipo_pessoa).Include(p => p.pessoa_imagem);
            return View(pessoa.ToList());
        }

        public ActionResult List(string searchString)
        {
            var pessoas = db.pessoa.Include(p => p.cargo).Include(p => p.cor_raca).Include(p => p.estado_civil).Include(p => p.grau_instrucao).Include(p => p.nacionalidade).Include(p => p.pessoa2).Include(p => p.tipo_sanguineo).Include(p => p.tipo_pessoa).Include(p => p.pessoa_imagem);


            if (!String.IsNullOrEmpty(searchString))
            {
                var pessoasNew = from s in db.pessoa
                                 select s;

                pessoasNew = pessoasNew.Where(s => s.nome.ToUpper().Contains(searchString.ToUpper())
                                                || s.email.ToUpper().Contains(searchString.ToUpper()));
                return View(pessoasNew.ToList());

            }
            return View(pessoas.ToList());
        }

        // GET: pessoa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pessoa pessoa = db.pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: pessoa/Create
        public ActionResult Create()
        {
            ViewBag.id_cargo = new SelectList(db.cargo, "id_cargo", "nome");
            ViewBag.id_cor_raca = new SelectList(db.cor_raca, "id_cor_raca", "descricao");
            ViewBag.id_estado_civil = new SelectList(db.estado_civil, "id_estado_civil", "descricao");
            ViewBag.id_grau_instrucao = new SelectList(db.grau_instrucao, "id_grau_instrucao", "descricao");
            ViewBag.id_nacionalidade = new SelectList(db.nacionalidade, "id_nacionalidade", "descricao");
            ViewBag.id_empresa_contato = new SelectList(db.pessoa, "id_pessoa", "nome");
            ViewBag.id_tipo_sanguineo = new SelectList(db.tipo_sanguineo, "id_tipo_sanguineo", "descricao");
            ViewBag.id_tipo_pessoa = new SelectList(db.tipo_pessoa, "id_tipo_pessoa", "nome");
            ViewBag.id_pessoa = new SelectList(db.pessoa_imagem, "id_pessoa", "extensao_foto");
            return View();
        }

        // POST: pessoa/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pessoa,nome,nome_juridico,nome_fantasia,cnpj,inscricao_estadual,sexo,dta_nascimento,ano_chegada,naturalidade,id_estado_civil,nome_conjuge,nome_pai,nome_mae,id_tipo_sanguineo,id_grau_instrucao,registro_conselho_profissional,rg,orgao_expedidor_rg,dta_expedicao_rg,cpf,pis_pasep,titulo_eleitor,zona_eleitoral,secao_eleitoral,dta_ultima_votacao,dta_emissao_titulo,cidade_titulo,certificado_reservista,categoria_militar,regiao_militar,registro_cnh,categoria_cnh,dta_primeira_cnh,dta_emissao_cnh,dta_validade_cnh,conta_bancaria,email,id_uf_rg,id_uf_conselho_profissional,id_uf_titulo,cnh,id_nacionalidade,nome_reduzido,id_cor_raca,email_pessoal,id_municipio_naturalidade,id_tipo_pessoa,id_cargo,id_empresa_contato,sin_ativo")] pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.pessoa.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cargo = new SelectList(db.cargo, "id_cargo", "nome", pessoa.id_cargo);
            ViewBag.id_cor_raca = new SelectList(db.cor_raca, "id_cor_raca", "descricao", pessoa.id_cor_raca);
            ViewBag.id_estado_civil = new SelectList(db.estado_civil, "id_estado_civil", "descricao", pessoa.id_estado_civil);
            ViewBag.id_grau_instrucao = new SelectList(db.grau_instrucao, "id_grau_instrucao", "descricao", pessoa.id_grau_instrucao);
            ViewBag.id_nacionalidade = new SelectList(db.nacionalidade, "id_nacionalidade", "descricao", pessoa.id_nacionalidade);
            ViewBag.id_empresa_contato = new SelectList(db.pessoa, "id_pessoa", "nome", pessoa.id_empresa_contato);
            ViewBag.id_tipo_sanguineo = new SelectList(db.tipo_sanguineo, "id_tipo_sanguineo", "descricao", pessoa.id_tipo_sanguineo);
            ViewBag.id_tipo_pessoa = new SelectList(db.tipo_pessoa, "id_tipo_pessoa", "nome", pessoa.id_tipo_pessoa);
            ViewBag.id_pessoa = new SelectList(db.pessoa_imagem, "id_pessoa", "extensao_foto", pessoa.id_pessoa);
            return View(pessoa);
        }

        // GET: pessoa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pessoa pessoa = db.pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cargo = new SelectList(db.cargo, "id_cargo", "nome", pessoa.id_cargo);
            ViewBag.id_cor_raca = new SelectList(db.cor_raca, "id_cor_raca", "descricao", pessoa.id_cor_raca);
            ViewBag.id_estado_civil = new SelectList(db.estado_civil, "id_estado_civil", "descricao", pessoa.id_estado_civil);
            ViewBag.id_grau_instrucao = new SelectList(db.grau_instrucao, "id_grau_instrucao", "descricao", pessoa.id_grau_instrucao);
            ViewBag.id_nacionalidade = new SelectList(db.nacionalidade, "id_nacionalidade", "descricao", pessoa.id_nacionalidade);
            ViewBag.id_empresa_contato = new SelectList(db.pessoa, "id_pessoa", "nome", pessoa.id_empresa_contato);
            ViewBag.id_tipo_sanguineo = new SelectList(db.tipo_sanguineo, "id_tipo_sanguineo", "descricao", pessoa.id_tipo_sanguineo);
            ViewBag.id_tipo_pessoa = new SelectList(db.tipo_pessoa, "id_tipo_pessoa", "nome", pessoa.id_tipo_pessoa);
            ViewBag.id_pessoa = new SelectList(db.pessoa_imagem, "id_pessoa", "extensao_foto", pessoa.id_pessoa);
            return View(pessoa);
        }

        // POST: pessoa/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pessoa,nome,nome_juridico,nome_fantasia,cnpj,inscricao_estadual,sexo,dta_nascimento,ano_chegada,naturalidade,id_estado_civil,nome_conjuge,nome_pai,nome_mae,id_tipo_sanguineo,id_grau_instrucao,registro_conselho_profissional,rg,orgao_expedidor_rg,dta_expedicao_rg,cpf,pis_pasep,titulo_eleitor,zona_eleitoral,secao_eleitoral,dta_ultima_votacao,dta_emissao_titulo,cidade_titulo,certificado_reservista,categoria_militar,regiao_militar,registro_cnh,categoria_cnh,dta_primeira_cnh,dta_emissao_cnh,dta_validade_cnh,conta_bancaria,email,id_uf_rg,id_uf_conselho_profissional,id_uf_titulo,cnh,id_nacionalidade,nome_reduzido,id_cor_raca,email_pessoal,id_municipio_naturalidade,id_tipo_pessoa,id_cargo,id_empresa_contato,sin_ativo")] pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cargo = new SelectList(db.cargo, "id_cargo", "nome", pessoa.id_cargo);
            ViewBag.id_cor_raca = new SelectList(db.cor_raca, "id_cor_raca", "descricao", pessoa.id_cor_raca);
            ViewBag.id_estado_civil = new SelectList(db.estado_civil, "id_estado_civil", "descricao", pessoa.id_estado_civil);
            ViewBag.id_grau_instrucao = new SelectList(db.grau_instrucao, "id_grau_instrucao", "descricao", pessoa.id_grau_instrucao);
            ViewBag.id_nacionalidade = new SelectList(db.nacionalidade, "id_nacionalidade", "descricao", pessoa.id_nacionalidade);
            ViewBag.id_empresa_contato = new SelectList(db.pessoa, "id_pessoa", "nome", pessoa.id_empresa_contato);
            ViewBag.id_tipo_sanguineo = new SelectList(db.tipo_sanguineo, "id_tipo_sanguineo", "descricao", pessoa.id_tipo_sanguineo);
            ViewBag.id_tipo_pessoa = new SelectList(db.tipo_pessoa, "id_tipo_pessoa", "nome", pessoa.id_tipo_pessoa);
            ViewBag.id_pessoa = new SelectList(db.pessoa_imagem, "id_pessoa", "extensao_foto", pessoa.id_pessoa);
            return View(pessoa);
        }

        // GET: pessoa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pessoa pessoa = db.pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pessoa pessoa = db.pessoa.Find(id);
            db.pessoa.Remove(pessoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult tipoPessoa(pessoa viewModel)
        {
            var pessoaTipo = viewModel.id_tipo_pessoa.ToString();

            ViewBag.TipoPessoa = pessoaTipo;

            if (pessoaTipo == "1")
            {
                return RedirectToAction("CreatePF");
            }
            else if (pessoaTipo == "2")
            {
                return RedirectToAction("CreatePJ");
            }
            else
            {
                return View();
            }


            return View();
        }

        public ActionResult CreatePF(pessoa viewModel)
        {
            var pessoaTipo = viewModel.id_tipo_pessoa.ToString();

            ViewBag.TipoPessoa = pessoaTipo;


            return View();
        }
        public ActionResult CreatePJ(pessoa viewModel)
        {
            var pessoaTipo = viewModel.id_tipo_pessoa.ToString();

            ViewBag.TipoPessoa = pessoaTipo;


            return View();
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
