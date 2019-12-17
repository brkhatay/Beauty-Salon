using mainUI;
using mainUI.Assets.Pages;
using PetraEntity.Assets.Pages;
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

namespace PetraEntity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FireBaseUpload fb = new FireBaseUpload();
        AdminContext db = new AdminContext();

        public string prog;

        public MainWindow()
        {
            InitializeComponent();
           // fb.FBGO();

        }

        int maximazeValue;

        private void PowerButtonClick(object sender, RoutedEventArgs e)
        {

            closePage k = new closePage();
            k.Show();

        }


        private void FullScreenButtonClick(object sender, RoutedEventArgs e)
        {
            if (maximazeValue == 1)
            {
                //WindowStyle = WindowStyle.None;
                WindowState = WindowState.Normal;
                maximazeValue = 0;

            }
            else
            {
                WindowState = WindowState.Maximized;
                maximazeValue = 1;
            }



        }

        private void MinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }
        private void TabablzControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void porocsOne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dayPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }


        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:

                    PageInsade.Children.Clear();
                    PageInsade.Children.Add(new HomePage());
                    break;
                case 1:
                    PageInsade.Children.Clear();
                    PageInsade.Children.Add(new PhoneBookPage());
                    break;
                case 2:
                    PageInsade.Children.Clear();
                    PageInsade.Children.Add(new LogPage());
                    break;
                case 3:
                    PageInsade.Children.Clear();
                    PageInsade.Children.Add(new AdminPage());
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Info nf = new Info();
            nf.Show();
        }

      
    }
}

