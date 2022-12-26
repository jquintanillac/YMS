using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YMSweb.Migrations
{
    public partial class MigrationSedes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anexo_Placa",
                columns: table => new
                {
                    id_aneplaca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_anexo = table.Column<int>(type: "int", nullable: false),
                    id_placa = table.Column<int>(type: "int", nullable: false),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anexo_Placa", x => x.id_aneplaca);
                });

            migrationBuilder.CreateTable(
                name: "Anexos",
                columns: table => new
                {
                    id_anexo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    anex_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    anex_act = table.Column<bool>(type: "bit", nullable: false),
                    esta_plac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anexos", x => x.id_anexo);
                });

            migrationBuilder.CreateTable(
                name: "Bloqueos",
                columns: table => new
                {
                    Id_bloq = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bloq_id = table.Column<int>(type: "int", nullable: false),
                    bloq_tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bloq_obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bloq_fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloqueos", x => x.Id_bloq);
                });

            migrationBuilder.CreateTable(
                name: "Camiones_Planificados_Cabecera",
                columns: table => new
                {
                    id_camplacab = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    camplacab_fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    camplacab_act = table.Column<bool>(type: "bit", nullable: false),
                    camplacab_fin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    camplacab_obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camiones_Planificados_Cabecera", x => x.id_camplacab);
                });

            migrationBuilder.CreateTable(
                name: "Canal",
                columns: table => new
                {
                    id_canal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    can_desc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    can_act = table.Column<bool>(type: "bit", nullable: false),
                    can_plac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    can_esta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canal", x => x.id_canal);
                });

            migrationBuilder.CreateTable(
                name: "Canal_Placa",
                columns: table => new
                {
                    id_canpla = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_canal = table.Column<int>(type: "int", nullable: false),
                    id_placa = table.Column<int>(type: "int", nullable: false),
                    fec_reg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nro_trans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canal_Placa", x => x.id_canpla);
                });

            migrationBuilder.CreateTable(
                name: "Chofer",
                columns: table => new
                {
                    id_chofer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chof_nomb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chof_apell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chof_dni = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    chof_brevette = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chof_act = table.Column<bool>(type: "bit", nullable: false),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chofer", x => x.id_chofer);
                });

            migrationBuilder.CreateTable(
                name: "Cuadrilla",
                columns: table => new
                {
                    id_cuadrilla = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cua_desc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cua_act = table.Column<bool>(type: "bit", nullable: false),
                    cua_libre = table.Column<bool>(type: "bit", nullable: false),
                    cua_plac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuadrilla", x => x.id_cuadrilla);
                });

            migrationBuilder.CreateTable(
                name: "Cuadrilla_Placa",
                columns: table => new
                {
                    id_cuapla = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cuadrilla = table.Column<int>(type: "int", nullable: false),
                    id_placa = table.Column<int>(type: "int", nullable: false),
                    fec_reg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nro_trans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuadrilla_Placa", x => x.id_cuapla);
                });

            migrationBuilder.CreateTable(
                name: "Estacionamiento",
                columns: table => new
                {
                    id_estacionamiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    esta_desc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    esta_act = table.Column<bool>(type: "bit", nullable: false),
                    esta_libre = table.Column<bool>(type: "bit", nullable: false),
                    esta_plac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamiento", x => x.id_estacionamiento);
                });

            migrationBuilder.CreateTable(
                name: "Estacionamiento_Placa",
                columns: table => new
                {
                    id_estplaca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_estacionamiento = table.Column<int>(type: "int", nullable: false),
                    id_placa = table.Column<int>(type: "int", nullable: false),
                    fec_reg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nro_trans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamiento_Placa", x => x.id_estplaca);
                });

            migrationBuilder.CreateTable(
                name: "Estados_Camion",
                columns: table => new
                {
                    id_estcam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estcam_desc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    estcam_act = table.Column<bool>(type: "bit", nullable: false),
                    estcam_busq = table.Column<bool>(type: "bit", nullable: false),
                    estcam_codigo = table.Column<int>(type: "int", nullable: false),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados_Camion", x => x.id_estcam);
                });

            migrationBuilder.CreateTable(
                name: "Montacarga_Placa",
                columns: table => new
                {
                    id_montaplaca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_monta = table.Column<int>(type: "int", nullable: false),
                    id_placa = table.Column<int>(type: "int", nullable: false),
                    fec_reg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nro_trans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Montacarga_Placa", x => x.id_montaplaca);
                });

            migrationBuilder.CreateTable(
                name: "Montacargas",
                columns: table => new
                {
                    id_monta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    monta_desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    monta_act = table.Column<bool>(type: "bit", nullable: false),
                    monta_plac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Montacargas", x => x.id_monta);
                });

            migrationBuilder.CreateTable(
                name: "Muelle",
                columns: table => new
                {
                    id_muelle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mue_desc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    mue_act = table.Column<bool>(type: "bit", nullable: false),
                    mue_libre = table.Column<bool>(type: "bit", nullable: false),
                    mue_plac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muelle", x => x.id_muelle);
                });

            migrationBuilder.CreateTable(
                name: "Muelle_Placa",
                columns: table => new
                {
                    id_muepla = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_muelle = table.Column<int>(type: "int", nullable: false),
                    id_placa = table.Column<int>(type: "int", nullable: false),
                    fec_reg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nro_trans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muelle_Placa", x => x.id_muepla);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Idrol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rol_desc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Idrol);
                });

            migrationBuilder.CreateTable(
                name: "Sede",
                columns: table => new
                {
                    id_sede = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sede_cod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sede_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sede", x => x.id_sede);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Transporte",
                columns: table => new
                {
                    id_tiptran = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tiptran_desc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tiptran_act = table.Column<bool>(type: "bit", nullable: true),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Transporte", x => x.id_tiptran);
                });

            migrationBuilder.CreateTable(
                name: "Transportista",
                columns: table => new
                {
                    id_transp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transp_desc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    transp_ruc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transp_act = table.Column<bool>(type: "bit", nullable: false),
                    transp_libre = table.Column<bool>(type: "bit", nullable: false),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportista", x => x.id_transp);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usua_user = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Usua_nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usua_apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usua_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usua_pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usua_Hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usua_act = table.Column<bool>(type: "bit", nullable: false),
                    Usua_imagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Placa",
                columns: table => new
                {
                    id_placa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_chofer = table.Column<int>(type: "int", nullable: false),
                    id_transp = table.Column<int>(type: "int", nullable: false),
                    plac_desc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    plac_tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    plac_act = table.Column<bool>(type: "bit", nullable: false),
                    plac_libre = table.Column<bool>(type: "bit", nullable: false),
                    id_sede = table.Column<int>(type: "int", nullable: false),
                    DChoferid_chofer = table.Column<int>(type: "int", nullable: true),
                    DTransportistaid_transp = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placa", x => x.id_placa);
                    table.ForeignKey(
                        name: "FK_Placa_Chofer_DChoferid_chofer",
                        column: x => x.DChoferid_chofer,
                        principalTable: "Chofer",
                        principalColumn: "id_chofer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Placa_Transportista_DTransportistaid_transp",
                        column: x => x.DTransportistaid_transp,
                        principalTable: "Transportista",
                        principalColumn: "id_transp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rol_Usuario",
                columns: table => new
                {
                    Idrol_usua = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idrol = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    id_sede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol_Usuario", x => x.Idrol_usua);
                    table.ForeignKey(
                        name: "FK_Rol_Usuario_Rol_Idrol",
                        column: x => x.Idrol,
                        principalTable: "Rol",
                        principalColumn: "Idrol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rol_Usuario_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Camiones_Planificados",
                columns: table => new
                {
                    id_campla = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_camplacab = table.Column<int>(type: "int", nullable: false),
                    id_tiptran = table.Column<int>(type: "int", nullable: false),
                    id_placa = table.Column<int>(type: "int", nullable: false),
                    campla_nrotrans = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    campla_peso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    campla_volumen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    campla_fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    campla_obse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    campla_cardesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    campla_orden = table.Column<int>(type: "int", nullable: false),
                    id_sede = table.Column<int>(type: "int", nullable: false),
                    DPlacaid_placa = table.Column<int>(type: "int", nullable: true),
                    DTipo_Transporteid_tiptran = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camiones_Planificados", x => x.id_campla);
                    table.ForeignKey(
                        name: "FK_Camiones_Planificados_Placa_DPlacaid_placa",
                        column: x => x.DPlacaid_placa,
                        principalTable: "Placa",
                        principalColumn: "id_placa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Camiones_Planificados_Tipo_Transporte_DTipo_Transporteid_tiptran",
                        column: x => x.DTipo_Transporteid_tiptran,
                        principalTable: "Tipo_Transporte",
                        principalColumn: "id_tiptran",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Viaje_Cabecera",
                columns: table => new
                {
                    id_vijcab = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_campla = table.Column<int>(type: "int", nullable: false),
                    vijcab_pick = table.Column<bool>(type: "bit", nullable: false),
                    vijcab_fecpick = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vijcab_insp = table.Column<bool>(type: "bit", nullable: false),
                    vijcab_fecinsp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vijcab_ingunidad = table.Column<bool>(type: "bit", nullable: false),
                    vijcab_fecunidad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vijcab_llegada = table.Column<bool>(type: "bit", nullable: false),
                    vijcab_fecllegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_sede = table.Column<int>(type: "int", nullable: false),
                    DCamiones_Planificadosid_campla = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viaje_Cabecera", x => x.id_vijcab);
                    table.ForeignKey(
                        name: "FK_Viaje_Cabecera_Camiones_Planificados_DCamiones_Planificadosid_campla",
                        column: x => x.DCamiones_Planificadosid_campla,
                        principalTable: "Camiones_Planificados",
                        principalColumn: "id_campla",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Viaje_Detalle",
                columns: table => new
                {
                    id_vijdet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_vijcab = table.Column<int>(type: "int", nullable: false),
                    id_estcam = table.Column<int>(type: "int", nullable: false),
                    viaj_muelles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    viaj_canales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    viaj_cuadrillas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    viaj_estacionamientos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vijdet_fecini_muelle = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vijdet_fecfin_muelle = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vijdet_fecini_canal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vijdet_fecfin_canal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vijdet_fecini_cuadril = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vijdet_fecfin_cuadril = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vijdet_fecini_estacio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vijdet_fecfin_estacio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vijdet_fecini = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vijdet_fecfin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vijdet_est = table.Column<bool>(type: "bit", nullable: false),
                    id_sede = table.Column<int>(type: "int", nullable: false),
                    DEstados_Camionsid_estcam = table.Column<int>(type: "int", nullable: true),
                    DViaje_Cabecerasid_vijcab = table.Column<int>(type: "int", nullable: true),
                    DMuellesid_muelle = table.Column<int>(type: "int", nullable: true),
                    DCanalsid_canal = table.Column<int>(type: "int", nullable: true),
                    DEstacionamientoid_estacionamiento = table.Column<int>(type: "int", nullable: true),
                    DCuadrillasid_cuadrilla = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viaje_Detalle", x => x.id_vijdet);
                    table.ForeignKey(
                        name: "FK_Viaje_Detalle_Canal_DCanalsid_canal",
                        column: x => x.DCanalsid_canal,
                        principalTable: "Canal",
                        principalColumn: "id_canal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Viaje_Detalle_Cuadrilla_DCuadrillasid_cuadrilla",
                        column: x => x.DCuadrillasid_cuadrilla,
                        principalTable: "Cuadrilla",
                        principalColumn: "id_cuadrilla",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Viaje_Detalle_Estacionamiento_DEstacionamientoid_estacionamiento",
                        column: x => x.DEstacionamientoid_estacionamiento,
                        principalTable: "Estacionamiento",
                        principalColumn: "id_estacionamiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Viaje_Detalle_Estados_Camion_DEstados_Camionsid_estcam",
                        column: x => x.DEstados_Camionsid_estcam,
                        principalTable: "Estados_Camion",
                        principalColumn: "id_estcam",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Viaje_Detalle_Muelle_DMuellesid_muelle",
                        column: x => x.DMuellesid_muelle,
                        principalTable: "Muelle",
                        principalColumn: "id_muelle",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Viaje_Detalle_Viaje_Cabecera_DViaje_Cabecerasid_vijcab",
                        column: x => x.DViaje_Cabecerasid_vijcab,
                        principalTable: "Viaje_Cabecera",
                        principalColumn: "id_vijcab",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Camiones_Planificados_campla_nrotrans",
                table: "Camiones_Planificados",
                column: "campla_nrotrans",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Camiones_Planificados_DPlacaid_placa",
                table: "Camiones_Planificados",
                column: "DPlacaid_placa");

            migrationBuilder.CreateIndex(
                name: "IX_Camiones_Planificados_DTipo_Transporteid_tiptran",
                table: "Camiones_Planificados",
                column: "DTipo_Transporteid_tiptran");

            migrationBuilder.CreateIndex(
                name: "IX_Canal_can_desc",
                table: "Canal",
                column: "can_desc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chofer_chof_dni",
                table: "Chofer",
                column: "chof_dni",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuadrilla_cua_desc",
                table: "Cuadrilla",
                column: "cua_desc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamiento_esta_desc",
                table: "Estacionamiento",
                column: "esta_desc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estados_Camion_estcam_desc",
                table: "Estados_Camion",
                column: "estcam_desc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Muelle_mue_desc",
                table: "Muelle",
                column: "mue_desc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Placa_DChoferid_chofer",
                table: "Placa",
                column: "DChoferid_chofer");

            migrationBuilder.CreateIndex(
                name: "IX_Placa_DTransportistaid_transp",
                table: "Placa",
                column: "DTransportistaid_transp");

            migrationBuilder.CreateIndex(
                name: "IX_Placa_plac_desc",
                table: "Placa",
                column: "plac_desc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rol_rol_desc",
                table: "Rol",
                column: "rol_desc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rol_Usuario_Idrol",
                table: "Rol_Usuario",
                column: "Idrol");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_Usuario_IdUsuario",
                table: "Rol_Usuario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Transporte_tiptran_desc",
                table: "Tipo_Transporte",
                column: "tiptran_desc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportista_transp_desc",
                table: "Transportista",
                column: "transp_desc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Usua_user",
                table: "Usuario",
                column: "Usua_user",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_Cabecera_DCamiones_Planificadosid_campla",
                table: "Viaje_Cabecera",
                column: "DCamiones_Planificadosid_campla");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_Detalle_DCanalsid_canal",
                table: "Viaje_Detalle",
                column: "DCanalsid_canal");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_Detalle_DCuadrillasid_cuadrilla",
                table: "Viaje_Detalle",
                column: "DCuadrillasid_cuadrilla");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_Detalle_DEstacionamientoid_estacionamiento",
                table: "Viaje_Detalle",
                column: "DEstacionamientoid_estacionamiento");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_Detalle_DEstados_Camionsid_estcam",
                table: "Viaje_Detalle",
                column: "DEstados_Camionsid_estcam");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_Detalle_DMuellesid_muelle",
                table: "Viaje_Detalle",
                column: "DMuellesid_muelle");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_Detalle_DViaje_Cabecerasid_vijcab",
                table: "Viaje_Detalle",
                column: "DViaje_Cabecerasid_vijcab");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anexo_Placa");

            migrationBuilder.DropTable(
                name: "Anexos");

            migrationBuilder.DropTable(
                name: "Bloqueos");

            migrationBuilder.DropTable(
                name: "Camiones_Planificados_Cabecera");

            migrationBuilder.DropTable(
                name: "Canal_Placa");

            migrationBuilder.DropTable(
                name: "Cuadrilla_Placa");

            migrationBuilder.DropTable(
                name: "Estacionamiento_Placa");

            migrationBuilder.DropTable(
                name: "Montacarga_Placa");

            migrationBuilder.DropTable(
                name: "Montacargas");

            migrationBuilder.DropTable(
                name: "Muelle_Placa");

            migrationBuilder.DropTable(
                name: "Rol_Usuario");

            migrationBuilder.DropTable(
                name: "Sede");

            migrationBuilder.DropTable(
                name: "Viaje_Detalle");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Canal");

            migrationBuilder.DropTable(
                name: "Cuadrilla");

            migrationBuilder.DropTable(
                name: "Estacionamiento");

            migrationBuilder.DropTable(
                name: "Estados_Camion");

            migrationBuilder.DropTable(
                name: "Muelle");

            migrationBuilder.DropTable(
                name: "Viaje_Cabecera");

            migrationBuilder.DropTable(
                name: "Camiones_Planificados");

            migrationBuilder.DropTable(
                name: "Placa");

            migrationBuilder.DropTable(
                name: "Tipo_Transporte");

            migrationBuilder.DropTable(
                name: "Chofer");

            migrationBuilder.DropTable(
                name: "Transportista");
        }
    }
}
