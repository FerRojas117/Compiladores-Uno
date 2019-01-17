using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Compiladores1
{
    class Compilador
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        const int estadoInicial = 0;
        const int estadoFinal = 26;
        int posicion;
        int estadoActual = 0;
        int valor;
        const string P = "Programa";
        const string I = "Inicio";
        const string F = "Fin";
        const string DC = "DibujarCara";
        const string EC = "EliminarCara";
        const string D = "Dormir";
        const string CM = "CambiarModo";

        const string PA = "(";
        const string N = "numero";
        const string CT = "cadenaTexto";
        const string C = ",";
        const string PC = ")";
        const string M = "modo";
        int[,] matrizTrans = new int[,]
        {
            {1,0,0,0,0,0,0,0,0,0,0,0,0}, // 1
            {0,0,0,0,0,0,0,0,0,2,0,0,0}, // 2
            {0,3,0,0,0,0,0,0,0,0,0,0,0}, // 3
            {0,0,26,4,15,18,21,0,0,0,0,0,0}, // 4
            {0,0,0,0,0,0,0,5,0,0,0,0,0}, // 5
            {0,0,0,0,0,0,0,0,6,0,0,0,0}, // 6
            {0,0,0,0,0,0,0,0,0,0,7,0,0}, // 7
            {0,0,0,0,0,0,0,0,8,0,0,0,0}, // 8
            {0,0,0,0,0,0,0,0,0,0,9,0,0}, // 9
            {0,0,0,0,0,0,0,0,10,0,0,0,0}, // 10
            {0,0,0,0,0,0,0,0,0,0,11,0,0}, // 11
            {0,0,0,0,0,0,0,0,0,12,0,0,0}, // 12
            {0,0,0,0,0,0,0,0,0,0,13,0,0}, // 13
            {0,0,0,0,0,0,0,0,0,0,0,0,14}, // 14
            {0,0,0,0,0,0,0,0,0,0,0,3,0}, // 15
            {0,0,0,0,0,0,0,16,0,0,0,0,0}, // 16
            {0,0,0,0,0,0,0,0,0,17,0,0,0}, // 17
            {0,0,0,0,0,0,0,0,0,0,0,3,0}, // 18
            {0,0,0,0,0,0,0,19,0,0,0,0,0}, // 19
            {0,0,0,0,0,0,0,0,20,0,0,0,0}, // 20
            {0,0,0,0,0,0,0,0,0,0,0,3,0}, // 21
            {0,0,0,0,0,0,0,22,0,0,0,0,0}, // 22
            {0,0,0,0,0,0,0,0,0,23,0,0,0}, // 23
            {0,0,0,0,0,0,0,0,0,0,24,0,0}, // 24
            {0,0,0,0,0,0,0,0,0,0,0,0,25}, // 25
            {0,0,0,0,0,0,0,0,0,0,0,3,0}, // 26
        };

        

        public void automata(string[] tokens)
        {
            int tamTokens = tokens.Length;
            posicion = 0;
            foreach (string tok in tokens)
            {
                if (string.IsNullOrEmpty(tok))
                {
                    posicion++;
                    continue;
                }
                switch (tok)
                {
                    case P:
                        valor = 0;
                        Console.WriteLine(P);
                        break;
                    case I:
                        valor = 1;
                        Console.WriteLine(I);
                        break;
                    case F:
                        valor = 2;
                        Console.WriteLine(F);
                        break;
                    case DC:
                        valor = 3;
                        Console.WriteLine(DC);
                        break;
                    case EC:
                        valor = 4;
                        Console.WriteLine(EC);
                        break;
                    case D:
                        valor = 5;
                        Console.WriteLine(D);
                        break;
                    case CM:
                        valor = 6;
                        Console.WriteLine(CM);
                        break;
                    case PA:
                        valor = 7;
                        Console.WriteLine(PA);
                        break;
                    case N:
                        valor = 8;
                        Console.WriteLine(N);
                        break;
                    case CT:
                        valor = 9;
                        Console.WriteLine(CT);
                        break;
                    case C:
                        valor = 10;
                        Console.WriteLine(C);
                        break;
                    case PC:
                        valor = 11;
                        Console.WriteLine(PC);
                        break;
                    case M:
                        valor = 12;
                        Console.WriteLine(M);
                        break;
                    default:
                        valor = 13;
                        Console.WriteLine("Malo");
                        break;
                }
                if (valor == 13)
                {
                    posicion++;
                    continue;
                }
                Console.WriteLine("EA:" + estadoActual);
                Console.WriteLine("valor:" + valor);
                // Error de secuencia de automata
                if (matrizTrans[estadoActual, valor] == 0)
                {
                    Console.WriteLine("Error de secuencia de automata");
                    estadoActual = valor;
                    posicion++;
                    checkFin(tamTokens, posicion, estadoActual);
                }
                // <todo bien
                else
                {
                    Console.WriteLine("alles ok");
                    estadoActual = matrizTrans[estadoActual, valor];
                    posicion++;
                    checkFin(tamTokens, posicion, estadoActual);
                }
            }     
        }

        public void checkFin (int tamTokens, int posicion, int estadoActual)
        {
            Console.WriteLine("EA:" + estadoActual);
            Console.WriteLine("pos:" + posicion);
            Console.WriteLine("tamTokens:" + tamTokens);
            if (posicion == tamTokens - 1 && estadoActual < 26)
            {
                Console.WriteLine("NO acabo bien" + '\n');
                this.posicion = 0;
                return;
            }
            if (posicion == tamTokens)
            {
                Console.WriteLine("Perfectillo" + '\n');
                posicion = 0;
                return;
            }
        }
    }
}
