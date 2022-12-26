using DNTCaptcha.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YMSweb.Data;
using YMSweb.Data.DataSql;
using YMSweb.Data.Entities;
using YMSweb.Helpers;
using YMSweb.Models;
using YMSweb.Models.ViewModels;

namespace YMS.web.Controllers
{
    public class HomeController : Controller
    {
        DataContext _ctx;
        SP_Administracion _administracion;
        public string sede = "";
        private readonly ILogger<HomeController> _logger;
        private readonly IDNTCaptchaValidatorService _validatorServices;
        private readonly DNTCaptchaOptions _catchaOptions;
        public HomeController(ILogger<HomeController> logger, DataContext ctx, IDNTCaptchaValidatorService validatorServices, IOptions<DNTCaptchaOptions> catchaOptions)
        {
            _logger = logger;
            _ctx = ctx;
            _administracion = new SP_Administracion();
            _validatorServices = validatorServices;
            _catchaOptions = catchaOptions == null ? throw new ArgumentNullException(nameof(catchaOptions)) : catchaOptions.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sedes()
        {
            return View();
        }
        public IActionResult recuperar()
        {
            return View();
        }

        public async Task<IActionResult> restablecer(string Usua_user, string Usua_pass, string Usua_pass_nuevo)
        {
            try
            {                
                var usuario = await _ctx.Usuarios.Where(x => x.Usua_user == Usua_user).SingleOrDefaultAsync();
                if (usuario == null)
                {
                    TempData["error"] = "El usuario no existe.";
                    return RedirectToAction("recuperar", "Home");
                }
                else if (HashHelper.CheckHash(Usua_pass, usuario.Usua_pass, usuario.Usua_Hash))
                {
                    var hash = HashHelper.Hash(Usua_pass_nuevo);
                    var Usua_pass1 = hash.Password;
                    var Usua_Hash1 = hash.Salt;
                    await _administracion.mUpdatecontrasena(usuario.IdUsuario, Usua_pass1, Usua_Hash1);
                    TempData["success"] = "Se reestablecio la contrasena.";
                }
                else
                {
                    TempData["error"] = "Contrasena anterior incorrecta.";
                    return RedirectToAction("recuperar", "Home");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return RedirectToAction("recuperar", "Home");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [BindProperty]
        public MDUsuario Usuario { get; set; }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login()
        {
            if (!_validatorServices.HasRequestValidCaptchaEntry(Language.English, DisplayMode.ShowDigits))
            {
                this.ModelState.AddModelError(_catchaOptions.CaptchaComponent.CaptchaInputName, "Por favor ingrese el codigo de seguridad.");
                TempData["error"] = "Por favor ingrese el codigo de seguridad.";
                return RedirectToAction("Index", "Home");
            }


            //declaracion de menu y submenu para acceder
            string menu1 = "N";
            string menu2 = "N";
            string menu3 = "N";
            string menu4 = "N";
            string menu5 = "N";

            //submenu Administracion
            string submenu1_1 = "N";
            string submenu1_2 = "N";
            string submenu1_3 = "N";
            string submenu1_4 = "N";
            string submenu1_5 = "N";
            string submenu1_6 = "N";
            string submenu1_7 = "N";
            string submenu1_8 = "N";
            string submenu1_9 = "N";
            string submenu1_10 = "N";
            string submenu1_11 = "N";
            string submenu1_12 = "N";
            string submenu1_13 = "N";

            //submenu Operacion
            string submenu2_1 = "N";
            string submenu2_2 = "N";
            string submenu2_3 = "N";
            string submenu2_4 = "N";
            string submenu2_5 = "N";

            //submenu programacion
            string submenu3_1 = "N";
            string submenu3_2 = "N";
            string submenu3_3 = "N";
            string submenu3_4 = "N";
            string submenu3_5 = "N";

            //submenu seguridad
            string submenu4_1 = "N";
            string submenu4_2 = "N";

            //submenu reporte
            string submenu5_1 = "N";

            try
            {
                DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
                @ViewData["id_sede"] = "";

                var usuario = await _ctx.Usuarios.Where(x => x.Usua_user == Usuario.Usua_user).SingleOrDefaultAsync();
                var role_usr = await _ctx.Rol_Usuarios.Where(x => x.IdUsuario == usuario.IdUsuario).SingleOrDefaultAsync();
                var rol = await _ctx.Roles.Where(x => x.Idrol == role_usr.Idrol).SingleOrDefaultAsync();

                   
                if (role_usr == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (HashHelper.CheckHash(Usuario.Usua_pass, usuario.Usua_pass, usuario.Usua_Hash))
                    {
                        if (role_usr.Idrol == 0)
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Usua_user .ToString()));
                        identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Usua_nombres));
                        identity.AddClaim(new Claim(ClaimTypes.Email, usuario.Usua_email));

                        if (usuario.Usua_imagen != null)
                        {
                            identity.AddClaim(new Claim("Imagen", usuario.Usua_imagen));
                        }
                        else
                        {
                            identity.AddClaim(new Claim("Imagen", "~/AdminLTE-master/img/profile.jpg"));
                        }

                        //foreach (var Rol in )
                        //{
                            identity.AddClaim(new Claim(ClaimTypes.Role, rol.rol_desc));
                            //Para asignar el menu de acuerdo al rol

                            var permisos = await _ctx.Rol_Permisos.Where(x => x.Idrol == rol.Idrol).ToListAsync();


                            //var admin = await _administracion.mRolpermadmin(Rol.Idrol);
                            //var oper = await _administracion.mRolpermoper(Rol.Idrol);
                            //var prog = await _administracion.mRolpermprog(Rol.Idrol);
                            //var segur = await _administracion.mRolpermsegu(Rol.Idrol);
                            //var repor = await _administracion.mRolpermrepor(Rol.Idrol);

                            foreach (var perm in permisos)
                            {
                                switch (perm.id_menu)
                                {
                                    case 1:
                                        var contmenu1 = _ctx.Rol_Permisos.Where(x => x.id_menu == 1 && x.rolperm_act == true && x.Idrol == perm.Idrol).Count();
                                        if (contmenu1 > 0)
                                        {
                                            menu1 = "S";
                                            identity.AddClaim(new Claim("menu1", menu1));
                                        }

                                        if (perm.id_submenu == 1 && perm.rolperm_act == true)
                                        {
                                            submenu1_1 = "S";
                                            identity.AddClaim(new Claim("submenu1_1", submenu1_1));
                                        }

                                        if (perm.id_submenu == 2 && perm.rolperm_act == true)
                                        {
                                            submenu1_2 = "S";
                                            identity.AddClaim(new Claim("submenu1_2", submenu1_2));
                                        }

                                        if (perm.id_submenu == 3 && perm.rolperm_act == true)
                                        {
                                            submenu1_3 = "S";
                                            identity.AddClaim(new Claim("submenu1_3", submenu1_3));
                                        }

                                        if (perm.id_submenu == 4 && perm.rolperm_act == true)
                                        {
                                            submenu1_4 = "S";
                                            identity.AddClaim(new Claim("submenu1_4", submenu1_4));
                                        }                                        
                                        if (perm.id_submenu == 5 && perm.rolperm_act == true)
                                        {
                                            submenu1_5 = "S";
                                            identity.AddClaim(new Claim("submenu1_5", submenu1_5));
                                        }

                                        if (perm.id_submenu == 6 && perm.rolperm_act == true)
                                        {
                                            submenu1_6 = "S";
                                            identity.AddClaim(new Claim("submenu1_6", submenu1_6));
                                        }

                                        if (perm.id_submenu == 7 && perm.rolperm_act == true)
                                        {
                                            submenu1_7 = "S";
                                            identity.AddClaim(new Claim("submenu1_7", submenu1_7));
                                        }

                                        if (perm.id_submenu == 8 && perm.rolperm_act == true)
                                        {
                                            submenu1_8 = "S";
                                            identity.AddClaim(new Claim("submenu1_8", submenu1_8));
                                        }

                                        if (perm.id_submenu == 9 && perm.rolperm_act == true)
                                        {
                                            submenu1_9 = "S";
                                            identity.AddClaim(new Claim("submenu1_9", submenu1_9));
                                        }

                                        if (perm.id_submenu == 10 && perm.rolperm_act == true)
                                        {
                                            submenu1_10 = "S";
                                            identity.AddClaim(new Claim("submenu1_10", submenu1_10));
                                        }

                                        if (perm.id_submenu == 11 && perm.rolperm_act == true)
                                        {
                                            submenu1_11 = "S";
                                            identity.AddClaim(new Claim("submenu1_11", submenu1_11));
                                        }

                                        if (perm.id_submenu == 12 && perm.rolperm_act == true)
                                        {
                                            submenu1_12 = "S";
                                            identity.AddClaim(new Claim("submenu1_12", submenu1_12));
                                        }

                                        if (perm.id_submenu == 26 && perm.rolperm_act == true)
                                        {
                                            submenu1_13 = "S";
                                            identity.AddClaim(new Claim("submenu1_13", submenu1_13));
                                        }

                                        break;
                                    case 2:
                                        var contmenu2 = _ctx.Rol_Permisos.Where(x => x.id_menu == 2 && x.rolperm_act == true && x.Idrol == perm.Idrol).Count();
                                        if (contmenu2 > 0)
                                        {
                                            menu2 = "S";
                                            identity.AddClaim(new Claim("menu2", menu2));
                                        }

                                        if (perm.id_submenu == 13 && perm.rolperm_act == true)
                                        {
                                            submenu2_1 = "S";
                                            identity.AddClaim(new Claim("submenu2_1", submenu2_1));
                                        }

                                        if (perm.id_submenu == 14 && perm.rolperm_act == true)
                                        {
                                            submenu2_2 = "S";
                                            identity.AddClaim(new Claim("submenu2_2", submenu2_2));
                                        }

                                        if (perm.id_submenu == 15 && perm.rolperm_act == true)
                                        {
                                            submenu2_3 = "S";
                                            identity.AddClaim(new Claim("submenu2_3", submenu2_3));
                                        }

                                        if (perm.id_submenu == 16 && perm.rolperm_act == true)
                                        {
                                            submenu2_4 = "S";
                                            identity.AddClaim(new Claim("submenu2_4", submenu2_4));
                                        }

                                        if (perm.id_submenu == 17 && perm.rolperm_act == true)
                                        {
                                            submenu2_5 = "S";
                                            identity.AddClaim(new Claim("submenu2_5", submenu2_5));
                                        }

                                        break;
                                    case 3:
                                        var contmenu3 = _ctx.Rol_Permisos.Where(x => x.id_menu == 3 && x.rolperm_act == true && x.Idrol == perm.Idrol).Count();
                                        if (contmenu3 > 0)
                                        {
                                            menu3 = "S";
                                            identity.AddClaim(new Claim("menu3", menu3));
                                        }

                                        if (perm.id_submenu == 18 && perm.rolperm_act == true)
                                        {
                                            submenu3_1 = "S";
                                            identity.AddClaim(new Claim("submenu3_1", submenu3_1));
                                        }

                                        if (perm.id_submenu == 19 && perm.rolperm_act == true)
                                        {
                                            submenu3_2 = "S";
                                            identity.AddClaim(new Claim("submenu3_2", submenu3_2));
                                        }

                                        if (perm.id_submenu == 20 && perm.rolperm_act == true)
                                        {
                                            submenu3_3 = "S";
                                            identity.AddClaim(new Claim("submenu3_3", submenu3_3));
                                        }

                                        if (perm.id_submenu == 21 && perm.rolperm_act == true)
                                        {
                                            submenu3_4 = "S";
                                            identity.AddClaim(new Claim("submenu3_4", submenu3_4));
                                        }

                                        if (perm.id_submenu == 22 && perm.rolperm_act == true)
                                        {
                                            submenu3_5 = "S";
                                            identity.AddClaim(new Claim("submenu3_5", submenu3_5));
                                        }

                                        break;
                                    case 4:
                                        var contmenu4 = _ctx.Rol_Permisos.Where(x => x.id_menu == 4 && x.rolperm_act == true && x.Idrol == perm.Idrol).Count();
                                        if (contmenu4 > 0)
                                        {
                                            menu4 = "S";
                                            identity.AddClaim(new Claim("menu4", menu4));
                                        }

                                        if (perm.id_submenu == 23 && perm.rolperm_act == true)
                                        {
                                            submenu4_1 = "S";
                                            identity.AddClaim(new Claim("submenu4_1", submenu4_1));
                                        }

                                        if (perm.id_submenu == 24 && perm.rolperm_act == true)
                                        {
                                            submenu4_2 = "S";
                                            identity.AddClaim(new Claim("submenu4_2", submenu4_2));
                                        }

                                        break;
                                    case 5:
                                        var contmenu5 = _ctx.Rol_Permisos.Where(x => x.id_menu == 5 && x.rolperm_act == true && x.Idrol == perm.Idrol).Count();
                                        if (contmenu5 > 0)
                                        {
                                            menu5 = "S";
                                            identity.AddClaim(new Claim("menu5", menu5));
                                        }

                                        if (perm.id_submenu == 25 && perm.rolperm_act == true)
                                        {
                                            submenu5_1 = "S";
                                            identity.AddClaim(new Claim("submenu5_1", submenu5_1));
                                        }

                                        break;
                                }
                            }
                        //}

                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                        new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddDays(2), IsPersistent = true });

                        return RedirectToAction("Sedes", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }

        }
        public IActionResult Principal(string id_sede)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            int sede = 0;
            string nombre = "";
            if(id_sede == null)
            {
                sede = 1;
                nombre = "AREQUIPA";
            }
            if (id_sede == "AQP")
            {
                sede = 1;
                nombre = "AREQUIPA";                
            }
            else
            {
                sede = 2;
                nombre = "INTRADEVCO";
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            //HttpContext.Session.SetString("Sede", id_sede);
            var id_user = _ctx.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
            var id_acceso = _ctx.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_accesos).SingleOrDefault();
            var mAccesos = _ctx.Accesos.Find(id_acceso);
            if(mAccesos == null)
            {
                MDAccesos dAccesos = new MDAccesos
                {
                    IdUsuario = id_user,
                    id_sede = sede
                };
                _ctx.Accesos.Update(dAccesos);
                _ctx.SaveChanges();
            }
            else
            {
                _ctx.Accesos.Update(mAccesos);
                _ctx.SaveChanges();
            }

            MDAccesos_historico mAcceHist = new MDAccesos_historico()
            {
                IdUsuario = id_user,
                id_sede = sede,
                acce_fecini = fecha
            };
            _ctx.Accesos_Historico.Add(mAcceHist);
            _ctx.SaveChanges();



            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
