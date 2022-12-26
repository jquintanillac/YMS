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
    public class SP_Administracion
    {
        public SqlConnection conexion;

        public SP_Administracion()
        {
            var config = GetConfiguration();
            conexion = new SqlConnection(config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);            
        }
        /// <summary>
        /// GetConfiguration
        /// </summary>
        /// <returns></returns>
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public async Task<List<VMRol_Usuario>> mRol_Usuarios()
        {
            try
            {
                List<VMRol_Usuario> ListaRolUser = new List<VMRol_Usuario>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_USUARIO_ROL_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMRol_Usuario objbal = new VMRol_Usuario();
                    objbal.Idrol_usua = rdr["Idrol_usua"].ToString();
                    objbal.Usuario = rdr["Usuario"].ToString();
                    objbal.Nombre_Completo = rdr["Nombre_Completo"].ToString();
                    objbal.Rol = rdr["Rol"].ToString();                        
                    ListaRolUser.Add(objbal);
                }
                conexion.Close();                
                return ListaRolUser;

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
        public async Task<List<VMRolUsarios>> mRolUsuarios()
        {
            try
            {
                List<VMRolUsarios> ListaRolUser = new List<VMRolUsarios>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_USUARIO_ROL_Q02]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMRolUsarios objbal = new VMRolUsarios();
                    objbal.Idrol_usua = rdr["Idrol_usua"].ToString();
                    objbal.Usuario = rdr["Usuario"].ToString();
                    objbal.Nombre_Completo = rdr["Nombre_Completo"].ToString();
                    objbal.Rol = rdr["Rol"].ToString();
                    objbal.Usua_pass = rdr["Usua_pass"].ToString();
                    objbal.Usua_Hash = rdr["Usua_Hash"].ToString();
                    objbal.Usua_email = rdr["Usua_email"].ToString();
                    ListaRolUser.Add(objbal);
                }
                conexion.Close();                
                return ListaRolUser;

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
        public async Task mUpdateUsuario(int IdUsuario, string Usua_user, string Usua_nombres, string Usua_apellidos, string Usua_email, string Usua_pass, string Usua_Hash,  bool Usua_act)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("[DBO].[SP_USUARIO_U01]", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.Parameters.AddWithValue("@Usua_user", Usua_user);
                    cmd.Parameters.AddWithValue("@Usua_nombres", Usua_nombres);
                    cmd.Parameters.AddWithValue("@Usua_apellidos", Usua_apellidos);
                    cmd.Parameters.AddWithValue("@Usua_email", Usua_email);
                    cmd.Parameters.AddWithValue("@Usua_pass", Usua_pass);
                    cmd.Parameters.AddWithValue("@Usua_Hash", Usua_Hash);
                    cmd.Parameters.AddWithValue("@Usua_act", Usua_act);
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
        public async Task<List<VMRol_permisos>> mRolpermadmin(int idrol)
        {
            try
            {
                List<VMRol_permisos> ListaRolUser = new List<VMRol_permisos>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_ADMINISTRACION_Q01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ROL", idrol);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMRol_permisos objbal = new VMRol_permisos();
                    objbal.id_rolperm = Convert.ToInt32(rdr["Id_rolperm"]);
                    objbal.submenu_desc = rdr["submenu_desc"].ToString();
                    objbal.rolperm_act = Convert.ToBoolean(rdr["rolperm_act"]);
                    ListaRolUser.Add(objbal);
                }
                conexion.Close();
                return ListaRolUser;

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
        public async Task<List<VMRol_permisos>> mRolpermoper(int idrol)
        {
            try
            {
                List<VMRol_permisos> ListaRolUser = new List<VMRol_permisos>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_ADMINISTRACION_Q02]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ROL", idrol);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMRol_permisos objbal = new VMRol_permisos();
                    objbal.id_rolperm = Convert.ToInt32(rdr["Id_rolperm"]);
                    objbal.submenu_desc = rdr["submenu_desc"].ToString();
                    objbal.rolperm_act = Convert.ToBoolean(rdr["rolperm_act"]);
                    ListaRolUser.Add(objbal);
                }
                conexion.Close();
                return ListaRolUser;

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
        public async Task<List<VMRol_permisos>> mRolpermprog(int idrol)
        {
            try
            {
                List<VMRol_permisos> ListaRolUser = new List<VMRol_permisos>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_ADMINISTRACION_Q03]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ROL", idrol);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMRol_permisos objbal = new VMRol_permisos();
                    objbal.id_rolperm = Convert.ToInt32(rdr["Id_rolperm"]);
                    objbal.submenu_desc = rdr["submenu_desc"].ToString();
                    objbal.rolperm_act = Convert.ToBoolean(rdr["rolperm_act"]);
                    ListaRolUser.Add(objbal);
                }
                conexion.Close();
                return ListaRolUser;

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
        public async Task<List<VMRol_permisos>> mRolpermsegu(int idrol)
        {
            try
            {
                List<VMRol_permisos> ListaRolUser = new List<VMRol_permisos>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_ADMINISTRACION_Q04]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ROL", idrol);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMRol_permisos objbal = new VMRol_permisos();
                    objbal.id_rolperm = Convert.ToInt32(rdr["Id_rolperm"]);
                    objbal.submenu_desc = rdr["submenu_desc"].ToString();
                    objbal.rolperm_act = Convert.ToBoolean(rdr["rolperm_act"]);
                    ListaRolUser.Add(objbal);
                }
                conexion.Close();
                return ListaRolUser;

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
        public async Task<List<VMRol_permisos>> mRolpermrepor(int idrol)
        {
            try
            {
                List<VMRol_permisos> ListaRolUser = new List<VMRol_permisos>();
                SqlCommand cmd = new SqlCommand("[DBO].[SP_ADMINISTRACION_Q05]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ROL", idrol);
                conexion.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    VMRol_permisos objbal = new VMRol_permisos();
                    objbal.id_rolperm = Convert.ToInt32(rdr["Id_rolperm"]);
                    objbal.submenu_desc = rdr["submenu_desc"].ToString();
                    objbal.rolperm_act = Convert.ToBoolean(rdr["rolperm_act"]);
                    ListaRolUser.Add(objbal);
                }
                conexion.Close();
                return ListaRolUser;

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
        public async Task mUpdatemenu(int idrol_perm)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_ADMINISTRACION_U01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ROLPERM", idrol_perm);  
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
        public async Task mInsrolpermiso(int idrol_perm)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_ADMINISTRACION_I01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ROL", idrol_perm);
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
        public async Task mDelrolpermiso(int idrol_perm)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_ADMINISTRACION_D01]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_ROL", idrol_perm);
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
        /// <param name="idUsua"></param>
        /// <param name="Pass"></param>
        /// <param name="Hass"></param>
        /// <returns></returns>
        public async Task mUpdatecontrasena(int idUsua, string Usua_pass1, string Usua_Hash1)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[DBO].[SP_ADMINISTRACION_U02]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsua", idUsua);
                cmd.Parameters.AddWithValue("@Usua_pass1", Usua_pass1);
                cmd.Parameters.AddWithValue("@Usua_Hash1", Usua_Hash1);
                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
