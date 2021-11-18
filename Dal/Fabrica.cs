using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public enum Tipos { Entity, SqlServerTest, SqlServerProduccion, MySqlTest, MySqlProduccion }
    public static class Fabrica
    {
        private static readonly IDaoPersona daoEntityPersona = new DaoEntityPersona();
        private static readonly IDaoVivienda daoEntityVivienda = new DaoEntityVivienda();
        private static readonly IDaoMunicipio daoEntityMunicipio = new DaoEntityMunicipio();
        private static readonly IDaoProvincia daoEntityProvincia = new DaoEntityProvincia();

        private const string CONEXION_SQLSERVER_TEST = @"Data Source=ryzen5-3600;Initial Catalog=EmpadronamientoTest;Integrated Security=True";
        private const string CONEXION_SQLSERVER_PRODUCCION = @"Data Source=ryzen5-3600;Initial Catalog=Empadronamiento;Integrated Security=True";

        public static IDaoPersona ObtenerDaoPersona(Tipos tipo)
        {
            switch (tipo)
            {
                case Tipos.Entity:
                    return daoEntityPersona;
                default:
                    throw new NotImplementedException("No existe implementación para ese tipo todavía: " + tipo);
            }
        }

        public static IDaoVivienda ObtenerDaoVivienda(Tipos tipo)
        {
            switch (tipo)
            {
                case Tipos.Entity:
                    return daoEntityVivienda;
                default:
                    throw new NotImplementedException("No existe implementación para ese tipo todavía: " + tipo);
            }
        }

        public static IDaoMunicipio ObtenerDaoMunicipio(Tipos tipo)
        {
            switch (tipo)
            {
                case Tipos.Entity:
                    return daoEntityMunicipio;
                default:
                    throw new NotImplementedException("No existe implementación para ese tipo todavía: " + tipo);
            }
        }

        public static IDaoProvincia ObtenerDaoProvincia(Tipos tipo)
        {
            switch (tipo)
            {
                case Tipos.Entity:
                    return daoEntityProvincia;
                default:
                    throw new NotImplementedException("No existe implementación para ese tipo todavía: " + tipo);
            }
        }

        public static string ObtenerConexion(Tipos tipo)
        {
            switch (tipo)
            {
                case Tipos.SqlServerTest:
                    return CONEXION_SQLSERVER_TEST;
                case Tipos.SqlServerProduccion:
                    return CONEXION_SQLSERVER_PRODUCCION;
                default:
                    throw new NotImplementedException("Todavía no se ha declarado la conexión: " + tipo);
            }
        }
    }
}
