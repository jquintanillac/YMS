using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Menu")]
    public class MDMenu
    {
        [Key]
        public int id_menu { get; set; }
        public int menu_iden { get; set; }
        public string menu_desc { get; set; }

    }
}
