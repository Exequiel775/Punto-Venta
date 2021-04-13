document.addEventListener('DOMContentLoaded', () => {
    ActualizarTabla();
});

document.querySelector('.agregarProvincia').addEventListener('click', () => {
    AgregarProvincia();
});

function ActualizarTabla(){
    let tabla = document.getElementById('body-provincias');
    tabla.innerHTML = '';
    
    fetch('/Provincias/JsonProvincias', {
        method:'POST'
    })
    .then(response => {
        if (response.status === 200){
            response.json()
            .then(json => {
                json.provincias.forEach((indice) => {
                    let row = tabla.insertRow();

                    row.innerHTML = `
                    <td>${indice.descripcion}</td>
                    `
                });
            })
        }
    })
    .catch((error) => {
        console.error(error.message);
    })
}

function AgregarProvincia(){
    let provincia = document.getElementById('descripcion').value;

    let data = new FormData();
    data.append('descripcion', provincia);

    fetch('/Provincias/AgregarProvincia', { method:'POST', body: data })
    .then(response => {
        if (response.status === 200){
            response.json()
            .then(json => {
                if (json.finalizado){
                    ActualizarTabla();
                }else{
                    alert("Se ah producido un error al agregar la provincia.");
                }
            })
        }
    })
    .catch((error) => {
        console.error(error.message);
    })
}