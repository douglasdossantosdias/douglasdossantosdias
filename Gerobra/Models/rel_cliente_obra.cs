namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class rel_cliente_obra
    {
        public int id_rel_cliente_obra { get; set; }

        [Display(Name = "Cliente")]
        public Nullable<int> id_cliente { get; set; }

        [Display(Name = "Obra")]
        public Nullable<int> id_obra { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual obra obra { get; set; }
    }
}
