namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class telefone
    {
        [Display(Name ="Numero de Telefone")]
        public int id_telefone { get; set; }

        [Display(Name = "Tipo de Telefone")]
        public string sta_tipo { get; set; }

        [Display(Name = "Numero de Telefone")]
        public string numero { get; set; }

        [Display(Name = "Ramal")]
        public string ramal { get; set; }
        
        
        public Nullable<int> id_pessoa { get; set; }

        
        public Nullable<int> id_obra { get; set; }

       
        public virtual obra obra { get; set; }
        public virtual pessoa pessoa { get; set; }
    }
}
