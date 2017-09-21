using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class tbl_Usuario
    {
        public int id_usuario { get; set; }
        public String nombre_usuario { get; set; }
        public String apellido_usuario { get; set; }
        public DateTime fecha_nacimiento { get; set; }

    }
}
