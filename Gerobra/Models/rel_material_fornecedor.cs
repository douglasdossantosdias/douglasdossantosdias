namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class rel_material_fornecedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rel_material_fornecedor()
        {
            this.custo = new HashSet<custo>();
        }
    
        public int id_rel_material_fornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        public Nullable<int> id_fornecedor { get; set; }

        [Display(Name = "Material")]
        public Nullable<int> id_material { get; set; }

        [Display(Name = "Unidade")]
        public string unidade { get; set; }

        [Display(Name = "Preço Unitário")]
        public Nullable<decimal> preco_unitario { get; set; }

        [Display(Name = "Marca")]
        public string marca { get; set; }

        [Display(Name = "Modelo")]
        public Nullable<int> modelo { get; set; }

        [Display(Name = "Cor")]
        public Nullable<int> cor { get; set; }

        [Display(Name = "Peso")]
        public Nullable<decimal> peso { get; set; }

        [Display(Name = "Textura")]
        public string textura { get; set; }

        [Display(Name = "Altura")]
        public Nullable<decimal> altura { get; set; }

        [Display(Name = "Largura")]
        public Nullable<decimal> largura { get; set; }

        [Display(Name = "Profundidade")]
        public Nullable<decimal> profundidade { get; set; }

        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<custo> custo { get; set; }
        public virtual fornecedor fornecedor { get; set; }
        public virtual material material { get; set; }
    }
}
