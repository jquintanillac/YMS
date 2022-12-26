class Operaciones {
    constructor() {
        this.id_vijdet = 0;
        this.id_vijcab = 0;
        this.id_estcam = 0;  
        this.placa = 0;
        this.id_estacionamiento = 0;
        this.id_cuadrilla = 0;
        this.id_canal = 0;
        this.id_muelle = 0;
    }
    Getviajes(data) {
        this.id_vijdet = data.id_vijdet;
        this.id_vijcab = data.id_vijcab;
        this.id_estcam = data.id_estcam;
        this.id_estcam = data.id_tiptran;
        document.getElementById("mid_vijdet").value = data.id_vijdet;
        document.getElementById("mid_vijcab").value = data.id_vijcab;
        document.getElementById("mid_estcam").value = data.id_estcam;
        document.getElementById("mid_tiptran").value = data.id_tiptran;
        document.getElementById("titestado").innerHTML = data.estcam_desc;
    }
    Getpicking(picking) {
        this.id_vijcab = picking.id_vijcab;
        document.getElementById("pid_vijcab").value = picking.id_vijcab;
    }
    Getingreso(ingreso) {
        this.id_vijcab = ingreso.id_vijcab;
        document.getElementById("nid_vijcab").value = ingreso.id_vijcab;
    }
    GetEstacionamiento(bloqueoes) {
        this.id_estacionamiento = bloqueoes.id_estacionamiento;
        document.getElementById("id").value = bloqueoes.id_estacionamiento;
    }
    GetCuadrilla(bloqueocu) {
        this.id_cuadrilla = bloqueocu.id_cuadrilla;
        document.getElementById("id").value = bloqueocu.id_cuadrilla;
    }
    GetCanal(bloqueoca) {
        this.id_canal = bloqueoca.id_canal;
        document.getElementById("id").value = bloqueoca.id_canal;
    }
    GetMuelle(bloqueomu) {
        this.id_muelle = bloqueomu.id_muelle;
        document.getElementById("id").value = bloqueomu.id_muelle;
    }
    ActualizarCanal() {     
        $.post(
            "Updatecanal",
            $('.formcanal').serialize(),
            (response) => {                
                try {
                    var nrotrans = "";
                    var idcanal = 0;
                    var target = $(this).attr("href");
                    var item = JSON.parse(response);
                    if (item == "Done") {
                        
                        console.log("Realizado");
                    } else {
                        console.log("CANAL NO AGREGADO");
                    }
                } catch (e) {
                    console.log("CANAL NO AGREGADO");
                }
            }
        );
    }
    ActualizarEstado() {
        $.post(
            "Updatecanal",
            $('.formcanal').serialize(),
            (response) => {
                try {
                    var item = JSON.parse(response);
                    if (item == "Done") {
                        console.log("Realizado");
                    } else {
                        console.log("No realizado");
                    }
                } catch (e) {
                    console.log("No realizado");
                }
            }
        );
    }
}
