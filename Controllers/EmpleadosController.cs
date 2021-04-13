namespace XCommerce.Controllers
{
    using System;
    using System.Collections.Generic;
    using Servicios.Interface.Persona;
    using Microsoft.AspNetCore.Mvc;
    using Servicios.Interface.Provincias;
    using Servicios.Interface.Localidad;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;
    using Servicios.Interface.Usuario;
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoServicio _empleadoServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly ILocalidadServicio _localidadServicio;
        private readonly IUsuarioServicio _usuarioServicio;
        public EmpleadosController(IEmpleadoServicio empleadoServicio, IProvinciaServicio provinciaServicio,
        ILocalidadServicio localidadServicio, IUsuarioServicio usuarioServicio)
        {
            _empleadoServicio = empleadoServicio;
            _provinciaServicio = provinciaServicio;
            _localidadServicio = localidadServicio;
            _usuarioServicio = usuarioServicio;
        }

        [HttpGet]
        public async Task<IActionResult> NuevoEmpleado()
        {
            var _selectProvincias = new List<SelectListItem>();
            var _selectLocalidades = new List<SelectListItem>();

            foreach (var provincia in await _provinciaServicio.GetProvincias())
            {
                _selectProvincias.Add(new SelectListItem
                {
                    Value = provincia.Id.ToString(),
                    Text = provincia.Descripcion
                });
            }

            foreach (var localidad in await _localidadServicio.GetLocalidades())
            {
                _selectLocalidades.Add(new SelectListItem
                {
                    Value = localidad.Id.ToString(),
                    Text = localidad.Descripcion
                });
            }

            ViewBag.Provincias = _selectProvincias;
            ViewBag.Localidades = _selectLocalidades;

            return View();
        }

        [HttpPost]
        public JsonResult NuevoEmpleado(EmpleadoDto empleado)
        {
            if (ModelState.IsValid)
            {
                _empleadoServicio.Add(empleado);
                return Json(new { finalizado = true });
            }
            
            return Json(new { finalizado = false });
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View((IEnumerable<EmpleadoDto>)_empleadoServicio.Get(typeof(EmpleadoDto)));
        }

        [HttpPost]
        public async Task<JsonResult> CrearUsuario([FromBody] List<EmpleadoDto> empleados)
        {
            var crearUsuarios = await _usuarioServicio.CrearUsuario(empleados);

            return Json(new {
                exitoso = crearUsuarios 
            });
        }
    }
}