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

namespace PetraEntity.Assets.Pages
{
    /// <summary>
    /// Interaction logic for CustomMessegeBox.xaml
    /// </summary>
    public partial class CustomMessegeBox : Window
    {

        string message;
        public string Message { get { return message; } set { message = value; } }

        public CustomMessegeBox()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            messegaTXT.Text = Message;
        }
    }
}
