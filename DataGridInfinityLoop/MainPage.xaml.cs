using DataGridInfinityLoop.Model;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DataGridInfinityLoop
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<DataModel> dataModels;
        public ObservableCollection<DataModel> DataModels
        {
            get => dataModels;
            set
            {
                if (dataModels == value) return;
                dataModels = value;

                OnPropertyChanged();
            }
        }

        private DataProvider provider;

        public MainPage()
        {
            this.InitializeComponent();
        }        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            provider = new DataProvider();

            Refresh();
        }

        public async void Refresh()
        {
            await provider.ReadData("Data/data.csv");
                        
            await Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
            {
                DataModels = new ObservableCollection<DataModel>(provider.DataModels);
            });            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
