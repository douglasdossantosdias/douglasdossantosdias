namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class rel_servico_fornecedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rel_servico_fornecedor()
        {
            this.custo = new HashSet<custo>();
        }
    
        public int id_rel_servico_fornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        public Nullable<int> id_fornecedor { get; set; }

        [Display(Name = "Serviço")]
        public Nullable<int> id_servico { get; set; }

        [Display(Name = "Unidade")]
        public string unidade { get; set; }

        [Display(Name = "Preço Unitário")]
        public Nullable<decimal> preco_unitario { get; set; }

        
        public Nullable<int> C_default_ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<custo> custo { get; set; }
        public virtual fornecedor fornecedor { get; set; }
        public virtual servico servico { get; set; }
    }
}
