namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class rel_funcionario_obra
    {
        
        public int id_rel_funcionario_obra { get; set; }

        [Display(Name = "Funcionario")]
        public Nullable<int> id_funcionario { get; set; }

        [Display(Name = "Obra")]
        public Nullable<int> id_obra { get; set; }
    
        public virtual funcionario funcionario { get; set; }
        public virtual obra obra { get; set; }
    }
}
