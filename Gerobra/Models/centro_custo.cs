namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class centro_custo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public centro_custo()
        {
            this.custo = new HashSet<custo>();
        }
    
        public int id_centro_custo { get; set; }

        [Display(Name = "Código")]
        public string codigo { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [Display(Name = "Ativo/Passivo")]
        public Nullable<bool> ativo { get; set; }

        [Display(Name = "Sintético/Analitico")]
        public Nullable<bool> sintetico { get; set; }

        [Display(Name = "ativo")]
        public Nullable<bool> sin_ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<custo> custo { get; set; }
    }
}
