namespace Servicios.Interface.Iva
{
    using EntityBase;
    public class Iva : Base
    {
        public string Descripcion { get; set; }
        public decimal Porcentaje { get; set; }
    }
}