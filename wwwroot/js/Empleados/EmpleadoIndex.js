const botonModificar = document.querySelectorAll('.btnModificar');

botonModificar.forEach((boton) => {
    boton.addEventListener('click', (e) => {
        alert("ID: " + e.target.value);
    });
});

const crearUser = document.getElementById('btnCrearUsuario');

crearUser.onclick = () => {
    let empleados = [];

    $('#tabla-empleados tr td input[type="checkbox"]:checked').each(function(){
        let row = $(this).closest('tr');

        let objEmpleado = {
            Id: parseInt(row.find('td').eq(0).text()),
            Nombre: row.find('td').eq(1).text(),
            Apellido: row.find('td').eq(2).text()
        }

        empleados.push(objEmpleado);
    });

    fetch('/Empleados/CrearUsuario', {
        method:'POST',
        headers:{
            'Content-Type':'application/json'
        },
        body:JSON.stringify(empleados)
    })
    .then(response => response.json())
    .then(json => {
        if (json.exitoso){
            alert("Creado");
        }else{
            alert("Error al crear");
        }
    })
}