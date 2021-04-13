namespace Servicios.Interface.Configuracion
{
    using System.Collections.Generic;
    public interface IConfiguracionServicio
    {
        bool Add(Configuracion configuracion);
        Configuracion Get(); 
    }
}