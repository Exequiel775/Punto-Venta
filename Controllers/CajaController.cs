namespace XCommerce.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Servicios.Interface.Caja;
    using Clases.Utiles;
    public class CajaController : Controller
    {
        private readonly ICajaServicio _cajaServicio;

        public CajaController(ICajaServicio cajaServicio)
        {
            VerificarSiEstaLogueado();
            _cajaServicio = cajaServicio;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AbrirCaja(decimal montoApertura)
        {
            try
            {
                var caja = new Caja
                {
                    UsuarioAperturaId = IdentidadUsuarioLogin.UsuarioId,
                    FechaApertura = System.DateTime.Now,
                    MontoApertura = montoApertura
                };

                var abrirCaja = _cajaServicio.AbrirCaja(caja);

                return Json(new { finalizado = abrirCaja });
            }
            catch
            {
                return Json(new { finalizado = false });
            }
        }

        [HttpPost]
        public JsonResult JsonCajas()
        {
            return Json(new { cajas = _cajaServicio.Get() });
        }

        [HttpGet]
        public JsonResult VerificarCajaAbierta()
        {
            return Json(new { existe = _cajaServicio.ExisteCajaAbierta() });
        }

        public IActionResult VerificarSiEstaLogueado()
        {
            if (!IdentidadUsuarioLogin.EstaLogueado)
            {
                return RedirectToAction("Login", "Seguridad");
            }

            return null;
        }

    }
}