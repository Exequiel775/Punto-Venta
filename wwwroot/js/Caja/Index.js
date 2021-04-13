document.addEventListener('DOMContentLoaded', () =>  {
    ActualizarTabla();
});

function ActualizarTabla() {
    
    const tabla = document.getElementById('tabla-cajas');
    tabla.innerHTML = '';

    fetch('/Caja/JsonCajas', { method:'POST' })
    .then(response => {
        if (response.status === 200){
            response.json()
            .then(json => {
                json.cajas.forEach((elemento) => {
                    let row = tabla.insertRow();

                    row.innerHTML = `
                    <td>${elemento.nombreUsuarioApertura}</td>
                    <td>${elemento.montoApertura}</td>
                    <td>${elemento.fechaAperturaStr}</td>
                    <td>${elemento.totalEfectivoEntrada}</td>
                    <td>${elemento.cuentaCorrienteEntrada}</td>
                    <td>${elemento.cuentaCorrienteSalida}</td>
                    <td>${elemento.nombreUsuarioCierre}</td>
                    <td>${elemento.montoCierre}</td>
                    <td>${elemento.fechaCierreStr}</td>
                    `
                });
            })
        }
    })
}

document.getElementById('btnAbrirCaja').onclick = () => {

    let monto = document.getElementById('txtMontoApertura').value;

    let data = new FormData();
    data.append('montoApertura', parseFloat(monto));

    fetch('/Caja/AbrirCaja', {
        method:'POST',
        body:data
    })
    .then(response => {
        if (response.status === 200){
            response.json()
            .then(json => {
                if (json.finalizado){
                    $('#modalAperturaCaja').modal('hide');
                    $('#modalAperturaCaja').hide('fast');
                    ActualizarTabla();
                }
            })
        }else{
            alert("Error al abrir la caja");
        }
    })
}