using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Alibot")]
    public class MDAlibot
    {      
        [Key]
        public string app_name { get; set; }
        public string sender { get; set; }
        public string message { get; set; }
        public string phone { get; set; }
        public string group_name { get; set; }
        
    }
}
