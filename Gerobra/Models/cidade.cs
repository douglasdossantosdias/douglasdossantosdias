namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class cidade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cidade()
        {
            this.endereco = new HashSet<endereco>();
        }

        [Display(Name = "Cidade")]
        public int id_cidade { get; set; }

        [Display(Name ="Cidade")]
        public string nome { get; set; }
        public string sin_vara_federal { get; set; }
        public Nullable<int> codigo_ibge { get; set; }
        public Nullable<int> id_orgao { get; set; }
        public string observacao { get; set; }
        public string uf { get; set; }
        public Nullable<int> id_uf { get; set; }
    
        public virtual uf uf1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<endereco> endereco { get; set; }
    }
}
