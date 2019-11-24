namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class acao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public acao()
        {
            this.log = new HashSet<log>();
        }
    
        public int id_acao { get; set; }
        public string nome { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<log> log { get; set; }
    }
}
