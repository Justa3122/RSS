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

namespace RSS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Image> images = new List<Image>();
        private int indexOfNews = 0;
        private List<TextBlock> textBlocks = new List<TextBlock>();
        private RSSReader rs = new RSSReader();
        private string linkOfChannel { get; set; }
        private NewsDB database;

        public MainWindow()
        {
            InitializeComponent();
            comboBox.SelectedIndex = 0;
            AddChannelsToList();
            LinkToChannel();
            PreparingWindowDesign();
            ShowNews();
        }

        #region wybieranie kanalu
        private void AddChannelsToList()
        {
            comboBox.Items.Add("Bielsko - Biała");
            comboBox.Items.Add("Bydgoszcz");
            comboBox.Items.Add("Gdańsk");
            comboBox.Items.Add("Gdynia");
            comboBox.Items.Add("Katowice");
            comboBox.Items.Add("Lublin");
            comboBox.Items.Add("Łódź");
            comboBox.Items.Add("Olsztyn");
            comboBox.Items.Add("Poznań");
            comboBox.Items.Add("Rzeszów");
            comboBox.Items.Add("Sopot");
            comboBox.Items.Add("Szczecin");
            comboBox.Items.Add("Toruń");
            comboBox.Items.Add("Warszawa");
            comboBox.Items.Add("Wrocław");
            comboBox.Items.Add("Zakopane");
        }
        private void LinkToChannel()
        {
            if (comboBox.Text == "Bielsko - Biała")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=7";
            }
            if (comboBox.Text == "Bydgoszcz")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=10";
            }
            if (comboBox.Text == "Gdańsk")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=27";
            }
            if (comboBox.Text == "Gdynia")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=28";
            }
            if (comboBox.Text == "Katowice")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=44";
            }
            if (comboBox.Text == "Lublin")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=60";
            }
            if (comboBox.Text == "Łódź")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=135";
            }
            if (comboBox.Text == "Olsztyn")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=71";
            }
            if (comboBox.Text == "Poznań")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=81";
            }
            if (comboBox.Text == "Rzeszów")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=94";
            }
            if (comboBox.Text == "Sopot")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=100";
            }
            if (comboBox.Text == "Szczecin")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=106";
            }
            if (comboBox.Text == "Toruń")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=118";
            }
            if (comboBox.Text == "Warszawa")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=123";
            }
            if (comboBox.Text == "Wrocław")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=127";
            }
            if (comboBox.Text == "Zakopane")
            {
                linkOfChannel = "http://film.wp.pl/rss.xml?id=130";
            }

        }
        private void DeleteNews()
        {
            
            rs.newsList.Clear();
            
            image1.Source = null;
            image2.Source = null;
            image3.Source = null;
            image4.Source = null;
            image5.Source = null;

            TextBlock1.Text = null;
            TextBlock2.Text = null;
            TextBlock3.Text = null;
            TextBlock4.Text = null;
            TextBlock5.Text = null;
        }
        #endregion

        #region Kod do uzycia Rss i wypelniania okna
        private void PreparingWindowDesign()
        {
            System.Windows.Media.Brush col1 = OuterGlow.BorderBrush;
            DropShadowEffect.Color = ((SolidColorBrush)col1).Color;
        }
        private void ShowNews()
        { 
            rs.ReadNews(linkOfChannel);
            ListingTextboxesAndImages();
            FillNewsInformation();
            
            //DodawanieDoBazy
            AddToDB();
        }
        private void ListingTextboxesAndImages()
        {
            images.Add(image1); images.Add(image2);images.Add(image3);
            images.Add(image4);images.Add(image5);
            textBlocks.Add(TextBlock1); textBlocks.Add(TextBlock2); textBlocks.Add(TextBlock3);
            textBlocks.Add(TextBlock4); textBlocks.Add(TextBlock5);
        }
        private void FillNewsInformation()
        {
            for (int i = 0; i < 5; i++)
            {
                if (rs.newsList[i + indexOfNews].DescriptionOfNews.ImageLink != @"http://i.wp.pl/a/f/film/001/16/97/0439716.jpg")
                {
                    images[i].Source = new BitmapImage(new Uri(rs.newsList[i + indexOfNews].DescriptionOfNews.ImageLink)); 
                }
                else
                {
                    images[i].Source = new BitmapImage(new Uri(@"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTkJOK5c3FY4LEGltI9O20KPVdKbJrS3rzoQ1TvzMoKDmagAzsCAQ"));
                }
                textBlocks[i].Text = rs.newsList[i + indexOfNews].TitleOfNews;
            }
        }
        #endregion

        #region Obsluga okna (zamyk. minim. przesuwanie)
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Rectangle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        #endregion

        private void AddToDB()
        {
            try
            {
                database = new NewsDB(false);
                var a = from c in database.niusiki select new { tytul = c.TitleOfNews, linkacz = c.ChannelLink };
                foreach (var item1 in rs.newsList)
                {
                    bool isInDatabase = false;
                    foreach (var item2 in a)
                    {
                        if (item2.linkacz == item1.ChannelLink && item2.tytul == item1.TitleOfNews)
                        {
                            isInDatabase = true;
                        }
                    }
                    if (!isInDatabase)
                    {
                        database.niusiki.Add(item1);
                    }
                }
                database.SaveChanges();
            }
            catch (Exception)
            {
                try
                {
                    database = new NewsDB(true);
                    var a = from c in database.niusiki select new { tytul = c.TitleOfNews, linkacz = c.ChannelLink };
                    foreach (var item1 in rs.newsList)
                    {
                        bool isInDatabase = false;
                        foreach (var item2 in a)
                        {
                            if (item2.linkacz == item1.ChannelLink && item2.tytul == item1.TitleOfNews)
                            {
                                isInDatabase = true;
                            }
                        }
                        if (!isInDatabase)
                        {
                            database.niusiki.Add(item1);
                        }
                    }
                    database.SaveChanges();
                }
                catch (Exception)
                {
                }
            }
        
        }

        public void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void applyComboBox_Click(object sender, RoutedEventArgs e)
        {
            DeleteNews();
            LinkToChannel();
            ShowNews();
        }
        
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        #region Przyciski Niżej Wyżej
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (indexOfNews < rs.newsList.Count() -5)
            {
                indexOfNews += 1; 
            }
            DeleteNews();
            ShowNews();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (indexOfNews > 0)
            {
                indexOfNews -= 1;
            }
            DeleteNews();
            ShowNews();
        }
    #endregion
        #region Przyciski Czytaj dalej
        private void czytaj_Click1(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2(rs.newsList[indexOfNews]);
            w2.Show();
        }
        private void czytaj_Click2(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2(rs.newsList[indexOfNews+1]);
            w2.Show();
        }
        private void czytaj_Click3(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2(rs.newsList[indexOfNews+2]);
            w2.Show();
        }
        private void czytaj_Click4(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2(rs.newsList[indexOfNews+3]);
            w2.Show();
        }
        private void czytaj_Click5(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2(rs.newsList[indexOfNews+4]);
            w2.Show();
        }
        #endregion
    }
}
