namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class custo
    {
        [Display(Name = "Custo")]
        public int id_custo { get; set; }

        [Display(Name = "Obra")]
        public Nullable<int> id_obra { get; set; }

        [Display(Name = "Centro de Custo")]
        public Nullable<int> id_centro_custo { get; set; }

        [Display(Name = "Quantidade")]
        public Nullable<int> quantidade { get; set; }

        
        public Nullable<int> id_rel_material_fornecedor { get; set; }
        public Nullable<int> id_rel_servico_fornecedor { get; set; }

        [Display(Name = "Documento Fiscal")]
        public Nullable<int> id_documento_fiscal { get; set; }

        [Display(Name = "Usuário")]
        public Nullable<int> id_usuario { get; set; }
    
        public virtual centro_custo centro_custo { get; set; }
        public virtual documento_fiscal documento_fiscal { get; set; }
        public virtual obra obra { get; set; }
        public virtual rel_material_fornecedor rel_material_fornecedor { get; set; }
        public virtual rel_servico_fornecedor rel_servico_fornecedor { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
