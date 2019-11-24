namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipo_obra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_obra()
        {
            this.obra = new HashSet<obra>();
        }
    
        public int id_tipo_obra { get; set; }
        public string descricao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<obra> obra { get; set; }
    }
}
