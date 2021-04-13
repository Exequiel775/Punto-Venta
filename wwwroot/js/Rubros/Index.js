document.addEventListener('DOMContentLoaded', () => {
    ActualizarTabla();
});

document.querySelector('.btnGuardar').addEventListener('click', () => {
    AgregarRubro();
});

function ActualizarTabla(){
    let tabla = document.getElementById('bodyRubros');
    tabla.innerHTML = '';

    fetch('/Rubros/JsonRubros', {
        method:'POST'
    })
    .then(response => {
        if (response.status === 200){
            response.json()
            .then(json => {
                json.rubros.forEach((indice) => {
                    let row = tabla.insertRow();

                    row.innerHTML = `
                    <td>${indice.id}</td>
                    <td>${indice.descripcion}</td>
                    <td></td>
                    `

                    let btnEliminar = document.createElement('button');
                    btnEliminar.classList.add('btn', 'btn-danger');
                    btnEliminar.innerHTML = `<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                    <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"/>
                    <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4L4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/>
                    </svg>`;

                    row.children[2].appendChild(btnEliminar);
                });
            })
        }
    })
    .catch(error => {
        console.error(error.message);
    });
}

function AgregarRubro(){
    let rubro = document.getElementById('txtDescripcion').value;

    let data = new FormData();
    data.append('descripcion', rubro);

    fetch('/Rubros/AddRubro', {
        method:'POST',
        body:data
    })
    .then(response => {
        if (response.status === 200){
            response.json()
            .then(json => {
                if (json.finalizado){
                    ActualizarTabla();
                    LimpiarControles();
                }
            })
        }
    })
    .catch(error => {
        console.error(error.message);
    })
}

function LimpiarControles(){
    document.getElementById('txtDescripcion').value = '';
}