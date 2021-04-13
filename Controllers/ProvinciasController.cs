namespace XCommerce.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Servicios.Interface.Provincias;
    public class ProvinciasController : Controller
    {
        private readonly IProvinciaServicio _provinciaServicio;

        public ProvinciasController(IProvinciaServicio provinciaServicio)
        {
            _provinciaServicio = provinciaServicio;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> JsonProvincias()
        {
            return Json(new 
            {
                provincias = await _provinciaServicio.GetProvincias()
            });
        }

        [HttpPost]
        public async Task<JsonResult> AgregarProvincia(string descripcion)
        {
            var estado = await _provinciaServicio.Add(descripcion);

            return Json(new {
                finalizado = estado
            });
        }
    }
}