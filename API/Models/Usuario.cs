using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Usuario
    {
        public Usuario()
        {
            this.beneficiario = new HashSet<Beneficiario>();
        }

        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }

        public virtual ICollection<Beneficiario> beneficiario { get; set; }
    }
}
