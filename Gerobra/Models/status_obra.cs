namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class status_obra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public status_obra()
        {
            this.obra = new HashSet<obra>();
        }
    
        public int id_status_obra { get; set; }
        public string descricao { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<obra> obra { get; set; }
    }
}
