namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class documento
    {
        [Display(Name = "Documento")] 
        public int id_documento { get; set; }
        public Nullable<int> id_obra { get; set; }
        public Nullable<int> id_tipo_documento { get; set; }

        [Display(Name = "Numero do Documento")]
        public string numero { get; set; }

        [Display(Name = "Data do Documento")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public Nullable<System.DateTime> dta_documento { get; set; }

        [Display(Name = "Ativo")]
        public Nullable<bool> sin_ativo { get; set; }

        [Display(Name = "Endereço do Arquivo")]
        public string endereco_arquivo { get; set; }

        [Display(Name = "Extenção do Arquivo")]
        public string extensao_arquivo { get; set; }

        [Display(Name = "Nome do Arquivo")]
        public string nome_arquivo { get; set; }
    
        public virtual obra obra { get; set; }
        public virtual tipo_documento tipo_documento { get; set; }
    }
}
