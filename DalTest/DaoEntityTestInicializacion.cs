using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Dal
{
    [TestClass]
    public abstract class DaoEntityTestInicializacion
    {
        // Daos
        protected static readonly IDaoPersona daoPersona = Fabrica.ObtenerDaoPersona(Tipos.Entity);
        protected static readonly IDaoVivienda daoVivienda = Fabrica.ObtenerDaoVivienda(Tipos.Entity);
        protected static readonly IDaoMunicipio daoMunicipio = Fabrica.ObtenerDaoMunicipio(Tipos.Entity);
        protected static readonly IDaoProvincia daoProvincia = Fabrica.ObtenerDaoProvincia(Tipos.Entity);

        // Conexiones
        protected static readonly string conexion = Fabrica.ObtenerConexion(Tipos.SqlServerTest);

        // Datos de Provincias
        protected static readonly Provincia provincia1 = new Provincia() { Id = 1L, Nombre = "Vizcaya" };

        protected static readonly List<Provincia> provincias = new List<Provincia>() { provincia1 };

        // Datos de Municipios
        protected static readonly Municipio municipio1 = new Municipio() { Id = 1L, Nombre = "Bilbao", ProvinciaId = 1L };
        protected static readonly Municipio municipio2 = new Municipio() { Id = 2L, Nombre = "Barakaldo", ProvinciaId = 1L };
        protected static readonly Municipio municipio3 = new Municipio() { Id = 3L, Nombre = "Amorebieta", ProvinciaId = 1L };

        protected static readonly List<Municipio> municipios = new List<Municipio>() { municipio1, municipio2, municipio3 };

        // Datos de Viviendas
        protected static readonly Vivienda vivienda1 = new Vivienda() { Id = 1L, MunicipioId = 1L, Direccion = "Autonomía, 40, 4ºE", Cp = "48011" };
        protected static readonly Vivienda vivienda2 = new Vivienda() { Id = 2L, MunicipioId = 2L, Direccion = "Gabriel Aresti, 5, 1ºA", Cp = "40025" };
        protected static readonly Vivienda vivienda3 = new Vivienda() { Id = 3L, MunicipioId = 3L, Direccion = "Zornotza, 21, 3ºB", Cp = "42015" };

        protected static readonly List<Vivienda> viviendas = new List<Vivienda>() { vivienda1, vivienda2, vivienda3 };

        // Datos de Personas
        protected static readonly Persona persona1 = new Persona() { Id = 1L, HogarId = 1L, Dni = "11111111A", Nombre = "Javier", Apellido = "Martínez", FechaNacimiento = new DateTime(1978, 9, 15) };
        protected static readonly Persona persona2 = new Persona() { Id = 2L, HogarId = 2L, Dni = "22222222B", Nombre = "Sandra", Apellido = "García", FechaNacimiento = new DateTime(1990, 2, 12) };
        protected static readonly Persona persona3 = new Persona() { Id = 3L, HogarId = 3L, Dni = "33333333C", Nombre = "Sergio", Apellido = "Alonso", FechaNacimiento = new DateTime(1985, 5, 27) };

        protected static readonly List<Persona> personas = new List<Persona>() { persona1, persona2, persona3 };

        // Datos de Propiedades
        protected static readonly Propiedad propiedad1 = new Propiedad() { PropietarioId = 1L, ViviendaId = 1L };
        protected static readonly Propiedad propiedad2 = new Propiedad() { PropietarioId = 1L, ViviendaId = 2L };
        protected static readonly Propiedad propiedad3 = new Propiedad() { PropietarioId = 2L, ViviendaId = 2L };
        protected static readonly Propiedad propiedad4 = new Propiedad() { PropietarioId = 3L, ViviendaId = 3L };
        protected static readonly Propiedad propiedad5 = new Propiedad() { PropietarioId = 3L, ViviendaId = 1L };

        protected static readonly List<Propiedad> propiedades = new List<Propiedad>() { propiedad1, propiedad2, propiedad3, propiedad4, propiedad5 };

        // Conexión a la BBDD
        private DbConnection ObtenerConexion()
        {
            return new SqlConnection(conexion);
        }

        [TestInitialize]
        public void PreTest()
        {
            using (DbConnection con = ObtenerConexion())
            {
                con.Open();

                DbCommand com = con.CreateCommand();

                // Eliminación del contenido de las tablas y 
                // reseteo de los "Id"
                com.CommandText = "DELETE FROM Propiedades";
                com.ExecuteNonQuery();

                com.CommandText = "DELETE FROM Personas";
                com.ExecuteNonQuery();

                com.CommandText = "DBCC CHECKIDENT ('[Personas]', RESEED, 0);";
                com.ExecuteNonQuery();

                com.CommandText = "DELETE FROM Viviendas";
                com.ExecuteNonQuery();

                com.CommandText = "DBCC CHECKIDENT ('[Viviendas]', RESEED, 0);";
                com.ExecuteNonQuery();

                com.CommandText = "DELETE FROM Municipios";
                com.ExecuteNonQuery();

                com.CommandText = "DBCC CHECKIDENT ('[Municipios]', RESEED, 0);";
                com.ExecuteNonQuery();

                com.CommandText = "DELETE FROM Provincias";
                com.ExecuteNonQuery();

                com.CommandText = "DBCC CHECKIDENT ('[Provincias]', RESEED, 0);";
                com.ExecuteNonQuery();

                // Inserción de datos en la tabla "Provincias"
                com.CommandText = "INSERT INTO Provincias (Nombre)" +
                    " VALUES (@NombreProvincia)";

                DbParameter parNombreProvincia = com.CreateParameter();
                parNombreProvincia.ParameterName = "NombreProvincia";
                parNombreProvincia.DbType = System.Data.DbType.String;
                com.Parameters.Add(parNombreProvincia);

                foreach (Provincia prov in provincias)
                {
                    parNombreProvincia.Value = prov.Nombre;

                    com.ExecuteNonQuery();
                }

                // Inserción de datos en la tabla "Municipios"
                com.CommandText = "INSERT INTO Municipios (Nombre, ProvinciaId)" +
                    " VALUES (@NombreMunicipio, @ProvinciaId)";

                DbParameter parNombreMunicipio = com.CreateParameter();
                parNombreMunicipio.ParameterName = "NombreMunicipio";
                parNombreMunicipio.DbType = System.Data.DbType.String;
                com.Parameters.Add(parNombreMunicipio);

                DbParameter parProvinciaId = com.CreateParameter();
                parProvinciaId.ParameterName = "ProvinciaId";
                parProvinciaId.DbType = System.Data.DbType.Int64;
                com.Parameters.Add(parProvinciaId);

                foreach (Municipio muni in municipios)
                {
                    parNombreMunicipio.Value = muni.Nombre;
                    parProvinciaId.Value = muni.ProvinciaId;

                    com.ExecuteNonQuery();
                }

                // Inserción de datos en la tabla "Viviendas"
                com.CommandText = "INSERT INTO Viviendas (MunicipioId, Direccion, Cp)" +
                    " VALUES (@MunicipioId, @Direccion, @Cp)";

                DbParameter parMunicipioId = com.CreateParameter();
                parMunicipioId.ParameterName = "MunicipioId";
                parMunicipioId.DbType = System.Data.DbType.Int64;
                com.Parameters.Add(parMunicipioId);

                DbParameter parDireccion = com.CreateParameter();
                parDireccion.ParameterName = "Direccion";
                parDireccion.DbType = System.Data.DbType.String;
                com.Parameters.Add(parDireccion);

                DbParameter parCp = com.CreateParameter();
                parCp.ParameterName = "Cp";
                parCp.DbType = System.Data.DbType.String;
                com.Parameters.Add(parCp);

                foreach (Vivienda vivi in viviendas)
                {
                    parMunicipioId.Value = vivi.MunicipioId;
                    parDireccion.Value = vivi.Direccion;
                    parCp.Value = vivi.Cp;

                    com.ExecuteNonQuery();
                }

                // Inserción de datos en la tabla "Personas"
                com.CommandText = "INSERT INTO Personas (HogarId, Dni, Nombre, Apellido, FechaNacimiento)" +
                    " VALUES (@HogarId, @Dni, @NombrePersona, @Apellido, @FechaNacimiento)";

                DbParameter parHogarId = com.CreateParameter();
                parHogarId.ParameterName = "HogarId";
                parHogarId.DbType = System.Data.DbType.Int64;
                com.Parameters.Add(parHogarId);

                DbParameter parDni = com.CreateParameter();
                parDni.ParameterName = "Dni";
                parDni.DbType = System.Data.DbType.String;
                com.Parameters.Add(parDni);

                DbParameter parNombrePersona = com.CreateParameter();
                parNombrePersona.ParameterName = "NombrePersona";
                parNombrePersona.DbType = System.Data.DbType.String;
                com.Parameters.Add(parNombrePersona);

                DbParameter parApellido = com.CreateParameter();
                parApellido.ParameterName = "Apellido";
                parApellido.DbType = System.Data.DbType.String;
                com.Parameters.Add(parApellido);

                DbParameter parFechaNacimiento = com.CreateParameter();
                parFechaNacimiento.ParameterName = "FechaNacimiento";
                parFechaNacimiento.DbType = System.Data.DbType.Date;
                com.Parameters.Add(parFechaNacimiento);

                foreach (Persona per in personas)
                {
                    parHogarId.Value = per.HogarId;
                    parDni.Value = per.Dni;
                    parNombrePersona.Value = per.Nombre;
                    parApellido.Value = per.Apellido;
                    parFechaNacimiento.Value = per.FechaNacimiento;

                    com.ExecuteNonQuery();
                }

                // Inserción de datos en la tabla "Propiedades"
                com.CommandText = "INSERT INTO Propiedades (PropietarioId, ViviendaId)" +
                    " VALUES (@PropietarioId, @ViviendaId)";

                DbParameter parPropietarioId = com.CreateParameter();
                parPropietarioId.ParameterName = "PropietarioId";
                parPropietarioId.DbType = System.Data.DbType.Int64;
                com.Parameters.Add(parPropietarioId);

                DbParameter parViviendaId = com.CreateParameter();
                parViviendaId.ParameterName = "ViviendaId";
                parViviendaId.DbType = System.Data.DbType.Int64;
                com.Parameters.Add(parViviendaId);

                foreach (Propiedad prop in propiedades)
                {
                    parPropietarioId.Value = prop.PropietarioId;
                    parViviendaId.Value = prop.ViviendaId;

                    com.ExecuteNonQuery();
                }
                Debug.Print("TestInitialize");
            }
            
        }
    }
}
