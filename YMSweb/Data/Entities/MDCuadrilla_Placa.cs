using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Cuadrilla_Placa")]
    public class MDCuadrilla_Placa
    {
        [Key]
        public int id_cuapla { get; set; }
        public int id_cuadrilla { get; set; }
        public int id_placa { get; set; }
        public DateTime fec_reg { get; set; }
        public string nro_trans { get; set; }
        public int id_sede { get; set; }
    }
}
