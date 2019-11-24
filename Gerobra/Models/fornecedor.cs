namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class fornecedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public fornecedor()
        {
            this.rel_material_fornecedor = new HashSet<rel_material_fornecedor>();
            this.rel_servico_fornecedor = new HashSet<rel_servico_fornecedor>();
        }

        [Display(Name = "Fornecedor")]
        public int id_fornecedor { get; set; }
        public Nullable<int> id_tipo_fornecedor { get; set; }
        public Nullable<int> id_pessoa { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
    
        public virtual pessoa pessoa { get; set; }
        public virtual tipo_fornecedor tipo_fornecedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rel_material_fornecedor> rel_material_fornecedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rel_servico_fornecedor> rel_servico_fornecedor { get; set; }
    }
}
