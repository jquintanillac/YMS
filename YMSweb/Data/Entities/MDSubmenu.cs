using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Submenu")]
    public class MDSubmenu
    {
        [Key]
        public int id_submenu { get; set; }
        public int id_menu { get; set; }
        public int submenu_iden { get; set; }
        public string submenu_desc { get; set; }

    }
}
