const btnDetalle = document.querySelectorAll('.verDetalle');

    const detalleDefault = `
        <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" fill="currentColor"
        class="bi bi-chevron-right" viewBox="0 0 16 16">
        <path fill-rule="evenodd"
        d="M4.646 1.646a.5.5 0 0 1 .708 0l6 6a.5.5 0 0 1 0 .708l-6 6a.5.5 0 0 1-.708-.708L10.293 8 4.646 2.354a.5.5 0 0 1 0-.708z" />
        </svg>`
            
        const detallePresionado = `<svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" fill="currentColor" class="bi bi-chevron-down" viewBox="0 0 16 16">'
        '<path fill-rule="evenodd" d="M1.646 4.646a.5.5 0 0 1 .708 0L8 10.293l5.646-5.647a.5.5 0 0 1 .708.708l-6 6a.5.5 0 0 1-.708 0l-6-6a.5.5 0 0 1 0-.708z"/>
        '</svg>`

    btnDetalle.forEach((boton) => {
        boton.addEventListener('click', (e) => {
            const detalleMostrar = document.getElementById(e.target.value);

            if (boton.innerHTML !== detallePresionado){
                boton.innerHTML = detallePresionado;
            }else{
                boton.innerHTML = detalleDefault;
            }

            if (detalleMostrar.style.display === 'none') {
                detalleMostrar.style.display = 'block';
            } else {
                detalleMostrar.style.display = 'none';
            }

        });
    });

    function MostrarDetalleComprobante(comprobante) {

        const tabla = document.getElementById('body-detalle');

        let data = new FormData();
        data.append('comprobante', comprobante);

        fetch('/Clientes/DetalleComprobante', {
            method: 'POST',
            body: data

        })
            .then(resp => resp.json())
            .then(json => {
                json.detalles.forEach((indice) => {
                    let row = tabla.insertRow();

                    row.innerHTML = `
                <td>${indice.id}</td>
                <td>${indice.codigo}</td>
                <td>${indice.descripcion}</td>
                <td>$${indice.total}</td>
                `
                });
            })

    }