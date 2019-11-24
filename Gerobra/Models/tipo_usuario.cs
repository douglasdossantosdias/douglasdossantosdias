namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipo_usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_usuario()
        {
            this.usuario = new HashSet<usuario>();
        }
    
        public int id_tipo_usuario { get; set; }
        public string descricao { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuario { get; set; }
    }
}
