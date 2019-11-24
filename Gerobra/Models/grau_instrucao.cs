namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class grau_instrucao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public grau_instrucao()
        {
            this.pessoa = new HashSet<pessoa>();
        }
    
        public int id_grau_instrucao { get; set; }


        [Display(Name = "Grau de intrução")]
        public string descricao { get; set; }
        public Nullable<int> ordem { get; set; }
        public Nullable<int> id_tipo_curso { get; set; }
    
        public virtual tipo_curso tipo_curso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pessoa> pessoa { get; set; }
    }
}
