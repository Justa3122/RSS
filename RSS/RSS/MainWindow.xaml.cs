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
        public MainWindow()
        {
            InitializeComponent();
            PreparingWindowDesign();
            ShowNews();
        }

        #region Kod do uzycia Rss i wypelniania okna
        private void PreparingWindowDesign()
        {
            System.Windows.Media.Brush col1 = OuterGlow.BorderBrush;
            DropShadowEffect.Color = ((SolidColorBrush)col1).Color;
        }
        private void ShowNews()
        { 
            rs.ReadNews(@"http://film.wp.pl/rss.xml?id=7");
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
    }
}
