namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class funcionario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public funcionario()
        {
            this.migracao = new HashSet<migracao>();
            this.rel_funcionario_obra = new HashSet<rel_funcionario_obra>();
        }
    
        public int id_funcionario { get; set; }
        public Nullable<int> id_tipo_funcionario { get; set; }
        public Nullable<int> id_pessoa { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
    
        public virtual pessoa pessoa { get; set; }
        public virtual tipo_funcionario tipo_funcionario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<migracao> migracao { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rel_funcionario_obra> rel_funcionario_obra { get; set; }
    }
}
