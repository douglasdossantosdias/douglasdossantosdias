namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class obra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public obra()
        {
            this.caixa = new HashSet<caixa>();
            this.custo = new HashSet<custo>();
            this.diario_obra = new HashSet<diario_obra>();
            this.documento = new HashSet<documento>();
            this.rel_cliente_obra = new HashSet<rel_cliente_obra>();
            this.rel_funcionario_obra = new HashSet<rel_funcionario_obra>();
            this.telefone = new HashSet<telefone>();
        }
    
        [Display(Name ="Nome da Obra")]
        public int id_obra { get; set; }

        [Display(Name = "Código da Obra")]
        public string cod_obra { get; set; }

        [Display(Name = "Descrição da Obra")]
        public string descricao { get; set; }


        [Display(Name = "Data de início da Obra")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public Nullable<System.DateTime> dta_inicio { get; set; }

        [Display(Name = "Data de término da Obra")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public Nullable<System.DateTime> dta_fim { get; set; }

        [Display(Name = "Data Prevista para início da Obra")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public Nullable<System.DateTime> dta_previsao_inicio { get; set; }

        [Display(Name = "Data prevista para o término da obra")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public Nullable<System.DateTime> dta_previsao_fim { get; set; }

       [Display(Name = "Orçamento previsto da Obra")]
        public Nullable<decimal> orcamento_previsao { get; set; }

        [Display(Name = "Orçamento total da Obra")]
        public Nullable<int> orcamento_total { get; set; }

           public Nullable<int> id_endereco { get; set; }
        public Nullable<int> id_status_obra { get; set; }
        public Nullable<int> id_tipo_obra { get; set; }

        [Display(Name = "Ativo")]
        public Nullable<bool> sin_ativo { get; set; }
        public Nullable<int> C_default_ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<caixa> caixa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<custo> custo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<diario_obra> diario_obra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<documento> documento { get; set; }
        public virtual endereco endereco { get; set; }
        public virtual status_obra status_obra { get; set; }
        public virtual tipo_obra tipo_obra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rel_cliente_obra> rel_cliente_obra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rel_funcionario_obra> rel_funcionario_obra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<telefone> telefone { get; set; }
    }
}
