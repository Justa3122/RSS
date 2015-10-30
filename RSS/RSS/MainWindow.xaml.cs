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
        public int indexOfNews;
        
        public List<News> newsFromRegion;
        public List<News> tmpNews;
        
        
        private List<TextBlock> textBlocks;
        private DBCreator database;
        private List<Image> images;
        
        public MainWindow()
        {
            InitializeComponent();
            database = new DBCreator();
            images = new List<Image>();
            textBlocks = new List<TextBlock>();

            AddChannelsToList();
            PreparingWindowDesign();
            
            comboBox.SelectedIndex = 0;
            indexOfNews = 0;
        }

        #region wybieranie kanalu
        private void AddChannelsToList()
        {
            var a = database.db.Region.Select(x => x.RegionName).ToList();
            foreach (var item in a)
                comboBox.Items.Add(item);
        }
        private void DeleteNews()
        {               
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
            DeleteNews();
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
            var tmpNews = newsFromRegion.OrderBy(x => x.NewsID).Skip(indexOfNews).Take(5).ToList();

            for (int i = 0; i < tmpNews.Count; i++)
            {
                if (tmpNews[i].DescriptionOfNews.ImageLink != @"http://i.wp.pl/a/f/film/001/16/97/0439716.jpg")
                {
                    images[i].Source = new BitmapImage(new Uri(tmpNews[i].DescriptionOfNews.ImageLink));
                }
                else
                {
                    images[i].Source = new BitmapImage(new Uri(@"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTkJOK5c3FY4LEGltI9O20KPVdKbJrS3rzoQ1TvzMoKDmagAzsCAQ"));
                }
                textBlocks[i].Text = tmpNews[i].TitleOfNews;
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

        public void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        private void applyComboBox_Click(object sender, RoutedEventArgs e)
        {
            newsFromRegion = database.db.News.Where(x => x.Region.RegionName == comboBox.SelectedItem.ToString())
                .OrderBy(x => x.NewsID).Select(x => x).ToList();       
            
            ShowNews();

        }
        
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        #region Przyciski Niżej Wyżej
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (indexOfNews < newsFromRegion.Count -5)
            {
                indexOfNews += 1;
            }
            ShowNews();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (indexOfNews > 0)
            {
                indexOfNews -= 1;
            }
            ShowNews();
        }
    #endregion
        #region Przyciski Czytaj dalej
        private void czytaj_Click1(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2(tmpNews[0]);
            w2.Show();
        }
        private void czytaj_Click2(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2(tmpNews[1]);
            w2.Show();
        }
        private void czytaj_Click3(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2(tmpNews[2]);
            w2.Show();
        }
        private void czytaj_Click4(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2(tmpNews[3]);
            w2.Show();
        }
        private void czytaj_Click5(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2(tmpNews[4]);
            w2.Show();
        }
        #endregion
    }
}
