/* ============================================
 * AUTOR:	Rubén Zúñiga García
 * FECHA:	12/03/2018
 * VERSION:	1.0
 * DESCRIPCIÓN:	Ejercicio 1
 * ============================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEntradas
{
    class Program
    {
        const int POPULARESTOTAL = 20;
        const int GENERALESTOTAL = 10;
        const int VIPTOTAL = 5;

        static void Main(string[] args)
        {
            bool salir = false;
            GestionarEntradas gestion = new GestionarEntradas(POPULARESTOTAL, GENERALESTOTAL, VIPTOTAL);

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine(
                    "          Gestion de Entradas \n" +
                    "    ===============================\n" +
                    "    1.   Entradas libres y vendidas\n" +
                    "    2.   Vender entrada\n" +
                    "    3.   Mostrar dinero recaudado\n" +
                    "    4.   Salir\n" +
                    "    Seleccione una opción: ");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        MostrarEntradas(gestion);
                        break;
                    case '2':
                        VenderEntrada(gestion);
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Dinero recaudado: {0} euros.", gestion.DineroRecaudado);
                        Console.WriteLine("Pulse una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case '4':
                        salir = true;
                        break;
                }
            }
        }

        static void MostrarEntradas(GestionarEntradas g)
        {
            Console.Clear();
            Console.WriteLine(
                "    Entradas libres y ocupadas \n" +
                "    ===============================\n");
            Console.WriteLine("      Populares libres: {0}", g.NEntPopLibres);
            Console.WriteLine("    Populares ocupadas: {0}", POPULARESTOTAL - g.NEntPopLibres);
            Console.WriteLine("      Generales libres: {0}", g.NEntGenLibres);
            Console.WriteLine("    Generales ocupadas: {0}", GENERALESTOTAL - g.NEntGenLibres);
            Console.WriteLine("            VIP libres: {0}", g.NEntVIPLibres);
            Console.WriteLine("          VIP ocupadas: {0}", VIPTOTAL - g.NEntVIPLibres);
            Console.WriteLine("\n    Pulse una tecla para continuar...");

            Console.ReadKey(true);
        }

        static void VenderEntrada(GestionarEntradas g)
        {
            Console.Clear();
            Console.WriteLine(
                "    Especifique el tipo: \n" +
                "    1. Popular\n" +
                "    2. General\n" +
                "    3. VIP\n" +
                "    Otra tecla para salir. \n");

            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    if (g.Vender(new Entrada(Tipo.Popular)))
                        Console.WriteLine("\nEntrada vendida con éxito.");
                    else
                        Console.WriteLine("\nNo quedan entradas disponibles.");
                    break;
                case '2':
                    if (g.Vender(new Entrada(Tipo.General)))
                        Console.WriteLine("\nEntrada vendida con éxito.");
                    else
                        Console.WriteLine("\nNo quedan entradas disponibles.");
                    break;
                case '3':
                    if (g.Vender(new Entrada(Tipo.VIP)))
                        Console.WriteLine("\nEntrada vendida con éxito.");
                    else
                        Console.WriteLine("\nNo quedan entradas disponibles.");
                    break;
            }
            Console.WriteLine("\nPulse una tecla para continuar...");
            Console.ReadKey(true);
        }
    }

    public enum Tipo { Popular, General, VIP }

    public class Entrada
    {
        

        Tipo _tipoEntrada;
        int _coste;

        public Entrada(Tipo tipo)
        {
            this._tipoEntrada = tipo;
            if (tipo == Tipo.Popular)
                _coste = 5;
            else if (tipo == Tipo.General)
                _coste = 10;
            else
                _coste = 20;
        }

        public Tipo TipoEntrada { get { return _tipoEntrada; } }
        public int Coste { get { return _coste; } }
    }

    class GestionarEntradas
    {
        int _nEntPopLibres;
        int _nEntGenLibres;
        int _nEntVIPLibres;
        float _dineroRecaudado;

        public GestionarEntradas(int entradasPop, int entradasGen, int entradasVIP)
        {
            _nEntPopLibres = entradasPop;
            _nEntGenLibres = entradasGen;
            _nEntVIPLibres = entradasVIP;
            _dineroRecaudado = 0;
        }

        public int NEntPopLibres { get { return _nEntPopLibres; } }
        public int NEntGenLibres { get { return _nEntGenLibres; } }
        public int NEntVIPLibres { get { return _nEntVIPLibres; } }
        public float DineroRecaudado { get { return _dineroRecaudado; } }

        public bool Vender(Entrada entrada)
        {
            bool vendido = false;

            switch (entrada.TipoEntrada)
            {
                case Tipo.Popular:
                    if (_nEntPopLibres != 0)
                    {
                        _nEntPopLibres--;
                        vendido = true;
                    }
                    break;
                case Tipo.General:
                    if (_nEntGenLibres != 0)
                    {
                        _nEntGenLibres--;
                        vendido = true;
                    }
                    break;
                case Tipo.VIP:
                    if (_nEntVIPLibres != 0)
                    {
                        _nEntVIPLibres--;
                        vendido = true;
                    }
                    break;
            }

            if (vendido)
                _dineroRecaudado += entrada.Coste;

            return vendido;
        }
    }
}
