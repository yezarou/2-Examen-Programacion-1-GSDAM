/* ============================================
 * AUTOR:	Rubén Zúñiga García
 * FECHA:	12/03/2018
 * VERSION:	1.0
 * DESCRIPCIÓN:	Ejercicio 2
 * ============================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Contar
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] argsFormateado;
            string ruta = string.Empty;
            string[] palabrasABuscar;
            char[] separadorLinea = { '\r', '\n' };
            char[] separadorFrase = { '\r', '\n', '.' };
            string[] texto;
            string[] textoMinuscula;
            
            try
            {
                argsFormateado = FormatearArgs(args);
                ruta = argsFormateado[0];
                palabrasABuscar = new string[argsFormateado.Length - 1];
                for (int i = 0; i < palabrasABuscar.Length; i++)
                    palabrasABuscar[i] = argsFormateado[i + 1].ToLower();

                using (StreamReader leer = new StreamReader(ruta))
                {
                    texto = leer.ReadToEnd().Split(separadorLinea);
                    textoMinuscula = new string[texto.Length];

                    for (int i = 0; i < texto.Length; i++)
                        textoMinuscula[i] = texto[i].ToLower();


                    for (int i = 0; i < textoMinuscula.Length; i++)
                    {
                        if (textoMinuscula[i] != string.Empty)
                        {
                            for (int j = 0; j < palabrasABuscar.Length; j++)
                                if (textoMinuscula[i].Contains(palabrasABuscar[j]))
                                {
                                    Console.WriteLine(texto[i]);
                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }


        }

        static string[] FormatearArgs(string[] args)
        {
            string ruta = string.Empty;
            int contador = 0;
            int nParametros = 0;
            const int MAXPALABRAS = 5;
            string[] resultado;

            while (!File.Exists(ruta))
            {
                ruta += args[contador++];
                ruta += " ";
            }

            if (contador == args.Length)
                throw new ArgumentNullException("No se especificó palabra a buscar.");

            if (args.Length - contador + 1 >=6)
                resultado = new string[6];
            else
                resultado = new string[(args.Length - contador + 1)];

            resultado[nParametros++] = ruta;

            while (nParametros < MAXPALABRAS + 1 && contador < args.Length)
                resultado[nParametros++] = args[contador++];

            return resultado;
        }
    }
}
