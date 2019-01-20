using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace Compiladores1
{
    class Lineas
    {
        public List<int> linea = new List<int>();
        public List<string> token = new List<string>();
        public List<string[]> tokens = new List<string[]>();

        public void addLinea(int noLinea, string linea)
        {
            string[] tokens = linea.Split('\r', '\n', ' ', '\0');
            this.linea.Add(noLinea);
            this.token.Add(linea);
            this.tokens.Add(tokens);
        }

        public int getSize()
        {
            return linea.Count;
        }

        public int getSizeArrayTokens()
        {
            return tokens.Count;
        }
    }
    
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string Pattern = @"^[a-zA-Z][a-zA-Z0-9]*$";

        Compilador compilador = new Compilador();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string codigo = textBox.Text;
            Lineas l = new Lineas();
            int contadorLineas = textBox.LineCount;
            for(int i = 0; i < contadorLineas; i++)
            {
                l.addLinea(i + 1, textBox.GetLineText(i));
            }
            int elementos = l.getSize();
            /*
            for (int i = 0; i < elementos; i++)
            {
                Console.WriteLine("Linea " + l.linea[i] + ": " + l.token[i]);
                Console.Write("Tokens en linea: ");
                foreach (string s in l.tokens[i])
                {
                    Console.Write( s + " " );
                }
                Console.WriteLine();
            }
            */
            compilador.automata(ref l, elementos);
        }

        public void setTextBox3 (string cadena)
        {
            textBox3.AppendText(cadena);
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}
