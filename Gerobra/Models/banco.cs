namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class banco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public banco()
        {
            this.conta_bancaria = new HashSet<conta_bancaria>();
        }
    
        [Display(Name = "Numero do Banco")]
        public int id_banco { get; set; }

        [Display(Name = "Numero do banco")]
        public string numero { get; set; }

        [Display(Name = "Nome do Banco")]
        public string nome { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<conta_bancaria> conta_bancaria { get; set; }
    }
}
