using PetraEntity.FireBase;
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
using System.Windows.Shapes;

namespace mainUI
{
    /// <summary>
    /// closePage.xaml etkileşim mantığı
    /// </summary>
    public partial class closePage : Window
    {
        FireBaseUpload fb = new FireBaseUpload();

        public closePage()
        {
            InitializeComponent();
        }

        public void quitYes_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown(); 
        }

        private void quitNo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
