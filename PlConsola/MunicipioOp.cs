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

            switch (opcion)
            {
                case 1:
                    ConsultarMunicipios();
                    Program.Continuar(2);
                    break;
                case 2:
                    id = OpcionMunicipioId();
                    //ConsultarMunicipioPorId(id);
                    break;
                case 3:
                    OpcionMunicipioNombre();
                    //ConsultarMunicipioPorNombre(Console.ReadLine());
                    break;
                case 4:
                    Municipio municipio = OpcionInsertarMunicipio();
                    InsertarMunicipio(municipio);
                    break;
                case 5:
                    //id = OpcionModificarMunicipio();
                    //ModificarMunicipio(id, Console.ReadLine());
                    break;
                case 6:
                    //id = OpcionEliminarMunicipio();
                    //EliminarMunicipio(id);
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

        private static Municipio OpcionInsertarMunicipio()
        {
            Console.WriteLine();
            Console.Write("Introduce el NOMBRE del nuevo MUNICIPIO: ");
            string nombre = Console.ReadLine();
            Console.Write("Introduce el ID de la PROVINCIA del nuevo MUNICIPIO: ");
            long provinciaId;
            Int64.TryParse(Console.ReadLine(), out provinciaId);
            Municipio municipio;
            if (provinciaId.Equals(""))
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

            Program.Continuar(2);
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
        }
    }
}
