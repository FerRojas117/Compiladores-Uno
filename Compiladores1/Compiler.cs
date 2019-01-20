using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Compiladores1
{

    class DibujarCara
    {
        // DibujarCara
       public string coordX; public string coordY; public string radio; public string nombreCara; public string modo;
        // int coordX; int coordY; int radio; string nombreCara; string modo;
        // DibujarCara - Constructor
        /* public FuncionesInterprete(string instruccion, int coordX, int coordY, int radio, string nombreCara, string modo)
         {
             this.coordX = coordX; this.coordY = coordY; this.radio = radio; this.nombreCara = nombreCara;
             this.modo = modo;
         } 
         */
        public DibujarCara(string coordX, string coordY, string radio, string nombreCara, string modo)
        {
            this.coordX = coordX; this.coordY = coordY; this.radio = radio; this.nombreCara = nombreCara;
            this.modo = modo;
        }

        public void imprimirAtributos()
        {
            Console.WriteLine(this.coordX + " " + this.coordY + " " + this.radio + " " + this.nombreCara + " " + this.modo + " ");
        }

        public bool checarDibujarCara(ref List<DibujarCara> dibujarCaraList, string nombreCara)
        {
            int longitud = dibujarCaraList.Count;
            if (longitud <= 0)
            {
                // cara se puede dibujar, no hay elementos
                Console.WriteLine("cara se puede dibujar, no hay elementos");
                return true;
            }
            else
            {
               foreach(DibujarCara fi in dibujarCaraList)
                {
                    // cara no se puede dibujar, el elementos ya está dibujado
                    if ( fi.nombreCara == nombreCara)
                    {
                        Console.WriteLine("cara no se puede dibujar, el elementos ya está dibujado");
                        return false;
                    }
                }
                // cara se puede dibujar, no hay nombre igual
                Console.WriteLine("cara se puede dibujar, no hay nombre igual");
                return true;
            }
        }   
    }

    class EliminarCara
    {
        // EliminarCara
        public string EliminarNombreCara;
        // EliminarCara - Constructor
        public EliminarCara(string EliminarNombreCara)
        {
            this.EliminarNombreCara = EliminarNombreCara;
        }

        public void imprimirAtributos()
        {
            Console.WriteLine(this.EliminarNombreCara);
        }

        public bool checarEliminarCara(ref List<DibujarCara> dibujarCaraList, string EliminarNombreCara)
        {
            int longitud = dibujarCaraList.Count;
            if (longitud <= 0)
            {
                // cara no existe, no hay elementos dibujados, no es posible eliminar
                Console.WriteLine("cara no existe, no hay elementos dibujados, no es posible eliminar");
                return false;
            }
            else
            {
                foreach (DibujarCara fi in dibujarCaraList)
                {
                    // cara existe, eliminar cara
                    if (fi.nombreCara == EliminarNombreCara)
                    {
                        Console.WriteLine("cara existe, eliminar cara");
                        return true;
                    }
                }
                // cara no existe, no es posible eliminar
                Console.WriteLine("cara no existe, no es posible eliminar");
                return false;
            }
        }
    }

    class Dormir
    {
        // Dormir
        //int nSegundos;
        public string nSegundos;

        // Dormir - Constructor
        /* public FuncionesInterprete(string instruccion, int nSegundos)
         {
             this.nSegundos = nSegundos;
         }
         */
        public Dormir(string nSegundos)
        {
            this.nSegundos = nSegundos;
        }

        public void imprimirAtributos()
        {
            Console.WriteLine(this.nSegundos);
        }
    }

    class CambiarModo
    {
        // CambiarModo
        public string CambiarModoNombreCara;
        public string nuevoModo;

        // CambiarModo - Constructor
        public CambiarModo(string CambiarModoNombreCara, string nuevoModo)
        {
            this.CambiarModoNombreCara = CambiarModoNombreCara;
            this.nuevoModo = nuevoModo;
        }

        public void imprimirAtributos()
        {
            Console.WriteLine(this.CambiarModoNombreCara + " " + this.nuevoModo);
        }

        public bool checarCambiarModo(ref List<DibujarCara> dibujarCaraList, string CambiarModoCara)
        {
            int longitud = dibujarCaraList.Count;
            if (longitud <= 0)
            {
                // cara no existe, no hay elementos dibujados, no es posible CambiarModo
                Console.WriteLine("cara no existe, no hay elementos dibujados, no es posible CambiarModo");
                return false;
            }
            else
            {
                foreach (DibujarCara fi in dibujarCaraList)
                {
                    // cara existe, cambiarModo
                    if (fi.nombreCara == CambiarModoCara)
                    {
                        Console.WriteLine("cara existe, cambiarModo");
                        return true;
                    }
                }
                Console.WriteLine("cara no existe, no es posible cambiarModo");
                // cara no existe, no es posible cambiarModo
                return false;
            }
        }

    }

    class Compilador
    {
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
        const string t = "triste";
        const string e = "enojada";
        const string f = "feliz";
        const string d = "dormida";
        const string n = "neutral";

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

        public void automata(ref Lineas l, int elementos)
        {
            List<string> toksCompletos = new List<string>();
            List<int> noLinea = new List<int>();
            int tamTokens = 0;
            for (int i = 0; i < l.getSizeArrayTokens(); i++)
            {
                tamTokens += l.tokens[i].Length;
            }
            posicion = 0;
            for (int i = 0; i < elementos; i++)
            {
                foreach (string tok in l.tokens[i])
                {
                    if (string.IsNullOrEmpty(tok))
                    {
                        posicion++;
                        CheckFin(tamTokens, posicion, estadoActual);
                        continue;
                    }
                    toksCompletos.Add(tok);
                    noLinea.Add(l.linea[i]);
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
                        case t:
                        case e:
                        case f:
                        case d:
                        case n:
                            valor = 12;
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
                    // Console.WriteLine("EA:" + estadoActual);
                    // Console.WriteLine("valor:" + valor);
                    // Error de secuencia de automata
                    if (matrizTrans[estadoActual, valor] == 0)
                    {
                        Console.WriteLine("Error sintactico en la linea: " + l.linea[i] + ", token inesperado: " + tok);
                        estadoActual = valor;
                        posicion++;
                        CheckFin(tamTokens, posicion, estadoActual);
                    }
                    // todo bien
                    else
                    {
                        Console.WriteLine("OK");
                        estadoActual = matrizTrans[estadoActual, valor];
                        posicion++;
                        CheckFin(tamTokens, posicion, estadoActual);
                    }
                }
            }
            estadoActual = 0;
            Console.WriteLine("--------------------------------------------");
            List<DibujarCara> dibujarCaraList = new List<DibujarCara>();
            List<EliminarCara> eliminarCaraList = new List<EliminarCara>();
            List<Dormir> dormirList = new List<Dormir>();
            List<CambiarModo> cambiarModoList = new List<CambiarModo>();

            int noToksCompletos = toksCompletos.Count;
            for (int j = 0; j < noToksCompletos; j++)
            {
                switch (toksCompletos[j])
                {
                    case DC:
                       //  Console.WriteLine(DC);
                        DibujarCara dc = new DibujarCara(toksCompletos[j + 2], toksCompletos[j + 4], toksCompletos[j + 6], toksCompletos[j + 8], toksCompletos[j + 10]);
                        //dc.imprimirAtributos();
                        if(!dc.checarDibujarCara(ref dibujarCaraList, toksCompletos[j + 8]))
                        {
                           Console.WriteLine("DC,Error semantico en linea: " + noLinea[j]);
                           j += 11;
                           break;
                         }
                        dibujarCaraList.Add(dc);
                        j += 11;
                        break;
                    case EC:
                        // Console.WriteLine(EC);
                        EliminarCara ec = new EliminarCara(toksCompletos[j + 2]);
                        if (!ec.checarEliminarCara(ref dibujarCaraList, toksCompletos[j + 2]))
                        {
                            Console.WriteLine("EC,Error semantico en linea: " + noLinea[j]);
                            j += 11;
                            break;
                        }
                        ec.imprimirAtributos();
                        // instrucciones.Add(ec);
                        j += 3;
                        break;
                    case D:
                        //Console.WriteLine(D);
                        Dormir d = new Dormir(toksCompletos[j + 2]);
                        d.imprimirAtributos();
                        //instrucciones.Add(d);
                        j += 3;
                        break;
                    case CM:
                        //Console.WriteLine(CM);
                        CambiarModo cm = new CambiarModo(toksCompletos[j + 2], toksCompletos[j + 4]);
                        if (!cm.checarCambiarModo(ref dibujarCaraList, toksCompletos[j + 2]))
                        {
                            Console.WriteLine("CM,Error semantico en linea: " + noLinea[j]);
                            j += 11;
                            break;
                        }
                        cm.imprimirAtributos();
                        //instrucciones.Add(cm);
                        j += 5;
                        break;
                }
            }
        }

        public void CheckFin(int tamTokens, int posicion, int estadoActual)
        {
            Console.WriteLine("EA:" + estadoActual);
            Console.WriteLine("pos:" + posicion);
            Console.WriteLine("tamTokens:" + tamTokens);
            if (posicion == tamTokens - 1 && estadoActual < 26)
            {
                Console.WriteLine("Error en la ultima linea, no acabo con Fin" + '\n');
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

