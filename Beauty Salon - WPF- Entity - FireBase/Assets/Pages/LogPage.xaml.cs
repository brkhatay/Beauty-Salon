
using PetraEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace mainUI.Assets.Pages
{
    /// <summary>
    /// LogPage.xaml etkileşim mantığı
    /// </summary>
    public partial class LogPage : UserControl
    {
        AdminContext db = new AdminContext();


        public LogPage()
        {
            InitializeComponent();
        }
        

        void Start()
        {


        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            db.contx();
            customers.DataContext = db.CustomersLOG.ToList();

        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            customers.DataContext = db.CustomersLOG.Where(x => x.CustomerOne.Contains(searchName.Text) || x.CustomerTwo.Contains(searchName.Text) || x.CustomerThree.Contains(searchName.Text)).ToList();


        }

        private void fullList_Click(object sender, RoutedEventArgs e)
        {
            customers.DataContext = db.CustomersLOG.ToList();

        }
    }
}
