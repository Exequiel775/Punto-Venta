namespace XCommerce.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Servicios.Interface.Usuario;
    using System.Threading.Tasks;
    using Clases.Utiles;
    using System.Collections.Generic;
    using System.Linq;

    public class SeguridadController : Controller
    {
        private readonly IUsuarioServicio _usuarioServicio;

        public SeguridadController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var verificarExistencia = await _usuarioServicio.VerificarAcceso(usuario.Nombre, usuario.Password);

                if (verificarExistencia)
                {
                    if (await _usuarioServicio.VerificarBloqueo(usuario.Nombre))
                    {
                        ModelState.AddModelError("inexistente", $"El usuario {usuario.Nombre} se encuentra bloqueado.");
                        return View();
                    }

                    var datosUsuario = await _usuarioServicio.GetByUser(usuario.Nombre);

                    IdentidadUsuarioLogin.EstaLogueado = true;
                    IdentidadUsuarioLogin.EmpleadoId = datosUsuario.PersonaId;
                    IdentidadUsuarioLogin.UsuarioId = datosUsuario.Id;
                    IdentidadUsuarioLogin.Nombre = datosUsuario.NombrePersona;
                    IdentidadUsuarioLogin.Apellido = datosUsuario.ApellidoPersona;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("inexistente", "Usuario y/o contraseña incorrectos.");
                    return View();
                }
            }

            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Usuarios()
        {
            if (!IdentidadUsuarioLogin.EstaLogueado)
            {
                return RedirectToAction("Login", "Seguridad");
            }

            return View(await _usuarioServicio.Get());
        }

        [HttpPost]
        public async Task<JsonResult> JsonUsuarios()
        {
            var users = await _usuarioServicio.Get();

            return Json(new { usuarios = users.OrderBy(x => x.Nombre).ToList() } );
        }

        [HttpPut]
        public async Task<JsonResult> AccionUsuarios([FromBody] List<Usuario> usuarios)
        {
            var accionBloquear = await _usuarioServicio.BloquearUsuarios(usuarios);

            return Json(new { finalizado = accionBloquear });
        }
    }
}