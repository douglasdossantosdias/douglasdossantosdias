namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tipo_sanguineo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_sanguineo()
        {
            this.pessoa = new HashSet<pessoa>();
        }
    
        public int id_tipo_sanguineo { get; set; }

        [Display(Name = "Tipo Sanguíneo")]
        public string descricao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pessoa> pessoa { get; set; }
    }
}
