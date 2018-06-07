using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.UI.ViewManagement;
using Windows.Graphics.Display;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;


namespace BattleShipUWP
{

    public class GridModel : INotifyPropertyChanged
    {
        private string statusValue = String.Empty;

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Status
        {
            get
            {
                return this.statusValue;
            }
            set
            {
                if (value != this.statusValue)
                {
                    this.statusValue = value;
                    NotifyPropertyChanged("Status");
                    Debug.WriteLine("Status NotifyPropertyChanged.");
                }
            }
        }
    }


public sealed partial class MainPage : Page
    {
        ObservableCollection<GridModel> mainBoard = new ObservableCollection<GridModel>();
        
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            var scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            var size = new Size(bounds.Width * scaleFactor, bounds.Height * scaleFactor);
            int Columns = (int)size.Width / 50;
            int Rows = (int)size.Height / 50;
            int GridSize = Columns * Rows;
            string statusValue = string.Empty;

            for (int i = 0; i < GridSize; i++)
            {
                //      newBoard.Add(new UserData() { Color = "blue" });
                mainBoard.Add(new GridModel { Status = "Clear" });
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Button) sender).Background = new SolidColorBrush(Windows.UI.Colors.Red);
            //         this.mainBoard[4].Status = "Shot";
            ((Button)sender).Content = "Shot";
            
        }
    }
}
