﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YMSweb.Data;

namespace YMSweb.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210408050621_Migracioncabe")]
    partial class Migracioncabe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YMSweb.Data.Entities.MDAnexo_Placa", b =>
                {
                    b.Property<int>("id_aneplaca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_anexo")
                        .HasColumnType("int");

                    b.Property<int>("id_placa")
                        .HasColumnType("int");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.HasKey("id_aneplaca");

                    b.ToTable("Anexo_Placa");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDAnexos", b =>
                {
                    b.Property<int>("id_anexo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("anex_act")
                        .HasColumnType("bit");

                    b.Property<string>("anex_desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("esta_plac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.HasKey("id_anexo");

                    b.ToTable("Anexos");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDBloqueos", b =>
                {
                    b.Property<int>("Id_bloq")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("bloq_fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("bloq_id")
                        .HasColumnType("int");

                    b.Property<string>("bloq_obs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bloq_tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.HasKey("Id_bloq");

                    b.ToTable("Bloqueos");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDCamiones_Planificados", b =>
                {
                    b.Property<int>("id_campla")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DPlacaid_placa")
                        .HasColumnType("int");

                    b.Property<int?>("DTipo_Transporteid_tiptran")
                        .HasColumnType("int");

                    b.Property<string>("campla_cardesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("campla_fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("campla_nrotrans")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("campla_obse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("campla_orden")
                        .HasColumnType("int");

                    b.Property<string>("campla_peso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("campla_volumen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_camplacab")
                        .HasColumnType("int");

                    b.Property<int>("id_placa")
                        .HasColumnType("int");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.Property<int>("id_tiptran")
                        .HasColumnType("int");

                    b.HasKey("id_campla");

                    b.HasIndex("DPlacaid_placa");

                    b.HasIndex("DTipo_Transporteid_tiptran");

                    b.HasIndex("campla_nrotrans")
                        .IsUnique();

                    b.ToTable("Camiones_Planificados");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDCamiones_Planificados_Cabecera", b =>
                {
                    b.Property<int>("id_camplacab")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("camplacab_act")
                        .HasColumnType("bit");

                    b.Property<DateTime>("camplacab_fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("camplacab_fin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("camplacab_obs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.HasKey("id_camplacab");

                    b.ToTable("Camiones_Planificados_Cabecera");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDCanal", b =>
                {
                    b.Property<int>("id_canal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("can_act")
                        .HasColumnType("bit");

                    b.Property<string>("can_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("can_esta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("can_plac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.HasKey("id_canal");

                    b.HasIndex("can_desc")
                        .IsUnique();

                    b.ToTable("Canal");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDCanal_Placa", b =>
                {
                    b.Property<int>("id_canpla")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("fec_reg")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_canal")
                        .HasColumnType("int");

                    b.Property<int>("id_placa")
                        .HasColumnType("int");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.Property<string>("nro_trans")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_canpla");

                    b.ToTable("Canal_Placa");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDChofer", b =>
                {
                    b.Property<int>("id_chofer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("chof_act")
                        .HasColumnType("bit");

                    b.Property<string>("chof_apell")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("chof_brevette")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("chof_dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("chof_nomb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.HasKey("id_chofer");

                    b.HasIndex("chof_dni")
                        .IsUnique();

                    b.ToTable("Chofer");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDCuadrilla", b =>
                {
                    b.Property<int>("id_cuadrilla")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("cua_act")
                        .HasColumnType("bit");

                    b.Property<string>("cua_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("cua_libre")
                        .HasColumnType("bit");

                    b.Property<string>("cua_plac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.HasKey("id_cuadrilla");

                    b.HasIndex("cua_desc")
                        .IsUnique();

                    b.ToTable("Cuadrilla");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDCuadrilla_Placa", b =>
                {
                    b.Property<int>("id_cuapla")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("fec_reg")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_cuadrilla")
                        .HasColumnType("int");

                    b.Property<int>("id_placa")
                        .HasColumnType("int");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.Property<string>("nro_trans")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_cuapla");

                    b.ToTable("Cuadrilla_Placa");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDEstacionamiento", b =>
                {
                    b.Property<int>("id_estacionamiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("esta_act")
                        .HasColumnType("bit");

                    b.Property<string>("esta_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("esta_libre")
                        .HasColumnType("bit");

                    b.Property<string>("esta_plac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.HasKey("id_estacionamiento");

                    b.HasIndex("esta_desc")
                        .IsUnique();

                    b.ToTable("Estacionamiento");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDEstacionamiento_Placa", b =>
                {
                    b.Property<int>("id_estplaca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("fec_reg")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_estacionamiento")
                        .HasColumnType("int");

                    b.Property<int>("id_placa")
                        .HasColumnType("int");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.Property<string>("nro_trans")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_estplaca");

                    b.ToTable("Estacionamiento_Placa");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDEstados_Camion", b =>
                {
                    b.Property<int>("id_estcam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estcam_act")
                        .HasColumnType("bit");

                    b.Property<bool>("estcam_busq")
                        .HasColumnType("bit");

                    b.Property<int>("estcam_codigo")
                        .HasColumnType("int");

                    b.Property<string>("estcam_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.HasKey("id_estcam");

                    b.HasIndex("estcam_desc")
                        .IsUnique();

                    b.ToTable("Estados_Camion");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDMontacarga_Placa", b =>
                {
                    b.Property<int>("id_montaplaca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("fec_reg")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_monta")
                        .HasColumnType("int");

                    b.Property<int>("id_placa")
                        .HasColumnType("int");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.Property<string>("nro_trans")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_montaplaca");

                    b.ToTable("Montacarga_Placa");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDMontacargas", b =>
                {
                    b.Property<int>("id_monta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.Property<bool>("monta_act")
                        .HasColumnType("bit");

                    b.Property<string>("monta_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("monta_plac")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_monta");

                    b.ToTable("Montacargas");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDMuelle", b =>
                {
                    b.Property<int>("id_muelle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.Property<bool>("mue_act")
                        .HasColumnType("bit");

                    b.Property<string>("mue_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("mue_libre")
                        .HasColumnType("bit");

                    b.Property<string>("mue_plac")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_muelle");

                    b.HasIndex("mue_desc")
                        .IsUnique();

                    b.ToTable("Muelle");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDMuelle_Placa", b =>
                {
                    b.Property<int>("id_muepla")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("fec_reg")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_muelle")
                        .HasColumnType("int");

                    b.Property<int>("id_placa")
                        .HasColumnType("int");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.Property<string>("nro_trans")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_muepla");

                    b.ToTable("Muelle_Placa");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDPlaca", b =>
                {
                    b.Property<int>("id_placa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DChoferid_chofer")
                        .HasColumnType("int");

                    b.Property<int?>("DTransportistaid_transp")
                        .HasColumnType("int");

                    b.Property<int>("id_chofer")
                        .HasColumnType("int");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.Property<int>("id_transp")
                        .HasColumnType("int");

                    b.Property<bool>("plac_act")
                        .HasColumnType("bit");

                    b.Property<string>("plac_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("plac_libre")
                        .HasColumnType("bit");

                    b.Property<string>("plac_tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_placa");

                    b.HasIndex("DChoferid_chofer");

                    b.HasIndex("DTransportistaid_transp");

                    b.HasIndex("plac_desc")
                        .IsUnique();

                    b.ToTable("Placa");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDRol", b =>
                {
                    b.Property<int>("Idrol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.Property<string>("rol_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Idrol");

                    b.HasIndex("rol_desc")
                        .IsUnique();

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDRol_Usuario", b =>
                {
                    b.Property<int>("Idrol_usua")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("Idrol")
                        .HasColumnType("int");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.HasKey("Idrol_usua");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("Idrol");

                    b.ToTable("Rol_Usuario");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDSedes", b =>
                {
                    b.Property<int>("id_sede")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("sede_cod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sede_desc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_sede");

                    b.ToTable("Sede");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDTipo_Transporte", b =>
                {
                    b.Property<int>("id_tiptran")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.Property<bool?>("tiptran_act")
                        .HasColumnType("bit");

                    b.Property<string>("tiptran_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id_tiptran");

                    b.HasIndex("tiptran_desc")
                        .IsUnique();

                    b.ToTable("Tipo_Transporte");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDTransportista", b =>
                {
                    b.Property<int>("id_transp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.Property<bool>("transp_act")
                        .HasColumnType("bit");

                    b.Property<string>("transp_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("transp_libre")
                        .HasColumnType("bit");

                    b.Property<string>("transp_ruc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_transp");

                    b.HasIndex("transp_desc")
                        .IsUnique();

                    b.ToTable("Transportista");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDUsuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Usua_Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Usua_act")
                        .HasColumnType("bit");

                    b.Property<string>("Usua_apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usua_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usua_imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usua_nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usua_pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usua_user")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Usua_user")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDViaje_Cabecera", b =>
                {
                    b.Property<int>("id_vijcab")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DCamiones_Planificadosid_campla")
                        .HasColumnType("int");

                    b.Property<int>("id_campla")
                        .HasColumnType("int");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.Property<DateTime>("vijcab_fecinsp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("vijcab_fecllegada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("vijcab_fecpick")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("vijcab_fecunidad")
                        .HasColumnType("datetime2");

                    b.Property<bool>("vijcab_ingunidad")
                        .HasColumnType("bit");

                    b.Property<bool>("vijcab_insp")
                        .HasColumnType("bit");

                    b.Property<bool>("vijcab_llegada")
                        .HasColumnType("bit");

                    b.Property<bool>("vijcab_pick")
                        .HasColumnType("bit");

                    b.Property<bool>("vijcab_segsal")
                        .HasColumnType("bit");

                    b.HasKey("id_vijcab");

                    b.HasIndex("DCamiones_Planificadosid_campla");

                    b.ToTable("Viaje_Cabecera");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDViaje_Detalle", b =>
                {
                    b.Property<int>("id_vijdet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DCanalsid_canal")
                        .HasColumnType("int");

                    b.Property<int?>("DCuadrillasid_cuadrilla")
                        .HasColumnType("int");

                    b.Property<int?>("DEstacionamientoid_estacionamiento")
                        .HasColumnType("int");

                    b.Property<int?>("DEstados_Camionsid_estcam")
                        .HasColumnType("int");

                    b.Property<int?>("DMuellesid_muelle")
                        .HasColumnType("int");

                    b.Property<int?>("DViaje_Cabecerasid_vijcab")
                        .HasColumnType("int");

                    b.Property<int>("id_estcam")
                        .HasColumnType("int");

                    b.Property<int>("id_sede")
                        .HasColumnType("int");

                    b.Property<int>("id_vijcab")
                        .HasColumnType("int");

                    b.Property<string>("viaj_canales")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("viaj_cuadrillas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("viaj_estacionamientos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("viaj_muelles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("vijdet_est")
                        .HasColumnType("bit");

                    b.Property<DateTime>("vijdet_fecfin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("vijdet_fecfin_canal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("vijdet_fecfin_cuadril")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("vijdet_fecfin_estacio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("vijdet_fecfin_muelle")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("vijdet_fecini")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("vijdet_fecini_canal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("vijdet_fecini_cuadril")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("vijdet_fecini_estacio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("vijdet_fecini_muelle")
                        .HasColumnType("datetime2");

                    b.HasKey("id_vijdet");

                    b.HasIndex("DCanalsid_canal");

                    b.HasIndex("DCuadrillasid_cuadrilla");

                    b.HasIndex("DEstacionamientoid_estacionamiento");

                    b.HasIndex("DEstados_Camionsid_estcam");

                    b.HasIndex("DMuellesid_muelle");

                    b.HasIndex("DViaje_Cabecerasid_vijcab");

                    b.ToTable("Viaje_Detalle");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDCamiones_Planificados", b =>
                {
                    b.HasOne("YMSweb.Data.Entities.MDPlaca", "DPlaca")
                        .WithMany("DCamiones_Planificados")
                        .HasForeignKey("DPlacaid_placa");

                    b.HasOne("YMSweb.Data.Entities.MDTipo_Transporte", "DTipo_Transporte")
                        .WithMany("DCamiones_Planificados")
                        .HasForeignKey("DTipo_Transporteid_tiptran");

                    b.Navigation("DPlaca");

                    b.Navigation("DTipo_Transporte");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDPlaca", b =>
                {
                    b.HasOne("YMSweb.Data.Entities.MDChofer", "DChofer")
                        .WithMany("DPlacas")
                        .HasForeignKey("DChoferid_chofer");

                    b.HasOne("YMSweb.Data.Entities.MDTransportista", "DTransportista")
                        .WithMany("DPlacas")
                        .HasForeignKey("DTransportistaid_transp");

                    b.Navigation("DChofer");

                    b.Navigation("DTransportista");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDRol_Usuario", b =>
                {
                    b.HasOne("YMSweb.Data.Entities.MDUsuario", "DUsuario")
                        .WithMany("DRol_Usuarios")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YMSweb.Data.Entities.MDRol", "DRol")
                        .WithMany("DRol_Usuarios")
                        .HasForeignKey("Idrol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DRol");

                    b.Navigation("DUsuario");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDViaje_Cabecera", b =>
                {
                    b.HasOne("YMSweb.Data.Entities.MDCamiones_Planificados", "DCamiones_Planificados")
                        .WithMany("DViaje_Cabecera")
                        .HasForeignKey("DCamiones_Planificadosid_campla");

                    b.Navigation("DCamiones_Planificados");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDViaje_Detalle", b =>
                {
                    b.HasOne("YMSweb.Data.Entities.MDCanal", "DCanals")
                        .WithMany("DViaje_Detalles")
                        .HasForeignKey("DCanalsid_canal");

                    b.HasOne("YMSweb.Data.Entities.MDCuadrilla", "DCuadrillas")
                        .WithMany("DViaje_Detalle")
                        .HasForeignKey("DCuadrillasid_cuadrilla");

                    b.HasOne("YMSweb.Data.Entities.MDEstacionamiento", "DEstacionamiento")
                        .WithMany()
                        .HasForeignKey("DEstacionamientoid_estacionamiento");

                    b.HasOne("YMSweb.Data.Entities.MDEstados_Camion", "DEstados_Camions")
                        .WithMany("DViaje_Detalle")
                        .HasForeignKey("DEstados_Camionsid_estcam");

                    b.HasOne("YMSweb.Data.Entities.MDMuelle", "DMuelles")
                        .WithMany("DViaje_Detalle")
                        .HasForeignKey("DMuellesid_muelle");

                    b.HasOne("YMSweb.Data.Entities.MDViaje_Cabecera", "DViaje_Cabeceras")
                        .WithMany("DViaje_Detalles")
                        .HasForeignKey("DViaje_Cabecerasid_vijcab");

                    b.Navigation("DCanals");

                    b.Navigation("DCuadrillas");

                    b.Navigation("DEstacionamiento");

                    b.Navigation("DEstados_Camions");

                    b.Navigation("DMuelles");

                    b.Navigation("DViaje_Cabeceras");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDCamiones_Planificados", b =>
                {
                    b.Navigation("DViaje_Cabecera");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDCanal", b =>
                {
                    b.Navigation("DViaje_Detalles");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDChofer", b =>
                {
                    b.Navigation("DPlacas");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDCuadrilla", b =>
                {
                    b.Navigation("DViaje_Detalle");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDEstados_Camion", b =>
                {
                    b.Navigation("DViaje_Detalle");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDMuelle", b =>
                {
                    b.Navigation("DViaje_Detalle");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDPlaca", b =>
                {
                    b.Navigation("DCamiones_Planificados");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDRol", b =>
                {
                    b.Navigation("DRol_Usuarios");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDTipo_Transporte", b =>
                {
                    b.Navigation("DCamiones_Planificados");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDTransportista", b =>
                {
                    b.Navigation("DPlacas");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDUsuario", b =>
                {
                    b.Navigation("DRol_Usuarios");
                });

            modelBuilder.Entity("YMSweb.Data.Entities.MDViaje_Cabecera", b =>
                {
                    b.Navigation("DViaje_Detalles");
                });
#pragma warning restore 612, 618
        }
    }
}
