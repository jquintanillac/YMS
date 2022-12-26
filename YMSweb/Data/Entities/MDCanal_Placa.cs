using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Canal_Placa")]
    public class MDCanal_Placa
    {
        [Key]
        public int id_canpla { get; set; }
        public int id_canal { get; set; }
        public int id_placa { get; set; }
        public DateTime fec_reg { get; set; }
        public string nro_trans { get; set; }
        public int id_sede { get; set; }
    }
}
