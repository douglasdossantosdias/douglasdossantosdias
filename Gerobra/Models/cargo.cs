namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class cargo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cargo()
        {
            this.pessoa = new HashSet<pessoa>();
        }
    
        public int id_cargo { get; set; }

        [Display(Name = "Cargo")]
        public string nome { get; set; }

        [Display(Name = "Carga Horária")]
        public int carga_horaria { get; set; }

        [Display(Name = "Ativo")]
        public Nullable<bool> sin_ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pessoa> pessoa { get; set; }
    }
}
