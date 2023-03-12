using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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


namespace Wpf_gallery_task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Image> Images { get; set; } = new ObservableCollection<Image>
        {
            new Image
            {
                Id=1,
                ImageName="Mona Lisa",
                ImagePath="Images/monalisa.jpg"
            },
            new Image
            {
                Id=2,
                ImageName="Vincent van Gogh",
                ImagePath="Images/vincent.png"
            },
            new Image
            {
                Id=3,
                ImageName="Salvator Mundi",
                ImagePath="Images/salvator.jpg"
            },
            new Image
            {
                Id=4,
                ImageName="The Brooklyn Rail",
                ImagePath="Images/brooklyn.jpg"
            },
            new Image
            {
                Id=5,
                ImageName="The Last Supper",
                ImagePath="Images/lastsupper.jpg"
            },
            new Image
            {
                Id=6,
                ImageName="Lady with an Ermine",
                ImagePath="Images/lady.jpg"
            }
        };

        private int width;

        public int ImageWidth
        {
            get { return width; }
            set { width = value; OnPropertyChanged(); }
        }
        private int height;

        public int ImageHeight
        {
            get { return height; }
            set { height = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
        public MainWindow()
        {
            InitializeComponent();
            ImageHeight = 200;
            ImageWidth = 300;
            this.DataContext = this;
        }
        public bool TilesClicked { get; set; } = false;
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!TilesClicked)
            {
                ImageWidth = 100;
                ImageHeight = 200;
            }
            TilesClicked = !TilesClicked;
        }
        public bool SmallIconsClicked { get; set; } = false;
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (!SmallIconsClicked)
            {
                ImageWidth = 50;
                ImageHeight = 100;
            }
            SmallIconsClicked = !SmallIconsClicked;
        }
        public bool DetailsClicked { get; set; } = false;
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (!DetailsClicked)
            {
                ImageWidth = 30;
                ImageHeight = 50;
            }
            DetailsClicked = !DetailsClicked;
        }
        private void ImageLbl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ImageWindow imageWindow = new ImageWindow();
            var item = ImagesListBox.SelectedItem as Image;
            imageWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            imageWindow.Path = item.ImagePath;
            imageWindow.ShowDialog();
        }
    }
}
