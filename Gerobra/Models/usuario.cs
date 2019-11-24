namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            this.caixa = new HashSet<caixa>();
            this.custo = new HashSet<custo>();
            this.log = new HashSet<log>();
            this.migracao = new HashSet<migracao>();
            this.rel_grupo_usuario = new HashSet<rel_grupo_usuario>();
            this.senha = new HashSet<senha>();
            this.tab_backup = new HashSet<tab_backup>();
        }
    
        public int id_usuario { get; set; }
        public Nullable<int> id_tipo_usuario { get; set; }
        public Nullable<int> id_pessoa { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<caixa> caixa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<custo> custo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<log> log { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<migracao> migracao { get; set; }
        public virtual pessoa pessoa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rel_grupo_usuario> rel_grupo_usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<senha> senha { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tab_backup> tab_backup { get; set; }
        public virtual tipo_usuario tipo_usuario { get; set; }
    }
}
