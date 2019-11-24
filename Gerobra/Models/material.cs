namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public material()
        {
            this.rel_material_fornecedor = new HashSet<rel_material_fornecedor>();
        }

        [Display(Name = "Nome do Material")]
        public int id_material { get; set; }

        [Display(Name = "Tipo de Material")]
        public Nullable<int> id_tipo_material { get; set; }

        [Display(Name = "Nome do Material")]
        public string nome { get; set; }

        [Display(Name = "Ativo")]
        public Nullable<bool> sin_ativo { get; set; }
    
        public virtual tipo_material tipo_material { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rel_material_fornecedor> rel_material_fornecedor { get; set; }
    }
}
