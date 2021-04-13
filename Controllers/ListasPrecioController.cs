namespace XCommerce.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Servicios.Interface.ListaPrecios;
    using Servicios.Interface.Marca;
    public class ListasPrecioController : Controller
    {
        private readonly IListaPrecioServicio _listaPrecioServicio;

        public ListasPrecioController(IListaPrecioServicio listaPrecioServicio)
        {
            _listaPrecioServicio = listaPrecioServicio;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult JsonListasPrecio()
        {
            return Json(new
            {
               listasPrecio = _listaPrecioServicio.GetListaPrecios() 
            });
        }

        [HttpPost]
        public JsonResult AgregarLista([FromBody] ListaPrecio listaPrecio)
        {
            var finalizado = _listaPrecioServicio.Add(listaPrecio);

            return Json(new
            {
                estado = finalizado
            });
        }

        [HttpGet]
        public IActionResult NuevaMarca()
        {
            return View(new Marca());
        }

        [HttpPost]
        public IActionResult NuevaMarca(Marca marca)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "ListasPrecio");
            }

            return View(marca);
        }
    }
}