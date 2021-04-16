var _cajaSeleccionadaEliminar = -1;

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
                        <td></td>
                        `

                        let botonCerrar = document.createElement('button');
                        botonCerrar.classList.add('btn', 'btn-danger');
                        botonCerrar.value = elemento.id;
                        botonCerrar.innerHTML = `
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="18" fill="currentColor" class="bi bi-inboxes-fill" viewBox="0 0 16 16">
                        <path d="M4.98 1a.5.5 0 0 0-.39.188L1.54 5H6a.5.5 0 0 1 .5.5 1.5 1.5 0 0 0 3 0A.5.5 0 0 1 10 5h4.46l-3.05-3.812A.5.5 0 0 0 11.02 1H4.98zM3.81.563A1.5 1.5 0 0 1 4.98 0h6.04a1.5 1.5 0 0 1 1.17.563l3.7 4.625a.5.5 0 0 1 .106.374l-.39 3.124A1.5 1.5 0 0 1 14.117 10H1.883A1.5 1.5 0 0 1 .394 8.686l-.39-3.124a.5.5 0 0 1 .106-.374L3.81.563zM.125 11.17A.5.5 0 0 1 .5 11H6a.5.5 0 0 1 .5.5 1.5 1.5 0 0 0 3 0 .5.5 0 0 1 .5-.5h5.5a.5.5 0 0 1 .496.562l-.39 3.124A1.5 1.5 0 0 1 14.117 16H1.883a1.5 1.5 0 0 1-1.489-1.314l-.39-3.124a.5.5 0 0 1 .121-.393z"/>
                        </svg>
                        `
                        botonCerrar.onclick = (e) => {
                            _cajaSeleccionadaEliminar = e.target.value;
                            $('#modalCierreCaja').modal('show');
                            $('#modalCierreCaja').show('fast');
                            ObtenerDatosCaja(e.target.value)
                            .then(result => {
                                var objetoCaja = JSON.parse(result);
                                document.getElementById('totalEfectivo').textContent = `$${objetoCaja.cajaSeleccionada.totalEfectivoEntrada}`
                                document.getElementById('ctacteSalida').textContent = `$${objetoCaja.cajaSeleccionada.cuentaCorrienteSalida}`
                                document.getElementById('totalRecaudado').textContent = `$${objetoCaja.cajaSeleccionada.totalEfectivoEntrada}`
                            })
                        }

                        row.children[9].appendChild(botonCerrar);
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
                        <td></td>
                        `

                        let botonCerrar = document.createElement('button');
                        botonCerrar.classList.add('btn', 'btn-danger');
                        botonCerrar.value = elemento.id;
                        botonCerrar.innerHTML = `
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="18" fill="currentColor" class="bi bi-inboxes-fill" viewBox="0 0 16 16">
                        <path d="M4.98 1a.5.5 0 0 0-.39.188L1.54 5H6a.5.5 0 0 1 .5.5 1.5 1.5 0 0 0 3 0A.5.5 0 0 1 10 5h4.46l-3.05-3.812A.5.5 0 0 0 11.02 1H4.98zM3.81.563A1.5 1.5 0 0 1 4.98 0h6.04a1.5 1.5 0 0 1 1.17.563l3.7 4.625a.5.5 0 0 1 .106.374l-.39 3.124A1.5 1.5 0 0 1 14.117 10H1.883A1.5 1.5 0 0 1 .394 8.686l-.39-3.124a.5.5 0 0 1 .106-.374L3.81.563zM.125 11.17A.5.5 0 0 1 .5 11H6a.5.5 0 0 1 .5.5 1.5 1.5 0 0 0 3 0 .5.5 0 0 1 .5-.5h5.5a.5.5 0 0 1 .496.562l-.39 3.124A1.5 1.5 0 0 1 14.117 16H1.883a1.5 1.5 0 0 1-1.489-1.314l-.39-3.124a.5.5 0 0 1 .121-.393z"/>
                        </svg>
                        `

                        row.children[9].appendChild(botonCerrar);
                    }
                });
            })
        }
    })
}

document.getElementById('modalCaja').onclick = () => {

    VerificarSiExisteCajaAbierta().then(result => {

        var objeto = JSON.parse(result);

        if (objeto.existe) {
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

document.getElementById('btnCerrarCaja').onclick = () => {
    fetch('/Caja/CerrarCaja', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(_cajaSeleccionadaEliminar)
    })
    .then(response => response.json())
    .then(json => {
        if (json.finalizado){
            alert("Cerrada");
            ActualizarTabla();
        }else{
            alert("ERror al cerrar caja");
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

async function ObtenerDatosCaja(caja){
    return await fetch('/Caja/JsonCajaById', { 
        method:'POST',
        headers:{
            'Content-Type':'application/json'
        },
        body: JSON.stringify(caja)
    })
    .then(response => response.text());
}