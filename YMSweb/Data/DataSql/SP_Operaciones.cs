using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YMSweb.Data.Entities;
using YMSweb.Models.ViewModels;

namespace YMSweb.Data.DataSql
{
    public class SP_Operaciones
    {
        public SqlConnection conexion;
        public SP_Operaciones()
        {
            var config = GetConfiguration();
            conexion = new SqlConnection(config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        /// <placas>
        /// Crea una lista de placas 
        /// </placas>
        /// <param name="conn"> conexion que se hace para la base de datos </param>
        /// <returns> lista de placas </returns>
        /// 
        public async Task<List<VMPlaca>> mPlacas ()
        {
            try
            {
                List<VMPlaca> ListaPlaca = new List<VMPlaca>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_PLACA_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMPlaca objbal = new VMPlaca();
                    objbal.id_placa = rdr["id_placa"].ToString();
                    objbal.Chofer = rdr["Chofer"].ToString();
                    objbal.Transportista = rdr["Transportista"].ToString();
                    objbal.Placa = rdr["Placa"].ToString();
                    objbal.Activa = Convert.ToBoolean(rdr["Activa"].ToString());
                    objbal.Libre = Convert.ToBoolean(rdr["Libre"].ToString());
                    ListaPlaca.Add(objbal);
                }
                conexion.Close();



                return ListaPlaca;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Camiones Planificados
        /// </summary>
        /// <param name="conn">conexion de la base de datos</param>
        /// <returns>Lista de camiones planificados</returns>
        public async Task<List<VMCamiones_Planificados>> mCamiones_Planificados_Carga(int placa, int id_sede)
        {
            try
            {
                List<VMCamiones_Planificados> ListaCampla = new List<VMCamiones_Planificados>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_CAMIONES_PLANIFICADOS_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IPLACA", placa);
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMCamiones_Planificados objbal = new VMCamiones_Planificados();
                    objbal.id_campla = Convert.ToInt32(rdr["id_campla"]);
                    objbal.tiptran = rdr["tiptran"].ToString();
                    objbal.placa = rdr["placa"].ToString();
                    objbal.campla_nrotrans = rdr["campla_nrotrans"].ToString();
                    objbal.campla_peso = rdr["campla_peso"].ToString();
                    objbal.campla_volumen = rdr["campla_volumen"].ToString();
                    objbal.campla_obse = rdr["campla_obse"].ToString();
                    objbal.id_camplacab = Convert.ToInt32(rdr["id_camplacab"]);
                    ListaCampla.Add(objbal);
                }
                conexion.Close();
                return ListaCampla;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Camiones Planificados
        /// </summary>
        /// <param name="conn">conexion de la base de datos</param>
        /// <returns>Lista de camiones planificados</returns>
        public async Task<List<VMCamiones_Planificados>> mCamiones_Planificados_Descarga(int placa, int id_sede)
        {
            try
            {
                List<VMCamiones_Planificados> ListaCampla = new List<VMCamiones_Planificados>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_CAMIONES_PLANIFICADOS_Q03]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IPLACA", placa);
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMCamiones_Planificados objbal = new VMCamiones_Planificados();
                    objbal.id_campla = Convert.ToInt32(rdr["id_campla"]);
                    objbal.tiptran = rdr["tiptran"].ToString();
                    objbal.placa = rdr["placa"].ToString();
                    objbal.campla_nrotrans = rdr["campla_nrotrans"].ToString();
                    objbal.campla_peso = rdr["campla_peso"].ToString();
                    objbal.campla_volumen = rdr["campla_volumen"].ToString();
                    objbal.campla_obse = rdr["campla_obse"].ToString();
                    objbal.id_camplacab = Convert.ToInt32(rdr["id_camplacab"]);
                    objbal.campla_orden = Convert.ToInt32(rdr["campla_orden"]);
                    ListaCampla.Add(objbal);
                }
                conexion.Close();
                return ListaCampla;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Viajes
        /// </summary>
        /// <param name="conn">conexcion de la base de datos</param>
        /// <returns>lista de los registros de viajes</returns>
        public async Task<List<VMviajes>> mViajescarga(int id_sede)
        {
            try
            {
                List<VMviajes> ListaViajes = new List<VMviajes>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMviajes objbal = new VMviajes();
                    objbal.id_camplacab = Convert.ToInt32(rdr["id_camplacab"]);
                    objbal.placa = rdr["placa"].ToString();
                    objbal.Nro_Trans = rdr["Nro_Trans"].ToString();
                    objbal.Fec_gen = Convert.ToDateTime(rdr["Fec_gen"]);
                    objbal.campla_obse = rdr["campla_obse"].ToString();
                    ListaViajes.Add(objbal);
                }
                conexion.Close();
                return ListaViajes;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// Viajes
        /// </summary>
        /// <param name="conn">conexcion de la base de datos</param>
        /// <returns>lista de los registros de viajes</returns>
        public async Task<List<VMviajes>> mViajesdescarga(int id_sede)
        {
            try
            {
                List<VMviajes> ListaViajes = new List<VMviajes>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_Q07]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMviajes objbal = new VMviajes();
                    objbal.id_camplacab = Convert.ToInt32(rdr["id_camplacab"]);
                    objbal.campla_orden = Convert.ToInt32(rdr["campla_orden"]);
                    objbal.placa = rdr["placa"].ToString();
                    objbal.Nro_Trans = rdr["Nro_Trans"].ToString();
                    objbal.Fec_gen = Convert.ToDateTime(rdr["Fec_gen"]);
                    objbal.campla_obse = rdr["campla_obse"].ToString();
                    ListaViajes.Add(objbal);
                }
                conexion.Close();
                return ListaViajes;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Viaje detalles
        /// </summary>
        /// <param name="conn">conexion de la base de datos</param>
        /// <param name="dplaca">placa del camion o transporte</param>
        /// <returns>devuelve los datos del viaje detalle y cabecera</returns>
        public async Task<List<VMViaje_Detalle>> mViajes_detalles(string dplaca, int id_camplacab, string tipcarg, int id_sede)
        {
            try
            {
                List<VMViaje_Detalle> ListaViadetalle = new List<VMViaje_Detalle>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_DETALLE_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PLACA", dplaca); 
                cmd.Parameters.AddWithValue("@PID_CAMCAB", id_camplacab);
                cmd.Parameters.AddWithValue("@PTIPCARG", tipcarg);
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMViaje_Detalle objbal = new VMViaje_Detalle();
                    objbal.id_vijcab = Convert.ToInt32(rdr["id_vijcab"]);
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.campla_nrotrans = rdr["campla_nrotrans"].ToString();
                    objbal.campla_peso = rdr["campla_peso"].ToString();
                    objbal.campla_volumen = rdr["campla_volumen"].ToString();
                    objbal.tiptran_desc = rdr["tiptran_desc"].ToString();
                    objbal.campla_obse = rdr["campla_obse"].ToString();
                    objbal.estcam_desc = rdr["estcam_desc"].ToString();
                    objbal.transp_desc = rdr["transp_desc"].ToString();
                    objbal.canales = rdr["canales"].ToString();
                    objbal.Estprepa = Convert.ToBoolean(rdr["Estprepa"]);
                    objbal.fecprepa = rdr["fecprepa"].ToString();
                    objbal.campla_fase = rdr["campla_fase"].ToString();
                    objbal.vijdet_fecini = rdr["vijdet_fecini"].ToString();
                    objbal.vijcab_fecpick = rdr["vijcab_fecpick"].ToString();
                    objbal.Estaprepcom = Convert.ToBoolean(rdr["Estaprepcom"]);
                    objbal.fecprepcom = rdr["fecprepcom"].ToString();
                    objbal.Estrecojo = Convert.ToBoolean(rdr["Estrecojo"]);
                    objbal.Fecinirecojo = rdr["Fecinirecojo"].ToString();
                    ListaViadetalle.Add(objbal);
                }
                conexion.Close();
                return ListaViadetalle;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Viaje detalles descarga
        /// </summary>
        /// <param name="conn">conexion de la base de datos</param>
        /// <param name="dplaca">placa del camion o transporte</param>
        /// <returns>devuelve los datos del viaje detalle y cabecera</returns>
        public async Task<List<VMViajeDetalle_descarga>> mViajes_detalles_descarga(string dplaca, int id_camplacab, string tipcarg, int id_sede)
        {
            try
            {
                List<VMViajeDetalle_descarga> ListaViadetalle = new List<VMViajeDetalle_descarga>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_DETALLE_Q10]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PLACA", dplaca);
                cmd.Parameters.AddWithValue("@PID_CAMCAB", id_camplacab);
                cmd.Parameters.AddWithValue("@PTIPCARG", tipcarg);
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMViajeDetalle_descarga objbal = new VMViajeDetalle_descarga();
                    objbal.id_vijcab = Convert.ToInt32(rdr["id_vijcab"]);
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.campla_nrotrans = rdr["campla_nrotrans"].ToString();
                    objbal.campla_peso = rdr["campla_peso"].ToString();
                    objbal.campla_volumen = rdr["campla_volumen"].ToString();
                    objbal.tiptran_desc = rdr["tiptran_desc"].ToString();
                    objbal.campla_obse = rdr["campla_obse"].ToString();
                    objbal.estcam_desc = rdr["estcam_desc"].ToString();
                    objbal.transp_desc = rdr["transp_desc"].ToString();
                    objbal.canales = rdr["canales"].ToString();
                    objbal.campla_fase = rdr["campla_fase"].ToString();
                    objbal.vijdet_fecini = rdr["vijdet_fecini"].ToString();
                    objbal.vijcab_fecpick = rdr["vijcab_fecpick"].ToString();
                    ListaViadetalle.Add(objbal);
                }
                conexion.Close();
                return ListaViadetalle;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Viaje detalles
        /// </summary>
        /// <param name="conn">conexion de la base de datos</param>
        /// <param name="dplaca">placa del camion o transporte</param>
        /// <returns>devuelve los datos del viaje detalle y cabecera</returns>
        public async Task<List<VMViaje_Detalle>> mViajes_detalles_ewm(string dplaca, int id_camplacab, string tipcarg, int id_sede)
        {
            try
            {
                List<VMViaje_Detalle> ListaViadetalle = new List<VMViaje_Detalle>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_DETALLE_Q08]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PLACA", dplaca);
                cmd.Parameters.AddWithValue("@PID_CAMCAB", id_camplacab);
                cmd.Parameters.AddWithValue("@PTIPCARG", tipcarg);
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMViaje_Detalle objbal = new VMViaje_Detalle();
                    objbal.id_vijcab = Convert.ToInt32(rdr["id_vijcab"]);
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.campla_nrotrans = rdr["campla_nrotrans"].ToString();
                    objbal.campla_peso = rdr["campla_peso"].ToString();
                    objbal.campla_obse = rdr["campla_obse"].ToString();
                    objbal.campla_fase = rdr["campla_fase"].ToString();
                    objbal.Estprepa = Convert.ToBoolean(rdr["Estprepa"]);
                    objbal.canales = rdr["canales"].ToString();
                    objbal.estcam_desc = rdr["estcam_desc"].ToString();
                    objbal.vijdet_fecfin_canal = rdr["vijdet_fecfin_canal"].ToString();
                    objbal.tiptran_desc = rdr["tiptran_desc"].ToString();
                    objbal.vijcab_horapropuesta = rdr["vijcab_horapropuesta"].ToString();
                    ListaViadetalle.Add(objbal);
                }
                conexion.Close();
                return ListaViadetalle;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Viaje detalles
        /// </summary>
        /// <param name="conn">conexion de la base de datos</param>
        /// <param name="dplaca">placa del camion o transporte</param>
        /// <returns>devuelve los datos del viaje detalle y cabecera</returns>
        public async Task<List<VMViaje_Detalle>> mViajes_detalles_sap(string dplaca, int id_camplacab, string tipcarg, int id_sede)
        {
            try
            {
                List<VMViaje_Detalle> ListaViadetalle = new List<VMViaje_Detalle>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_DETALLE_Q09]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PLACA", dplaca);
                cmd.Parameters.AddWithValue("@PID_CAMCAB", id_camplacab);
                cmd.Parameters.AddWithValue("@PTIPCARG", tipcarg);
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMViaje_Detalle objbal = new VMViaje_Detalle();
                    objbal.id_vijcab = Convert.ToInt32(rdr["id_vijcab"]);
                    objbal.transp_desc = rdr["transp_desc"].ToString();
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.campla_nrotrans = rdr["campla_nrotrans"].ToString();
                    objbal.campla_peso = rdr["campla_peso"].ToString();
                    objbal.campla_volumen = rdr["campla_volumen"].ToString();
                    objbal.vijdet_fecini = rdr["vijdet_fecini"].ToString();
                    objbal.vijcab_fecpick = rdr["vijcab_fecpick"].ToString();
                    objbal.Estrecojo = Convert.ToBoolean(rdr["Estrecojo"]);
                    objbal.Fecinirecojo = rdr["Fecinirecojo"].ToString();
                    objbal.tiptran_desc = rdr["tiptran_desc"].ToString();
                    objbal.campla_obse = rdr["campla_obse"].ToString();
                    objbal.estcam_desc = rdr["estcam_desc"].ToString();                    
                    objbal.canales = rdr["canales"].ToString();
                    objbal.campla_fase = rdr["campla_fase"].ToString();                                        
                    ListaViadetalle.Add(objbal);
                }
                conexion.Close();
                return ListaViadetalle;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        /// <summary>
        /// Transportes
        /// </summary>
        /// <param name="conn">Conexion de la base de datos</param>
        /// <param name="id">Codigo de la tabla viaje cabecera</param>
        /// <returns> lista de viajes detalles</returns>
        public async Task<List<VMviajes_Q1>> mTransportes(int id)
        {
            try
            {
                List<VMviajes_Q1> Listatrans = new List<VMviajes_Q1>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_DETALLE_Q02]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_VIACAB", id);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMviajes_Q1 objbal = new VMviajes_Q1();
                    objbal.id_vijdet = Convert.ToInt32(rdr["id_vijdet"]);
                    objbal.id_vijcab = Convert.ToInt32(rdr["id_vijcab"]);
                    objbal.id_estcam = Convert.ToInt32(rdr["id_estcam"]);
                    objbal.estcam_desc = rdr["estcam_desc"].ToString();
                    objbal.vijdet_fecini = rdr["vijdet_fecini"].ToString();
                    objbal.vijdet_est = Convert.ToBoolean(rdr["vijdet_est"]);
                    objbal.id_tiptran = Convert.ToInt32(rdr["id_tiptran"]);
                    Listatrans.Add(objbal);
                }
                conexion.Close();
                return Listatrans;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Datos Generales
        /// </summary>
        /// <param name="conn"> conexion a la base de datos</param>
        /// <param name="id"> id de viaje cabecera</param>
        /// <returns>Retorna los datos generales como chofer, placa, etc que hayan generado un nro de transporte</returns>
        public async Task<List<VMviajes_Q2>> mDatosGenerales(int id)
        {
            try
            {
                List<VMviajes_Q2> Listageneral = new List<VMviajes_Q2>();
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_DETALLE_Q03]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_VIACAB", id);
                    conexion.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        VMviajes_Q2 objbal = new VMviajes_Q2();
                        objbal.plac_desc = rdr["plac_desc"].ToString();
                        objbal.campla_nrotrans = rdr["campla_nrotrans"].ToString();
                        objbal.tiptran_desc = rdr["tiptran_desc"].ToString();
                        objbal.campla_peso = rdr["campla_peso"].ToString();
                        objbal.campla_volumen = rdr["campla_volumen"].ToString();
                        objbal.Chofer = rdr["Chofer"].ToString();
                        objbal.transp_desc = rdr["transp_desc"].ToString();
                        objbal.vijcab_pick = Convert.ToBoolean(rdr["vijcab_pick"]);
                        objbal.vijcab_fecpick = Convert.ToDateTime(rdr["vijcab_fecpick"]);
                        objbal.cua_desc = rdr["cua_desc"].ToString();
                        objbal.cua_libre = Convert.ToBoolean(rdr["cua_libre"]);
                        objbal.esta_desc = rdr["esta_desc"].ToString();
                        objbal.esta_libre = Convert.ToBoolean(rdr["esta_libre"]);
                        objbal.mue_desc = rdr["mue_desc"].ToString();
                        objbal.mue_libre = Convert.ToBoolean(rdr["mue_libre"]);
                        objbal.vijcab_insp = Convert.ToBoolean(rdr["vijcab_insp"]);
                        objbal.vijcab_fecinsp = Convert.ToDateTime(rdr["vijcab_fecinsp"]);
                        objbal.vijcab_ingunidad = Convert.ToBoolean(rdr["vijcab_ingunidad"]);
                        objbal.vijcab_fecunidad = Convert.ToDateTime(rdr["vijcab_fecunidad"]);
                        objbal.vijcab_horapropuesta = Convert.ToDateTime(rdr["vijcab_horapropuesta"]);
                        objbal.can_desc = rdr["can_desc"].ToString();
                        objbal.can_act = Convert.ToBoolean(rdr["can_act"]);
                        objbal.id_vijcab = Convert.ToInt32(rdr["id_vijcab"]);
                        Listageneral.Add(objbal);
                    }
                    conexion.Close();                
                return Listageneral;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Canales
        /// </summary>
        /// <param name="conn">conexion de la base de datos</param>
        /// <returns>Lista de canales</returns>
        public async Task<List<VMcanal>> mCanales (int id_sede)
        {
            try
            {
                List<VMcanal> Listacanal = new List<VMcanal>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_CANALES_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMcanal objbal = new VMcanal();
                    objbal.id_canal = Convert.ToInt32(rdr["id_canal"]);
                    objbal.can_cod = Convert.ToInt32(rdr["can_cod"]);
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.can_act = Convert.ToBoolean(rdr["can_act"]);
                    objbal.nro_trans = rdr["nro_trans"].ToString();
                    objbal.can_esta = rdr["can_esta"].ToString();
                    Listacanal.Add(objbal);
                }
                conexion.Close();
                return Listacanal;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Muelles
        /// </summary>
        /// <param name="conn">conexion de la base de datos</param>
        /// <returns>Lista de Muelles</returns>
        public async Task<List<VMmuelle>> mMuelles (int id_sede)
        {
            try
            {
                List<VMmuelle> Listamuelle = new List<VMmuelle>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_MUELLES_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMmuelle objbal = new VMmuelle();
                    objbal.id_muelle = Convert.ToInt32(rdr["id_muelle"]);
                    objbal.mue_cod = Convert.ToInt32(rdr["mue_cod"]);
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.mue_act = Convert.ToBoolean(rdr["mue_act"]);
                    Listamuelle.Add(objbal);
                }
                conexion.Close();               
                return Listamuelle;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Cuadrillas
        /// </summary>
        /// <param name="conn">Conexion a la base de datos</param>
        /// <returns>Lista de cuadrillas</returns>

        public async Task<List<VMcuadrilla>> mCuadrillas(int id_sede)
        {
            try
            {
                List<VMcuadrilla> Listacuadrilla = new List<VMcuadrilla>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_CUADRILLA_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMcuadrilla objbal = new VMcuadrilla();
                    objbal.cua_desc = rdr["cua_desc"].ToString();
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.cua_act = Convert.ToBoolean(rdr["cua_act"]);
                    Listacuadrilla.Add(objbal);
                }
                conexion.Close();
                return Listacuadrilla;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<VMestacionamiento>> mEstacionamientos(int id_sede)
        {
            try
            {
                List<VMestacionamiento> Listaestacio = new List<VMestacionamiento>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_ESTACIONAMIENTO_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMestacionamiento objbal = new VMestacionamiento();
                    objbal.id_estacionamiento = Convert.ToInt32(rdr["id_estacionamiento"]);
                    objbal.esta_cod = Convert.ToInt32(rdr["esta_cod"]);
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.esta_act = Convert.ToBoolean(rdr["esta_act"]);
                    objbal.esta_obs = rdr["esta_obs"].ToString();
                    Listaestacio.Add(objbal);
                }
                conexion.Close();
                return Listaestacio;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<VMAnexos>> mAnexos(int id_sede)
        {
            try
            {
                List<VMAnexos> Listanex = new List<VMAnexos>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_ANEXO_Q02]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMAnexos objbal = new VMAnexos();
                    objbal.id_anexo = Convert.ToInt32(rdr["id_anexo"]);
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.anex_act = Convert.ToBoolean(rdr["anex_act"]);
                    Listanex.Add(objbal);
                }
                conexion.Close();
                return Listanex;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Generar Viaje
        /// </summary>
        /// <param name="conn">Conexion a la base de datos</param>
        /// <param name="dcampla_nrotrans">Numero de transporte</param>
        /// <returns>Genera los viajes de la cabecera y el detalle </returns>
        public async Task mGenerarViaje (string dcampla_nrotrans, DateTime fecha, int id_sede)
        {
            try
            {               
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_I01]", conexion);               
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NRO_TRANS", dcampla_nrotrans);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                    
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task mEstadoViaje(int viadet, int viacab, int viaest, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_DETALLE_U01]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_VIACAB", viacab);
                    cmd.Parameters.AddWithValue("@ID_VIADET", viadet);
                    cmd.Parameters.AddWithValue("@ID_ESTCAM", viaest);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task mLiberarCanal(int viacab, int vijdet, DateTime Fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_CANALES_U02]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PICAB", viacab);
                    cmd.Parameters.AddWithValue("@PIDET", vijdet);
                    cmd.Parameters.AddWithValue("@FECHA", Fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task mLiberarCuadrilla(int viacab, int vijdet, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_CUADRILLAS_U02]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PICAB", viacab);
                    cmd.Parameters.AddWithValue("@PIDET", vijdet);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task mLiberarmonta(int viacab, int vijdet, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_MONTACARGA_U03]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PICAB", viacab);
                    cmd.Parameters.AddWithValue("@PIDET", vijdet);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task mLiberarTotal(int viacab, int vijdet, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_U05]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PICAB", viacab);
                    cmd.Parameters.AddWithValue("@PIDET", vijdet);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task mLiberarTotald(int viacab, int vijdet, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_U06]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PICAB", viacab);
                    cmd.Parameters.AddWithValue("@PIDET", vijdet);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mBuscab(int placa, DateTime fecha)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_CAMIONES_PLANIFICADOS_Q02]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IPLACA", placa);
                cmd.Parameters.AddWithValue("@FECHA", fecha);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["NRO_VIAJE"]);                       
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mBuscaViaje(int placa, DateTime fecha)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_CAMIONES_PLANIFICADOS_Q04]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IPLACA", placa);
                cmd.Parameters.AddWithValue("@FECHA", fecha);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["NRO_VIAJE"]);
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mBuscaplac(string placa)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SP_PLACA_Q02]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PLACA", placa);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["ID_PLACA"]);
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// mUpdateViaje
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="indCab"></param>
        /// <returns></returns>
        public async Task mUpdateViaje(int indCab)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_CAMIONES_PLANIFICADOS_U01]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IND_CAB", indCab);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// mUpdateViaje
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="indCab"></param>
        /// <returns></returns>
        public async Task mUpdateViajedesc(int id_campla, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_CAMIONES_PLANIFICADOS_U02]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IND_PLANI", id_campla);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// mCheckCanales
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public async Task<List<MDCanal>> mCheckCanales(int id_sede)
        {
            try
            {
                List<MDCanal> Listacanal = new List<MDCanal>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_CANALES_Q02]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    MDCanal objbal = new MDCanal();
                    objbal.id_canal = Convert.ToInt32(rdr["id_canal"]);
                    objbal.can_desc = rdr["can_desc"].ToString();
                    objbal.can_plac = rdr["can_plac"].ToString();
                    objbal.can_act = Convert.ToBoolean(rdr["can_act"]);
                    Listacanal.Add(objbal);
                }
                conexion.Close();                
                return Listacanal;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mUpdatecanal(int id_canal, string placa, string nro_trans, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_CANALES_U01]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    cmd.Parameters.AddWithValue("@PLACA", placa);
                    cmd.Parameters.AddWithValue("@PID_CANAL", id_canal);
                    cmd.Parameters.AddWithValue("@PNRO_TRANS", nro_trans);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// mCheckCanales
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public async Task<List<MDCuadrilla>> mCheckCuadrilla(int id_sede)
        {
            try
            {
                List<MDCuadrilla> Listacuad = new List<MDCuadrilla>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_CUADRILLA_Q02]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    MDCuadrilla objbal = new MDCuadrilla();
                    objbal.id_cuadrilla = Convert.ToInt32(rdr["id_cuadrilla"]);
                    objbal.cua_desc = rdr["cua_desc"].ToString();
                    objbal.cua_plac = rdr["cua_plac"].ToString();
                    objbal.cua_act = Convert.ToBoolean(rdr["cua_act"]);
                    Listacuad.Add(objbal);
                }
                conexion.Close();                
                return Listacuad;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mUpdatecuadrilla(int id_cuadrilla, string placa, string nro_trans, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_CUADRILLAS_U01]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PLACA", placa);
                    cmd.Parameters.AddWithValue("@PID_CUADRILLA", id_cuadrilla);
                    cmd.Parameters.AddWithValue("@PNRO_TRANS", nro_trans);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mUpdatesincuadrilla(string placa, string nro_trans, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_CUADRILLAS_U03]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PLACA", placa);
                    cmd.Parameters.AddWithValue("@PNRO_TRANS", nro_trans);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// mCheckCanales
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public async Task<List<MDEstacionamiento>> mCheckEstacionamiento(int id_sede)
        {
            try
            {
                List<MDEstacionamiento> Listaestac = new List<MDEstacionamiento>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_ESTACIONAMIENTO_Q02]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    MDEstacionamiento objbal = new MDEstacionamiento();
                    objbal.id_estacionamiento = Convert.ToInt32(rdr["id_estacionamiento"]);
                    objbal.esta_desc = rdr["esta_desc"].ToString();
                    objbal.esta_plac = rdr["esta_plac"].ToString();
                    objbal.esta_act = Convert.ToBoolean(rdr["esta_act"]);
                    Listaestac.Add(objbal);
                }
                conexion.Close();                
                return Listaestac;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// mCheckCanales
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public async Task<List<MDAnexos>> mCheckAnexos(int id_sede)
        {
            try
            {
                List<MDAnexos> Listanex = new List<MDAnexos>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_ANEXO_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    MDAnexos objbal = new MDAnexos();
                    objbal.id_anexo = Convert.ToInt32(rdr["id_anexo"]);
                    objbal.anex_desc = rdr["anex_desc"].ToString();
                    objbal.esta_plac = rdr["esta_plac"].ToString();
                    objbal.anex_act = Convert.ToBoolean(rdr["anex_act"]);
                    Listanex.Add(objbal);
                }
                conexion.Close();                
                return Listanex;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mUpdateEstacionamiento(int id_estacionamiento, string placa, string nro_trans, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_ESTACIONAMIENTO_U01]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PLACA", placa);
                    cmd.Parameters.AddWithValue("@PID_ESTACIO", id_estacionamiento);
                    cmd.Parameters.AddWithValue("@PNRO_TRANS", nro_trans);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mUpdateEstacionseguridad(int id_estacionamiento, int id_vijcab, string placa, string nro_trans, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_ESTACIONAMIENTO_U02]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PLACA", placa);
                    cmd.Parameters.AddWithValue("@PID_ESTACIO", id_estacionamiento);
                    cmd.Parameters.AddWithValue("@PNRO_TRANS", nro_trans);
                    cmd.Parameters.AddWithValue("@ID_VIJCAB", id_vijcab);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mUpdateAnexoSeguridad(int id_anexo, int id_vijcab, string placa, string nro_trans, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_ANEXO_U01]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PLACA", placa);
                    cmd.Parameters.AddWithValue("@PID_ANEXO", id_anexo);
                    cmd.Parameters.AddWithValue("@PNRO_TRANS", nro_trans);
                    cmd.Parameters.AddWithValue("@ID_VIJCAB", id_vijcab);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// mCheckCanales
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public async Task<List<MDMuelle>> mCheckMuelle(int id_sede)
        {
            try
            {
                List<MDMuelle> Listamuelle = new List<MDMuelle>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_MUELLE_Q02]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    MDMuelle objbal = new MDMuelle();
                    objbal.id_muelle = Convert.ToInt32(rdr["id_muelle"]);
                    objbal.mue_desc = rdr["mue_desc"].ToString();
                    objbal.mue_plac = rdr["mue_plac"].ToString();
                    objbal.mue_act = Convert.ToBoolean(rdr["mue_act"]);
                    Listamuelle.Add(objbal);
                }
                conexion.Close();
                return Listamuelle;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mUpdateMuelle(int id_muelle, string placa, string nro_trans, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_MUELLE_U01]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PLACA", placa);
                    cmd.Parameters.AddWithValue("@PID_MUELLE", id_muelle);
                    cmd.Parameters.AddWithValue("@PNRO_TRANS", nro_trans);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// mCheckCanales
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public async Task<List<MDMontacargas>> mCheckMontacarga(int id_sede)
        {
            try
            {
                List<MDMontacargas> Listacuad = new List<MDMontacargas>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_MONTACARGA_Q02]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    MDMontacargas objbal = new MDMontacargas();
                    objbal.id_monta = Convert.ToInt32(rdr["id_monta"]);
                    objbal.monta_desc = rdr["monta_desc"].ToString();
                    objbal.monta_plac = rdr["monta_plac"].ToString();
                    objbal.monta_act = Convert.ToBoolean(rdr["monta_act"]);
                    Listacuad.Add(objbal);
                }
                conexion.Close();                
                return Listacuad;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mUpdatemontacarga(int id_cuadrilla, string placa, string nro_trans, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_MONTACARGAS_U02]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PLACA", placa);
                    cmd.Parameters.AddWithValue("@PID_MONTA", id_cuadrilla);
                    cmd.Parameters.AddWithValue("@PNRO_TRANS", nro_trans);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mUpdatesinmontacarga(string placa, string nro_trans, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_MONTACARGAS_U01]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PLACA", placa);
                    cmd.Parameters.AddWithValue("@PNRO_TRANS", nro_trans);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// mCheckCanales
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public async Task<List<MDMuelle>> mCheckinspec(string placa)
        {
            try
            {
                List<MDMuelle> Listamuelle = new List<MDMuelle>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_MUELLE_Q04]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PLACA", placa);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    MDMuelle objbal = new MDMuelle();
                    objbal.id_muelle = Convert.ToInt32(rdr["id_muelle"]);
                    objbal.mue_desc = rdr["mue_desc"].ToString();
                    objbal.mue_act = Convert.ToBoolean(rdr["mue_act"]);
                    Listamuelle.Add(objbal);
                }
                conexion.Close();                
                return Listamuelle;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mUpdateInspec(int id_muelle, int id_vijcab, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_MUELLE_U03]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PID_MUELLE", id_muelle);
                    cmd.Parameters.AddWithValue("@ID_VIJCAB", id_vijcab);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mUpdatePicking(int mid_vijcab, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_U01]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_VIACAB", mid_vijcab);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mUpdateFacturacion(int mid_vijcab, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_U10]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_VIACAB", mid_vijcab);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mUpdatefase(int mid_vijcab, string id_fase)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_U08]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_VIACAB", mid_vijcab);
                    cmd.Parameters.AddWithValue("@P_FASE", id_fase);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mUpdateingunidad(int mid_vijcab, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_U04]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_VIACAB", mid_vijcab);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mUpdatefecalma(int mid_vijcab, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_U09]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_VIACAB", mid_vijcab);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        /// 
        public async Task<List<VMcanal>> mBloqCanal(int id_sede)
        {
            try
            {
                List<VMcanal> Listacanal = new List<VMcanal>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_CANALES_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMcanal objbal = new VMcanal();
                    objbal.id_canal = Convert.ToInt32(rdr["id_canal"]);
                    objbal.can_cod = Convert.ToInt32(rdr["can_cod"]);
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.nro_trans = rdr["nro_trans"].ToString();
                    objbal.can_act = Convert.ToBoolean(rdr["can_act"]);
                    Listacanal.Add(objbal);
                }
                conexion.Close();                
                return Listacanal;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Muelles
        /// </summary>
        /// <param name="conn">conexion de la base de datos</param>
        /// <returns>Lista de Muelles</returns>
        public async Task<List<VMmuelle>> mBloqmuelles(int id_sede)
        {
            try
            {
                List<VMmuelle> Listamuelle = new List<VMmuelle>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_MUELLES_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMmuelle objbal = new VMmuelle();
                    objbal.id_muelle = Convert.ToInt32(rdr["id_muelle"]);
                    objbal.mue_cod = Convert.ToInt32(rdr["mue_cod"]);
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.nro_trans = rdr["nro_trans"].ToString();
                    objbal.mue_act = Convert.ToBoolean(rdr["mue_act"]);
                    Listamuelle.Add(objbal);
                }
                conexion.Close();                
                return Listamuelle;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<VMcuadrilla>> mBloqcuadrillas(int id_sede)
        {
            try
            {
                List<VMcuadrilla> Listacuadrilla = new List<VMcuadrilla>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_CUADRILLA_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMcuadrilla objbal = new VMcuadrilla();
                    objbal.id_cuadrilla = Convert.ToInt32(rdr["id_cuadrilla"]);
                    objbal.cua_desc = rdr["cua_desc"].ToString();
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.nro_trans = rdr["nro_trans"].ToString();
                    objbal.cua_act = Convert.ToBoolean(rdr["cua_act"]);
                    Listacuadrilla.Add(objbal);
                }
                conexion.Close();                
                return Listacuadrilla;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<VMestacionamiento>> mBloqestacionamientos(int id_sede)
        {
            try
            {
                List<VMestacionamiento> Listaestacio = new List<VMestacionamiento>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_ESTACIONAMIENTO_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMestacionamiento objbal = new VMestacionamiento();
                    objbal.id_estacionamiento = Convert.ToInt32(rdr["id_estacionamiento"]);
                    objbal.esta_cod = Convert.ToInt32(rdr["esta_cod"]);
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.nro_trans = rdr["nro_trans"].ToString();
                    objbal.esta_act = Convert.ToBoolean(rdr["esta_act"]);
                    Listaestacio.Add(objbal);
                }
                conexion.Close();                
                return Listaestacio;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mvalcanal(int mid_vijcab)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_CANALES_Q03]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_VIJCAB", mid_vijcab);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["CANAL"]);
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mvalfase(int mid_vijcab)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_FASE_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_VIJCAB", mid_vijcab);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["FASE"]);
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mvalanexo(int mid_vijcab)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_ANEXO_Q03]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_VIJCAB", mid_vijcab);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["ANEXO"]);
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mvalcuad(int mid_vijcab)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_CUADRILLA_Q03]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_VIJCAB", mid_vijcab);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["CUAD"]);
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mvalmonta(int mid_vijcab)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_MONTACARGA_Q03]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_VIJCAB", mid_vijcab);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["MONT"]);
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mvalmuelle(int mid_vijcab)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_MUELLE_Q03]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_VIJCAB", mid_vijcab);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["MUEL"]);
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mvalinspsani(int mid_vijcab)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_Q04]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_VIJCAB", mid_vijcab);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["ING_INS"]);
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mvalinguni(int mid_vijcab)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_Q02]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_VIJCAB", mid_vijcab);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["ING_UNI"]);
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mvalingpick(int mid_vijcab)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_Q03]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_VIJCAB", mid_vijcab);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["ING_PICK"]);
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Datos Generales
        /// </summary>
        /// <param name="conn"> conexion a la base de datos</param>
        /// <param name="id"> id de viaje cabecera</param>
        /// <returns>Retorna los datos generales como chofer, placa, etc que hayan generado un nro de transporte</returns>
        public async Task<List<VMSeguridad>> mSeguridad(int id_sede)
        {
            try
            {
                List<VMSeguridad> Listaseguridad = new List<VMSeguridad>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_Q06]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMSeguridad objbal = new VMSeguridad();
                    objbal.id_vijcab = Convert.ToInt32(rdr["id_vijcab"]);
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.campla_nrotrans = rdr["campla_nrotrans"].ToString();
                    objbal.campla_obse = rdr["campla_obse"].ToString();
                    objbal.vijcab_ingunidad = Convert.ToBoolean(rdr["vijcab_ingunidad"]);
                    objbal.vijcab_llegada = Convert.ToBoolean(rdr["vijcab_llegada"]);
                    Listaseguridad.Add(objbal);
                }
                conexion.Close();                
                return Listaseguridad;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Datos Generales
        /// </summary>
        /// <param name="conn"> conexion a la base de datos</param>
        /// <param name="id"> id de viaje cabecera</param>
        /// <returns>Retorna los datos generales como chofer, placa, etc que hayan generado un nro de transporte</returns>
        public async Task<List<VMSeguridad>> mSeguridadsalida(int id_sede)
        {
            try
            {
                List<VMSeguridad> Listaseguridad = new List<VMSeguridad>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_Q10]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMSeguridad objbal = new VMSeguridad();
                    objbal.id_vijcab = Convert.ToInt32(rdr["id_vijcab"]);
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.campla_nrotrans = rdr["campla_nrotrans"].ToString();
                    objbal.campla_obse = rdr["campla_obse"].ToString();
                    objbal.vijcab_ingunidad = Convert.ToBoolean(rdr["vijcab_ingunidad"]);
                    objbal.vijcab_llegada = Convert.ToBoolean(rdr["vijcab_llegada"]);
                    Listaseguridad.Add(objbal);
                }
                conexion.Close();                
                return Listaseguridad;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Datos Generales
        /// </summary>
        /// <param name="conn"> conexion a la base de datos</param>
        /// <param name="id"> id de viaje cabecera</param>
        /// <returns>Retorna los datos generales como chofer, placa, etc que hayan generado un nro de transporte</returns>
        public async Task mUpdateseg(int mid_vijcab, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_U02]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_PLACAB", mid_vijcab);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Datos Generales
        /// </summary>
        /// <param name="conn"> conexion a la base de datos</param>
        /// <param name="id"> id de viaje cabecera</param>
        /// <returns>Retorna los datos generales como chofer, placa, etc que hayan generado un nro de transporte</returns>
        public async Task mUpdatesalida(int mid_vijcab, DateTime fecha, int id_sede)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_U07]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_PLACAB", mid_vijcab);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Datos Generales
        /// </summary>
        /// <param name="conn"> conexion a la base de datos</param>
        /// <param name="id"> id de viaje cabecera</param>
        /// <returns>Retorna los datos generales como chofer, placa, etc que hayan generado un nro de transporte</returns>
        public async Task mUpdatellegada(int mid_vijcab, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_U03]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_PLACAB", mid_vijcab);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mIndcarga(int mid_vijcab)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_Q08]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VIJCAB", mid_vijcab);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["IND_CARGA"]);
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mInddescarga(int mid_vijcab)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_Q08]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VIJCAB", mid_vijcab);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["IND_CARGA"]);
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mIndestado (int mid_vijcab, int mid_estcam)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_DETALLE_Q04]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_VIACAB", mid_vijcab);
                cmd.Parameters.AddWithValue("@ID_ESTCAM", mid_estcam);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["IND_EST"]);
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mIndtip(int mid_vijcab)
        {
            int ind = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_DETALLE_Q05]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_VIACAB", mid_vijcab);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    ind = Convert.ToInt32(rdr["IND_TIPOPE"]);
                }
                conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Datos Generales
        /// </summary>
        /// <param name="conn"> conexion a la base de datos</param>
        /// <param name="id"> id de viaje cabecera</param>
        /// <returns>Retorna los datos generales como chofer, placa, etc que hayan generado un nro de transporte</returns>
        public async Task mUpdateBloqueos(int id, string tipest, string obser, DateTime fecha)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_BLOQUEOS_I01]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PI_bloq_id", id);
                    cmd.Parameters.AddWithValue("@PI_bloq_tipo", tipest);
                    cmd.Parameters.AddWithValue("@PI_bloq_obs", obser);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Datos Generales
        /// </summary>
        /// <param name="conn"> conexion a la base de datos</param>
        /// <param name="id"> id de viaje cabecera</param>
        /// <returns>Retorna los datos generales como chofer, placa, etc que hayan generado un nro de transporte</returns>
        public async Task mUpdatePlanificacion(int id, int placa, string campla_nrotrans, string campla_peso, string campla_volumen, string campla_obse)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_CAMIONES_PLANIFICADOS_U03]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IND_PLANI", id);
                    cmd.Parameters.AddWithValue("@ID_PLACA", placa);
                    cmd.Parameters.AddWithValue("@NROPLA", campla_nrotrans);
                    cmd.Parameters.AddWithValue("@PESO", campla_peso);
                    cmd.Parameters.AddWithValue("@VOLUMEN", campla_volumen);
                    cmd.Parameters.AddWithValue("@OBSER", campla_obse);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Estados Viaje
        /// </summary>
        /// <param name="conn">conexion de base de datos</param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<int> mIndtrans(string nrotrans)
        {
            int ind = 0;
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_CAMIONES_PLANIFICADOS_Q05]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NROTRANS", nrotrans);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        ind = Convert.ToInt32(rdr["@INDNRO"]);
                    }
                    conexion.Close();                
                return ind;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// mCheckCanales
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public async Task<List<MDCanal>> mCheckCanalesocupados(int id_sede)
        {
            try
            {
                List<MDCanal> Listacanal = new List<MDCanal>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_CANALES_Q04]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    MDCanal objbal = new MDCanal();
                    objbal.id_canal = Convert.ToInt32(rdr["id_canal"]);
                    objbal.can_desc = rdr["can_desc"].ToString();
                    objbal.can_plac = rdr["can_plac"].ToString();
                    objbal.can_act = Convert.ToBoolean(rdr["can_act"]);
                    Listacanal.Add(objbal);
                }
                conexion.Close();                
                return Listacanal;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        public async Task mLiberarcanaldes(int id_canal)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_CANALES_U03]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;                   
                    cmd.Parameters.AddWithValue("@PID_CANAL", id_canal);
                    await conexion.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conexion.Close();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Transportes
        /// </summary>
        /// <param name="conn">Conexion de la base de datos</param>
        /// <param name="id">Codigo de la tabla viaje cabecera</param>
        /// <returns> lista de viajes detalles</returns>
        public List<VMAlibot> mWhatsapauto(string value)
        {            
            try
            {
                List<VMAlibot> Alibot = new List<VMAlibot>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_DETALLE_Q07]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_VALUE", value);
                conexion.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    VMAlibot objbal = new VMAlibot();
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.campla_nrotrans = rdr["campla_nrotrans"].ToString();
                    objbal.viaj_canales = rdr["viaj_canales"].ToString();
                    objbal.estado = rdr["estado"].ToString();
                    objbal.transp_desc = rdr["transp_desc"].ToString();
                    objbal.vijcab_horapropuesta = rdr["vijcab_horapropuesta"].ToString();
                    Alibot.Add(objbal);
                }
                conexion.Close();
                return Alibot;               

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// mCheckCanales
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public async Task<List<VMCuadro>> mCuadro(int id_sede)
        {
            try
            {
                List<VMCuadro> Listacuadro = new List<VMCuadro>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_Q11]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SEDE", id_sede);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMCuadro objbal = new VMCuadro();
                    objbal.id_estcam = Convert.ToInt32(rdr["id_estcam"]);
                    objbal.cuad_concep = rdr["cuad_concep"].ToString();
                    objbal.cuad_cant = Convert.ToInt32(rdr["cuad_cant"]);
                    Listacuadro.Add(objbal);
                }
                conexion.Close();
                return Listacuadro;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// mCheckCanales
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public async Task<List<VMCuadro_Detalle>> mCuadroDetalle(int id_estcam)
        {
            try
            {
                List<VMCuadro_Detalle> Listacuaddet = new List<VMCuadro_Detalle>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_VIAJE_CABECERA_Q12]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ESTCAM", id_estcam);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMCuadro_Detalle objbal = new VMCuadro_Detalle();
                    objbal.transp_desc =rdr["transp_desc"].ToString();
                    objbal.campla_nrotrans = rdr["campla_nrotrans"].ToString();
                    objbal.plac_desc = rdr["plac_desc"].ToString();
                    objbal.campla_peso = rdr["campla_peso"].ToString();
                    objbal.campla_volumen = rdr["campla_volumen"].ToString();
                    objbal.canal = rdr["canal"].ToString();
                    objbal.tiptran_desc = rdr["tiptran_desc"].ToString();
                    objbal.campla_obse = rdr["campla_obse"].ToString();
                    Listacuaddet.Add(objbal);
                }
                conexion.Close();
                return Listacuaddet;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="id_canal"></param>
        /// <param name="placa"></param>
        /// <returns></returns>
        //public async Task mRegistraralibot(string message, string app, string sender)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[DBO].[SP_CANALES_U03]", conexion);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@PID_CANAL", id_canal);
        //        cmd.Parameters.AddWithValue("@PID_CANAL", id_canal);
        //        cmd.Parameters.AddWithValue("@PID_CANAL", id_canal);
        //        await conexion.OpenAsync();
        //        await cmd.ExecuteNonQueryAsync();
        //        conexion.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

    }
}
