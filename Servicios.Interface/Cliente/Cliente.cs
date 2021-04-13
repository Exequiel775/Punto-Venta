namespace Servicios.Interface.Cliente
{
    using Persona;
    using System;
    public class Cliente : PersonaDto
    {
        public bool ActivarCtaCte { get; set; }
        public bool TieneLimite { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal LimiteMonto { get; set; }
        public string TieneCtaCteStr => ActivarCtaCte ? "Si" : "No";
        public string TieneLimiteStr => TieneLimite ? "Si" : "No";
    }
}