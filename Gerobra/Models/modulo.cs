namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class modulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public modulo()
        {
            this.permissao = new HashSet<permissao>();
            this.relatorio = new HashSet<relatorio>();
        }
    
        public int id_modulo { get; set; }
        public string nome { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<permissao> permissao { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<relatorio> relatorio { get; set; }
    }
}
