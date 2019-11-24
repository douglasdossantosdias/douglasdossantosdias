namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tab_backup
    {
        public int id_tab_backup { get; set; }
        public string nome_arquivo { get; set; }
        public Nullable<System.DateTime> dta_backup { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
        public Nullable<int> id_tipo_backup { get; set; }
    
        public virtual tipo_backup tipo_backup { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
