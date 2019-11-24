namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipo_curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_curso()
        {
            this.grau_instrucao = new HashSet<grau_instrucao>();
        }
    
        public int id_tipo_curso { get; set; }
        public string nome { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<grau_instrucao> grau_instrucao { get; set; }
    }
}
