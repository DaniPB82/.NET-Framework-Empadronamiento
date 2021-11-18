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
    public class DaoEntityMunicipioTest: DaoEntityTestInicializacion
    {
        [TestMethod]
        public void ObtenerTodosLosMunicipios()
        {
            List<Municipio> municipios = daoMunicipio.ObtenerTodos() as List<Municipio>;

            Assert.IsNotNull(municipios);

            Assert.AreEqual(3, municipios.Count);

            Assert.AreEqual(municipio1, municipios[0]);
            Assert.AreEqual(municipio2, municipios[1]);
            Assert.AreEqual(municipio3, municipios[2]);
        }

        [TestMethod]
        public void ObtenerMunicipioPorId()
        {
            Municipio municipio = daoMunicipio.ObtenerPorId(1L);
            Assert.IsNotNull(municipio);
            Assert.AreEqual(municipio1, municipio);

            municipio = daoMunicipio.ObtenerPorId(2L);
            Assert.IsNotNull(municipio);
            Assert.AreEqual(municipio2, municipio);

            municipio = daoMunicipio.ObtenerPorId(3L);
            Assert.IsNotNull(municipio);
            Assert.AreEqual(municipio3, municipio);

            municipio = daoMunicipio.ObtenerPorId(4L);
            Assert.IsNull(municipio);
        }

        [TestMethod]
        public void ObtenerMunicipioPorNombre()
        {
            List<Municipio> municipios = daoMunicipio.ObtenerPorNombre("bi") as List<Municipio>;
            Assert.IsNotNull(municipios);
            Assert.AreEqual(2, municipios.Count);
            Assert.AreEqual(municipio1, municipios[0]);
            Assert.AreEqual(municipio3, municipios[1]);

            municipios = daoMunicipio.ObtenerPorNombre("ra") as List<Municipio>;
            Assert.IsNotNull(municipios);
            Assert.AreEqual(1, municipios.Count);
            Assert.AreEqual(municipio2, municipios[0]);

            municipios = daoMunicipio.ObtenerPorNombre("o") as List<Municipio>;
            Assert.IsNotNull(municipios);
            Assert.AreEqual(3, municipios.Count);
            Assert.AreEqual(municipio1, municipios[0]);
            Assert.AreEqual(municipio2, municipios[1]);
            Assert.AreEqual(municipio3, municipios[2]);

            municipios = daoMunicipio.ObtenerPorNombre("fer") as List<Municipio>;
            Assert.IsNotNull(municipios);
            Assert.AreEqual(0, municipios.Count);
        }

        [TestMethod]
        public void InsertarMunicipio()
        {
            Municipio municipio = new Municipio() { Nombre = "Portugalete", ProvinciaId = 1L };
            daoMunicipio.Insertar(municipio);
            Assert.IsNotNull(municipio);

            Municipio municipioNuevo = daoMunicipio.ObtenerPorId(4L);
            Assert.AreEqual(municipioNuevo, municipio);
        }

        [TestMethod]
        public void ModificarMunicipio()
        {
            Municipio municipioModificado = new Municipio() { Id = 3L, Nombre = "Durango", ProvinciaId = 1L };
            daoMunicipio.Modificar(municipioModificado);
            Assert.IsNotNull(municipioModificado);

            Municipio municipioNuevo = daoMunicipio.ObtenerPorId(3L);
            Assert.IsNotNull(municipioNuevo);
            Assert.AreEqual(municipioNuevo, municipioModificado);
        }

        [TestMethod]
        public void EliminarMunicipio()
        {
            daoMunicipio.Eliminar(1L);
            Municipio municipio = daoMunicipio.ObtenerPorId(1L);
            Assert.IsNull(municipio);
        }
    }
}
