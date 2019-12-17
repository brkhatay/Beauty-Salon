using PetraEntity;
using PetraEntity.Assets.Pages;
using PetraEntity.Context;
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

namespace mainUI.Assets.Pages
{
    /// <summary>
    /// AdminPage.xaml etkileşim mantığı
    /// </summary>
    public partial class AdminPage : UserControl
    {
        AdminContext db = new AdminContext();
        string adminPassword;
        string phoneBookPassword;
        string localPassword;

        public AdminPage()
        {
            InitializeComponent();
            AdminGrid.Visibility = Visibility.Hidden;
            adminPassPremisionGrid.Visibility = Visibility.Hidden;
            adminPassGrid.Visibility = Visibility.Hidden;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           // db.contx();
            comboFill();

            AdminPS ps = db.AdminPSs.Where(x => x.Definition == "PhoneBookPassword").First();
            phoneBookPassword = ps.Password;

            AdminPS aps = db.AdminPSs.Where(x => x.Definition == "AdminPassword").First();
            adminPassword = aps.Password;

            AdminPS lps = db.AdminPSs.Where(x => x.Definition == "LocalPassword").First();
            localPassword = lps.Password;


        }

        void comboFill()
        {

            ProductCombo.Items.Clear();

            foreach (var item in db.Products.ToList())
            {
                ProductCombo.Items.Add(item.ProductName);
            }

        }
        private void giris_Click(object sender, RoutedEventArgs e)
        {
            if (adminPass.Password == adminPassword)
            {
                permissionGrid.Visibility = Visibility.Hidden;
                AdminGrid.Visibility = Visibility.Visible;
            }
            else
            {
                CustomMessegeBox mb = new CustomMessegeBox();
                mb.Message = "Şifre hatalı";
                mb.Show();
            }
        }

        private void adminPass_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void ProductTXT_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProductTXT.Text = "";
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (ProductTXT.Text != null)
            {
                Product pt = new Product();
                pt.ProductName = ProductTXT.Text;
                db.Products.Add(pt);
                db.SaveChanges();
                comboFill();
            }
            else
            {
                CustomMessegeBox mb = new CustomMessegeBox();
                mb.Message = "Ekleme alanı boş olamaz!";
                mb.Show();
            }
        }



        private void ProductCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductCombo.SelectedItem == null)
            {
                ProductTXT.Text = "";
            }
            else
            ProductTXT.Text = ProductCombo.SelectedItem.ToString();

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ProductTXT.Text))
            {
                Product deleted = db.Products.Where(x => x.ProductName == ProductTXT.Text).First();
                db.Products.Remove(deleted);
                db.SaveChanges();
                comboFill();
            }
            else
            {
                CustomMessegeBox mb = new CustomMessegeBox();
                mb.Message = "Çıkarılacak öğe seçilmeli ya da yazılmalıdır!!";
                mb.Show();

            }
            

        }

        private void adminPassGiris_Click(object sender, RoutedEventArgs e)
        {
            if (passChaceAdminPass.Password == adminPassword && localPass.Password == localPassword)
            {
                adminPassPremisionGrid.Visibility = Visibility.Hidden;
                adminPassGrid.Visibility = Visibility.Visible;
                phoneBookPassTXT.Text = phoneBookPassword;
                AdminPassTXT.Text = adminPassword;

            }
            else
            {
                CustomMessegeBox mb = new CustomMessegeBox();
                mb.Message = "Şifre hatalı";
                mb.Show();
            }
        }

        private void passCahance_Click(object sender, RoutedEventArgs e)
        {
            adminPassPremisionGrid.Visibility = Visibility.Visible;
        }

        private void phoneBookPass_Click(object sender, RoutedEventArgs e)
        {
            AdminPS aps = db.AdminPSs.Where(x => x.Definition == "PhoneBookPassword").First();
            aps.Password = phoneBookPassTXT.Text;    
            db.SaveChanges();
        }

        private void adminPassC_Click(object sender, RoutedEventArgs e)
        {
            AdminPS adps = db.AdminPSs.Where(x => x.Definition == "AdminPassword").First();
            adps.Password= AdminPassTXT.Text;
            db.SaveChanges();
        }

        private void adminPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (adminPass.Password == adminPassword)
                {
                    permissionGrid.Visibility = Visibility.Hidden;
                    AdminGrid.Visibility = Visibility.Visible;
                }
                else
                {
                    CustomMessegeBox mb = new CustomMessegeBox();
                    mb.Message = "Şifre hatalı";
                    mb.Show();
                }
            }

        }
    }
}
