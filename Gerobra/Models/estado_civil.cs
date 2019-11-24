namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class estado_civil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public estado_civil()
        {
            this.pessoa = new HashSet<pessoa>();
        }

        [Display(Name = "Estado Civíl")]
        public int id_estado_civil { get; set; }

        [Display(Name = "Estado Civíl")]
        public string descricao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pessoa> pessoa { get; set; }
    }
}
