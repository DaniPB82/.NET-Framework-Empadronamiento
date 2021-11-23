using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuPincipal();
        }

        internal static void MenuPincipal()
        {
            Console.Clear();

            Cabecera("MENÚ PRINCIPAL");

            Console.WriteLine("1 - Operaciones con PROVINCIAS");
            Console.WriteLine("2 - Operaciones con MUNICIPIOS");
            Console.WriteLine("3 - Operaciones con VIVIENDAS");
            Console.WriteLine("4 - Operaciones con PERSONAS");
            Console.WriteLine("5 - SALIR");
            
            int accion = OpcionMenu();

            AccionMenuPrincipal(accion);
        }

        internal static int OpcionMenu()
        {
            Console.WriteLine();
            Console.Write("Elige la opción deseada: ");
            int opcion;
            Int32.TryParse(Console.ReadLine(), out opcion);
            return opcion;
        }

        private static void AccionMenuPrincipal(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    ProvinciaOp.MenuProvincias();
                    break;
                case 2:
                    MunicipioOp.MenuMunicipios();
                    break;
                case 3:
                    MenuViviendas();
                    break;
                case 4:
                    MenuPersonas();
                    break;
                case 5:
                    Environment.Exit(1);
                    break;
                default:
                    MenuPincipal();
                    break;
            }
        }

        internal static void Cabecera(string nombre)
        {
            Separador();
            Console.WriteLine(nombre);
            Separador();
        }

        internal static void Separador()
        {
            for (int i = 0; i < 80; i++)
            {
                if (i < 79)
                {
                    Console.Write("-");
                }
                else
                {
                    Console.WriteLine("-");
                }
            }
        }

        internal static void Continuar(int menu)
        {
            Console.WriteLine();
            Console.Write("Presione una tecla para continuar...");
            Console.ReadKey();

            switch (menu)
            {
                case 1:
                    MenuPincipal();
                    break;
                case 2:
                    ProvinciaOp.MenuProvincias();
                    break;
                case 3:
                    MunicipioOp.MenuMunicipios();
                    break;
                case 4:
                    MenuViviendas();
                    break;
                case 5:
                    MenuPersonas();
                    break;
                default:
                    break;
            }
        }

        

        internal static void MenuViviendas()
        {
            Console.WriteLine("Viviendas");
            //Console.Clear();

            //Cabecera("MENÚ PROVINCIAS");

            //Console.WriteLine("1 - Listado");
            //Console.WriteLine("2 - Búsqueda por ID");
            //Console.WriteLine("3 - Búsqueda por NOMBRE");
            //Console.WriteLine("4 - Insertar");
            //Console.WriteLine("5 - Modificar");
            //Console.WriteLine("6 - Eliminar");

            //Console.WriteLine();
            //Console.Write("Elige la opción deseada: ");
            //int opcionElegida = Console.Read();
            //OpcionMenuProvincias(opcionElegida);
        }

        internal static void MenuPersonas()
        {
            Console.WriteLine("Personas");
            //Console.Clear();

            //Cabecera("MENÚ PROVINCIAS");

            //Console.WriteLine("1 - Listado");
            //Console.WriteLine("2 - Búsqueda por ID");
            //Console.WriteLine("3 - Búsqueda por NOMBRE");
            //Console.WriteLine("4 - Insertar");
            //Console.WriteLine("5 - Modificar");
            //Console.WriteLine("6 - Eliminar");

            //Console.WriteLine();
            //Console.Write("Elige la opción deseada: ");
            //int opcionElegida = Console.Read();
            //OpcionMenuProvincias(opcionElegida);
        }
    }
}
