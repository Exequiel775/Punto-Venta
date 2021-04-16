namespace Servicios.Interface.Caja
{
    using System.Collections.Generic;
    using DetalleCaja;
    public interface ICajaServicio
    {
        bool AbrirCaja(Caja caja);
        bool CerrarCaja(Caja caja);
        bool ExisteCajaAbierta();
        long ObtenerCajaAbierta(); 
        IEnumerable<Caja> Get();
        Caja GetById(long id);
    }
}