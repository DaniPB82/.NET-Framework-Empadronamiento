using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlConsola
{
    internal class PersonaOp
    {
        internal static void MenuPersonasPropiedades()
        {
            Console.Clear();

            Program.Cabecera("MENÚ PERSONAS Y PROPIEDADES");

            Console.WriteLine("1 - Operaciones con PERSONAS");
            Console.WriteLine("2 - Operaciones con PROPIEDADES");
            Console.WriteLine("3 - Volver al MENÚ PRINCIPAL");
            Console.WriteLine("4 - SALIR");

            int accion = Program.OpcionMenu();

            //AccionMenuPersonasPropiedades(accion);
        }

        internal static void MenuPersonas()
        {
            Console.Clear();

            Program.Cabecera("MENÚ PERSONAS");

            Console.WriteLine("1 - Listado");
            Console.WriteLine("2 - Búsqueda por ID");
            Console.WriteLine("3 - Búsqueda por MUNICIPIO");
            Console.WriteLine("4 - Búsqueda por DIRECCIÓN");
            Console.WriteLine("5 - Búsqueda por CP");
            Console.WriteLine("6 - Insertar");
            Console.WriteLine("7 - Modificar");
            Console.WriteLine("8 - Eliminar");
            Console.WriteLine("9 - Volver al MENÚ PRINCIPAL");
            Console.WriteLine("10 - SALIR");

            int accion = Program.OpcionMenu();

            //AccionMenuPersonas(accion);
        }

        internal static void MenuPropiedades()
        {
            Console.Clear();

            Program.Cabecera("MENÚ PROPIEDADES");

            Console.WriteLine("1 - Listado");
            Console.WriteLine("2 - Búsqueda por IDs");
            Console.WriteLine("3 - Búsqueda de PROPIEDADES por PERSONA");
            Console.WriteLine("4 - Búsqueda de PERSONAS por PROPIEDAD");
            Console.WriteLine("5 - Insertar");
            Console.WriteLine("6 - Modificar");
            Console.WriteLine("7 - Eliminar");
            Console.WriteLine("8 - Volver al MENÚ PRINCIPAL");
            Console.WriteLine("9 - SALIR");

            int accion = Program.OpcionMenu();

            //AccionMenuPropiedades(accion);
        }
    }
}
