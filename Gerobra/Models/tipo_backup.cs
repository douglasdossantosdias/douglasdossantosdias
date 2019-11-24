namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipo_backup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_backup()
        {
            this.tab_backup = new HashSet<tab_backup>();
        }
    
        public int id_tipo_backup { get; set; }
        public string nome { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tab_backup> tab_backup { get; set; }
    }
}
