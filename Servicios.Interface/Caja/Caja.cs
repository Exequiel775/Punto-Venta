namespace Servicios.Interface.Caja
{
    using EntityBase;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    public class Caja : Base
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public long UsuarioAperturaId { get; set; }
        [Required(ErrorMessage = "Debe ingresar un monto de apertura")]
        public decimal MontoApertura { get; set; }
        public DateTime FechaApertura { get; set; }
        public string NombreUsuarioApertura { get; set; }
        // CIERRE DE CAJA
        public long? UsuarioCierreId { get; set; }
        #nullable enable
        public string? NombreUsuarioCierre { get; set; }
        #nullable disable
        public DateTime? FechaCierre { get; set; }
        public decimal? MontoCierre { get; set; }
        public decimal? TotalEfectivoEntrada { get; set; }
        public decimal? CuentaCorrienteEntrada { get; set; }
        public decimal? CuentaCorrienteSalida { get; set; }
        public string FechaAperturaStr => FechaApertura.ToString("yyyy/MM/dd hh:mm");
        public string FechaCierreStr => FechaCierre.HasValue ? FechaCierre.GetValueOrDefault().ToString("yyyy-MM-dd hh:mm") : "--";
        public List<DetalleCaja.DetalleCaja> DetalleCajas { get; set; }
    }
}