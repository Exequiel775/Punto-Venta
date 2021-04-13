namespace Servicios.Interface.Usuario
{
    using EntityBase;
    using System.ComponentModel.DataAnnotations;
    public class Usuario : Base
    {
        public long PersonaId { get; set; }
        [Required(ErrorMessage = "Por favor ingrese su usuario")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Por favor ingrese su contraseña")]
        public string Password { get; set; }
        public bool EstaBloqueado { get; set; }
        public string EstaBloqueadoStr => EstaBloqueado ? "SI" : "NO";

        // CAMPOS AL NAVEGAR A PERSONA
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public string ApyNomPersona => $"{ApellidoPersona}, {NombrePersona}";
    }
}