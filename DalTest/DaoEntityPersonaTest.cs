using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Persona;

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
        public void ObtenerPropietariosPorVivienda()
        {
            List<Persona> propietarios = daoPersona.ObtenerPropietariosPorVivienda(1L) as List<Persona>;
            Assert.IsNotNull(propietarios);
            Assert.AreEqual(2, propietarios.Count);
            Assert.AreEqual(persona1, propietarios[0]);
            Assert.AreEqual(persona3, propietarios[1]);

            propietarios = daoPersona.ObtenerPropietariosPorVivienda(2L) as List<Persona>;
            Assert.IsNotNull(propietarios);
            Assert.AreEqual(2, propietarios.Count);
            Assert.AreEqual(persona1, propietarios[0]);
            Assert.AreEqual(persona2, propietarios[1]);

            propietarios = daoPersona.ObtenerPropietariosPorVivienda(3L) as List<Persona>;
            Assert.IsNotNull(propietarios);
            Assert.AreEqual(2, propietarios.Count);
            Assert.AreEqual(persona2, propietarios[0]);
            Assert.AreEqual(persona3, propietarios[1]);

            propietarios = daoPersona.ObtenerPropietariosPorVivienda(4L) as List<Persona>;
            Assert.IsNotNull(propietarios);
            Assert.AreEqual(0, propietarios.Count);
        }

        [TestMethod]
        public void ObtenerPropiedadesPorPersona()
        {
            List<Vivienda> viviendas = daoPersona.ObtenerPropiedadesPorPersona(1L) as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(2, viviendas.Count);
            Assert.AreEqual(vivienda1, viviendas[0]);
            Assert.AreEqual(vivienda2, viviendas[1]);

            viviendas = daoPersona.ObtenerPropiedadesPorPersona(2L) as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(2, viviendas.Count);
            Assert.AreEqual(vivienda2, viviendas[0]);
            Assert.AreEqual(vivienda3, viviendas[1]);

            viviendas = daoPersona.ObtenerPropiedadesPorPersona(3L) as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(2, viviendas.Count);
            Assert.AreEqual(vivienda1, viviendas[0]);
            Assert.AreEqual(vivienda3, viviendas[1]);

            viviendas = daoPersona.ObtenerPropiedadesPorPersona(4L) as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(0, viviendas.Count);
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

        [TestMethod]
        public void InsertarPropiedad()
        {
            Propiedad propiedad = new Propiedad() { PropietarioId = 3L, ViviendaId = 2L };
            daoPersona.Insertar(propiedad);
            Assert.IsNotNull(propiedad);

            Propiedad propiedadNueva = daoPersona.ObtenerPropiedadPorId(3L, 2L);
            Assert.AreEqual(propiedadNueva, propiedad);
        }

        //[TestMethod]
        //public void ModificarPropiedad()
        //{
        //    Propiedad propiedadModificada = new Propiedad() { PropietarioId = 1L, ViviendaId = 3L };
        //    daoPersona.Modificar(propiedadModificada);
        //    Assert.IsNotNull(propiedadModificada);

        //    Propiedad propiedadNueva = daoPersona.ObtenerPropiedadPorId(1L, 3L);
        //    Assert.IsNotNull(propiedadNueva);
        //    Assert.AreEqual(propiedadNueva, propiedadModificada);
        //}

        [TestMethod]
        public void EliminarPropiedad()
        {
            daoPersona.Eliminar(2L, 3L);
            Propiedad propiedad = daoPersona.ObtenerPropiedadPorId(2L, 3L);
            Assert.IsNull(propiedad);
        }

        [TestMethod]
        public void ObtenerPropiedadPorId()
        {
            Propiedad propiedad = daoPersona.ObtenerPropiedadPorId(1L, 1L);
            Assert.IsNotNull(propiedad);

            propiedad = daoPersona.ObtenerPropiedadPorId(4L, 2L);
            Assert.IsNull(propiedad);
        }


    }
}
