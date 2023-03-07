using System;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int tim = 0;
        
        public Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            foreach(UIElement element in Mainroot.Children)
            {
                if(element is Button)
                {
                    ((Button)element).Click += Button_Click;
                }
            
                
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string str = (string)((Button)e.OriginalSource).Content;
            
            if (str == "AC")
            {
                TextBlock.Text = "";
            }           
            else if (str == "=")
            {
                try
                {
                    string value = new DataTable().Compute(TextBlock.Text, null).ToString();
                    TextBlock.Text = "";
                    TextBlock.Text = value;

                }
                catch(System.Data.SyntaxErrorException)
                {
                    MessageBox.Show("Ошибка");
                   
                
                }
                catch(System.Data.EvaluateException)
                {
                    MessageBox.Show("Ошибка");
                    
                    
                }
                
                    
                
            }
            else if (str == "←")
            {                
                string DeleteSymbol = TextBlock.Text;
                if(DeleteSymbol.Length > 0)
                {
                    DeleteSymbol = DeleteSymbol.Remove(DeleteSymbol.Length - 1);
                }
                
               
                TextBlock.Text = DeleteSymbol;
                
            }            
            else
            {
                TextBlock.Text += str;
            }
        }
        

    }
}
