namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class endereco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public endereco()
        {
            this.obra = new HashSet<obra>();
        }
    
        public int id_endereco { get; set; }
        [Display(Name = "Logradouro")]
        public string logradouro { get; set; }

        [Display(Name = "Complemento")]
        public string complemento { get; set; }

        [Display(Name = "Numero")]
        public string numero { get; set; }

        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [Display(Name = "Cidade")]
        public Nullable<int> id_cidade { get; set; }

        [Display(Name = "Pessoa")]
        public Nullable<int> id_pessoa { get; set; }

        [Display(Name = "CEP")]
        public string cep { get; set; }
    
        [Display(Name ="Cidade")]
        public virtual cidade cidade { get; set; }

        [Display(Name = "Pessoa")]
        public virtual pessoa pessoa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [Display(Name ="Obra")]
        public virtual ICollection<obra> obra { get; set; }
    }
}
