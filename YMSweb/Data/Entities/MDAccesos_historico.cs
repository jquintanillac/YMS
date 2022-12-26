using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Accesos_Historico")]
    public class MDAccesos_historico
    {
        [Key]
        public int id_acchist { get; set; }
        public int IdUsuario { get; set; }
        public DateTime acce_fecini { get; set; }
        public int id_sede { get; set; }
    }
}
