namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class diario_obra
    {
        [Display(Name = "Di�rio de Obra")]
        public int id_diario_obra { get; set; }

        [Display(Name ="Descri��o")]
        public string descricao { get; set; }

        [Display(Name = "Data do Di�rio da Obra")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inv�lido")]
        public Nullable<System.DateTime> dta_diario { get; set; }


        public Nullable<int> id_obra { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
    
        public virtual obra obra { get; set; }
    }
}
