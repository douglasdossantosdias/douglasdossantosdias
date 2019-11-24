namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class uf
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public uf()
        {
            this.cidade = new HashSet<cidade>();
        }
    
        public int id_uf { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public Nullable<int> id_pais { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cidade> cidade { get; set; }
        public virtual pais pais { get; set; }
    }
}
