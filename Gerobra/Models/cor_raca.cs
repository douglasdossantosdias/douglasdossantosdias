namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cor_raca
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cor_raca()
        {
            this.pessoa = new HashSet<pessoa>();
        }
    
        public int id_cor_raca { get; set; }
        public string descricao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pessoa> pessoa { get; set; }
    }
}
