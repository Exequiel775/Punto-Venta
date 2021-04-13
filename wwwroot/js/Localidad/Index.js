let _localidadSeleccionada = -1;

document.addEventListener('DOMContentLoaded', () => {
    ActualizarTabla();
});

document.querySelector('.btnGuardar').addEventListener('click', () => {
    AgregarLocalidad();
});

document.querySelector('.btnModificar').addEventListener('click', () => {
    RealizarModificacion();
});

function ActualizarTabla() {
    let tabla = document.getElementById('tabla-localidades');

    tabla.innerHTML = '';

    fetch('/Localidades/JsonLocalidades', { method: 'POST' })
        .then(response => {
            if (response.status === 200) {
                response.json()
                    .then(json => {
                        json.localidades.forEach((indice) => {
                            let row = tabla.insertRow();

                            row.innerHTML = `
                           <td>${indice.descripcion}</td>
                           <td>${indice.provincia}</td>
                           <td></td>
                           `

                            let btnModificar = document.createElement('button');
                            btnModificar.classList.add('btn', 'btn-primary');
                            btnModificar.innerHTML = `
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456l-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                            <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                            </svg>
                            `
                            btnModificar.value = indice.id;

                            btnModificar.onclick = function (e) {
                                OpenModal();
                                ObtenerDatosLocalidad(e.target.value);
                                _localidadSeleccionada = e.target.value;
                            }

                            row.children[2].appendChild(btnModificar);
                        });
                    })
            }
        })
        .catch((error) => {
            console.log(error.message);
        })
}

function OpenModal() {
    $('#modalLocalidad').modal('show');
    $('#modalLocalidad').show('fast');
}

function AgregarLocalidad() {

    let obj = {
        ProvinciaId: document.getElementById('cmbProvincia').value,
        Descripcion: document.getElementById('txtDescripcion').value
    }

    fetch('/Localidades/AgregarLocalidad',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(obj)
        })
        .then(response => {
            if (response.status === 200) {
                response.json()
                    .then(json => {
                        if (json.finalizado) {
                            ActualizarTabla();
                        }
                        else {
                            alert("No se pudo agregar la localidad");
                        }
                    })
            }
        })
        .catch((error) => {
            console.log(error.message);
        });
}

const ObtenerDatosLocalidad = (localidad) => {
    let data = new FormData();
    data.append('localidad', localidad);

    fetch('/Localidades/GetLocalidad', {
        method: 'POST',
        body: data
    })
        .then(response => {
            if (response.status === 200) {
                response.json()
                    .then(json => {
                        document.getElementById('descripcionLocalidad').value = json.loc.descripcion;
                        CargarProvincias(json.loc.provinciaId);
                    })
            } else {
                alert("No se pudo obtener los datos de la localidad");
            }
        })
        .catch((error) => {
            console.log(error.message);
        })
}

function CargarProvincias(provincia) {

    let select = document.getElementById('cmbNuevaProvincia');
    select.innerHTML = '';

    fetch('/Provincias/JsonProvincias', { method: 'POST' })
        .then(response => {
            if (response.status === 200) {
                response.json()
                    .then(json => {
                        json.provincias.forEach((indice) => {
                            let option = document.createElement('option');

                            option.text = indice.descripcion;
                            option.value = indice.id;

                            select.add(option);
                        });

                        select.value = provincia;
                    })
            }
        })
}

function RealizarModificacion(){
    let descripcion = document.getElementById('descripcionLocalidad').value;
    let provincia = document.getElementById('cmbNuevaProvincia').value;

    let obj = {
        Id: _localidadSeleccionada,
        ProvinciaId: provincia,
        Descripcion: descripcion
    }

    fetch('/Localidades/ModificarLocalidad',{
        method:'PUT',
        headers:{
            'Content-Type':'application/json'
        },
        body:JSON.stringify(obj)
    })
    .then(response => {
        if (response.status === 200){
            response.json()
            .then(json => {
                if (json.finalizado){
                    $('#modalLocalidad').modal('hide');
                    $('#modalLocalidad').hide('fast');
                    ActualizarTabla();
                }
                else{
                    alert("Error al modificar la localidad");
                }
            })
        }
    })
    .catch((er) => {
        console.log(er.message);
    })
}