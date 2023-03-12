using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Threading;

namespace Wpf_gallery_task
{
    /// <summary>
    /// Interaction logic for ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window, INotifyPropertyChanged
    {
        DispatcherTimer timer = new DispatcherTimer();
        List<string> list = new List<string>();
        private string path;
        public string Path
        {
            get { return path; }
            set { path = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
        public RelayCommand StopCommand { get; set; }
        public RelayCommand PlayCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public RelayCommand ForwardCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }
        int count = 0;
        private void AddImage()
        {
            list.Add("Images/monalisa.jpg");
            list.Add("Images/vincent.png");
            list.Add("Images/salvator.jpg");
            list.Add("Images/brooklyn.jpg");
            list.Add("Images/lastsupper.jpg");
            list.Add("Images/lady.jpg");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (list.Count == 0)
            {
                AddImage();
            }
            Path = list[count];
            if (count == 5)
            {
                count = 0;
            }
            else
            {
                count++;
            }
        }
        public ImageWindow()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            InitializeComponent();
            StopCommand = new RelayCommand((obj) =>
            {
                timer.Stop();
            });
            PlayCommand = new RelayCommand((obj) =>
            {
                timer.Start();
            });
            BackCommand = new RelayCommand((obj) =>
            {
                timer.Stop();
                if (count == -1)
                {
                    count = 5;
                }
                Path = list[count--];
                timer.Start();
            });
            ForwardCommand = new RelayCommand((obj) =>
            {
                timer.Stop();
                if (count == 5)
                {
                    count = 0;
                }
                Path = list[count++];
                timer.Start();
            });
            CloseCommand = new RelayCommand((obj) =>
            {
                this.Close();
            });
            this.DataContext = this;
        }
    }
}
