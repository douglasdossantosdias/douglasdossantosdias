namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tipo_documento_fiscal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_documento_fiscal()
        {
            this.documento_fiscal = new HashSet<documento_fiscal>();
        }

        [Display(Name = "Nome do Documento Fiscal")]
        public int id_tipo_documento_fiscal { get; set; }

        [Display(Name = "Nome do Documento Fiscal")]
        public string nome { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<documento_fiscal> documento_fiscal { get; set; }
    }
}
