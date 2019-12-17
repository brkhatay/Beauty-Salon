using PetraEntity;
using PetraEntity.Assets.Pages;
using PetraEntity.Context;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mainUI.Assets.Pages
{

    public partial class PhoneBookPage : UserControl
    {
        AdminContext db = new AdminContext();
        int update = 0;
        string phoneBookPassword;
        FBconnection con = new FBconnection();

        public PhoneBookPage()
        {
            InitializeComponent();
            phoneBookGrid.Visibility = Visibility.Hidden;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            db.contx();

            getSource();
            AdminPS ps = db.AdminPSs.Where(x => x.Definition == "PhoneBookPassword").First();
            phoneBookPassword = ps.Password;
        }

        void getSource()
        {
            poneListDgrid.DataContext = db.PhoneBooks.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (phoneAcces.Password == phoneBookPassword)
            {
                permissionGrid.Visibility = Visibility.Hidden;
                phoneBookGrid.Visibility = Visibility.Visible;
            }
            else
            {
                 CustomMessegeBox mb = new CustomMessegeBox();
                mb.Message = "Şifre hatalı";
                mb.Show();
            }


        }
      

        private void phoneAcces_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            phoneAcces.Password = "";
        }

        private void note_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(update==0)
            note.Text = "";
        }

        private void number_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (update == 0)
            {
                number.Text = "";
            }
            
        }

        private void name_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (update == 0)
            {
                name.Text = "";
            }
            
        }
        string id;
        private void poneListDgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update = 1;
            var data = poneListDgrid.SelectedItem;
            string Name = (poneListDgrid.SelectedCells[0].Column.GetCellContent(data) as TextBlock).Text;
            name.Text = Name;
            string Number = (poneListDgrid.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text;
            number.Text = Number;
            string Note = (poneListDgrid.SelectedCells[2].Column.GetCellContent(data) as TextBlock).Text;
            note.Text = Note;
            id = (poneListDgrid.SelectedCells[3].Column.GetCellContent(data) as TextBlock).Text;
            name.Foreground = Brushes.Purple;
            number.Foreground = Brushes.Purple;
            note.Foreground = Brushes.Purple;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            saveSystem();

        }


        void saveSystem()
        {

            if (name.Text != null && number.Text != null)
            {
                if (update == 0)
                {
                    PhoneBook pb = new PhoneBook();
                    pb.Name = name.Text;
                    pb.Number = number.Text;
                    pb.Note = note.Text;
                    db.PhoneBooks.Add(pb);
                    db.SaveChanges();

                    PhoneBook PBid = db.PhoneBooks.Where(x => x.Name == name.Text && x.Number == number.Text).First();
                    string iddd = PBid.PoneID.ToString();

                    con.client = new FireSharp.FirebaseClient(con.config);
                    con.response = con.client.Set("Phone Book/" + iddd, pb);

                }
                else
                {
                    PhoneBook pb = new PhoneBook();
                    pb.PoneID = Convert.ToInt32(id);
                    pb.Name = name.Text;
                    pb.Number = number.Text;
                    pb.Note = note.Text;


                    db.Entry(db.PhoneBooks.Find(pb.PoneID)).CurrentValues.SetValues(pb);
                    db.SaveChanges();

                    PhoneBook PBid = db.PhoneBooks.Where(x => x.Name == name.Text && x.Number == number.Text).First();
                    string iddd = PBid.PoneID.ToString();

                    con.client = new FireSharp.FirebaseClient(con.config);
                    con.response = con.client.Update("Phone Book/" + iddd, pb);

                    update = 0;
                    name.Foreground = Brushes.Black;
                    number.Foreground = Brushes.Black;
                    note.Foreground = Brushes.Black;
                    name.Text = "Ad Soyad";
                    number.Text = "Telefon";
                    note.Text = "Not";


                }

                getSource();
            }
            else
            {
                CustomMessegeBox mb = new CustomMessegeBox();
                mb.Message = "İsim ve Telefon Numarası boş olamaz!";
                mb.Show();
            }


            
        }

        private void searchTXT_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            searchTXT.Text = "";

        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            poneListDgrid.DataContext = db.PhoneBooks.Where(x => x.Name.Contains(searchTXT.Text)).ToList();


        }

        private void searchALL_Click(object sender, RoutedEventArgs e)
        {
            poneListDgrid.DataContext = db.PhoneBooks.ToList();

        }

        private void number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                saveSystem();
            }
        }

        private void note_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                saveSystem();
            }
        }

        private void phoneAcces_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.Key == Key.Return)
            {
                if (phoneAcces.Password == phoneBookPassword)
                {
                    permissionGrid.Visibility = Visibility.Hidden;
                    phoneBookGrid.Visibility = Visibility.Visible;
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
