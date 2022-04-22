using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string zawartoscBtn;
        string startowy = "0";
        double czasowy;
        string funkcja = "";


        public MainWindow()
        {
            InitializeComponent();
            Ekran.Text = startowy;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (startowy == "0")
            {
                startowy = "";
                Ekran.Text = startowy;
                zawartoscBtn = (string)((Button)sender).Content;
                czasowy = double.Parse(zawartoscBtn);
                Ekran.Text += czasowy.ToString();
            }
            else
            {
                zawartoscBtn = (string)((Button)sender).Content;
                czasowy = double.Parse(zawartoscBtn);
                Ekran.Text += czasowy.ToString();
            }
            
        }
       


        #region Operacje


        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            var operacja = Ekran.Text;

            if (ZawartaOperacja(operacja))
            {
                Ekran.Text = OperacjeObliczeniowe(operacja).ToString();
            }
            
            funkcja = "+";
            Ekran.Text += funkcja;

        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            var operacja = Ekran.Text;
            if (ZawartaOperacja(operacja))
            {
                Ekran.Text = OperacjeObliczeniowe(operacja).ToString();
            }

            funkcja = "-";
            Ekran.Text += funkcja;
        }

        private void btnRazy_Click(object sender, RoutedEventArgs e)
        {
            var operacja = Ekran.Text;
            if (ZawartaOperacja(operacja))
            {
                Ekran.Text = OperacjeObliczeniowe(operacja).ToString();
            }
            funkcja = "x";
            Ekran.Text += funkcja;
        }

        private void btnDziel_Click(object sender, RoutedEventArgs e)
        {
            var operacja = Ekran.Text;
            if (ZawartaOperacja(operacja))
            {
                Ekran.Text = OperacjeObliczeniowe(operacja).ToString();

            }
            funkcja = "/";
            Ekran.Text += funkcja;
        }
        #endregion

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            startowy = "0";
            czasowy = 0;
            funkcja = "";
            Ekran.Text = startowy;
        }

        private void btnRowna_Click(object sender, RoutedEventArgs e)
        {
            var operacja = Ekran.Text;
            

            Ekran.Text = OperacjeObliczeniowe(operacja).ToString();
            
            

            //startowy = "0";
        }

        private bool ZawartaOperacja(string operacja) => operacja.Contains("+") || operacja.Contains("-") || operacja.Contains("x") || operacja.Contains("/");
       
        
        private string OperacjeObliczeniowe(string operacja)
        {
            if (operacja.Contains("+"))
            {
                var elements = operacja.Split('+');

                if (elements[1] == "")
                {
                    return (double.Parse(elements[0]) + double.Parse(elements[0])).ToString();

                }
                else
                {
                    return (double.Parse(elements[0]) + double.Parse(elements[1])).ToString();


                }

            }

            if (operacja.Contains("-"))
            {
                var elements = operacja.Split('-');
                if (elements[1] == "")
                {
                    return (double.Parse(elements[0]) - double.Parse(elements[0])).ToString();

                }
                else if (elements[0].Contains("-"))
                {
                    return double.Parse(elements[0]).ToString();
                }
                else
                {
                    return (double.Parse(elements[0]) - double.Parse(elements[1])).ToString();


                }
            }

            if (operacja.Contains("x"))
            {
                var elements = operacja.Split('x');

                if (elements[1] == "")
                {
                    return (double.Parse(elements[0]) * double.Parse(elements[0])).ToString();

                }
                else
                {
                    return (double.Parse(elements[0]) * double.Parse(elements[1])).ToString();


                }

            }

            if (operacja.Contains("/"))
            {
                var elements = operacja.Split('/');


                if (elements[1] == "")
                {
                    return (double.Parse(elements[0]) / double.Parse(elements[0])).ToString();

                }
                else if(elements[1] == "0")
                {
                    return "nie dziel przez 0";
                }
                else
                {

                    
                    return (double.Parse(elements[0]) / double.Parse(elements[1])).ToString();
                    
                }
            }
            return "0";
        
        }
    }
}

