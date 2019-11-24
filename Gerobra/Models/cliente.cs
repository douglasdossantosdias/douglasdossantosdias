namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            this.historico_cliente = new HashSet<historico_cliente>();
            this.rel_cliente_obra = new HashSet<rel_cliente_obra>();
        }
    
        public int id_cliente { get; set; }
        public Nullable<int> id_tipo_cliente { get; set; }
        public Nullable<int> id_pessoa { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
    
        public virtual pessoa pessoa { get; set; }
        public virtual tipo_cliente tipo_cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<historico_cliente> historico_cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rel_cliente_obra> rel_cliente_obra { get; set; }
    }
}
