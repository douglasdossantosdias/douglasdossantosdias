namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class caixa
    {

        [Display(Name = "Caixa")]
        public int id_caixa { get; set; }

        [Display(Name = "Data do Documento")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public Nullable<System.DateTime> dta_movimento { get; set; }

        [Display(Name = "Tipo de Movimento")]
        public string tipo_movimento { get; set; }

        [Display(Name = "Valor")]
        public Nullable<decimal> valor { get; set; }

        [Display(Name = "Documento Fiscal")]
        public Nullable<int> id_documento_fiscal { get; set; }

        [Display(Name = "Usuário")]
        public Nullable<int> id_usuario { get; set; }

        [Display(Name = "Obra")]
        public Nullable<int> id_obra { get; set; }
    
        public virtual documento_fiscal documento_fiscal { get; set; }
        public virtual obra obra { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
