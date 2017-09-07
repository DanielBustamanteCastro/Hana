using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class tbl_Flora
    {
        public int id_flora { get; set; }
        public String nombre_cientifico { get; set; }
        public String  nombre_comun { get; set; }
        public String  estado_flora { get; set; }
        public String descripcion_flora { get; set; }
    }
}
