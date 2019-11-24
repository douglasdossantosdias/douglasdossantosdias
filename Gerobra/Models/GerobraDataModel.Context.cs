namespace Gerobra.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.Entity.Validation;

    public partial class GerobraDbContext : DbContext
    {
        public GerobraDbContext()
            : base("name=GerobraDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }



        public virtual DbSet<acao> acao { get; set; }
        public virtual DbSet<banco> banco { get; set; }
        public virtual DbSet<caixa> caixa { get; set; }
        public virtual DbSet<cargo> cargo { get; set; }
        public virtual DbSet<centro_custo> centro_custo { get; set; }
        public virtual DbSet<cidade> cidade { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<conta_bancaria> conta_bancaria { get; set; }
        public virtual DbSet<cor_raca> cor_raca { get; set; }
        public virtual DbSet<custo> custo { get; set; }
        public virtual DbSet<diario_obra> diario_obra { get; set; }
        public virtual DbSet<documento> documento { get; set; }
        public virtual DbSet<documento_fiscal> documento_fiscal { get; set; }
        public virtual DbSet<endereco> endereco { get; set; }
        public virtual DbSet<estado_civil> estado_civil { get; set; }
        public virtual DbSet<fornecedor> fornecedor { get; set; }
        public virtual DbSet<funcionario> funcionario { get; set; }
        public virtual DbSet<grau_instrucao> grau_instrucao { get; set; }
        public virtual DbSet<grupo> grupo { get; set; }
        public virtual DbSet<historico_cliente> historico_cliente { get; set; }
        public virtual DbSet<log> log { get; set; }
        public virtual DbSet<material> material { get; set; }
        public virtual DbSet<migracao> migracao { get; set; }
        public virtual DbSet<modulo> modulo { get; set; }
        public virtual DbSet<nacionalidade> nacionalidade { get; set; }
        public virtual DbSet<obra> obra { get; set; }
        public virtual DbSet<pais> pais { get; set; }
        public virtual DbSet<permissao> permissao { get; set; }
        public virtual DbSet<pessoa> pessoa { get; set; }
        public virtual DbSet<pessoa_imagem> pessoa_imagem { get; set; }
        public virtual DbSet<rel_cliente_obra> rel_cliente_obra { get; set; }
        public virtual DbSet<rel_funcionario_obra> rel_funcionario_obra { get; set; }
        public virtual DbSet<rel_grupo_usuario> rel_grupo_usuario { get; set; }
        public virtual DbSet<rel_material_fornecedor> rel_material_fornecedor { get; set; }
        public virtual DbSet<rel_servico_fornecedor> rel_servico_fornecedor { get; set; }
        public virtual DbSet<relatorio> relatorio { get; set; }
        public virtual DbSet<senha> senha { get; set; }
        public virtual DbSet<servico> servico { get; set; }
        public virtual DbSet<status_obra> status_obra { get; set; }
        public virtual DbSet<tab_backup> tab_backup { get; set; }
        public virtual DbSet<telefone> telefone { get; set; }
        public virtual DbSet<tipo_backup> tipo_backup { get; set; }
        public virtual DbSet<tipo_cliente> tipo_cliente { get; set; }
        public virtual DbSet<tipo_curso> tipo_curso { get; set; }
        public virtual DbSet<tipo_documento> tipo_documento { get; set; }
        public virtual DbSet<tipo_documento_fiscal> tipo_documento_fiscal { get; set; }
        public virtual DbSet<tipo_fornecedor> tipo_fornecedor { get; set; }
        public virtual DbSet<tipo_funcionario> tipo_funcionario { get; set; }
        public virtual DbSet<tipo_material> tipo_material { get; set; }
        public virtual DbSet<tipo_obra> tipo_obra { get; set; }
        public virtual DbSet<tipo_pessoa> tipo_pessoa { get; set; }
        public virtual DbSet<tipo_sanguineo> tipo_sanguineo { get; set; }
        public virtual DbSet<tipo_servico> tipo_servico { get; set; }
        public virtual DbSet<tipo_usuario> tipo_usuario { get; set; }
        public virtual DbSet<uf> uf { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    }
}
