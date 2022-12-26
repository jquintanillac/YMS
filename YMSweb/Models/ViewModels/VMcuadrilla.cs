using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Models.ViewModels
{
    public class VMcuadrilla
    {
        public string cua_desc { get; set; }
        public int id_cuadrilla { get; set; }
        public int cua_cod { get; set; }
        public string plac_desc { get; set; }
        public string nro_trans { get; set; }
        public bool cua_act { get; set; }
    }
}
