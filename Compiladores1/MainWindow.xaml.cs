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

namespace Compiladores1
{
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
            string[] tokens;
            string codigo = textBox.Text;
            tokens = codigo.Split('\r', '\n', ' ', '\0');
            if(tokens.Length == 0)
            {
                string sinTokens = "El editor está vacío.";    
                MessageBox.Show(sinTokens);
                return;
            }
            /*foreach(string s in tokens)
            {
                if (string.IsNullOrEmpty(s))
                {
                    Console.WriteLine("Empty");
                    continue;
                }
                Console.WriteLine("WORD:" + s + "/");
            }
            */
           compilador.automata(tokens);
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
