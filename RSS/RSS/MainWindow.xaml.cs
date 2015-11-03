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
        private List<Image> images;
        private List<Button> buttons;
        private DBCreator database;
        
        public MainWindow()
        {
            InitializeComponent();
            database = new DBCreator();
            images = new List<Image>();
            textBlocks = new List<TextBlock>();
            buttons = new List<Button>();

            ListingTextboxesImagesAndButtons();
            DeleteNews();
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
            for (int i = 0; i < 5; i++)
            {
                images[i].Source = null;
                images[i].Visibility = Visibility.Collapsed;
                textBlocks[i].Text = null;
                textBlocks[i].Visibility = Visibility.Collapsed;
                buttons[i].Visibility = Visibility.Collapsed;
            }
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
            FillNewsInformation();
        }
        private void ListingTextboxesImagesAndButtons()
        {
            images.Add(image1); images.Add(image2);images.Add(image3);
            images.Add(image4);images.Add(image5);
            textBlocks.Add(TextBlock1); textBlocks.Add(TextBlock2); textBlocks.Add(TextBlock3);
            textBlocks.Add(TextBlock4); textBlocks.Add(TextBlock5);
            buttons.Add(button1); buttons.Add(button2); buttons.Add(button3);
            buttons.Add(button4); buttons.Add(button5);
        }
        private void FillNewsInformation()
        {
            tmpNews = newsFromRegion.OrderBy(x => x.NewsID).Skip(indexOfNews).Take(5).ToList(); 
            
           for (int i = 0; i < 5; i++)
            {
                try
                {
                    BitmapImage bitImg = new BitmapImage();
                    bitImg.BeginInit();
                    bitImg.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                    bitImg.UriSource = new Uri(tmpNews[i].DescriptionOfNews.ImageLink);
                    bitImg.EndInit();
                    images[i].Source = bitImg;
                    textBlocks[i].Text = tmpNews[i].TitleOfNews;
                    images[i].Visibility = Visibility.Visible;
                    textBlocks[i].Visibility = Visibility.Visible;
                    buttons[i].Visibility = Visibility.Visible;

                }
                catch (Exception)
                {
                }
            }
        }
        #endregion

        #region Obsluga okna (zamyk. minim. przesuwanie)
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
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

        private void applyComboBox_Click(object sender, RoutedEventArgs e)
        {
            newsFromRegion = database.db.News.Where(x => x.Region.RegionName == comboBox.SelectedItem.ToString())
                .OrderBy(x => x.NewsID).Select(x => x).ToList();       
            
            ShowNews();
        }

        #region Przyciski Niżej Wyżej
        private void Nizej_Click(object sender, RoutedEventArgs e)
        {
            if (indexOfNews < newsFromRegion.Count -5)
            {
                indexOfNews += 1;
            }
            ShowNews();
        }
        private void Wyzej_Click(object sender, RoutedEventArgs e)
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

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {

            myMediaElement1_Copy1.Position = TimeSpan.FromMilliseconds(1);
            myMediaElement1_Copy2.Position = TimeSpan.FromMilliseconds(1);
            myMediaElement1_Copy3.Position = TimeSpan.FromMilliseconds(1);
            //myMediaElement1_Copy5.Position = TimeSpan.FromMilliseconds(1);
        }
    
    
    }

}
