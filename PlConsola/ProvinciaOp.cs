using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlConsola
{
    internal class ProvinciaOp
    {
        internal static void MenuProvincias()
        {
            Console.Clear();

            Program.Cabecera("MENÚ PROVINCIAS");

            Console.WriteLine("1 - Listado");
            Console.WriteLine("2 - Búsqueda por ID");
            Console.WriteLine("3 - Búsqueda por NOMBRE");
            Console.WriteLine("4 - Insertar");
            Console.WriteLine("5 - Modificar");
            Console.WriteLine("6 - Eliminar");
            Console.WriteLine("7 - Volver al MENÚ PRINCIPAL");
            Console.WriteLine("8 - SALIR");

            int accion = Program.OpcionMenu();

            AccionMenuProvincias(accion);
        }

        private static void AccionMenuProvincias(int opcion)
        {
            long id;

            switch (opcion)
            {
                case 1:
                    ConsultarProvincias();
                    Program.Continuar(2);
                    break;
                case 2:
                    id = OpcionProvinciaId();
                    ConsultarProvinciaPorId(id);
                    break;
                case 3:
                    OpcionProvinciaNombre();
                    ConsultarProvinciaPorNombre(Console.ReadLine());
                    break;
                case 4:
                    Provincia provincia = OpcionInsertarProvincia();
                    InsertarProvincia(provincia);
                    break;
                case 5:
                    id = OpcionModificarProvincia();
                    ModificarProvincia(id, Console.ReadLine());
                    break;
                case 6:
                    id = OpcionEliminarProvincia();
                    EliminarProvincia(id);
                    break;
                case 7:
                    Program.MenuPincipal();
                    break;
                case 8:
                    Environment.Exit(1);
                    break;
                default:
                    Program.MenuPincipal();
                    break;
            }
        }

        private static long OpcionEliminarProvincia()
        {
            long id;
            Console.WriteLine();
            Console.Write("Introduce el ID de la PROVINCIA que deseas ELIMINAR: ");
            Int64.TryParse(Console.ReadLine(), out id);
            return id;
        }

        private static long OpcionModificarProvincia()
        {
            long id;
            Console.WriteLine();
            ConsultarProvincias();
            Console.WriteLine();
            Console.Write("Introduce el ID de la PROVINCIA que deseas MODIFICAR: ");
            Int64.TryParse(Console.ReadLine(), out id);
            Console.Write("Introduce el nuevo NOMBRE de la PROVINCIA: ");
            return id;
        }

        private static Provincia OpcionInsertarProvincia()
        {
            Console.WriteLine();
            Console.Write("Introduce el NOMBRE de la nueva PROVINCIA: ");
            string nombre = Console.ReadLine();
            Provincia provincia;
            if (nombre.Equals(""))
            {
                Console.WriteLine("Nombre de provincia No Válida");
                provincia = null;
            }
            else
            {
                provincia = new Provincia()
                {
                    Nombre = nombre,
                };
            }
            return provincia;
        }

        private static void OpcionProvinciaNombre()
        {
            Console.WriteLine();
            Console.Write("Introduce el NOMBRE de la PROVINCIA que deseas buscar: ");
        }

        private static long OpcionProvinciaId()
        {
            long id;
            Console.WriteLine();
            Console.Write("Introduce el ID de la PROVINCIA que deseas buscar: ");
            Int64.TryParse(Console.ReadLine(), out id);
            return id;
        }

        private static void ConsultarProvincias()
        {
            var provincias = Bll.ProvinciasBll.Consultar();

            Console.WriteLine();
            Program.Cabecera("LISTADO DE PROVINCIAS");
            foreach (var item in provincias)
            {
                Console.WriteLine(item);
            }
        }

        private static void ConsultarProvinciaPorId(long id)
        {
            Provincia provincia = Bll.ProvinciasBll.BuscarPorId(id);

            if (provincia != null)
            {
                Console.WriteLine(provincia);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No existe la provincia con el Id = " + id);
            }

            Program.Continuar(2);
        }

        private static void ConsultarProvinciaPorNombre(string nombre)
        {
            List<Provincia> provincias = Bll.ProvinciasBll.BuscarPorNombre(nombre).ToList();

            if (provincias.Count > 0)
            {
                foreach (var item in provincias)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No existen provincias que contengan la expresión: " + nombre);
            }

            Program.Continuar(2);
        }

        private static void InsertarProvincia(Provincia provincia)
        {
            if (provincia != null)
            {
                Bll.ProvinciasBll.Guardar(provincia);
            }
            else
            {
                Console.WriteLine("No se ha podido insertar la PROVINCIA.");
            }

            Program.Continuar(2);
        }

        private static void ModificarProvincia(long id, string nombre)
        {
            Provincia provincia = Bll.ProvinciasBll.BuscarPorId(id);

            if (provincia != null)
            {
                Bll.ProvinciasBll.Modificar(new Provincia()
                {
                    Id = id,
                    Nombre = nombre
                });
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No existe ninguna provinciacon el ID = " + id);
            }
            Program.Continuar(2);
        }

        private static void EliminarProvincia(long id)
        {
            Bll.ProvinciasBll.Eliminar(id);

            Program.Continuar(2);
        }
    }
}
