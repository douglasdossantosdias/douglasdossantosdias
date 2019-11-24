namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class grupo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public grupo()
        {
            this.permissao = new HashSet<permissao>();
            this.rel_grupo_usuario = new HashSet<rel_grupo_usuario>();
        }
    
        public int id_grupo { get; set; }
        public string nome { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<permissao> permissao { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rel_grupo_usuario> rel_grupo_usuario { get; set; }
    }
}
