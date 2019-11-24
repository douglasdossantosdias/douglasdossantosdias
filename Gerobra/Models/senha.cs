namespace Gerobra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class senha
    {
        public int id_senha { get; set; }
        public string senha1 { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public Nullable<bool> sin_ativo { get; set; }
    
        public virtual usuario usuario { get; set; }
    }
}
