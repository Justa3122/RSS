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
        private List<TextBlock> textBlocks = new List<TextBlock>();
        private RSSReader rs = new RSSReader();
        private string linkOfChannel { get; set; }

        public MainWindow()
        {
           
            InitializeComponent();
            comboBox.SelectedIndex = 1;
            AddChannelsToList();
            LinkToChannel();
            PreparingWindowDesign();
            ShowNews();
        }

        #region wybieranie kanalu
        private void AddChannelsToList()
        {
            comboBox.Items.Add("Bielsko-Biała");
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
            if (comboBox.Text == "Bielsko-Biała")
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
                images[i].Source = new BitmapImage(new Uri(rs.newsList[i].DescriptionOfNews.ImageLink));
                textBlocks[i].Text = rs.newsList[i].TitleOfNews;
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

        public void button1_Click(object sender, RoutedEventArgs e)
        {
            Window2 okno2 = new Window2();
            okno2.Show();
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
    }
}
