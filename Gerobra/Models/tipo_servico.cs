namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tipo_servico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipo_servico()
        {
            this.servico = new HashSet<servico>();
        }

        [Display(Name = "Nome do Serviço")]
        public int id_tipo_servico { get; set; }

        [Display(Name = "Nome do Serviço")] 
        public string nome { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<servico> servico { get; set; }
    }
}
