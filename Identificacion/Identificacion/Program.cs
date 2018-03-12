/* ============================================
 * AUTOR:	Rubén Zúñiga García
 * FECHA:	12/03/2018
 * VERSION:	1.0
 * DESCRIPCIÓN:	Ejercicio 3
 * ============================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Identificacion
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = @"C:\basura\claves.dat";
            string usuario = string.Empty;
            string clave = string.Empty;
            string[] archivo;
            bool claveCorrecta = false;

            try
            {
                using (StreamReader leer = new StreamReader(ruta))
                    archivo = leer.ReadToEnd().Split(';');

                claveCorrecta = Conectarse(archivo);
                Console.Clear();

                if (claveCorrecta)
                    Console.WriteLine("Bienvenido al sistema.");
            }
            catch
            {
                Console.WriteLine("ERROR: El archivo de la ruta {0} no existe.", ruta);
            }

            Console.WriteLine("Pulse una tecla para salir.");

            Console.ReadKey();
        }

        static bool Conectarse(string[] archivo)
        {
            string usuario = string.Empty;
            string clave = string.Empty;
            int intentos = 0;
            const int MAXINTENTOS = 3;
            bool claveCorrecta = false;
            bool salir = false;
            while (intentos < MAXINTENTOS && !salir)
            {
                Console.Clear();

                Console.WriteLine("          IDENTIFICACIÓN (Clave no admite espacios o ;)");
                Console.WriteLine("   =======================================================================");
                Console.WriteLine("     Quedan {0} de {1} intentos.",intentos + 1, MAXINTENTOS);
                Console.Write("      Usuario: ");
                usuario = Console.ReadLine();
                Console.Write("        Clave: ");
                clave = IntroducirClave();

                foreach (string linea in archivo)
                {
                    if (linea == usuario + " " + clave)
                        claveCorrecta = true;
                }

                if (!claveCorrecta)
                {
                    intentos++;
                    Console.WriteLine("Usuario o contraseña invalidos. Intente de nuevo.");
                }
                else
                    salir = true;
            }

            return claveCorrecta;
        }

        static string IntroducirClave()
        {
            ConsoleKeyInfo entrada;
            string clave = string.Empty;

            do
            {
                entrada = Console.ReadKey(true);
                if (entrada.Key == ConsoleKey.Backspace && clave.Length > 0)
                {
                    Console.Write("\b \b");
                    clave = clave.Remove(clave.Length - 1);
                }
                else if (entrada.KeyChar != ' ' && entrada.KeyChar != ';' && entrada.Key != ConsoleKey.Backspace && entrada.Key != ConsoleKey.Enter)
                {
                    clave += entrada.KeyChar;
                    Console.Write("*");
                }
            } while (entrada.Key != ConsoleKey.Enter);

            return clave;
        }
    }
}
