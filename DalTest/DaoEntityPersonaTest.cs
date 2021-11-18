using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    [TestClass]
    public class DaoEntityPersonaTest: DaoEntityTestInicializacion
    {
        [TestMethod]
        public void ObtenerTodasLasPersonas()
        {
            List<Persona> personas = daoPersona.ObtenerTodos() as List<Persona>;

            Assert.IsNotNull(personas);

            Assert.AreEqual(3, personas.Count);

            Assert.AreEqual(persona1, personas[0]);
            Assert.AreEqual(persona2, personas[1]);
            Assert.AreEqual(persona3, personas[2]);
        }

        [TestMethod]
        public void ObtenerPersonaPorId()
        {
            Persona persona = daoPersona.ObtenerPorId(1L);
            Assert.IsNotNull(persona);
            Assert.AreEqual(persona1, persona);

            persona = daoPersona.ObtenerPorId(2L);
            Assert.IsNotNull(persona);
            Assert.AreEqual(persona2, persona);

            persona = daoPersona.ObtenerPorId(3L);
            Assert.IsNotNull(persona);
            Assert.AreEqual(persona3, persona);

            persona = daoPersona.ObtenerPorId(4L);
            Assert.IsNull(persona);
        }

        [TestMethod]
        public void ObtenerPersonaPorNombre()
        {
            List<Persona> personas = daoPersona.ObtenerPorNombre("er") as List<Persona>;
            Assert.IsNotNull(personas);
            Assert.AreEqual(2, personas.Count);
            Assert.AreEqual(persona1, personas[0]);
            Assert.AreEqual(persona3, personas[1]);

            personas = daoPersona.ObtenerPorNombre("a") as List<Persona>;
            Assert.IsNotNull(personas);
            Assert.AreEqual(2, personas.Count);
            Assert.AreEqual(persona1, personas[0]);
            Assert.AreEqual(persona2, personas[1]);

            personas = daoPersona.ObtenerPorNombre("gi") as List<Persona>;
            Assert.IsNotNull(personas);
            Assert.AreEqual(1, personas.Count);
            Assert.AreEqual(persona3, personas[0]);

            personas = daoPersona.ObtenerPorNombre("s") as List<Persona>;
            Assert.IsNotNull(personas);
            Assert.AreEqual(2, personas.Count);
            Assert.AreEqual(persona2, personas[0]);
            Assert.AreEqual(persona3, personas[1]);

            personas = daoPersona.ObtenerPorNombre("ve") as List<Persona>;
            Assert.AreEqual(0, personas.Count);
        }

        [TestMethod]
        public void ObtenerPersonaPorApellido()
        {
            List<Persona> personas = daoPersona.ObtenerPorApellido("ar") as List<Persona>;
            Assert.IsNotNull(personas);
            Assert.AreEqual(2, personas.Count);
            Assert.AreEqual(persona1, personas[0]);
            Assert.AreEqual(persona2, personas[1]);

            personas = daoPersona.ObtenerPorApellido("a") as List<Persona>;
            Assert.IsNotNull(personas);
            Assert.AreEqual(3, personas.Count);
            Assert.AreEqual(persona1, personas[0]);
            Assert.AreEqual(persona2, personas[1]);
            Assert.AreEqual(persona3, personas[2]);

            personas = daoPersona.ObtenerPorApellido("on") as List<Persona>;
            Assert.IsNotNull(personas);
            Assert.AreEqual(1, personas.Count);
            Assert.AreEqual(persona3, personas[0]);

            personas = daoPersona.ObtenerPorApellido("cí") as List<Persona>;
            Assert.IsNotNull(personas);
            Assert.AreEqual(1, personas.Count);
            Assert.AreEqual(persona2, personas[0]);

            personas = daoPersona.ObtenerPorApellido("ti") as List<Persona>;
            Assert.AreEqual(0, personas.Count);
        }

        [TestMethod]
        public void ObtenerPersonaPorDni()
        {
            List<Persona> personas = daoPersona.ObtenerPorDni("1111") as List<Persona>;
            Assert.IsNotNull(personas);
            Assert.AreEqual(1, personas.Count);
            Assert.AreEqual(persona1, personas[0]);

            personas = daoPersona.ObtenerPorDni("22B") as List<Persona>;
            Assert.IsNotNull(personas);
            Assert.AreEqual(1, personas.Count);
            Assert.AreEqual(persona2, personas[0]);

            personas = daoPersona.ObtenerPorDni("333333") as List<Persona>;
            Assert.IsNotNull(personas);
            Assert.AreEqual(1, personas.Count);
            Assert.AreEqual(persona3, personas[0]);

            personas = daoPersona.ObtenerPorDni("342") as List<Persona>;
            Assert.AreEqual(0, personas.Count);
        }

        [TestMethod]
        public void ObtenerPersonaPorAnioNacimiento()
        {
            List<Persona> personas = daoPersona.ObtenerPorAnioNacimiento(1985) as List<Persona>;
            Assert.IsNotNull(personas);
            Assert.AreEqual(1, personas.Count);
            Assert.AreEqual(persona3, personas[0]);

            personas = daoPersona.ObtenerPorAnioNacimiento(1990) as List<Persona>;
            Assert.IsNotNull(personas);
            Assert.AreEqual(1, personas.Count);
            Assert.AreEqual(persona2, personas[0]);

            personas = daoPersona.ObtenerPorAnioNacimiento(1978) as List<Persona>;
            Assert.IsNotNull(personas);
            Assert.AreEqual(1, personas.Count);
            Assert.AreEqual(persona1, personas[0]);

            personas = daoPersona.ObtenerPorAnioNacimiento(2000) as List<Persona>;
            Assert.AreEqual(0, personas.Count);
        }

        [TestMethod]
        public void InsertarPersona()
        {
            Persona persona = new Persona() { HogarId = null, Dni = "44444444D", Nombre = "Pepe", Apellido = "Palo", FechaNacimiento = new DateTime(1980, 8, 8) };
            daoPersona.Insertar(persona);
            Assert.IsNotNull(persona);

            Persona personaNueva = daoPersona.ObtenerPorId(4L);
            Assert.AreEqual(personaNueva, persona);
        }

        [TestMethod]
        public void ModificarPersona()
        {
            Persona personaModificada = new Persona() { Id = 3L, HogarId = null, Dni = "12345678X", Nombre = "Patxi", Apellido = "Aguirre", FechaNacimiento = new DateTime(1975, 3, 10) };
            daoPersona.Modificar(personaModificada);
            Assert.IsNotNull(personaModificada);

            Persona personaNueva = daoPersona.ObtenerPorId(3L);
            Assert.IsNotNull(personaNueva);
            Assert.AreEqual(personaNueva, personaModificada);
        }

        [TestMethod]
        public void EliminarPersona()
        {
            daoPersona.Eliminar(1L);
            Persona persona = daoPersona.ObtenerPorId(1L);
            Assert.IsNull(persona);
        }
    }
}
