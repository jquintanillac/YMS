using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Sede")]
    public class MDSedes
    {
        [Key]
        public int id_sede { get; set; }
        public string sede_cod { get; set; }
        public string sede_desc { get; set; }
    }
}
