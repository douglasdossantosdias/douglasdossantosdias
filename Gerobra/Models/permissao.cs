namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class permissao
    {
        public int id_permissao { get; set; }
        public Nullable<bool> listar { get; set; }
        public Nullable<bool> editar { get; set; }
        public Nullable<int> criar { get; set; }
        public Nullable<bool> excluir { get; set; }
        public Nullable<bool> visualizar { get; set; }
        public Nullable<int> id_modulo { get; set; }
        public Nullable<int> id_grupo { get; set; }
    
        public virtual grupo grupo { get; set; }
        public virtual modulo modulo { get; set; }
    }
}
