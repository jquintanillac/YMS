using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    public class MDHistorico_Viajes
    {
        public int Id_histviaj { get; set; }
        public string hist_canales { get; set; }
        public string hist_cuadrilla { get; set; }
        public string hist_muelle { get; set; }
        public string hist_estaciona { get; set; }
        public string hist_Nrotransp { get; set; }
        public string hist_placa { get; set; }
        public string hist_nroviaje{ get; set; }
        public string hist_peso { get; set; }
        public string hist_volumen { get; set; }
        public string hist_tipo { get; set; }
        public DateTime hist_fectransp { get; set; }
        public int id_sede { get; set; }

    }
}
