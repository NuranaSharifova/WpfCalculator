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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool pressedoperator = false;
        bool pressedequal = false;
        string tempcalc = "";
        string tempsign = "";
        bool minus = false;
        public MainWindow()
        {
            InitializeComponent();
            textBox1.Text = "";
            textBox2.Text = "";
        }
        void Calculate(string text) {

            double answer = 0;
            string[] arr = textBox1.Text.Split('+', '-', '/', '*');
            if (arr[0] == "") { arr[0] = arr[1]; minus = true; }
            switch (text)
            {
                case "+":
                    if (!minus) answer = Double.Parse(arr[0]) + Double.Parse(textBox2.Text);
                    else { answer = Double.Parse(textBox2.Text) - Double.Parse(arr[0]); minus = false; };

                    break;
                case "-":
                    if (!minus) answer = Double.Parse(arr[0]) - Double.Parse(textBox2.Text);
                    else { answer = Double.Parse(arr[0]) + Double.Parse(textBox2.Text); minus = false; };
                    break;
                case "*":
                    answer = Double.Parse(arr[0]) * Double.Parse(textBox2.Text);
                    break;
                case "/":
                    answer = Double.Parse(arr[0]) / Double.Parse(textBox2.Text);
                    break;
                default:
                    break;
            }
            textBox2.Text = answer.ToString();
            if (!pressedequal)
            {

                textBox1.Text = answer.ToString() + tempsign;
            }




        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!pressedoperator)
            {
                textBox2.Text += (sender as Button).Content.ToString();
            }
            else
            {

                textBox2.Text = (sender as Button).Content.ToString();
                pressedoperator = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            pressedoperator = true;
            if (textBox1.Text == "" || pressedequal == true)
            {
                textBox1.Text = textBox2.Text + (sender as Button).Content.ToString();
                tempcalc = (sender as Button).Content.ToString();
                tempsign = (sender as Button).Content.ToString();
                pressedequal = false;
            }
            else
            {

                tempsign = (sender as Button).Content.ToString();
                Calculate(tempcalc);
                tempcalc = (sender as Button).Content.ToString();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            string text = textBox2.Text;
            pressedequal = true;
            Calculate(tempcalc);
            textBox1.Text += text;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
           

                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            
        }
    }
}
