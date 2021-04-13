namespace Servicios.Interface.Persona
{
    using System.Collections.Generic;
    using System;
    public interface IPersonaServicio
    {
        void Add(PersonaDto persona);
        IEnumerable<PersonaDto> Get(Type type);
        PersonaDto GetById(Type type, long id);
    }
}