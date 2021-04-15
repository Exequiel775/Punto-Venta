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

                    if (elemento.montoCierre == 0){
                        row.style.backgroundColor = 'green';
                        row.style.color = 'white';
                        row.innerHTML = `
                        <td>${elemento.nombreUsuarioApertura}</td>
                        <td>$${elemento.montoApertura}</td>
                        <td>${elemento.fechaAperturaStr}</td>
                        <td>$${elemento.totalEfectivoEntrada}</td>
                        <td>$${elemento.cuentaCorrienteEntrada}</td>
                        <td>$${elemento.cuentaCorrienteSalida}</td>
                        <td>${elemento.nombreUsuarioCierre}</td>
                        <td>${elemento.montoCierre}</td>
                        <td>${elemento.fechaCierreStr}</td>
                        `
                    }else {

                        row.innerHTML = `
                        <td>${elemento.nombreUsuarioApertura}</td>
                        <td>$${elemento.montoApertura}</td>
                        <td>${elemento.fechaAperturaStr}</td>
                        <td>$${elemento.totalEfectivoEntrada}</td>
                        <td>$${elemento.cuentaCorrienteEntrada}</td>
                        <td>$${elemento.cuentaCorrienteSalida}</td>
                        <td>${elemento.nombreUsuarioCierre}</td>
                        <td>${elemento.montoCierre}</td>
                        <td>${elemento.fechaCierreStr}</td>
                        `
                    }
                });
            })
        }
    })
}

document.getElementById('modalCaja').onclick = () => {

    VerificarSiExisteCajaAbierta().then(result => {
        if (result) {
            Swal.fire({
                icon: 'error',
                title: 'Caja Abierta',
                text: 'Ya existe una caja abierta, debe cerrarla para poder abrir otra'
            })

            return;
        }

        $('#modalAperturaCaja').modal('show');
        $('#modalAperturaCaja').hide('fast');
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

async function VerificarSiExisteCajaAbierta()
{
    return await fetch('/Caja/VerificarCajaAbierta',{
        method:'GET'
    }).then(response => response.text());
        /*
        if (response.status === 200){
            response.json()
            .then(json => {
                console.log(json.existe);
                return json.existe;
            })
        }else{
            alert("No se pudo obtener una caja abierta");
        }
    })
    .catch((error) => { 
        console.log(error.message);
        return true;
    });*/
}