namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class nacionalidade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nacionalidade()
        {
            this.pessoa = new HashSet<pessoa>();
        }
    
        public int id_nacionalidade { get; set; }

        [Display(Name = "Nacionalidade")]
        public string descricao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pessoa> pessoa { get; set; }
    }
}
