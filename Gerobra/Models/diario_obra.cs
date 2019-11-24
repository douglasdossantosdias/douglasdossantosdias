namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class diario_obra
    {
        [Display(Name = "Diário de Obra")]
        public int id_diario_obra { get; set; }

        [Display(Name ="Descrição")]
        public string descricao { get; set; }

        [Display(Name = "Data do Diário da Obra")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public Nullable<System.DateTime> dta_diario { get; set; }


        public Nullable<int> id_obra { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
    
        public virtual obra obra { get; set; }
    }
}
