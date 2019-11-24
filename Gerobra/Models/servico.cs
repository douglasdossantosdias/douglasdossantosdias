namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class servico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public servico()
        {
            this.rel_servico_fornecedor = new HashSet<rel_servico_fornecedor>();
        }
    
        public int id_servico { get; set; }
        public Nullable<int> id_tipo_servico { get; set; }
        public string nome { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rel_servico_fornecedor> rel_servico_fornecedor { get; set; }
        public virtual tipo_servico tipo_servico { get; set; }
    }
}
