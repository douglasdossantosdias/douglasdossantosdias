namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class log
    {
        public int id_log { get; set; }
        public Nullable<int> dta_log { get; set; }
        public string banco_dados { get; set; }
        public string entidade { get; set; }
        public Nullable<int> id_entidade { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public Nullable<int> id_acao { get; set; }
    
        public virtual acao acao { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
