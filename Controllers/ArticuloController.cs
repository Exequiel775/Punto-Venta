namespace XCommerce.Controllers
{
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Servicios.Interface.Articulos;
    using Servicios.Interface.Rubros;
    using Servicios.Interface.Marca;
    using Servicios.Interface.Iva;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ArticuloController : Controller
    {
        private readonly IArticuloServicio _articuloServicio;
        private readonly IRubroServicio _rubroServicio;
        private readonly IMarcaServicio _marcaServicio;    
        private readonly IIvaServicio _ivaServicio;
        private readonly IWebHostEnvironment _env;
        public ArticuloController(IArticuloServicio articuloServicio, IWebHostEnvironment env,
        IRubroServicio rubroServicio, IMarcaServicio marcaServicio, IIvaServicio ivaServicio)
        {
            _articuloServicio = articuloServicio;
            _rubroServicio = rubroServicio;
            _marcaServicio = marcaServicio;
            _ivaServicio = ivaServicio;
            _env = env;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View(_articuloServicio.Get());
        }

        [HttpGet]
        public IActionResult NuevoArticulo()
        {
            try
            {
                var _selectMarcas = new List<SelectListItem>();
                var _selectRubros = new List<SelectListItem>();
                var _selectIvas = new List<SelectListItem>();

                // cargamos las marcas
                foreach (var item in _marcaServicio.Get())
                {
                    _selectMarcas.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.Descripcion
                    });
                }

                // cargamos los rubros
                foreach (var item in _rubroServicio.GetRubros())
                {
                    _selectRubros.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.Descripcion
                    });
                }

                // Cargamos IVAS
                foreach(var item in _ivaServicio.Get())
                {
                    _selectIvas.Add(new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.Descripcion
                    });
                }

                ViewBag.Marcas = _selectMarcas;
                ViewBag.Rubros = _selectRubros;
                ViewBag.Ivas = _selectIvas;

                return View();
            }
            catch
            {
                return BadRequest("No se pudo cargar la pagina...");
            }
        }

        [HttpPost]
        public IActionResult NuevoArticulo(Articulo articulo, IFormFile imagen)
        {
            try
            {
                var fileName = imagen.FileName;

                var logoPath = Path.Combine(_env.WebRootPath, "Imagenes-Articulo");

                using (var fileStream = new FileStream(Path.Combine(logoPath, fileName), FileMode.Create))
                {
                    imagen.CopyTo(fileStream);
                }

                articulo.Foto = $"~/Imagenes-Articulo/{fileName}";

                _articuloServicio.Add(articulo);

                return RedirectToAction("NuevoArticulo", "Articulo");
            }
            catch
            {
                throw new System.Exception("Error al cargar el articulo...");
            }
        }
    }
}