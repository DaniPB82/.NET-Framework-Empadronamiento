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
    public class DaoEntityProvinciaTest: DaoEntityTestInicializacion
    {
        [TestMethod]
        public void ObtenerTodasLasProvincias()
        {
            List<Provincia> provincias = daoProvincia.ObtenerTodos() as List<Provincia>;

            Assert.IsNotNull(provincias);

            Assert.AreEqual(1, provincias.Count);

            Assert.AreEqual(provincia1, provincias[0]);
        }

        [TestMethod]
        public void ObtenerProvinciaPorNombre()
        {
            List<Provincia> provincias = daoProvincia.ObtenerPorNombre("cay") as List<Provincia>;
            Assert.IsNotNull(provincias);
            Assert.AreEqual(1, provincias.Count);
            Assert.AreEqual(provincia1, provincias[0]);

            provincias = daoProvincia.ObtenerPorNombre("via") as List<Provincia>;
            Assert.IsNotNull(provincias);
            Assert.AreEqual(0, provincias.Count);
        }

        [TestMethod]
        public void ObtenerProvinciaPorId()
        {
            Provincia provincia = daoProvincia.ObtenerPorId(1L);
            Assert.IsNotNull(provincia);
            Assert.AreEqual(provincia1, provincia);

            provincia = daoProvincia.ObtenerPorId(2L);
            Assert.IsNull(provincia);
        }

        [TestMethod]
        public void InsertarProvincia()
        {
            Provincia provincia = new Provincia() { Nombre = "Guipuzcoa" };
            daoProvincia.Insertar(provincia);
            Assert.IsNotNull(provincia);

            Provincia provinciaNueva = daoProvincia.ObtenerPorId(2L);
            Assert.AreEqual(provinciaNueva, provincia);
        }

        [TestMethod]
        public void ModificarProvincia()
        {
            Provincia provinciaModificada = new Provincia() { Id = 1L, Nombre = "Alava" };
            daoProvincia.Modificar(provinciaModificada);
            Assert.IsNotNull(provinciaModificada);

            Provincia provinciaNueva = daoProvincia.ObtenerPorId(1L);
            Assert.AreEqual(provinciaNueva, provinciaModificada);
        }
    }
}
