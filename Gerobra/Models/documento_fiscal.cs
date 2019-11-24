namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class documento_fiscal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public documento_fiscal()
        {
            this.caixa = new HashSet<caixa>();
            this.custo = new HashSet<custo>();
        }

        [Display(Name = "Documento Fiscal")]
        public int id_documento_fiscal { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [Display(Name = "Numero")]
        public string numero { get; set; }

        [Display(Name = "Série")]
        public string serie { get; set; }

        [Display(Name = "Data do documento Fiscal")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]

        public Nullable<System.DateTime> dta_doc_fiscal { get; set; }

        [Display(Name = "Tipo do Documento Fiscal")]
        public Nullable<int> id_tipo_documento_fiscal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<caixa> caixa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<custo> custo { get; set; }
        public virtual tipo_documento_fiscal tipo_documento_fiscal { get; set; }
    }
}
