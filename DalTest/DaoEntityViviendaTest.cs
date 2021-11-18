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
    public class DaoEntityViviendaTest: DaoEntityTestInicializacion
    {
        [TestMethod]
        public void ObtenerTodasLasViviendas()
        {
            List<Vivienda> viviendas = daoVivienda.ObtenerTodos() as List<Vivienda>;

            Assert.IsNotNull(viviendas);

            Assert.AreEqual(3, viviendas.Count);

            Assert.AreEqual(vivienda1, viviendas[0]);
            Assert.AreEqual(vivienda2, viviendas[1]);
            Assert.AreEqual(vivienda3, viviendas[2]);
        }

        [TestMethod]
        public void ObtenerViviendaPorId()
        {
            Vivienda vivienda = daoVivienda.ObtenerPorId(1L);
            Assert.IsNotNull(vivienda);
            Assert.AreEqual(vivienda1, vivienda);

            vivienda = daoVivienda.ObtenerPorId(2L);
            Assert.IsNotNull(vivienda);
            Assert.AreEqual(vivienda2, vivienda);

            vivienda = daoVivienda.ObtenerPorId(3L);
            Assert.IsNotNull(vivienda);
            Assert.AreEqual(vivienda3, vivienda);

            vivienda = daoVivienda.ObtenerPorId(4L);
            Assert.IsNull(vivienda);
        }

        [TestMethod]
        public void ObtenerViviendaPorNombre()
        {
            List<Vivienda> viviendas = daoVivienda.ObtenerPorDireccion("no") as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(2, viviendas.Count);
            Assert.AreEqual(vivienda1, viviendas[0]);
            Assert.AreEqual(vivienda3, viviendas[1]);

            viviendas = daoVivienda.ObtenerPorDireccion("ab") as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(1, viviendas.Count);
            Assert.AreEqual(vivienda2, viviendas[0]);

            viviendas = daoVivienda.ObtenerPorDireccion("a") as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(3, viviendas.Count);
            Assert.AreEqual(vivienda1, viviendas[0]);
            Assert.AreEqual(vivienda2, viviendas[1]);
            Assert.AreEqual(vivienda3, viviendas[2]);

            viviendas = daoVivienda.ObtenerPorDireccion("fer") as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(0, viviendas.Count);
        }

        [TestMethod]
        public void ObtenerViviendaPorCp()
        {
            List<Vivienda> viviendas = daoVivienda.ObtenerPorCp("2") as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(2, viviendas.Count);
            Assert.AreEqual(vivienda2, viviendas[0]);
            Assert.AreEqual(vivienda3, viviendas[1]);

            viviendas = daoVivienda.ObtenerPorCp("01") as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(2, viviendas.Count);
            Assert.AreEqual(vivienda1, viviendas[0]);
            Assert.AreEqual(vivienda3, viviendas[1]);

            viviendas = daoVivienda.ObtenerPorCp("4") as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(3, viviendas.Count);
            Assert.AreEqual(vivienda1, viviendas[0]);
            Assert.AreEqual(vivienda2, viviendas[1]);
            Assert.AreEqual(vivienda3, viviendas[2]);

            viviendas = daoVivienda.ObtenerPorCp("49") as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(0, viviendas.Count);
        }

        [TestMethod]
        public void ObtenerViviendaPorMunicipioId()
        {
            List<Vivienda> viviendas = daoVivienda.ObtenerPorMunicipio(1L) as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(1, viviendas.Count);
            Assert.AreEqual(vivienda1, viviendas[0]);

            viviendas = daoVivienda.ObtenerPorMunicipio(2L) as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(1, viviendas.Count);
            Assert.AreEqual(vivienda2, viviendas[0]);

            viviendas = daoVivienda.ObtenerPorMunicipio(3L) as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(1, viviendas.Count);
            Assert.AreEqual(vivienda3, viviendas[0]);

            viviendas = daoVivienda.ObtenerPorMunicipio(4L) as List<Vivienda>;
            Assert.IsNotNull(viviendas);
            Assert.AreEqual(0, viviendas.Count);
        }

        [TestMethod]
        public void InsertarVivienda()
        {
            Vivienda vivienda = new Vivienda() { MunicipioId = null, Direccion = "San Blas, 40, 4ºE", Cp = "41008" };
            daoVivienda.Insertar(vivienda);
            Assert.IsNotNull(vivienda);

            Vivienda viviendaNueva = daoVivienda.ObtenerPorId(4L);
            Assert.IsNotNull(viviendaNueva);
            Assert.AreEqual(viviendaNueva, vivienda);
        }

        [TestMethod]
        public void ModificarVivienda()
        {
            Vivienda vivienda = new Vivienda() { Id = 2L, MunicipioId = null, Direccion = "San Blas, 40, 4ºE", Cp = "41008" };
            daoVivienda.Modificar(vivienda);
            Assert.IsNotNull(vivienda);

            Vivienda viviendaNueva = daoVivienda.ObtenerPorId(4L);
            Assert.IsNull(viviendaNueva);

            viviendaNueva = daoVivienda.ObtenerPorId(2L);
            Assert.IsNotNull(viviendaNueva);
            Assert.AreEqual(viviendaNueva, vivienda);
        }

        [TestMethod]
        public void EliminarVivienda()
        {
            daoVivienda.Eliminar(2L);

            Vivienda vivienda = daoVivienda.ObtenerPorId(2L);
            Assert.IsNull(vivienda);
        }
    }
}
