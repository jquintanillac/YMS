using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Anexos")]
    public class MDAnexos
    {
        [Key]
        public int id_anexo { get; set; }
        public string anex_desc { get; set; }
        public bool anex_act { get; set; }
        public string esta_plac { get; set; }
        public int id_sede { get; set; }
        public int anex_cod { get; set; }
    }
}
