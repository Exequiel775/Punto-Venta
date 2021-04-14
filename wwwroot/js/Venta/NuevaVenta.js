var _listaArticulos = new Array();

document.addEventListener('DOMContentLoaded', () => {
    ActualizarTotal();
    CargarConfiguracion();
});

document.getElementById('txtCodigo').addEventListener('keyup', (e) => {
    let tecla = e.keyCode || e.which;

    if (tecla === 13) {
        BuscarArticulo();
    }
});

document.getElementById('pagaCon').addEventListener('keyup', (e) => {
    let tecla = e.keyCode || e.which;

    if (tecla === 13) {
        let vuelto = CalcularVuelto(parseFloat(ObtenerSubTotal()), parseFloat(e.target.value));

        document.getElementById('vuelto').value = vuelto.toFixed(2);
    }
});

document.getElementById('descuento').addEventListener('change', (e) => {
    let descuento = e.target.value;
    ActualizarTotal();
    /*
    console.log(CalcularDescuento(descuento).toFixed(2));

    let vistaTotal = document.getElementById('sub-total');

    vistaTotal.textContent = CalcularDescuento(descuento).toFixed(2);
    */
});

document.getElementById('cmbTipoPago').onchange = (e) => {
    alert(e.target.value);
}

const CalcularDescuento = (descuento) => {
    let total = ObtenerSubTotal();
    let totalParseado = parseFloat(total).toFixed(2);

    return (totalParseado * descuento / 100).toFixed(2);
}

document.getElementById('facturar').addEventListener('click', () => { Facturar(); });

function BuscarArticulo() {
    let codigo = document.getElementById('txtCodigo').value;

    if (VerificarExistenciaArray(codigo)) {
        AgregarArticuloGrilla();
        return;
    }

    let tabla = document.getElementById('body-venta');
    let listaPrecio = parseInt(document.getElementById('cmbListaPrecio').value);
    let cliente = document.getElementById('cmbCliente').value;
    let total = ObtenerSubTotal();

    let venta = {
        Codigo: codigo,
        listaPrecio: listaPrecio,
        cliente: cliente,
        totalFactura: total
    }

    /*
    let data = new FormData();
    data.append('codigo', codigo);
    data.append('listaPrecio', listaPrecio);
    data.append('cliente', cliente);
    data.append('totalFactura', parseFloat(total));
    data.append('facturita', parseFloat(total));*/

    fetch('/Venta/BuscarArticulo', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(venta)
    })
        .then(response => {
            if (response.status === 200) {
                response.json()
                    .then(json => {

                        if (json.articulo === null) {
                            alert("El articulo no existe.");
                            return;
                        }

                        if (json.limite) {
                            alert("El cliente tiene un limite de venta de $" + json.limiteCliente);
                            return;
                        }

                        let articulo = {
                            Codigo: json.articulo.codigo,
                            CodigoBarra: json.articulo.codigoBarra,
                            Descripcion: json.articulo.descripcion,
                            TotalIva: json.articulo.totalIva,
                            Cantidad: 1,
                            PrecioPublico: json.articulo.precioPublico,
                            Total: json.articulo.total
                        }

                        _listaArticulos.push(articulo);

                        AgregarArticuloGrilla();
                    });
                /*

                let row = tabla.insertRow();

                row.setAttribute('id', json.articulo.id);

                row.innerHTML = `
        <td>${json.articulo.codigo}</td>
        <td>${json.articulo.codigoBarra}</td>
        <td>${json.articulo.descripcion}</td>
        <td>${json.articulo.totalIva}</td>
        <td>${json.articulo.precioPublico}</td>
        <td>${json.articulo.total}</td>
        <td></td>
        `

                let btnEliminarItem = document.createElement('button');
                btnEliminarItem.classList.add('btn', 'btn-danger');
                btnEliminarItem.textContent = 'D';
                btnEliminarItem.value = json.articulo.id;
                btnEliminarItem.addEventListener('click', (e) => {
                    EliminarItemGrilla(e.target.value);
                    ActualizarTotal();
                });

                row.children[6].appendChild(btnEliminarItem);

                ActualizarTotal();
                LimpiarControles();
            })

        console.log(_listaArticulos);
        */

            }
        })
        .catch(error => {
            console.log(error.message);
        })

}

function AgregarArticuloGrilla() {

    let tabla = document.getElementById('body-venta');
    tabla.innerHTML = '';

    _listaArticulos.forEach((articulo) => {
        let row = tabla.insertRow();

        row.setAttribute('id', articulo.Id);

        row.innerHTML = `
        <td>${articulo.Codigo}</td>
        <td>${articulo.CodigoBarra}</td>
        <td>${articulo.Descripcion}</td>
        <td>${articulo.TotalIva}</td>
        <td>${articulo.Cantidad}</td>
        <td>${articulo.PrecioPublico}</td>
        <td>${articulo.Total}</td>
        <td></td>
        `

        let btnEliminarItem = document.createElement('button');
        btnEliminarItem.classList.add('btn', 'btn-danger', 'm-1');
        btnEliminarItem.innerHTML = `
        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="18" fill="currentColor" class="bi bi-x-square-fill" viewBox="0 0 16 16">
        <path d="M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2zm3.354 4.646L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 1 1 .708-.708z"/>
        </svg>
        `
        btnEliminarItem.value = articulo.Codigo;
        btnEliminarItem.title = 'Eliminar Articulo de la lista';
        btnEliminarItem.addEventListener('click', (e) => {
            if (EliminarItemGrilla(e.target.value)) {
                ActualizarTotal();
            }
        });

        let btnCambiarCantidad = document.createElement('button');
        btnCambiarCantidad.classList.add('btn', 'btn-warning', 'm-1');
        btnCambiarCantidad.value = articulo.Codigo;
        btnCambiarCantidad.title = 'Cambiar Cantidad';
        btnCambiarCantidad.innerHTML = `
        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="18" fill="currentColor" class="bi bi-plus" viewBox="0 0 16 16">
        <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z"/>
        </svg>
        `
        btnCambiarCantidad.onclick = (e) => {
            $('#modal-cantidad').modal('show');
            $('#modal-cantidad').show('fast');
            CargarCantidadActual(e.target.value);
        }

        row.children[7].appendChild(btnCambiarCantidad);
        row.children[7].appendChild(btnEliminarItem);

        ActualizarTotal();
        LimpiarControles();
    })
}

const VerificarExistenciaArray = (codigo) => {
    let articuloBuscar = _listaArticulos.find((art) => art.Codigo === parseInt(codigo));

    if (articuloBuscar !== undefined) {
        articuloBuscar.Cantidad += 1;
        return true;
    }

    return false;
}

function ActualizarTotal() {
    let subTotal = 0;
    let cantidad = 0;

    $('#body-venta tr').each(function () {
        let row = $(this);

        cantidad = parseInt(row.find('td').eq(4).text());

        subTotal += parseFloat(row.find('td').eq(6).text() * cantidad);
    });

    document.getElementById('sub-total').textContent = '$' + subTotal.toFixed(2);

    let descuento = CalcularDescuento(document.getElementById('descuento').value);
    let total = parseFloat(subTotal - descuento).toFixed(2);

    document.getElementById('total').textContent = '$' + total;
}

function ObtenerSubTotal() {
    let total = 0;
    let cantidad = 0;
    $('#body-venta tr').each(function () {
        let row = $(this);

        cantidad = parseInt(row.find('td').eq(4).text());
        total += parseFloat(row.find('td').eq(6).text() * cantidad);
    });

    return total.toFixed(2);
}

function LimpiarControles() {
    let codigo = document.getElementById('txtCodigo');
    codigo.value = '';
    codigo.focus();
}

function Facturar() {
    /*
    let array = new Array();

    $('#body-venta tr').each(function () {
        let row = $(this);

        let articulo = {
            Codigo: parseInt(row.find('td').eq(0).text()),
            CodigoBarra: parseInt(row.find('td').eq(1).text()),
            Descripcion: row.find('td').eq(2).text(),
            TotalIva: parseFloat(row.find('td').eq(3).text()),
            PrecioPublico: parseFloat(row.find('td').eq(4).text()),
            Total: parseFloat(row.find('td').eq(5).text())
        }

        array.push(articulo);
    });*/

    let tipoComprobante = parseInt(document.getElementById('cmbTipoComprobante').value);
    let totalPagar = parseFloat(document.getElementById('pagaCon').value).toFixed(2);
    let descuento = parseFloat(CalcularDescuento(document.getElementById('descuento').value)).toFixed(2);
    let tipoPago = parseInt(document.getElementById('cmbTipoPago').value);

    let comprobante = {
        ClienteId: document.getElementById('cmbCliente').value,
        Numero: document.getElementById('numero').value,
        TipoComprobante: tipoComprobante,
        Descuento: descuento,
        TotalPagar: totalPagar,
        TipoPago: tipoPago,
        Items: _listaArticulos
    }

    fetch('/Venta/Facturar', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(comprobante)
    })
        .then(response => response.json())
        .then(json => {

            if (!json.finalizado) {
                alert(json.msg);
                return;
            }

            if (json.finalizado) {
                //array.length = 0;
                window.location.reload(true);
            } else {
                alert("Ocurrio un error al facturar los productos...");
            }
        })
        .catch((error) => {
            console.log(error.message);
        });
}

function EliminarItemGrilla(id) {
    /*
    let itemElimiar = document.getElementById(id);
    itemElimiar.remove();*/
    try 
    {
        Swal.fire({
            title: '¿Desea Eliminar el articulo de la lista?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Eliminar',
            cancelButtonText: 'Cancelar'
        })
            .then((result) => {
                if (result.isConfirmed) {
                    let objetoEliminar = _listaArticulos.find((code) => code.Codigo === parseInt(id));

                    var i = _listaArticulos.indexOf(objetoEliminar);

                    _listaArticulos.splice(i, 1);

                    AgregarArticuloGrilla();

                    Swal.fire(
                        'Eliminado',
                        'El articulo se elimino exitosamente',
                        'success'
                    )

                    return true;
                }
            })
    }
    catch {
        return false;
    }
}

function FormatearGrilla() {
    document.getElementById('body-venta').innerHTML = '';
    ActualizarTotal();
}

const CalcularVuelto = (totalPagar, paga) => {
    console.log(`Paga con: ${paga}, total a pagar: ${totalPagar}`);
    return paga - totalPagar;
}

function CalcularTotal() {
    let subTotal = ObtenerSubTotal();

    let descuentoParseado = document.getElementById('descuento').value;
    let descuento = CalcularDescuento(descuentoParseado);

    return parseFloat(subTotal - descuento).toFixed(2);
}

// ====================== CAMBIO DE CANTIDAD ================ //
const CargarCantidadActual = (codigoArticulo) => {
    try 
    {
        const inputCantidad = document.getElementById('txtNuevaCantidad');

        let articuloSeleccionado = _listaArticulos.find((x) => x.Codigo === parseInt(codigoArticulo));

        inputCantidad.value = parseInt(articuloSeleccionado.Cantidad);

        document.getElementById('cambiarCantidad').onclick = () => {
            articuloSeleccionado.Cantidad = parseInt(inputCantidad.value);
            AgregarArticuloGrilla();
            $('#modal-cantidad').modal('hide');
            $('#modal-cantidad').hide('fast');
        }
    }
    catch(error)
    {
        alert(error);
    }
}
// =========================================================== //

function CargarConfiguracion() {
    const cmbCliente = document.getElementById('cmbCliente');
    const cmbListaPrecio = document.getElementById('cmbListaPrecio');

    fetch('/Configuracion/ObtenerConfiguracion', { method: 'POST' })
        .then(response => {
            if (response.status === 200) {
                response.json()
                    .then(json => {
                        cmbCliente.value = json.configuracion.clientePorDefectoId;
                        cmbListaPrecio.value = json.configuracion.listaPrecioPorDefectoId;
                    })
            }
        })
}