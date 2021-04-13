namespace XCommerce.Controllers
{
    using System.Threading.Tasks;
    using Servicios.Interface.Persona;
    using Microsoft.AspNetCore.Mvc;
    using Servicios.Interface.Provincias;
    using System.Linq;
    using System.Collections.Generic;
    using Servicios.Interface.Comprobante;
    using Servicios.Interface.DetalleComprobante;
    using System;
    using Rotativa;

    public class ClientesController : Controller
    {
        private readonly IClienteServicio _clienteServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly IComprobanteServicio _comprobanteServicio;
        private readonly IDetalleComprobanteServicio _datalleComprobanteServicio;

        public ClientesController(IClienteServicio clienteServicio, IProvinciaServicio provinciaServicio,
        IComprobanteServicio comprobanteServicio, IDetalleComprobanteServicio detalleComprobanteServicio)
        {
            _clienteServicio = clienteServicio;
            _provinciaServicio = provinciaServicio;
            _comprobanteServicio = comprobanteServicio;
            _datalleComprobanteServicio = detalleComprobanteServicio;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Provincias = await _provinciaServicio.GetProvincias();

            return View();
        }

        [HttpGet]
        public IActionResult Todos()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AgregarCliente(ClienteDto cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] campos = { cliente.Nombre, cliente.Apellido, cliente.Direccion };

                    _clienteServicio.Add(cliente);

                    return Json(new
                    {
                        finalizado = true
                    });
                }
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }

            return Json(new
            {
                finalizado = false
            });
        }

        [HttpGet]
        public IActionResult NuevoCliente()
        {
            return View();
        }

        [HttpGet]
        [Route("/Clientes/MisComprobantes/{cliente}/")]
        public async Task<IActionResult> Comprobantes(long cliente)
        {
            var comprobantes = await _comprobanteServicio.GetByCliente(cliente);

            var servicioDetalle = _datalleComprobanteServicio;

            ViewBag.Detalle = servicioDetalle;

            return View(comprobantes.Any() ?
            comprobantes.OrderBy(x => x.Numero).ToList()
            : new List<Comprobante>());
        }

        [HttpGet]
        public async Task<IActionResult> ImprimirComprobante(long comprobante)
        {
            return new Rotativa.AspNetCore.ViewAsPdf("ImprimirComprobante", await _comprobanteServicio.GetById(comprobante))
            {
                PageSize = Rotativa.AspNetCore.Options.Size.A4
                //FileName = "impresiones/comprobante/" + comprobante + ".pdf"
            };
        }

        [HttpGet]
        [Route("/Clientes/DatosCliente/{cliente}")]
        public IActionResult DatosCliente(long cliente)
        {
            var clienteEncontrado = (ClienteDto)_clienteServicio.GetById(typeof(ClienteDto), cliente);
            return View(clienteEncontrado);
        }

        // ========================== POSTS ========================= //
        [HttpPost]
        public JsonResult JsonClientes()
        {
            return Json(new
            {
                clientes = _clienteServicio.Get(typeof(ClienteDto))
            });
        }

        [HttpPost]
        public async Task<JsonResult> ActivarDesactivarCuentas([FromBody] List<ClienteDto> clientes)
        {
            try
            {    
                await _clienteServicio.ActivarDesactivarCuenta(clientes);

                return Json(new { finalizado = true });
            }
            catch
            {
                return Json(new { finalizado = false });
            }
        }

        [HttpPost]
        public JsonResult GetClientes()
        {
            var clientes = (IEnumerable<ClienteDto>)_clienteServicio.Get(typeof(ClienteDto));

            return Json(new
            {
                lista = clientes.OrderBy(x => x.ApyNom).ToList()
            });
        }

        [HttpPost]
        public async Task<JsonResult> ComprobantesCliente(long cliente)
        {
            var comprobantes = await _comprobanteServicio.GetByCliente(cliente);

            return Json(new
            {
                facturas = comprobantes.Any() ?
               comprobantes.OrderBy(x => x.Numero).ToList()
               : new List<Comprobante>()
            });
        }

        [HttpPost]
        public async Task<JsonResult> DetalleComprobante(long comprobante)
        {
            var detalle = await _datalleComprobanteServicio.GetByCompropante(comprobante);
            return Json(new { detalles = detalle });
        }

        private (bool, string) CamposValidos(string[] datos)
        {
            for (int i = 0; i < datos.Length; i++)
            {
                if (datos[i] == null) return (false, datos[i]);
            }

            return (true, string.Empty);
        }
    }
}