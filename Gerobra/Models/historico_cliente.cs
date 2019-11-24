namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class historico_cliente
    {
        public int id_historico_cliente { get; set; }
        public string descricao { get; set; }
        public Nullable<System.DateTime> dta_historico { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
        public Nullable<int> id_cliente { get; set; }
    
        public virtual cliente cliente { get; set; }
    }
}
