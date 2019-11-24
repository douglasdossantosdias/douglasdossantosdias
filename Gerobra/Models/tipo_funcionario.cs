namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipo_funcionario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_funcionario()
        {
            this.funcionario = new HashSet<funcionario>();
        }
    
        public int id_tipo_funcionario { get; set; }
        public string nome { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<funcionario> funcionario { get; set; }
    }
}
