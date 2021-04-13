namespace Servicios.Implementacion.Persona
{
    using System.Threading.Tasks;
    using Servicios.Interface.Persona;
    using System.Collections.Generic;
    using System;
    public class Persona
    {
        public virtual void Add(PersonaDto persona)
        {
        }

        public virtual IEnumerable<PersonaDto> Get()
        {
            return null;
        }

        public virtual PersonaDto GetById(long id)
        {
            return null;
        }
    }
}