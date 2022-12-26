using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    public class MDBloqueos
    {
        [Key]
        public int Id_bloq { get; set; }
        public int bloq_id { get; set; }
        public string bloq_tipo { get; set; }
        public string bloq_obs { get; set; }
        public DateTime bloq_fecha { get; set; }
        public int id_sede { get; set; }
    }
}
