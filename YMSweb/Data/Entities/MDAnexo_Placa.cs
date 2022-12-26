using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace  YMSweb.Data.Entities
{
    [Table("Anexo_Placa")]
    public class MDAnexo_Placa
    {
        [Key]
        public int id_aneplaca { get; set; }
        public int id_anexo { get; set; }
        public int id_placa { get; set; }
        public int id_sede { get; set; }
    }
}
