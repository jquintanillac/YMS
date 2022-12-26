using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YMSweb.Models.ViewModels;

namespace YMSweb.Data.DataSql
{
    public class SP_Reportes
    {

        public SqlConnection conexion;
        public SP_Reportes()
        {
            var config = GetConfiguration();
            conexion = new SqlConnection(config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
        }

        /// <summary>
        /// Conexion a la base de datos del arhivo appsettings.json
        /// </summary>
        /// <returns></returns>
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }


        /// <placas>
        /// Crea una lista de reportes de datos. 
        /// </placas>
        /// <param name="conn"> conexion que se hace para la base de datos </param>
        /// <returns> lista de placas </returns>
        public async Task<List<VMReporte1>> mReporteviaje(DateTime fecini, DateTime fecfin, int nro_viaje, string nro_trans)
        {
            try
            {
                List<VMReporte1> ReporteViaje = new List<VMReporte1>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_DETALLE_Q06]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FEC_INI", fecini);
                cmd.Parameters.AddWithValue("@FEC_FIN", fecfin);
                cmd.Parameters.AddWithValue("@NRO_VIAJE", nro_viaje);
                cmd.Parameters.AddWithValue("@NRO_TRANS", nro_trans);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMReporte1 objbal = new VMReporte1();
                    objbal.placa = rdr["placa"].ToString();
                    objbal.nro_viaje = rdr["nro_viaje"].ToString();
                    objbal.empresa = rdr["empresa"].ToString();
                    objbal.volumen = rdr["volumen"].ToString();
                    objbal.peso = rdr["peso"].ToString();
                    objbal.tipo_transporte = rdr["tipo_transporte"].ToString();
                    objbal.hora_propuesta = rdr["hora_propuesta"].ToString();
                    objbal.fase = rdr["fase"].ToString();
                    objbal.fecha_viaje = rdr["fecha_viaje"].ToString();
                    objbal.vijcab_fecllegada = rdr["vijcab_fecllegada"].ToString();
                    objbal.vijcab_fecunidad = rdr["vijcab_fecunidad"].ToString();
                    objbal.nro_transportes = rdr["nro_transportes"].ToString();
                    objbal.estcam_desc = rdr["estcam_desc"].ToString();
                    objbal.vijdet_fecini = rdr["vijdet_fecini"].ToString();
                    objbal.vijdet_fecfin = rdr["vijdet_fecfin"].ToString();
                    objbal.nro_canales = rdr["nro_canales"].ToString();
                    objbal.can_fecini = rdr["can_fecini"].ToString();
                    objbal.placa = rdr["placa"].ToString();
                    objbal.can_fecfin = rdr["can_fecfin"].ToString();
                    objbal.nro_muelles = rdr["nro_muelles"].ToString();
                    objbal.muell_fecini = rdr["muell_fecini"].ToString();
                    objbal.muell_fecfin = rdr["muell_fecfin"].ToString();
                    objbal.nro_estacionamiento = rdr["nro_estacionamiento"].ToString();
                    objbal.estacion_fecini = rdr["estacion_fecini"].ToString();
                    objbal.estacion_fecfin = rdr["estacion_fecfin"].ToString();
                    objbal.nro_cuadrilla = rdr["nro_cuadrilla"].ToString();
                    objbal.cuadri_fecini = rdr["cuadri_fecini"].ToString();
                    objbal.cuadri_fecfin = rdr["cuadri_fecfin"].ToString();
                    objbal.nro_montacarga = rdr["nro_montacarga"].ToString();
                    objbal.monta_fecini = rdr["monta_fecini"].ToString();
                    objbal.monta_fecfin = rdr["monta_fecfin"].ToString();    
                    ReporteViaje.Add(objbal);
                }
                conexion.Close();                
                return ReporteViaje;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
