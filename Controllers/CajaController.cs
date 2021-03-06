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

        [HttpPost]
        public JsonResult JsonCajaById([FromBody] long caja)
        {
            try
            {
                var cajita = _cajaServicio.GetById(caja);
                return Json(new { cajaSeleccionada = cajita } );
            }
            catch(System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        [HttpPost]
        public JsonResult CerrarCaja([FromBody] long caja)
        {
            var datosCaja = _cajaServicio.GetById(caja);

            var cajaCerrar = new Caja
            {
                UsuarioCierreId = IdentidadUsuarioLogin.UsuarioId,
                MontoCierre = datosCaja.TotalEfectivoEntrada,
                CuentaCorrienteEntrada = datosCaja.CuentaCorrienteEntrada,
                CuentaCorrienteSalida = datosCaja.CuentaCorrienteSalida,
                TotalEfectivoEntrada = datosCaja.TotalEfectivoEntrada,
                Id = caja
            };

            return Json(new { finalizado = _cajaServicio.CerrarCaja(cajaCerrar) });
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