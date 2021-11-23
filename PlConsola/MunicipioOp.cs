using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlConsola
{
    internal class MunicipioOp
    {
        internal static void MenuMunicipios()
        {
            Console.Clear();

            Program.Cabecera("MENÚ MUNICIPIOS");

            Console.WriteLine("1 - Listado");
            Console.WriteLine("2 - Búsqueda por ID");
            Console.WriteLine("3 - Búsqueda por NOMBRE");
            Console.WriteLine("4 - Insertar");
            Console.WriteLine("5 - Modificar");
            Console.WriteLine("6 - Eliminar");
            Console.WriteLine("7 - Volver al MENÚ PRINCIPAL");
            Console.WriteLine("8 - SALIR");

            int accion = Program.OpcionMenu();

            AccionMenuMunicipios(accion);
        }

        private static void AccionMenuMunicipios(int opcion)
        {
            long id;
            Municipio municipio;

            switch (opcion)
            {
                case 1:
                    ConsultarMunicipios();
                    Program.Continuar(2);
                    break;
                case 2:
                    id = OpcionMunicipioId();
                    ConsultarMunicipioPorId(id);
                    break;
                case 3:
                    OpcionMunicipioNombre();
                    ConsultarMunicipioPorNombre(Console.ReadLine());
                    break;
                case 4:
                    municipio = OpcionInsertarMunicipio();
                    InsertarMunicipio(municipio);
                    break;
                case 5:
                    id = OpcionModificarMunicipio();
                    ModificarMunicipio(id, Console.ReadLine());
                    break;
                case 6:
                    id = OpcionEliminarMunicipio();
                    EliminarMunicipio(id);
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

        private static void EliminarMunicipio(long id)
        {
            Municipio municipio = Bll.MunicipiosBll.BuscarPorId(id);
            if (municipio != null)
            {
                Bll.MunicipiosBll.Eliminar(id);
            }
            else
            {
                Console.WriteLine("No exixte ningún municipio con el ID = " + id);
            }

            Program.Continuar(3);
        }

        private static long OpcionEliminarMunicipio()
        {
            long id;
            Console.WriteLine();
            Console.Write("Introduce el ID del MUNICIPIO que deseas ELIMINAR: ");
            Int64.TryParse(Console.ReadLine(), out id);
            return id;
        }

        private static void ModificarMunicipio(long id, string nombre)
        {
            long provinciaId;
            Municipio municipio = Bll.MunicipiosBll.BuscarPorId(id);
            if (municipio != null)
            {
                Console.Write("Introduce el ID de la PROVINCIA a la que pertenece el MUNICIPIO: ");
                Int64.TryParse(Console.ReadLine(), out provinciaId);
                Provincia provincia = Bll.ProvinciasBll.BuscarPorId(provinciaId);
                if (provincia != null)
                {
                    Bll.MunicipiosBll.Modificar(new Municipio()
                    {
                        Id = id,
                        Nombre = nombre,
                        ProvinciaId = provinciaId
                    });
                }
                else
                {
                    Bll.MunicipiosBll.Modificar(new Municipio()
                    {
                        Id = id,
                        Nombre = nombre,
                        ProvinciaId = null
                    });
                }
            }
            Program.Continuar(3);
        }

        private static long OpcionModificarMunicipio()
        {
            long id;
            Console.WriteLine();
            ConsultarMunicipios();
            Console.WriteLine();
            Console.Write("Introduce el ID del MUNICIPIO que deseas MODIFICAR: ");
            Int64.TryParse(Console.ReadLine(), out id);
            Console.Write("Introduce el nuevo NOMBRE del MUNICIPIO: ");
            return id;
        }

        private static void ConsultarMunicipioPorNombre(string nombre)
        {
            List<Municipio> municipios = Bll.MunicipiosBll.BuscarPorNombre(nombre).ToList();

            if (municipios.Count > 0)
            {
                foreach (var item in municipios)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No existen MUNICIPIOS que contengan la expresión: " + nombre);
            }

            Program.Continuar(3);
        }

        private static void ConsultarMunicipioPorId(long id)
        {
            Municipio municipio = Bll.MunicipiosBll.BuscarPorId(id);

            if (municipio != null)
            {
                Console.WriteLine(municipio);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No existe el MUNICIPIO con el Id = " + id);
            }

            Program.Continuar(3);
        }

        private static Municipio OpcionInsertarMunicipio()
        {
            Console.WriteLine();
            Console.Write("Introduce el NOMBRE del nuevo MUNICIPIO: ");
            string nombre = Console.ReadLine();
            Console.Write("Introduce el ID de la PROVINCIA del nuevo MUNICIPIO (0 para null): ");
            long provinciaId;
            Int64.TryParse(Console.ReadLine(), out provinciaId);
            Municipio municipio;
            Provincia provincia = Bll.ProvinciasBll.BuscarPorId(provinciaId);
            if (provincia == null)
            {
                municipio = new Municipio()
                {
                    Nombre = nombre,
                    ProvinciaId = null
                };
            }
            else
            {
                municipio = new Municipio()
                {
                    Nombre = nombre,
                    ProvinciaId = provinciaId
                };
            }

            return municipio;
        }

        private static void InsertarMunicipio(Municipio municipio)
        {
            Bll.MunicipiosBll.Guardar(municipio);

            Program.Continuar(3);
        }

        private static void OpcionMunicipioNombre()
        {
            Console.WriteLine();
            Console.Write("Introduce el NOMBRE del MUNICIPIO que deseas buscar: ");
        }

        private static long OpcionMunicipioId()
        {
            long id;
            Console.WriteLine();
            Console.Write("Introduce el ID del MUNICIPIO que deseas buscar: ");
            Int64.TryParse(Console.ReadLine(), out id);
            return id;
        }

        private static void ConsultarMunicipios()
        {
            var municipios = Bll.MunicipiosBll.Consultar();

            Console.WriteLine();
            Program.Cabecera("LISTADO DE MUNICIPIOS");

            foreach (var item in municipios)
            {
                Console.WriteLine(item);
            }

            Program.Continuar(3);
        }
    }
}
