document.addEventListener('DOMContentLoaded', () => {
    ActualizarTabla();
});

document.getElementById('btnGrabar').addEventListener('click', () => {
    GrabarNuevaListaPrecio();
});

function ActualizarTabla(){
    let tabla = document.getElementById('body-tabla');
    // Formateamos la tabla para no repetir datos
    tabla.innerHTML = '';
    fetch('/ListasPrecio/JsonListasPrecio', { method:'POST' })
    .then(response => {
        if (response.status === 200){
            response.json()
            .then(json => {
                json.listasPrecio.forEach((indice) => {
                    let row = tabla.insertRow();
                    row.innerHTML = `
                    <td>${indice.descripcion}</td>
                    <td>${indice.porcentaje}%</td>
                    `
                });
            })
            .catch(error => {
                console.error(error.message);
            })
        } else {return;}
    })
}

function GrabarNuevaListaPrecio(){

    let descripcion = document.getElementById('txtDescripcion').value;
    let porcentaje = document.getElementById('porcentaje').value;

    let objetoLista = {
        Descripcion: descripcion,
        Porcentaje: porcentaje
    }

    fetch('/ListasPrecio/AgregarLista', {
        method:'POST',
        headers:{
            'Content-Type':'application/json'
        },
        body:JSON.stringify(objetoLista)
    })
    .then(response => {
        if (response.status === 200){
            response.json()
            .then(json => {
                if (json.estado){
                    LimpiarControles();
                    ActualizarTabla();
                }else{
                    alert("No se pudo grabar la lista de precio");
                }
            })
            .catch(error => {
                console.log(error.message);
            })
        }
    })
}

function LimpiarControles(){
    let descrip = document.getElementById('txtDescripcion');

    descrip.value = '';
    document.getElementById('porcentaje').value = '';
    descrip.focus();
}