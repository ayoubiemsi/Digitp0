using Service.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VideoApp.Business.Helpers;
using Windows.UI.Xaml.Controls;

namespace VideoApp.Views
{
    public sealed partial class MainPage : Page
    {
        ObservableCollection<VideoFeeds> VideoFeeds;

        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;        
        }
       

        private void MyAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
   
        }

        private void CommandBar_Opening(object sender, object e)
        {
            CommandBar cb = sender as CommandBar;
            if (cb != null) cb.Background.Opacity = 1.0;
        }

        private void CommandBar_Closing(object sender, object e)
        {
            CommandBar cb = sender as CommandBar;
            if (cb != null) cb.Background.Opacity = 0;
           
        }
    }
}
