namespace XCommerce.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Servicios.Interface.Articulos;
    using System.Collections.Generic;
    using System.Linq;
    using Servicios.Interface.ListaPrecios;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Servicios.Interface.Persona;
    using System.Threading.Tasks;
    using Servicios.Interface.Comprobante;
    using Clases.Utiles;
    using Servicios.Interface.DetalleComprobante;
    using Servicios.Interface.Caja;
    public class VentaController : Controller
    {
        private readonly IArticuloServicio _articuloServicio;
        private readonly IListaPrecioServicio _listaPrecioServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly IComprobanteServicio _comprobanteServicio;
        private readonly IDetalleComprobanteServicio _detalleComprobanteServicio;
        private readonly ICajaServicio _cajaServicio;
        public VentaController(IArticuloServicio articuloServicio, IListaPrecioServicio listaPrecioServicio,
        IClienteServicio clienteServicio, IComprobanteServicio comprobanteServicio,
        IDetalleComprobanteServicio detalleComprobanteServicio, ICajaServicio cajaServicio)
        {
            _articuloServicio = articuloServicio;
            _listaPrecioServicio = listaPrecioServicio;
            _clienteServicio = clienteServicio;
            _comprobanteServicio = comprobanteServicio;
            _detalleComprobanteServicio = detalleComprobanteServicio;
            _cajaServicio = cajaServicio;
        }

        [HttpGet]
        public async Task<IActionResult> NuevaVenta()
        {
            if (!IdentidadUsuarioLogin.EstaLogueado)
            {
                return RedirectToAction("Login", "Seguridad");
            }

            if (!_cajaServicio.ExisteCajaAbierta())
            {
                return BadRequest("Debe abrir una caja para poder realizar ventas");
            }

            var _selectListaPrecio = new List<SelectListItem>();
            var _selectClientes = new List<SelectListItem>();

            foreach (var item in _listaPrecioServicio.GetListaPrecios())
            {
                _selectListaPrecio.Add(new SelectListItem
                {
                    Text = item.Descripcion,
                    Value = item.Id.ToString()
                });
            }

            var clientes = (IEnumerable<ClienteDto>)_clienteServicio.Get(typeof(ClienteDto));

            foreach (var item in clientes.Where(x => x.ActivarCtaCte))
            {
                _selectClientes.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.ApyNom
                });
            }

            ViewBag.NumeroFactura = await _comprobanteServicio.ObtenerSiguienteNumeroComprobante();
            ViewBag.Clientes = _selectClientes;
            ViewBag.ListasPrecio = _selectListaPrecio;

            return View();
        }

        [HttpPost]
        public JsonResult BuscarArticulo([FromBody] ObjetoVenta venta)
        {
            var verificarLimite = VerificarLimite(venta.Cliente);

            if (verificarLimite.tieneLimite)
            {
                if (venta.totalFactura > verificarLimite.monto)
                {
                    return Json(new
                    {
                        limite = true,
                        limiteCliente = verificarLimite.monto
                    });
                }
            }

            return Json(new
            {
                articulo = _articuloServicio.GetByCodigo(venta.Codigo, venta.listaPrecio)
            });
        }

        [HttpPost]
        public async Task<JsonResult> Facturar([FromBody] Comprobante comprobante)
        {
            try
            {
                var totalFactura = comprobante.Items.Sum(x => x.Total * x.Cantidad) - comprobante.Descuento;

                if (comprobante.TotalPagar >= totalFactura)
                {
                    comprobante.EstadoComprobante = EstadoComprobante.Pagado;

                    var estado = await _comprobanteServicio.Facturar(comprobante);

                    return Json(new { finalizado = estado });
                }
                else
                {
                    return Json(new 
                    {
                        finalizado = false,
                        msg = "El monto a pagar debe ser mayor o igual al total de la factura..." 
                    });
                }
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }

        }

        public IActionResult MasVendidos()
        {
            ViewBag.Empleados = _comprobanteServicio.EmpleadosQueMasVendieron();

            return View(_detalleComprobanteServicio.MasVendidos());
        }
        private (bool tieneLimite, decimal monto) VerificarLimite(long cliente)
        {
            var clienteSeleccionado = (ClienteDto)_clienteServicio.GetById(typeof(ClienteDto), cliente);

            //return (clienteSeleccionado.TieneLimite, clienteSeleccionado.LimiteMonto);
            if (!clienteSeleccionado.TieneLimite) return(false, 0);

            return (true, clienteSeleccionado.LimiteMonto);
        }

        public class ObjetoVenta
        {
            public int Codigo { get; set; }
            public int listaPrecio { get; set; }
            public long Cliente { get; set; }
            public decimal totalFactura { get; set; }
        }
    }
}