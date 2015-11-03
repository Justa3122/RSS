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
using System.Windows.Shapes;

namespace RSS
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2(News selectedNews)
        {
            InitializeComponent();
            PreparingWindowDesign();
            FillWithNews(selectedNews);
        }
        private void FillWithNews(News selectedNews)
        {
            TextBlock1Win2.Text = selectedNews.DescriptionOfNews.Text;
            string link1 = selectedNews.DescriptionOfNews.ImageLink;

            if (selectedNews.DescriptionOfNews.ImageLink != @"http://i.wp.pl/a/f/film/001/16/97/0439716.jpg")
            {
                image1win2.Source = new BitmapImage(new Uri(link1));
            }
            else
            {
                image1win2.Source = new BitmapImage(new Uri(@"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTkJOK5c3FY4LEGltI9O20KPVdKbJrS3rzoQ1TvzMoKDmagAzsCAQ"));
            }


            TextBlock2Win2.Text = selectedNews.TitleOfNews;

            TextBlock3Win2.Text = selectedNews.LinkToWebsite;
            TextBlock4Win2.Text = selectedNews.DateOfPublication.ToString();
        }
        #region Obsługa okna
        private void PreparingWindowDesign()
        {
            System.Windows.Media.Brush col1 = OuterGlow.BorderBrush;
            DropShadowEffect2.Color = ((SolidColorBrush)col1).Color;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Rectangle_PreviewMouseLeftButtonDown2(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
	    #endregion
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {


            myMediaElement1_Copy5.Position = TimeSpan.FromMilliseconds(1);
        }
    }
}
