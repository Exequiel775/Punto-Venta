namespace Servicios.Interface.Persona
{
    using System.ComponentModel.DataAnnotations;
    using EntityBase;
    public class PersonaDto : Base
    {
        [Required(ErrorMessage = "Por favor seleccione una localidad.")]
        public long LocalidadId { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Por favor ingrese su DNI")]
        public int Dni { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Direccion { get; set; }
        public string ApyNom => $"{Apellido}, {Nombre}";
    }
}