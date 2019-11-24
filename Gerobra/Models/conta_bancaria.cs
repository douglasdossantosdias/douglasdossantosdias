namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class conta_bancaria
    {
        public int id_conta_bancaria { get; set; }

        [Display(Name = "Agência")]
        [MaxLength(5)]
        public string agencia { get; set; }

        [MaxLength(14)]
        [Display(Name = "Conta")]
        public string conta { get; set; }

        [Display(Name = "Banco")]
        public Nullable<int> id_banco { get; set; }

        [Display(Name = "Pessoa")]
        public Nullable<int> id_pessoa { get; set; }
    
        public virtual banco banco { get; set; }
        public virtual pessoa pessoa { get; set; }
    }
}
