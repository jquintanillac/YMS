using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Muelle_Placa")]
    public class MDMuelle_Placa
    {
        [Key]
        public int id_muepla { get; set; }
        public int id_muelle { get; set; }
        public int id_placa { get; set; }
        public DateTime fec_reg { get; set; }
        public string nro_trans { get; set; }
        public int id_sede { get; set; }
    }
}
