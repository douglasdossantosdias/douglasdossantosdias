namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipo_fornecedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_fornecedor()
        {
            this.fornecedor = new HashSet<fornecedor>();
        }
    
        public int id_tipo_fornecedor { get; set; }
        public string nome { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fornecedor> fornecedor { get; set; }
    }
}
