namespace XCommerce.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Servicios.Interface.Configuracion;
    using Clases.Utiles;
    using Servicios.Interface.Persona;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Servicios.Interface.Provincias;
    using System.Threading.Tasks;
    using System.Linq;
    using Servicios.Interface.ListaPrecios;
    public class ConfiguracionController : Controller
    {
        private readonly IConfiguracionServicio _configuracionServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly IListaPrecioServicio _listaPrecioServicio;
        public ConfiguracionController(IConfiguracionServicio configuracionServicio, 
        IClienteServicio clienteServicio, IProvinciaServicio provinciaServicio, IListaPrecioServicio listaPrecioServicio)
        {
            _configuracionServicio = configuracionServicio;
            _clienteServicio = clienteServicio;
            _provinciaServicio = provinciaServicio;
            _listaPrecioServicio = listaPrecioServicio;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!IdentidadUsuarioLogin.EstaLogueado)
            {
                return RedirectToAction("Login", "Seguridad");
            }

            var _selectClientes = new List<SelectListItem>();

            foreach(var item in (IEnumerable<ClienteDto>)_clienteServicio.Get(typeof(ClienteDto)))
            {
                _selectClientes.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.ApyNom
                });
            }

            ViewBag.Provincias = await ObtenerProvincias();
            ViewBag.Clientes = _selectClientes;
            ViewBag.ListasPrecios = ObtenerListasPrecios();

            return View(_configuracionServicio.Get() ?? new Configuracion());
        }

        [HttpPost]
        public IActionResult Index(Configuracion configuracion)
        {
            if (ModelState.IsValid)
            {
                _configuracionServicio.Add(configuracion);
                return RedirectToAction("Index", "Configuracion");
                //var operacionGrabar = _configuracionServicio.Add(configuracion);
                //return Json(new { finalizado = operacionGrabar });
            }

            return RedirectToAction("Index", "Configuracion");

            //return Json(new { finalizado = false });
        }

        [HttpPost]
        public JsonResult ObtenerConfiguracion()
        {
            return Json(new { configuracion = _configuracionServicio.Get() });
        }
        
        private async Task<IEnumerable<SelectListItem>> ObtenerProvincias()
        {
            var select = new List<SelectListItem>();

            var provincias = await _provinciaServicio.GetProvincias();

            foreach(var item in provincias)
            {
                select.Add(new SelectListItem
                {
                    Text = item.Descripcion,
                    Value = item.Id.ToString()
                });
            }

            return select;
        }

        private IEnumerable<SelectListItem> ObtenerListasPrecios()
        {
            var select = new List<SelectListItem>();

            foreach(var item in _listaPrecioServicio.GetListaPrecios())
            {
                select.Add(new SelectListItem
                {
                    Text = item.Descripcion,
                    Value = item.Id.ToString()
                });
            }

            return select;
        }
    }
}