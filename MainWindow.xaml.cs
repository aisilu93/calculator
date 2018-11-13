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

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double a, b,b_prev,res;
        String operation, operation_prev;
        bool operation_pressed=false;
        public MainWindow()
        {
            InitializeComponent();
            a = b = 0;
            operation = "";
        }

        private String get_content(object obj)
        {
            Button button = (Button)obj;
            return button.Content.ToString();
        }

        private void Num_Click(object sender, RoutedEventArgs e)
        {
            String num = get_content(sender);
            if (operation_pressed) textBlock_main.Text = "";
            do
            {
                if (textBlock_main.Text == "")
                {
                    if (num == ",") { textBlock_main.Text = "0,"; break; }
                    if (num == "0") break;
                }
                textBlock_main.Text += num;
            } while (false);
            operation_pressed = false;
        }

        private void Button_Click_Equal(object sender, RoutedEventArgs e)
        {
            if (operation == "=")
            {
                operation = operation_prev;
                b = b_prev;
            }
            else b = double.Parse(textBlock_main.Text);
            operation_prev = operation;
            
            switch (operation)
            {
                case "+":
                    textBlock_history.Text = textBlock_history.Text + a.ToString() + " + "+b.ToString()+ " = ";
                    res = a + b;
                    break;
                case "-":
                    textBlock_history.Text = textBlock_history.Text + a.ToString() + " - " + b.ToString() + " = ";
                    res = a - b;
                    break;
                case "*":
                    textBlock_history.Text = textBlock_history.Text + a.ToString() + " * " + b.ToString() + " = ";
                    res = a * b;
                    break;
                case "/":
                    textBlock_history.Text = textBlock_history.Text + a.ToString() + " / " + b.ToString() + " = ";
                    res = a / b;
                    break;
            }
            a = res;
            b_prev = b;
            b = 0;
            textBlock_main.Text = res.ToString();
            textBlock_history.Text += res.ToString();
            textBlock_history.Text += "\n";
            textBlock_history.ScrollToEnd();
            operation_pressed = true;
            operation = "=";
        }

        private void Click_Operation(object sender, RoutedEventArgs e)
        {
            String oper = get_content(sender);
            if (operation == oper) return;
            if (operation_pressed) a = 0;
            operation = operation_prev = oper;
            operation_pressed = true;
            if (a == 0) a = double.Parse(textBlock_main.Text);
            else
            {
                if (textBlock_main.Text == "") return;
                Button_Click_Equal(sender, e);
            }
        }

        private void Button_Click_C(object sender, RoutedEventArgs e)
        {
            textBlock_main.Text = "";
        }

        private void Button_Click_CE(object sender, RoutedEventArgs e)
        {
            textBlock_main.Text = "";
            a = 0;
            b = 0;
            operation = "";
        }
    }
}
