namespace Servicios.Interface.Marca
{
    using System.ComponentModel.DataAnnotations;
    using EntityBase;
    public class Marca : Base
    {
        [Required(ErrorMessage = "Ingrese una {0}")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Ingrese un {0}")]
        public string Nombre { get; set; }
    }
}