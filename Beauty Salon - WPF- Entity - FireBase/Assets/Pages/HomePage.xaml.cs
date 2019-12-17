using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PetraEntity;
using PetraEntity.Context;
using PetraEntity.FireBase;
using FireSharp.Response;
using FireSharp.Config;
using FireSharp.Interfaces;


namespace mainUI
{
    /// <summary>
    /// HomePage.xaml etkileşim mantığı
    /// </summary>
    public partial class HomePage : UserControl
    {

        AdminContext db = new AdminContext();
        FireBaseUpload fb = new FireBaseUpload();
        int dayIDLocal;
        Customer cs;
        DateTime choseDay;
        string fireBaseDayTime;

        public HomePage()
        {
            InitializeComponent();
            Loaded += HomePage_Loaded;
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            ComboFill();
            dayPicker.SelectedDate = DateTime.Now.Date;
            dateLabel.Content = DateTime.Now.Date.ToString("D");
            fireBaseDayTime = DateTime.Now.Date.ToString("D");
            con.client = new FireSharp.FirebaseClient(con.config);
        }

        void resetText()
        {
            nineOcCustomerOne.Text = null;
            ninePorocsOne.SelectedIndex = 0;
            nineOcCustomerTwo.Text = "";
            ninePorocsTwo.SelectedIndex = 0;
            nineOcCustomerThree.Text = "";
            ninePorocsThree.SelectedIndex = 0;

            nineHOcCustomerOne.Text = "";
            nineHPorocsOne.SelectedIndex = 0;
            nineHOcCustomerTwo.Text = "";
            nineHPorocsTwo.SelectedIndex = 0;
            nineHOcCustomerThree.Text = "";
            nineHPorocsThree.SelectedIndex = 0;

            tenOcCustomerOne.Text = "";
            tenPorocsOne.SelectedIndex = 0;
            tenOcCustomerTwo.Text = "";
            tenPorocsTwo.SelectedIndex = 0;
            tenOcCustomerThree.Text = "";
            tenPorocsThree.SelectedIndex = 0;

            tenHOcCustomerOne.Text = "";
            tenHPorocsOne.SelectedIndex = 0;
            tenHOcCustomerTwo.Text = "";
            tenHPorocsTwo.SelectedIndex = 0;
            tenHOcCustomerThree.Text = "";
            tenHPorocsThree.SelectedIndex = 0;

            elevenOcCustomerOne.Text = "";
            elevenPorocsOne.SelectedIndex = 0;
            elevenOcCustomerTwo.Text = "";
            elevenPorocsTwo.SelectedIndex = 0;
            elevenOcCustomerThree.Text = "";
            elevenPorocsThree.SelectedIndex = 0;

            elevenHOcCustomerOne.Text = "";
            elevenHPorocsOne.SelectedIndex = 0;
            elevenHOcCustomerTwo.Text = "";
            elevenHPorocsTwo.SelectedIndex = 0;
            elevenHOcCustomerThree.Text = "";
            elevenHPorocsThree.SelectedIndex = 0;

            twelveOcCustomerOne.Text = "";
            twelvePorocsOne.SelectedIndex = 0;
            twelveOcCustomerTwo.Text = "";
            twelvePorocsTwo.SelectedIndex = 0;
            twelveOcCustomerThree.Text = "";
            twelvePorocsThree.SelectedIndex = 0;

            twelveHOcCustomerOne.Text = "";
            twelveHPorocsOne.SelectedIndex = 0;
            twelveHOcCustomerTwo.Text = "";
            twelveHPorocsTwo.SelectedIndex = 0;
            twelveHOcCustomerThree.Text = "";
            twelveHPorocsThree.SelectedIndex = 0;

            thirteenOcCustomerOne.Text = "";
            thirteenPorocsOne.SelectedIndex = 0;
            thirteenOcCustomerTwo.Text = "";
            thirteenPorocsTwo.SelectedIndex = 0;
            thirteenOcCustomerThree.Text = "";
            thirteenPorocsThree.SelectedIndex = 0;

            thirteenHOcCustomerOne.Text = "";
            thirteenHPorocsOne.SelectedIndex = 0;
            thirteenHOcCustomerTwo.Text = "";
            thirteenHPorocsTwo.SelectedIndex = 0;
            thirteenHOcCustomerThree.Text = "";
            thirteenHPorocsThree.SelectedIndex = 0;

            fourteenOcCustomerOne.Text = "";
            fourteenPorocsOne.SelectedIndex = 0;
            fourteenOcCustomerTwo.Text = "";
            fourteenPorocsTwo.SelectedIndex = 0;
            fourteenOcCustomerThree.Text = "";
            fourteenPorocsThree.SelectedIndex = 0;

            fourteenHOcCustomerOne.Text = "";
            fourteenHPorocsOne.SelectedIndex = 0;
            fourteenHOcCustomerTwo.Text = "";
            fourteenHPorocsTwo.SelectedIndex = 0;
            fourteenHOcCustomerThree.Text = "";
            fourteenHPorocsThree.SelectedIndex = 0;

            fifteenOcCustomerOne.Text = "";
            fifteenPorocsOne.SelectedIndex = 0;
            fifteenOcCustomerTwo.Text = "";
            fifteenPorocsTwo.SelectedIndex = 0;
            fifteenOcCustomerThree.Text = "";
            fifteenPorocsThree.SelectedIndex = 0;

            fifteenHOcCustomerOne.Text = "";
            fifteenHPorocsOne.SelectedIndex = 0;
            fifteenHOcCustomerTwo.Text = "";
            fifteenHPorocsTwo.SelectedIndex = 0;
            fifteenHOcCustomerThree.Text = "";
            fifteenHPorocsThree.SelectedIndex = 0;

            sixteenOcCustomerOne.Text = "";
            sixteenPorocsOne.SelectedIndex = 0;
            sixteenOcCustomerTwo.Text = "";
            sixteenPorocsTwo.SelectedIndex = 0;
            sixteenOcCustomerThree.Text = "";
            sixteenPorocsThree.SelectedIndex = 0;

            sixteenHOcCustomerOne.Text = "";
            sixteenHPorocsOne.SelectedIndex = 0;
            sixteenHOcCustomerTwo.Text = "";
            sixteenHPorocsTwo.SelectedIndex = 0;
            sixteenHOcCustomerThree.Text = "";
            sixteenHPorocsThree.SelectedIndex = 0;


            seventeenOcCustomerOne.Text = "";
            seventeenPorocsOne.SelectedIndex = 0;
            seventeenOcCustomerTwo.Text = "";
            seventeenPorocsTwo.SelectedIndex = 0;
            seventeenOcCustomerThree.Text = "";
            seventeenPorocsThree.SelectedIndex = 0;

            seventeenHOcCustomerOne.Text = "";
            seventeenHPorocsOne.SelectedIndex = 0;
            seventeenHOcCustomerTwo.Text = "";
            seventeenHPorocsTwo.SelectedIndex = 0;
            seventeenHOcCustomerThree.Text = "";
            seventeenHPorocsThree.SelectedIndex = 0;

            eighteenOcCustomerOne.Text = "";
            eighteenPorocsOne.SelectedIndex = 0;
            eighteenOcCustomerTwo.Text = "";
            eighteenPorocsTwo.SelectedIndex = 0;
            eighteenOcCustomerThree.Text = "";
            eighteenPorocsThree.SelectedIndex = 0;

            eighteenHOcCustomerOne.Text = "";
            eighteenHPorocsOne.SelectedIndex = 0;
            eighteenHOcCustomerTwo.Text = "";
            eighteenHPorocsTwo.SelectedIndex = 0;
            eighteenHOcCustomerThree.Text = "";
            eighteenHPorocsThree.SelectedIndex = 0;

            nineteenOcCustomerOne.Text = "";
            nineteenPorocsOne.SelectedIndex = 0;
            nineteenOcCustomerTwo.Text = "";
            nineteenPorocsTwo.SelectedIndex = 0;
            nineteenOcCustomerThree.Text = "";
            nineteenPorocsThree.SelectedIndex = 0;


            noteTxt.Text = "";
        }


        void LoadTexts()
        {

            resetText();

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 1).ToList())
            {
                nineOcCustomerOne.Text = item.CustomerOne;
                ninePorocsOne.SelectedIndex = ninePorocsOne.Items.IndexOf(item.psOne);
                nineOcCustomerTwo.Text = item.CustomerTwo;
                ninePorocsTwo.SelectedIndex = ninePorocsTwo.Items.IndexOf(item.psTwo);
                nineOcCustomerThree.Text = item.CustomerThree;
                ninePorocsThree.SelectedIndex = ninePorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 2).ToList())
            {
                nineHOcCustomerOne.Text = item.CustomerOne;
                nineHPorocsOne.SelectedIndex = nineHPorocsOne.Items.IndexOf(item.psOne);
                nineHOcCustomerTwo.Text = item.CustomerTwo;
                nineHPorocsTwo.SelectedIndex = nineHPorocsTwo.Items.IndexOf(item.psTwo);
                nineHOcCustomerThree.Text = item.CustomerThree;
                nineHPorocsThree.SelectedIndex = nineHPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 4).ToList())
            {
                tenOcCustomerOne.Text = item.CustomerOne;
                tenPorocsOne.SelectedIndex = tenPorocsOne.Items.IndexOf(item.psOne);
                tenOcCustomerTwo.Text = item.CustomerTwo;
                tenPorocsTwo.SelectedIndex = tenPorocsTwo.Items.IndexOf(item.psTwo);
                tenOcCustomerThree.Text = item.CustomerThree;
                tenPorocsThree.SelectedIndex = tenPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 5).ToList())
            {
                tenHOcCustomerOne.Text = item.CustomerOne;
                tenHPorocsOne.SelectedIndex = tenHPorocsOne.Items.IndexOf(item.psOne);
                tenHOcCustomerTwo.Text = item.CustomerTwo;
                tenHPorocsTwo.SelectedIndex = tenHPorocsTwo.Items.IndexOf(item.psTwo);
                tenHOcCustomerThree.Text = item.CustomerThree;
                tenHPorocsThree.SelectedIndex = tenHPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 6).ToList())
            {
                elevenOcCustomerOne.Text = item.CustomerOne;
                elevenPorocsOne.SelectedIndex = elevenPorocsOne.Items.IndexOf(item.psOne);
                elevenOcCustomerTwo.Text = item.CustomerTwo;
                elevenPorocsTwo.SelectedIndex = elevenPorocsTwo.Items.IndexOf(item.psTwo);
                elevenOcCustomerThree.Text = item.CustomerThree;
                elevenPorocsThree.SelectedIndex = elevenPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 7).ToList())
            {
                elevenHOcCustomerOne.Text = item.CustomerOne;
                elevenHPorocsOne.SelectedIndex = elevenHPorocsOne.Items.IndexOf(item.psOne);
                elevenHOcCustomerTwo.Text = item.CustomerTwo;
                elevenHPorocsTwo.SelectedIndex = elevenHPorocsTwo.Items.IndexOf(item.psTwo);
                elevenHOcCustomerThree.Text = item.CustomerThree;
                elevenHPorocsThree.SelectedIndex = elevenHPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 8).ToList())
            {
                twelveOcCustomerOne.Text = item.CustomerOne;
                twelvePorocsOne.SelectedIndex = twelvePorocsOne.Items.IndexOf(item.psOne);
                twelveOcCustomerTwo.Text = item.CustomerTwo;
                twelvePorocsTwo.SelectedIndex = twelvePorocsTwo.Items.IndexOf(item.psTwo);
                twelveOcCustomerThree.Text = item.CustomerThree;
                twelvePorocsThree.SelectedIndex = twelvePorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 9).ToList())
            {
                twelveHOcCustomerOne.Text = item.CustomerOne;
                twelveHPorocsOne.SelectedIndex = twelveHPorocsOne.Items.IndexOf(item.psOne);
                twelveHOcCustomerTwo.Text = item.CustomerTwo;
                twelveHPorocsTwo.SelectedIndex = twelveHPorocsTwo.Items.IndexOf(item.psTwo);
                twelveHOcCustomerThree.Text = item.CustomerThree;
                twelveHPorocsThree.SelectedIndex = twelveHPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 10).ToList())
            {
                thirteenOcCustomerOne.Text = item.CustomerOne;
                thirteenPorocsOne.SelectedIndex = thirteenPorocsOne.Items.IndexOf(item.psOne);
                thirteenOcCustomerTwo.Text = item.CustomerTwo;
                thirteenPorocsTwo.SelectedIndex = thirteenPorocsTwo.Items.IndexOf(item.psTwo);
                thirteenOcCustomerThree.Text = item.CustomerThree;
                thirteenPorocsThree.SelectedIndex = thirteenPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 11).ToList())
            {
                thirteenHOcCustomerOne.Text = item.CustomerOne;
                thirteenHPorocsOne.SelectedIndex = thirteenHPorocsOne.Items.IndexOf(item.psOne);
                thirteenHOcCustomerTwo.Text = item.CustomerTwo;
                thirteenHPorocsTwo.SelectedIndex = thirteenHPorocsTwo.Items.IndexOf(item.psTwo);
                thirteenHOcCustomerThree.Text = item.CustomerThree;
                thirteenHPorocsThree.SelectedIndex = thirteenHPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 12).ToList())
            {
                fourteenOcCustomerOne.Text = item.CustomerOne;
                fourteenPorocsOne.SelectedIndex = fourteenPorocsOne.Items.IndexOf(item.psOne);
                fourteenOcCustomerTwo.Text = item.CustomerTwo;
                fourteenPorocsTwo.SelectedIndex = fourteenPorocsTwo.Items.IndexOf(item.psTwo);
                fourteenOcCustomerThree.Text = item.CustomerThree;
                fourteenPorocsThree.SelectedIndex = fourteenPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 13).ToList())
            {
                fourteenHOcCustomerOne.Text = item.CustomerOne;
                fourteenHPorocsOne.SelectedIndex = fourteenPorocsOne.Items.IndexOf(item.psOne);
                fourteenHOcCustomerTwo.Text = item.CustomerTwo;
                fourteenHPorocsTwo.SelectedIndex = fourteenPorocsTwo.Items.IndexOf(item.psTwo);
                fourteenHOcCustomerThree.Text = item.CustomerThree;
                fourteenHPorocsThree.SelectedIndex = fourteenHPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 14).ToList())
            {
                fifteenOcCustomerOne.Text = item.CustomerOne;
                fifteenPorocsOne.SelectedIndex = fifteenPorocsOne.Items.IndexOf(item.psOne);
                fifteenOcCustomerTwo.Text = item.CustomerTwo;
                fifteenPorocsTwo.SelectedIndex = fifteenPorocsTwo.Items.IndexOf(item.psTwo);
                fifteenOcCustomerThree.Text = item.CustomerThree;
                fifteenPorocsThree.SelectedIndex = fifteenPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 15).ToList())
            {
                fifteenHOcCustomerOne.Text = item.CustomerOne;
                fifteenHPorocsOne.SelectedIndex = fifteenHPorocsOne.Items.IndexOf(item.psOne);
                fifteenHOcCustomerTwo.Text = item.CustomerTwo;
                fifteenHPorocsTwo.SelectedIndex = fifteenHPorocsTwo.Items.IndexOf(item.psTwo);
                fifteenHOcCustomerThree.Text = item.CustomerThree;
                fifteenHPorocsThree.SelectedIndex = fifteenHPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 16).ToList())
            {
                sixteenOcCustomerOne.Text = item.CustomerOne;
                sixteenPorocsOne.SelectedIndex = sixteenPorocsOne.Items.IndexOf(item.psOne);
                sixteenOcCustomerTwo.Text = item.CustomerTwo;
                sixteenPorocsTwo.SelectedIndex = sixteenPorocsTwo.Items.IndexOf(item.psTwo);
                sixteenOcCustomerThree.Text = item.CustomerThree;
                sixteenPorocsThree.SelectedIndex = sixteenPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 17).ToList())
            {
                sixteenHOcCustomerOne.Text = item.CustomerOne;
                sixteenHPorocsOne.SelectedIndex = sixteenHPorocsOne.Items.IndexOf(item.psOne);
                sixteenHOcCustomerTwo.Text = item.CustomerTwo;
                sixteenHPorocsTwo.SelectedIndex = sixteenHPorocsTwo.Items.IndexOf(item.psTwo);
                sixteenHOcCustomerThree.Text = item.CustomerThree;
                sixteenHPorocsThree.SelectedIndex = sixteenHPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 18).ToList())
            {
                seventeenOcCustomerOne.Text = item.CustomerOne;
                seventeenPorocsOne.SelectedIndex = seventeenPorocsOne.Items.IndexOf(item.psOne);
                seventeenOcCustomerTwo.Text = item.CustomerTwo;
                seventeenPorocsTwo.SelectedIndex = seventeenPorocsTwo.Items.IndexOf(item.psTwo);
                seventeenOcCustomerThree.Text = item.CustomerThree;
                seventeenPorocsThree.SelectedIndex = seventeenPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 19).ToList())
            {
                seventeenHOcCustomerOne.Text = item.CustomerOne;
                seventeenHPorocsOne.SelectedIndex = seventeenHPorocsOne.Items.IndexOf(item.psOne);
                seventeenHOcCustomerTwo.Text = item.CustomerTwo;
                seventeenHPorocsTwo.SelectedIndex = seventeenHPorocsTwo.Items.IndexOf(item.psTwo);
                seventeenHOcCustomerThree.Text = item.CustomerThree;
                seventeenHPorocsThree.SelectedIndex = seventeenHPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 20).ToList())
            {
                eighteenOcCustomerOne.Text = item.CustomerOne;
                eighteenPorocsOne.SelectedIndex = eighteenPorocsOne.Items.IndexOf(item.psOne);
                eighteenOcCustomerTwo.Text = item.CustomerTwo;
                eighteenPorocsTwo.SelectedIndex = eighteenPorocsTwo.Items.IndexOf(item.psTwo);
                eighteenOcCustomerThree.Text = item.CustomerThree;
                eighteenPorocsThree.SelectedIndex = eighteenPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 21).ToList())
            {
                eighteenHOcCustomerOne.Text = item.CustomerOne;
                eighteenHPorocsOne.SelectedIndex = eighteenHPorocsOne.Items.IndexOf(item.psOne);
                eighteenHOcCustomerTwo.Text = item.CustomerTwo;
                eighteenHPorocsTwo.SelectedIndex = eighteenHPorocsTwo.Items.IndexOf(item.psTwo);
                eighteenHOcCustomerThree.Text = item.CustomerThree;
                eighteenHPorocsThree.SelectedIndex = eighteenHPorocsThree.Items.IndexOf(item.psThree);
            }

            foreach (Customer item in db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 22).ToList())
            {
                nineteenOcCustomerOne.Text = item.CustomerOne;
                nineteenPorocsOne.SelectedIndex = nineteenPorocsOne.Items.IndexOf(item.psOne);
                nineteenOcCustomerTwo.Text = item.CustomerTwo;
                nineteenPorocsTwo.SelectedIndex = nineteenPorocsTwo.Items.IndexOf(item.psTwo);
                nineteenOcCustomerThree.Text = item.CustomerThree;
                nineteenPorocsThree.SelectedIndex = nineteenPorocsThree.Items.IndexOf(item.psThree);
            }


            foreach (DayNote item in db.DayNotes.Where(c => c.dayID == dayIDLocal).ToList())
            {
                noteTxt.Text = item.Note;

            }
        }

        void ComboFill()
        {

            foreach (var item in db.Products.ToList())
            {
                ninePorocsOne.Items.Add(item.ProductName);
                ninePorocsTwo.Items.Add(item.ProductName);
                ninePorocsThree.Items.Add(item.ProductName);

                nineHPorocsOne.Items.Add(item.ProductName);
                nineHPorocsTwo.Items.Add(item.ProductName);
                nineHPorocsThree.Items.Add(item.ProductName);

                tenPorocsOne.Items.Add(item.ProductName);
                tenPorocsTwo.Items.Add(item.ProductName);
                tenPorocsThree.Items.Add(item.ProductName);

                tenHPorocsOne.Items.Add(item.ProductName);
                tenHPorocsTwo.Items.Add(item.ProductName);
                tenHPorocsThree.Items.Add(item.ProductName);

                elevenPorocsOne.Items.Add(item.ProductName);
                elevenPorocsTwo.Items.Add(item.ProductName);
                elevenPorocsThree.Items.Add(item.ProductName);

                elevenHPorocsOne.Items.Add(item.ProductName);
                elevenHPorocsTwo.Items.Add(item.ProductName);
                elevenHPorocsThree.Items.Add(item.ProductName);

                twelvePorocsOne.Items.Add(item.ProductName);
                twelvePorocsTwo.Items.Add(item.ProductName);
                twelvePorocsThree.Items.Add(item.ProductName);


                twelveHPorocsOne.Items.Add(item.ProductName);
                twelveHPorocsTwo.Items.Add(item.ProductName);
                twelveHPorocsThree.Items.Add(item.ProductName);

                thirteenPorocsOne.Items.Add(item.ProductName);
                thirteenPorocsTwo.Items.Add(item.ProductName);
                thirteenPorocsThree.Items.Add(item.ProductName);

                thirteenHPorocsOne.Items.Add(item.ProductName);
                thirteenHPorocsTwo.Items.Add(item.ProductName);
                thirteenHPorocsThree.Items.Add(item.ProductName);


                fourteenPorocsOne.Items.Add(item.ProductName);
                fourteenPorocsTwo.Items.Add(item.ProductName);
                fourteenPorocsThree.Items.Add(item.ProductName);

                fourteenHPorocsOne.Items.Add(item.ProductName);
                fourteenHPorocsTwo.Items.Add(item.ProductName);
                fourteenHPorocsThree.Items.Add(item.ProductName);

                fifteenPorocsOne.Items.Add(item.ProductName);
                fifteenPorocsTwo.Items.Add(item.ProductName);
                fifteenPorocsThree.Items.Add(item.ProductName);


                fifteenHPorocsOne.Items.Add(item.ProductName);
                fifteenHPorocsTwo.Items.Add(item.ProductName);
                fifteenHPorocsThree.Items.Add(item.ProductName);

                sixteenPorocsOne.Items.Add(item.ProductName);
                sixteenPorocsTwo.Items.Add(item.ProductName);
                sixteenPorocsThree.Items.Add(item.ProductName);

                sixteenHPorocsOne.Items.Add(item.ProductName);
                sixteenHPorocsTwo.Items.Add(item.ProductName);
                sixteenHPorocsThree.Items.Add(item.ProductName);

                seventeenPorocsOne.Items.Add(item.ProductName);
                seventeenPorocsTwo.Items.Add(item.ProductName);
                seventeenPorocsThree.Items.Add(item.ProductName);

                seventeenHPorocsOne.Items.Add(item.ProductName);
                seventeenHPorocsTwo.Items.Add(item.ProductName);
                seventeenHPorocsThree.Items.Add(item.ProductName);

                eighteenPorocsOne.Items.Add(item.ProductName);
                eighteenPorocsTwo.Items.Add(item.ProductName);
                eighteenPorocsThree.Items.Add(item.ProductName);


                eighteenHPorocsOne.Items.Add(item.ProductName);
                eighteenHPorocsTwo.Items.Add(item.ProductName);
                eighteenHPorocsThree.Items.Add(item.ProductName);


                nineteenPorocsOne.Items.Add(item.ProductName);
                nineteenPorocsTwo.Items.Add(item.ProductName);
                nineteenPorocsThree.Items.Add(item.ProductName);




            }



        }


        private void dayPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            choseDay = dayPicker.SelectedDate.Value;
            dateLabel.Content = choseDay.Date.ToString("D");
            fireBaseDayTime = choseDay.Date.ToString("D");

            if (choseDay == db.Days.Where(x => x.Date == choseDay).Select(y => y.Date).FirstOrDefault())
            {
                Day ds = db.Days.Where(x => x.Date == choseDay).First();
                dayIDLocal = ds.DayID;

                LoadTexts();
            }
            else
            {
                Day dys = new Day();
                dys.Date = dayPicker.SelectedDate.Value;
                db.Days.Add(dys);
                db.SaveChanges();
                dayIDLocal = dys.DayID;
                LoadTexts();

            }
        }


        FBconnection con = new FBconnection();

        private void nineSave_Click(object sender, RoutedEventArgs e)
        {

            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 1).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = nineOcCustomerOne.Text;
                cs.psOne = ninePorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = nineOcCustomerTwo.Text;
                cs.psTwo = ninePorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = nineOcCustomerThree.Text;
                cs.psThree = ninePorocsThree.SelectedItem.ToString();
                cs.ClockID = 1;
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 0900/", cs);


            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 1).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "09.00";
                log.CustomerOne = nineOcCustomerOne.Text;
                log.psOne = ninePorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = nineOcCustomerTwo.Text;
                log.psTwo = ninePorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = nineOcCustomerThree.Text;
                log.psThree = ninePorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 1).First();
                c.CustomerOne = nineOcCustomerOne.Text;
                c.psOne = ninePorocsOne.SelectedItem.ToString();
                c.CustomerTwo = nineOcCustomerTwo.Text;
                c.psTwo = ninePorocsTwo.SelectedItem.ToString();
                c.CustomerThree = nineOcCustomerThree.Text;
                c.psThree = ninePorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == nineOcCustomerOne.Text && x.CustomerTwo == nineOcCustomerTwo.Text && x.CustomerThree == nineOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 0900/", c);
            }
        }


        private void nineHSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 2).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = nineHOcCustomerOne.Text;
                cs.psOne = nineHPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = nineHOcCustomerTwo.Text;
                cs.psTwo = nineHPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = nineHOcCustomerThree.Text;
                cs.psThree = nineHPorocsThree.SelectedItem.ToString();
                cs.ClockID = 2;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 0930/", cs);

            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 2).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "09.30";
                log.CustomerOne = nineHOcCustomerOne.Text;
                log.psOne = nineHPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = nineHOcCustomerTwo.Text;
                log.psTwo = nineHPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = nineHOcCustomerThree.Text;
                log.psThree = nineHPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 2).First();
                c.CustomerOne = nineHOcCustomerOne.Text;
                c.psOne = nineHPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = nineHOcCustomerTwo.Text;
                c.psTwo = nineHPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = nineHOcCustomerThree.Text;
                c.psThree = nineHPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == nineHOcCustomerOne.Text && x.CustomerTwo == nineHOcCustomerTwo.Text && x.CustomerThree == nineHOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 0930/", c);
            }
        }


        /// ///////////////////////////////////////////////////////////////////////////

        private void tenSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 3).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = tenOcCustomerOne.Text;
                cs.psOne = tenPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = tenOcCustomerTwo.Text;
                cs.psTwo = tenPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = tenOcCustomerThree.Text;
                cs.psThree = tenPorocsThree.SelectedItem.ToString();
                cs.ClockID = 3;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1000/", cs);

            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 3).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "10.00";
                log.CustomerOne = tenOcCustomerOne.Text;
                log.psOne = tenPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = tenOcCustomerTwo.Text;
                log.psTwo = tenPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = tenOcCustomerThree.Text;
                log.psThree = tenPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 3).First();
                c.CustomerOne = tenOcCustomerOne.Text;
                c.psOne = tenPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = tenOcCustomerTwo.Text;
                c.psTwo = tenPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = tenOcCustomerThree.Text;
                c.psThree = tenPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == tenOcCustomerOne.Text && x.CustomerTwo == tenOcCustomerTwo.Text && x.CustomerThree == tenOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1000/", c);
            }
        }



        private void tenHSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 4).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = tenHOcCustomerOne.Text;
                cs.psOne = tenHPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = tenHOcCustomerTwo.Text;
                cs.psTwo = tenHPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = tenHOcCustomerThree.Text;
                cs.psThree = tenHPorocsThree.SelectedItem.ToString();
                cs.ClockID = 4;  
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1030/", cs);

            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 4).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "10.30";
                log.CustomerOne = tenHOcCustomerOne.Text;
                log.psOne = tenHPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = tenHOcCustomerTwo.Text;
                log.psTwo = tenHPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = tenHOcCustomerThree.Text;
                log.psThree = tenHPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 4).First();
                c.CustomerOne = tenHOcCustomerOne.Text;
                c.psOne = tenHPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = tenHOcCustomerTwo.Text;
                c.psTwo = tenHPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = tenHOcCustomerThree.Text;
                c.psThree = tenHPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == tenHOcCustomerOne.Text && x.CustomerTwo == tenHOcCustomerTwo.Text && x.CustomerThree == tenHOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1030/", c);
            }

        }

        /// ///////////////////////////////////////////////////////////////////////////

        private void elevenSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 5).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = elevenOcCustomerOne.Text;
                cs.psOne = elevenPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = elevenOcCustomerTwo.Text;
                cs.psTwo = elevenPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = elevenOcCustomerThree.Text;
                cs.psThree = elevenPorocsThree.SelectedItem.ToString();
                cs.ClockID = 5;  
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1100/", cs);
            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 5).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "11.00";
                log.CustomerOne = elevenOcCustomerOne.Text;
                log.psOne = elevenPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = elevenOcCustomerTwo.Text;
                log.psTwo = elevenPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = elevenOcCustomerThree.Text;
                log.psThree = elevenPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 5).First();
                c.CustomerOne = elevenOcCustomerOne.Text;
                c.psOne = elevenPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = elevenOcCustomerTwo.Text;
                c.psTwo = elevenPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = elevenOcCustomerThree.Text;
                c.psThree = elevenPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == elevenOcCustomerOne.Text && x.CustomerTwo == elevenOcCustomerTwo.Text && x.CustomerThree == elevenOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1100/", c);
            }

        }



        private void elevenHSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 6).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = elevenHOcCustomerOne.Text;
                cs.psOne = elevenHPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = elevenHOcCustomerTwo.Text;
                cs.psTwo = elevenHPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = elevenHOcCustomerThree.Text;
                cs.psThree = elevenHPorocsThree.SelectedItem.ToString();
                cs.ClockID = 6;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1130/", cs);
            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 6).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "11.30";
                log.CustomerOne = elevenHOcCustomerOne.Text;
                log.psOne = elevenHPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = elevenHOcCustomerTwo.Text;
                log.psTwo = elevenHPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = elevenHOcCustomerThree.Text;
                log.psThree = elevenHPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 6).First();
                c.CustomerOne = elevenHOcCustomerOne.Text;
                c.psOne = elevenHPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = elevenHOcCustomerTwo.Text;
                c.psTwo = elevenHPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = elevenHOcCustomerThree.Text;
                c.psThree = elevenHPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == elevenHOcCustomerOne.Text && x.CustomerTwo == elevenHOcCustomerTwo.Text && x.CustomerThree == elevenHOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1130/", c);
            }

        }




        /// ///////////////////////////////////////////////////////////////////////////

        private void twelveSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 7).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = twelveOcCustomerOne.Text;
                cs.psOne = twelvePorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = twelveOcCustomerTwo.Text;
                cs.psTwo = twelvePorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = twelveOcCustomerThree.Text;
                cs.psThree = twelvePorocsThree.SelectedItem.ToString();
                cs.ClockID = 7;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1200/", cs);
            }

            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 7).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "12.00";
                log.CustomerOne = twelveOcCustomerOne.Text;
                log.psOne = twelvePorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = twelveOcCustomerTwo.Text;
                log.psTwo = twelvePorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = twelveOcCustomerThree.Text;
                log.psThree = twelvePorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 7).First();
                c.CustomerOne = twelveOcCustomerOne.Text;
                c.psOne = twelvePorocsOne.SelectedItem.ToString();
                c.CustomerTwo = twelveOcCustomerTwo.Text;
                c.psTwo = twelvePorocsTwo.SelectedItem.ToString();
                c.CustomerThree = twelveOcCustomerThree.Text;
                c.psThree = twelvePorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == twelveOcCustomerOne.Text && x.CustomerTwo == twelveOcCustomerTwo.Text && x.CustomerThree == twelveOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1200/", c);

            }

        }




        private void twelveHSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 8).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = twelveHOcCustomerOne.Text;
                cs.psOne = twelveHPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = twelveHOcCustomerTwo.Text;
                cs.psTwo = twelveHPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = twelveHOcCustomerThree.Text;
                cs.psThree = twelveHPorocsThree.SelectedItem.ToString();
                cs.ClockID = 8;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1230/", cs);
            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 8).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "12.30";
                log.CustomerOne = twelveHOcCustomerOne.Text;
                log.psOne = twelveHPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = twelveHOcCustomerTwo.Text;
                log.psTwo = twelveHPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = twelveHOcCustomerThree.Text;
                log.psThree = twelveHPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 8).First();
                c.CustomerOne = twelveHOcCustomerOne.Text;
                c.psOne = twelveHPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = twelveHOcCustomerTwo.Text;
                c.psTwo = twelveHPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = twelveHOcCustomerThree.Text;
                c.psThree = twelveHPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == twelveHOcCustomerOne.Text && x.CustomerTwo == twelveHOcCustomerTwo.Text && x.CustomerThree == twelveHOcCustomerTwo.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1230/", c);

            }

        }




        /// ///////////////////////////////////////////////////////////////////////////

        private void thirteenSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 9).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = thirteenOcCustomerOne.Text;
                cs.psOne = thirteenPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = thirteenOcCustomerTwo.Text;
                cs.psTwo = thirteenPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = thirteenOcCustomerThree.Text;
                cs.psThree = thirteenPorocsThree.SelectedItem.ToString();
                cs.ClockID = 9;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1300/", cs);
            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 9).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "13.00";
                log.CustomerOne = thirteenOcCustomerOne.Text;
                log.psOne = thirteenPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = thirteenOcCustomerTwo.Text;
                log.psTwo = thirteenPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = thirteenOcCustomerThree.Text;
                log.psThree = thirteenPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 9).First();
                c.CustomerOne = thirteenOcCustomerOne.Text;
                c.psOne = thirteenPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = thirteenOcCustomerTwo.Text;
                c.psTwo = thirteenPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = thirteenOcCustomerThree.Text;
                c.psThree = thirteenPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == thirteenOcCustomerOne.Text && x.CustomerTwo == thirteenOcCustomerTwo.Text && x.CustomerThree == thirteenOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1300/", c);
            }


        }


        private void thirteenHSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 10).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = thirteenHOcCustomerOne.Text;
                cs.psOne = thirteenHPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = thirteenHOcCustomerTwo.Text;
                cs.psTwo = thirteenHPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = thirteenHOcCustomerThree.Text;
                cs.psThree = thirteenHPorocsThree.SelectedItem.ToString();
                cs.ClockID = 10;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1330/", cs);
            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 10).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "13.30";
                log.CustomerOne = thirteenHOcCustomerOne.Text;
                log.psOne = thirteenHPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = thirteenHOcCustomerTwo.Text;
                log.psTwo = thirteenHPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = thirteenHOcCustomerThree.Text;
                log.psThree = thirteenHPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 10).First();
                c.CustomerOne = thirteenHOcCustomerOne.Text;
                c.psOne = thirteenHPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = thirteenHOcCustomerTwo.Text;
                c.psTwo = thirteenHPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = thirteenHOcCustomerThree.Text;
                c.psThree = thirteenHPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == thirteenOcCustomerThree.Text && x.CustomerTwo == thirteenHOcCustomerTwo.Text && x.CustomerThree == thirteenHOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1330/", c);

            }

        }



        /// ///////////////////////////////////////////////////////////////////////////

        private void fourteenSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 11).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = fourteenOcCustomerOne.Text;
                cs.psOne = fourteenPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = fourteenOcCustomerTwo.Text;
                cs.psTwo = fourteenPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = fourteenOcCustomerThree.Text;
                cs.psThree = fourteenPorocsThree.SelectedItem.ToString();
                cs.ClockID = 11;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1400/", cs);

            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 11).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "14.00";
                log.CustomerOne = fourteenOcCustomerOne.Text;
                log.psOne = fourteenPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = fourteenOcCustomerTwo.Text;
                log.psTwo = fourteenPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = fourteenOcCustomerThree.Text;
                log.psThree = fourteenPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 11).First();
                c.CustomerOne = fourteenOcCustomerOne.Text;
                c.psOne = fourteenPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = fourteenOcCustomerTwo.Text;
                c.psTwo = fourteenPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = fourteenOcCustomerThree.Text;
                c.psThree = fourteenPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == fourteenOcCustomerOne.Text && x.CustomerTwo == fourteenOcCustomerTwo.Text && x.CustomerThree == fourteenOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1400/", c);
            }

        }


        private void fourteenHSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 12).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = fourteenHOcCustomerOne.Text;
                cs.psOne = fourteenHPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = fourteenHOcCustomerTwo.Text;
                cs.psTwo = fourteenHPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = fourteenHOcCustomerThree.Text;
                cs.psThree = fourteenHPorocsThree.SelectedItem.ToString();
                cs.ClockID = 12;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1430/", cs);

            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 12).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "14.30";
                log.CustomerOne = fourteenHOcCustomerOne.Text;
                log.psOne = fourteenHPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = fourteenHOcCustomerTwo.Text;
                log.psTwo = fourteenHPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = fourteenHOcCustomerThree.Text;
                log.psThree = fourteenHPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 12).First();
                c.CustomerOne = fourteenHOcCustomerOne.Text;
                c.psOne = fourteenHPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = fourteenHOcCustomerTwo.Text;
                c.psTwo = fourteenHPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = fourteenHOcCustomerThree.Text;
                c.psThree = fourteenHPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == nineOcCustomerOne.Text && x.CustomerTwo == fourteenHOcCustomerTwo.Text && x.CustomerThree == fourteenHOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1430/", c);
            }

        }



        /// ///////////////////////////////////////

        private void fifteenSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 13).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = fifteenOcCustomerOne.Text;
                cs.psOne = fifteenPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = fifteenOcCustomerTwo.Text;
                cs.psTwo = fifteenPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = fifteenOcCustomerThree.Text;
                cs.psThree = fifteenPorocsThree.SelectedItem.ToString();
                cs.ClockID = 13;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1500/", cs);
            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 13).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "15.00";
                log.CustomerOne = fifteenOcCustomerOne.Text;
                log.psOne = fifteenPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = fifteenOcCustomerTwo.Text;
                log.psTwo = fifteenPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = fifteenOcCustomerThree.Text;
                log.psThree = fifteenPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 13).First();
                c.CustomerOne = fifteenOcCustomerOne.Text;
                c.psOne = fifteenPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = fifteenOcCustomerTwo.Text;
                c.psTwo = fifteenPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = fifteenOcCustomerThree.Text;
                c.psThree = fifteenPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == fifteenOcCustomerOne.Text && x.CustomerTwo == fifteenOcCustomerTwo.Text && x.CustomerThree == fifteenOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1500/", c);
            }


        }

        private void fifteenHSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 14).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = fifteenHOcCustomerOne.Text;
                cs.psOne = fifteenHPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = fifteenHOcCustomerTwo.Text;
                cs.psTwo = fifteenHPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = fifteenHOcCustomerThree.Text;
                cs.psThree = fifteenHPorocsThree.SelectedItem.ToString();
                cs.ClockID = 14;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1530/", cs);
            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 14).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "15.30";
                log.CustomerOne = fifteenHOcCustomerOne.Text;
                log.psOne = fifteenHPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = fifteenHOcCustomerTwo.Text;
                log.psTwo = fifteenHPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = fifteenHOcCustomerThree.Text;
                log.psThree = fifteenHPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 14).First();
                c.CustomerOne = fifteenHOcCustomerOne.Text;
                c.psOne = fifteenHPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = fifteenHOcCustomerTwo.Text;
                c.psTwo = fifteenHPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = fifteenHOcCustomerThree.Text;
                c.psThree = fifteenHPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == fifteenHOcCustomerOne.Text && x.CustomerTwo == fifteenHOcCustomerTwo.Text && x.CustomerThree == fifteenHOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1530/", c);
            }

        }




        /// ////////////////////////////////////////////

        private void sixteenSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 15).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = sixteenOcCustomerOne.Text;
                cs.psOne = sixteenPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = sixteenOcCustomerTwo.Text;
                cs.psTwo = sixteenPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = sixteenOcCustomerThree.Text;
                cs.psThree = sixteenPorocsThree.SelectedItem.ToString();
                cs.ClockID = 15;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1600/", cs);
            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 15).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "16.00";
                log.CustomerOne = sixteenOcCustomerOne.Text;
                log.psOne = sixteenPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = sixteenOcCustomerTwo.Text;
                log.psTwo = sixteenPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = sixteenOcCustomerThree.Text;
                log.psThree = sixteenPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 15).First();
                c.CustomerOne = sixteenOcCustomerOne.Text;
                c.psOne = sixteenPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = sixteenOcCustomerTwo.Text;
                c.psTwo = sixteenPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = sixteenOcCustomerThree.Text;
                c.psThree = sixteenPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == sixteenOcCustomerOne.Text && x.CustomerTwo == sixteenOcCustomerTwo.Text && x.CustomerThree == sixteenOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1600/", c);

            }

        }


        private void sixteenHSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 16).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = sixteenHOcCustomerOne.Text;
                cs.psOne = sixteenHPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = sixteenHOcCustomerTwo.Text;
                cs.psTwo = sixteenHPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = sixteenHOcCustomerThree.Text;
                cs.psThree = sixteenHPorocsThree.SelectedItem.ToString();
                cs.ClockID = 16;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1630/", cs);
            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 16).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "16.30";
                log.CustomerOne = sixteenHOcCustomerOne.Text;
                log.psOne = sixteenHPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = sixteenHOcCustomerTwo.Text;
                log.psTwo = sixteenHPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = sixteenHOcCustomerThree.Text;
                log.psThree = sixteenHPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 16).First();
                c.CustomerOne = sixteenHOcCustomerOne.Text;
                c.psOne = sixteenHPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = sixteenHOcCustomerTwo.Text;
                c.psTwo = sixteenHPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = sixteenHOcCustomerThree.Text;
                c.psThree = sixteenHPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == sixteenHOcCustomerOne.Text && x.CustomerTwo == sixteenHOcCustomerTwo.Text && x.CustomerThree == sixteenHOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1630/", c);

            }

        }



        /// /////////////////////////////////////////////

        private void seventeenSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 17).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = seventeenOcCustomerOne.Text;
                cs.psOne = seventeenPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = seventeenOcCustomerTwo.Text;
                cs.psTwo = seventeenPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = seventeenOcCustomerThree.Text;
                cs.psThree = seventeenPorocsThree.SelectedItem.ToString();
                cs.ClockID = 17;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1700/", cs);
            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 17).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "17.00";
                log.CustomerOne = seventeenOcCustomerOne.Text;
                log.psOne = seventeenPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = seventeenOcCustomerTwo.Text;
                log.psTwo = seventeenPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = seventeenOcCustomerThree.Text;
                log.psThree = seventeenPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 17).First();
                c.CustomerOne = seventeenOcCustomerOne.Text;
                c.psOne = seventeenPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = seventeenOcCustomerTwo.Text;
                c.psTwo = seventeenPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = seventeenOcCustomerThree.Text;
                c.psThree = seventeenPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == seventeenOcCustomerOne.Text && x.CustomerTwo == seventeenOcCustomerTwo.Text && x.CustomerThree == seventeenOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1700/", c);

            }
        }


        private void seventeenHSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 18).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = seventeenHOcCustomerOne.Text;
                cs.psOne = seventeenHPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = seventeenHOcCustomerTwo.Text;
                cs.psTwo = seventeenHPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = seventeenHOcCustomerThree.Text;
                cs.psThree = seventeenHPorocsThree.SelectedItem.ToString();
                cs.ClockID = 18;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1730/", cs);
            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 18).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "17.30";
                log.CustomerOne = seventeenHOcCustomerOne.Text;
                log.psOne = seventeenHPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = seventeenHOcCustomerTwo.Text;
                log.psTwo = seventeenHPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = seventeenHOcCustomerThree.Text;
                log.psThree = seventeenHPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 18).First();
                c.CustomerOne = seventeenHOcCustomerOne.Text;
                c.psOne = seventeenHPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = seventeenHOcCustomerTwo.Text;
                c.psTwo = seventeenHPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = seventeenHOcCustomerThree.Text;
                c.psThree = seventeenHPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == seventeenHOcCustomerOne.Text && x.CustomerTwo == seventeenHOcCustomerTwo.Text && x.CustomerThree == seventeenHOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1730/", c);
            }

        }



        /// /////////////////////////////////////////

        private void eighteenSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 19).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = eighteenOcCustomerOne.Text;
                cs.psOne = eighteenPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = eighteenOcCustomerTwo.Text;
                cs.psTwo = eighteenPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = eighteenOcCustomerThree.Text;
                cs.psThree = eighteenPorocsThree.SelectedItem.ToString();
                cs.ClockID = 19;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1800/", cs);
            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 19).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "18.00";
                log.CustomerOne = eighteenOcCustomerOne.Text;
                log.psOne = eighteenPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = eighteenOcCustomerTwo.Text;
                log.psTwo = eighteenPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = eighteenOcCustomerThree.Text;
                log.psThree = eighteenPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 19).First();
                c.CustomerOne = eighteenOcCustomerOne.Text;
                c.psOne = eighteenPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = eighteenOcCustomerTwo.Text;
                c.psTwo = eighteenPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = eighteenOcCustomerThree.Text;
                c.psThree = eighteenPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == eighteenOcCustomerOne.Text && x.CustomerTwo == eighteenOcCustomerTwo.Text && x.CustomerThree == eighteenOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1800/", c);
            }

        }


        private void eighteenHSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 20).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = eighteenHOcCustomerOne.Text;
                cs.psOne = eighteenHPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = eighteenHOcCustomerTwo.Text;
                cs.psTwo = eighteenHPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = eighteenHOcCustomerThree.Text;
                cs.psThree = eighteenHPorocsThree.SelectedItem.ToString();
                cs.ClockID = 20;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1830/", cs);
            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 20).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "18.30";
                log.CustomerOne = eighteenHOcCustomerOne.Text;
                log.psOne = eighteenHPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = eighteenHOcCustomerTwo.Text;
                log.psTwo = eighteenHPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = eighteenHOcCustomerThree.Text;
                log.psThree = eighteenHPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 20).First();
                c.CustomerOne = eighteenHOcCustomerOne.Text;
                c.psOne = eighteenHPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = eighteenHOcCustomerTwo.Text;
                c.psTwo = eighteenHPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = eighteenHOcCustomerThree.Text;
                c.psThree = eighteenHPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == eighteenHOcCustomerOne.Text && x.CustomerTwo == eighteenHOcCustomerTwo.Text && x.CustomerThree == eighteenHOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1830/", c);

            }


        }


        /// /////////////////////////////////////////

        private void nineteenSave_Click(object sender, RoutedEventArgs e)
        {
            if (db.Customers.Where(c => c.dayID == dayIDLocal && c.ClockID == 21).Select(y => y.CustomerID).FirstOrDefault() == 0)
            {
                Customer cs = new Customer();
                cs.CustomerOne = nineteenOcCustomerOne.Text;
                cs.psOne = nineteenPorocsOne.SelectedItem.ToString();
                cs.CustomerTwo = nineteenOcCustomerTwo.Text;
                cs.psTwo = nineteenPorocsTwo.SelectedItem.ToString();
                cs.CustomerThree = nineteenOcCustomerThree.Text;
                cs.psThree = nineteenPorocsThree.SelectedItem.ToString();
                cs.ClockID = 21;  //**********************************************
                cs.dayID = dayIDLocal;
                db.Customers.Add(cs);
                db.SaveChanges();

                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Saat 1900/", cs);

            }
            else //update
            {
                Customer cc = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 21).First();

                CustomerLOG log = new CustomerLOG();
                log.Clock = "19.00";
                log.CustomerOne = nineteenOcCustomerOne.Text;
                log.psOne = nineteenPorocsOne.SelectedItem.ToString();

                log.BeforeCustomerOne = cc.CustomerOne;
                log.BeforepsOne = cc.psOne;

                log.CustomerTwo = nineteenOcCustomerTwo.Text;
                log.psTwo = nineteenPorocsTwo.SelectedItem.ToString();

                log.BeforeCustomerTwo = cc.CustomerTwo;
                log.BeforepsTwo = cc.psTwo;

                log.CustomerThree = nineteenOcCustomerThree.Text;
                log.psThree = nineteenPorocsThree.SelectedItem.ToString();

                log.BeforeCustomerThree = cc.CustomerThree;
                log.BeforepsThree = cc.psThree;

                log.updateDate = DateTime.Now;
                db.CustomersLOG.Add(log);


                Customer c = db.Customers.Where(x => x.dayID == dayIDLocal && x.ClockID == 21).First();
                c.CustomerOne = nineteenOcCustomerOne.Text;
                c.psOne = nineteenPorocsOne.SelectedItem.ToString();
                c.CustomerTwo = nineteenOcCustomerTwo.Text;
                c.psTwo = nineteenPorocsTwo.SelectedItem.ToString();
                c.CustomerThree = nineteenOcCustomerThree.Text;
                c.psThree = nineteenPorocsThree.SelectedItem.ToString();
                db.SaveChanges();

                CustomerLOG logid = db.CustomersLOG.Where(x => x.CustomerOne == nineteenOcCustomerOne.Text && x.CustomerTwo == nineteenOcCustomerTwo.Text && x.CustomerThree == nineteenOcCustomerThree.Text).First();
                string cLOGid = logid.CustomerID.ToString();
                con.response = con.client.Set(@"Log/" + cLOGid, log);

                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Saat 1900/", c);
            }

        }




        private void Button_Click(object sender, RoutedEventArgs e) //note button
        {
            if (db.DayNotes.Where(c => c.dayID == dayIDLocal).Select(y => y.NoteID).FirstOrDefault() == 0)
            {
                DayNote dn = new DayNote();
                dn.Note = noteTxt.Text;
                dn.dayID = dayIDLocal;

                db.DayNotes.Add(dn);
                db.SaveChanges();
                con.response = con.client.Set(fireBaseDayTime + @"/" + @"Day Note/", dn);

            }
            else //update
            {
                DayNote d = db.DayNotes.Where(x => x.dayID == dayIDLocal).First();
                d.Note = noteTxt.Text;

                db.SaveChanges();
                con.response = con.client.Update(fireBaseDayTime + @"/" + @"Day Note/", d);

            }
        }
    }
}
