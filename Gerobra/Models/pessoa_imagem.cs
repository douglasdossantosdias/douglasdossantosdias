namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pessoa_imagem
    {
        public int id_pessoa { get; set; }
        public byte[] foto { get; set; }
        public string extensao_foto { get; set; }
    
        public virtual pessoa pessoa { get; set; }
    }
}
