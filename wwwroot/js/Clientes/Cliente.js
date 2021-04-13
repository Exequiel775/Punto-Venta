document.addEventListener('DOMContentLoaded', () => {
    CargarClientes();
});

document.getElementById('btbActDesacCta').addEventListener('click', () => {
    let clientes = [];
    $('#tabla tr td input[type="checkbox"]:checked').each(function () {
        let row = $(this).closest('tr');

        let cliente = {
            Id: parseInt(row.find('td').eq(0).text()),
            ApyNom: row.find('td').eq(1).text()
        }

        clientes.push(cliente);
    });

    fetch('/Clientes/ActivarDesactivarCuentas', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(clientes)
    })
        .then(response => {
            if (response.status === 200) {
                response.json()
                    .then(json => {
                        if (json.finalizado) {
                            CargarClientes();
                            return;
                        }
                    })
            } else {
                alert("Error al desactivar/activar las cuentas...");
            }
        })
        .catch((error) => {
            console.log(error.message);
        })
});

function CargarClientes() {

    const tabla = document.getElementById('tabla');
    tabla.innerHTML = '';

    fetch('/Clientes/GetClientes',
        {
            method: 'POST'
        })
        .then(response => {
            if (response.status === 200) {
                response.json()
                    .then(json => {
                        json.lista.forEach((indice) => {
                            let row = tabla.insertRow();

                            row.innerHTML = `
                            <td>${indice.id}</td>
                            <td>${indice.apyNom}</td>
                            <td>${indice.tieneCtaCteStr}</td>
                            <td>${indice.tieneLimiteStr}</td>
                            <td>${indice.limiteMonto}</td>
                            <td></td>
                            <td></td>
                            `

                            let chk = document.createElement('input');
                            chk.type = 'checkbox';

                            let btnCtaCte = document.createElement('button');
                            btnCtaCte.title = 'Cuenta Corriente';
                            btnCtaCte.classList.add('btn', 'btn-primary');
                            btnCtaCte.value = indice.id;
                            btnCtaCte.innerHTML = `
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="18" fill="currentColor" class="bi bi-card-list" viewBox="0 0 16 16">
                            <path d="M14.5 3a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-13a.5.5 0 0 1-.5-.5v-9a.5.5 0 0 1 .5-.5h13zm-13-1A1.5 1.5 0 0 0 0 3.5v9A1.5 1.5 0 0 0 1.5 14h13a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2h-13z"/>
                            <path d="M5 8a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7A.5.5 0 0 1 5 8zm0-2.5a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5zm0 5a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5zm-1-5a.5.5 0 1 1-1 0 .5.5 0 0 1 1 0zM4 8a.5.5 0 1 1-1 0 .5.5 0 0 1 1 0zm0 2.5a.5.5 0 1 1-1 0 .5.5 0 0 1 1 0z"/>
                            </svg>
                            `
                            btnCtaCte.onclick = (e) => {
                                console.log(e.target.value);
                                window.location.href = '/Clientes/MisComprobantes/' + e.target.value;
                            }

                            // BOTON MODIFICAR
                            let btnModificar = document.createElement('button');
                            btnModificar.title = "Modificar";
                            btnModificar.value = indice.id;
                            btnModificar.classList.add('btn', 'btn-danger');
                            btnModificar.innerHTML = `
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                            <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                            </svg>
                            `
                            btnModificar.onclick = function(e){
                                window.location.href = "/Clientes/DatosCliente/" + e.target.value;
                            }

                            row.children[5].appendChild(chk);
                            row.children[6].appendChild(btnCtaCte);
                            row.children[6].appendChild(btnModificar);
                        })
                    })
            } else {
                alert("No se pudieron cargar los clientes...");
            }
        })
        .catch((error) => {
            console.log(error.message);
        });
}