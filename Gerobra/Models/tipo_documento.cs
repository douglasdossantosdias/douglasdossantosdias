namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tipo_documento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_documento()
        {
            this.documento = new HashSet<documento>();
        }
    
        [Display(Name ="Nome do Documento")]
        public int id_tipo_documento { get; set; }

        [Display(Name = "Nome do Documento")]
        public string nome { get; set; }

        [Display(Name = "Ativo")]
        public Nullable<bool> sin_ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<documento> documento { get; set; }
    }
}
