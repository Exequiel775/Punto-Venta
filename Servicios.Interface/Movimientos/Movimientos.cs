namespace Servicios.Interface.Movimientos
{
    using EntityBase;
    using System;
    using Clases.Utiles;
    public class Movimientos : Base
    {
        public long CajaId { get; set; }
        public long ComprobanteId { get; set; }
        public long UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
    }
}