namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class migracao
    {
        public int id_migracao { get; set; }
        public Nullable<System.DateTime> dta_migracao { get; set; }
        public string entidade_origem { get; set; }
        public string entidade_destino { get; set; }
        public Nullable<int> id_funcionario { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
        public Nullable<int> id_usuario { get; set; }
    
        public virtual funcionario funcionario { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
