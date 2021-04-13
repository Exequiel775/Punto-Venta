namespace Servicios.Interface.ListaPrecios
{
    using EntityBase;
    public class ListaPrecio : Base
    {
        public string Descripcion { get; set; }
        public decimal Porcentaje { get; set; }
    }
}