namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipo_cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_cliente()
        {
            this.cliente = new HashSet<cliente>();
        }
    
        public int id_tipo_cliente { get; set; }
        public string descricao { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cliente> cliente { get; set; }
    }
}
