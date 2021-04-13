namespace XCommerce.Controllers
{
    using Servicios.Interface.Localidad;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Servicios.Interface.Provincias;
    using Servicios.Interface.Persona;
    using Servicios.Implementacion.Persona;
    public class LocalidadesController : Controller
    {
        private readonly ILocalidadServicio _localidadServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly IEmpleadoServicio _empleadoServicio;

        public LocalidadesController(ILocalidadServicio localidadServicio, IProvinciaServicio provinciaServicio,
        IEmpleadoServicio empleadoServicio)
        {
            _localidadServicio = localidadServicio;
            _provinciaServicio = provinciaServicio;
            _empleadoServicio = empleadoServicio;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Provincias = await _provinciaServicio.GetProvincias();

            return View(await _localidadServicio.GetLocalidades());
        }

        [HttpPost]
        public async Task<JsonResult> JsonLocalidades()
        {
            return Json(new
            {
                localidades = await _localidadServicio.GetLocalidades()
            });
        }

        [HttpPost]
        public async Task<JsonResult> JsonLocalidadesProvincia(long provincia)
        {
            return Json(new 
                {
                    localidades = await _localidadServicio.GetLocalidades(provincia)
                }
            );
        }

        [HttpPost]
        public async Task<JsonResult> AgregarLocalidad([FromBody] Localidad localidad)
        {
            if (localidad.Descripcion == string.Empty || localidad.Descripcion == string.Empty){
                return Json(new { finalizado = false });
            }

            var estado = await _localidadServicio.Add(localidad);

            return Json(new 
            {
                finalizado = estado
            });
        }

        [HttpPost]
        public async Task<JsonResult> GetLocalidad(long localidad)
        {
            return Json(new 
            {
               loc = await _localidadServicio.GetById(localidad) 
            });
        }

        [HttpPut]
        public async Task<JsonResult> ModificarLocalidad([FromBody] Localidad localidad)
        {
            var estado = await _localidadServicio.Update(localidad);

            return Json(new 
            {
                finalizado = estado
            });
        }
    }
}