namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tipo_material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_material()
        {
            this.material = new HashSet<material>();
        }

        [Display(Name = "Nome do Material")]
        public int id_tipo_material { get; set; }

        [Display(Name = "Nome do Material")]
        public string nome { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<material> material { get; set; }
    }
}
