namespace XCommerce.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Servicios.Interface.Rubros;
    public class RubrosController : Controller
    {
        private readonly IRubroServicio _rubroServicio;

        public RubrosController(IRubroServicio rubroServicio)
        {
            _rubroServicio = rubroServicio;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult JsonRubros()
        {
            return Json(new {
                rubros = _rubroServicio.GetRubros()
            });
        }

        [HttpPost]
        public JsonResult AddRubro(string descripcion)
        {
            var accion = _rubroServicio.Add(descripcion);

            return Json(new {
                finalizado = accion
            });
        }
    }
}