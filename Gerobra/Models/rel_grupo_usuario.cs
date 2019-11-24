namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class rel_grupo_usuario
    {
        public int id_rel_grupo_usuario { get; set; }
        public Nullable<int> id_grupo { get; set; }
        public Nullable<int> id_usuario { get; set; }
    
        public virtual grupo grupo { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
