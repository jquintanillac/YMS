using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMSweb.Data.Entities;

namespace YMSweb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public virtual DbSet<MDChofer> Choferes { get; set; }
        public virtual DbSet<MDCamiones_Planificados> Camiones_Planificados { get; set; }
        public virtual DbSet<MDCamiones_Planificados_Cabecera> Camiones_Planificados_Cabecera { get; set; }
        public virtual DbSet<MDCanal> Canales { get; set; }
        public virtual DbSet<MDCuadrilla> Cuadrillas { get; set; }
        public virtual DbSet<MDEstacionamiento> Estacionamientos { get; set; }
        public virtual DbSet<MDEstados_Camion> Estados_Camiones { get; set; }
        public virtual DbSet<MDMuelle> Muelles { get; set; }
        public virtual DbSet<MDPlaca> Placas { get; set; }
        public virtual DbSet<MDMontacargas> Montacargas { get; set; }
        public virtual DbSet<MDTipo_Transporte> Tipo_Transportes { get; set; }
        public virtual DbSet<MDTipo_unidad> Tipo_Unidades { get; set; }
        public virtual DbSet<MDTransportista> Transportistas { get; set; }
        public virtual DbSet<MDViaje_Cabecera> Viaje_Cabeceras { get; set; }
        public virtual DbSet<MDViaje_Detalle> Viaje_Detalles { get; set; }
        public virtual DbSet<MDUsuario> Usuarios { get; set; }
        public virtual DbSet<MDRol> Roles { get; set; }
        public virtual DbSet<MDRol_Usuario> Rol_Usuarios { get; set; }
        public virtual DbSet<MDCanal_Placa> Canal_Placa { get; set; }
        public virtual DbSet<MDCuadrilla_Placa> Cuadrilla_Placa { get; set; }
        public virtual DbSet<MDMuelle_Placa> Muelle_Placa { get; set; }
        public virtual DbSet<MDEstacionamiento_Placa> Estacionamiento_Placa { get; set; }
        public virtual DbSet<MDMontacarga_Placa> Montacarga_Placas { get; set; }
        public virtual DbSet<MDBloqueos> Bloqueos { get; set; }
        public virtual DbSet<MDAnexos> Anexos { get; set; }
        public virtual DbSet<MDAnexo_Placa> Anexo_Placas { get; set; }
        public virtual DbSet<MDSedes> Sedes { get; set; }
        public virtual DbSet<MDAccesos> Accesos { get; set; }
        public virtual DbSet<MDAccesos_historico> Accesos_Historico { get; set; }
        public virtual DbSet<MDMenu> Menus { get; set; }
        public virtual DbSet<MDSubmenu> Submenus { get; set; }
        public virtual DbSet<MDRol_Permisos> Rol_Permisos { get; set; }
        public virtual DbSet<MDAlibot> Alibots { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MDCamiones_Planificados>()
                        .HasIndex(t => t.campla_nrotrans)
                        .IsUnique();

            modelBuilder.Entity<MDCanal>()
                .HasIndex(t => t.can_desc);

            modelBuilder.Entity<MDChofer>()
                .HasIndex(t => t.chof_dni)
                .IsUnique();
            modelBuilder.Entity<MDCuadrilla>()
                .HasIndex(t => t.cua_desc);
            modelBuilder.Entity<MDEstacionamiento>()
                .HasIndex(t => t.esta_desc);
            modelBuilder.Entity<MDEstados_Camion>()
                .HasIndex(t => t.estcam_desc)
                .IsUnique();
            modelBuilder.Entity<MDMuelle>()
                .HasIndex(t => t.mue_desc);
            modelBuilder.Entity<MDPlaca>()
                .HasIndex(t => t.plac_desc)
                .IsUnique();
            modelBuilder.Entity<MDTipo_Transporte>()
               .HasIndex(t => t.tiptran_desc)
               .IsUnique();
            modelBuilder.Entity<MDTransportista>()
               .HasIndex(t => t.transp_desc)
               .IsUnique();
            modelBuilder.Entity<MDUsuario>()
               .HasIndex(t => t.Usua_user)
               .IsUnique();
            modelBuilder.Entity<MDRol>()
               .HasIndex(t => t.rol_desc)
               .IsUnique();

        }

    }
}
