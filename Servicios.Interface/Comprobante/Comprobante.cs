namespace Servicios.Interface.Comprobante
{
    using EntityBase;
    using System;
    using System.Collections.Generic;
    using Clases.Utiles;
    public class Comprobante : Base
    {
        public long ClienteId { get; set; }
        public long EmpleadoId { get; set; }
        public long Numero { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal Descuento { get; set; }
        public decimal TotalIva { get; set; }
        public DateTime Fecha { get; set; }
        public TipoComprobante TipoComprobante { get; set; }
        public int TipoComprobanteInt { get; set; }
        public EstadoComprobante EstadoComprobante { get; set; }
        public TipoPago TipoPago { get; set; }
        // Lo uso para saber si el comprobante es para facturar al contado y pasarlo a estado pagado
        public decimal TotalPagar { get; set; }
        // DATOS DEL EMPLEADO
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public string ApyNomEmpleado => $"{ApellidoEmpleado}, {NombreEmpleado}";
        public List<Articulos.ArticuloVentaDto> Items { get; set; }

        // CANTIDAD VENDIDA - PARA TRAER LOS EMPLEADOS QUE MAS VENDIERON
        public int CantidadVendida { get; set; }
    }

    public enum TipoComprobante
    {
        A = 1,
        B = 2,
        C = 3,
        Remito = 4,
        Nota_Credito = 5
    }

    public enum EstadoComprobante
    {
        Pendiente = 1,
        Pagado = 2
    }
}