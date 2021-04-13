namespace Servicios.Implementacion.Persona
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Servicios.Interface.Persona;

    public class PersonaServicio : IPersonaServicio
    {
        private Dictionary<Type, string> _diccionario;

        public PersonaServicio()
        {
            _diccionario = new Dictionary<Type, string>();
            InicializadorDiccionario();
        }

        public void Add(PersonaDto entidad)
        {
            var persona = InstanciaPersona(entidad);

            persona.Add(entidad);
        }

        public IEnumerable<PersonaDto> Get(Type type)
        {
            var persona = InstanciarPersonaPorTipo(type);

            return persona.Get();
        }

        public PersonaDto GetById(Type type, long id)
        {
            var persona = InstanciarPersonaPorTipo(type);

            return persona.GetById(id);
        }

        private void InicializadorDiccionario()
        {
            _diccionario.Add(typeof(EmpleadoDto), "Servicios.Implementacion.Persona.Empleado");
            _diccionario.Add(typeof(ClienteDto), "Servicios.Implementacion.Persona.Cliente");
        }

        private Persona InstanciaPersona(PersonaDto entidad)
        {
            if (!_diccionario.TryGetValue(entidad.GetType(), out var tipoEntidad))
                throw new Exception($"No hay {entidad.GetType()} para Instanciar.");

            var persona = InstanciarEntidad(tipoEntidad);

            if (persona == null) throw new Exception($"Ocurrió un error al Instanciar {entidad.GetType()}");

            return persona;
        }

        private Persona InstanciarEntidad(string tipoEntidad)
        {
            var tipoObjeto = Type.GetType(tipoEntidad);

            if (tipoObjeto == null) return null;

            var entidad = Activator.CreateInstance(tipoObjeto) as Persona;

            return entidad;
        }

        private Persona InstanciarPersonaPorTipo(Type tipo)
        {
            if (!_diccionario.TryGetValue(tipo, out var tipoEntidad))
                throw new Exception($"No hay {tipoEntidad} para Instanciar.");

            var persona = InstanciarEntidad(tipoEntidad);

            if (persona == null) throw new Exception($"Ocurrió un error al Instanciar {tipo}");

            return persona;
        }
    }
}