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
        
        public MainWindow()
        {
            
            InitializeComponent();
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            System.Windows.Media.Brush col1 = OuterGlow.BorderBrush;
            DropShadowEffect.Color = ((SolidColorBrush)col1).Color;
            //DataBase db = new DataBase();
            News wojna = new News(1, "wojna w rosji","<img src=/>- Jestem gotów poprzeć rząd mniejszościowy PiS, żeby nie destabilizować państwa - mówi w Kontrwywiadzie RMF FM szef ruchu Kukiz&#8217;15 Paweł Kukiz. - Chcę być potężnym językiem u wagi, który zmieni ustrój Polski, zmieni konstytucję, doprowadzi do tego, że Sejm zacznie pracować. Nie chcę rządzić po tych wyborach. Ja się nie nadaję na wicepremiera - dodaje. - Sondaże? Jakie sondaże, proszę pana. Patrzę na wyniki Petru i jestem przekonany, że on jest symulowany przez te sondaże - komentuje Kukiz. <a href=>wiadomosci.wp.pl</a>","dsadsa", "Mon, 12 Oct 2015 08:45:00 +0200");
            Category swiat = new Category(1, "swiat");
            swiat.AddNews(wojna);
            string link1 = "http://i.wp.pl/a/f/film/001/12/12/0431212.jpg";
            string link2 = "http://i.wp.pl/a/f/film/001/84/76/0437684.jpg";
            string link3 = "http://i.wp.pl/a/f/film/001/10/34/0433410.jpg";
            string link4 = "http://i.wp.pl/a/f/film/001/76/45/0434576.jpg";
            string link5 = "http://i.wp.pl/a/f/film/001/23/35/0433523.jpg";
            image1.Source = new BitmapImage(new Uri(link1));
            image2.Source = new BitmapImage(new Uri(link2));
            image3.Source = new BitmapImage(new Uri(link3));
            image4.Source = new BitmapImage(new Uri(link4));
            image5.Source = new BitmapImage(new Uri(link5));
            expander.Content = swiat.Name;
            TextBlock1.Text = wojna.DescriptionOfNews.Text;
            TextBlock2.Text = "Fajne się wydaje";
            TextBlock3.Text = "Tyty ryty trytytki!";
            TextBlock4.Text = "Chcę oglądać! ";
            TextBlock5.Text = "To też chcę oglądać :) ";
            //if (label1.MouseDoubleClick())
            //{
            //    TextBlock4.Text = "KLIK ";
            //}
           
            




            //db.Categories.Add(swiat);
            //db.SaveChanges();
        }

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
