namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class relatorio
    {
        public int id_relatorio { get; set; }
        public Nullable<System.DateTime> dta_relatorio { get; set; }
        public Nullable<System.DateTime> dta_ultima_atualizacao { get; set; }
        public string nome_view { get; set; }
        public Nullable<int> id_modulo { get; set; }
    
        public virtual modulo modulo { get; set; }
    }
}
