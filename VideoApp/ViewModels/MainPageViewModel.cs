using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using VideoApp.Business.Helpers;
using Service.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace VideoApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region change handling
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            //Fire the PropertyChanged event in case somebody subscribed to it
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        ObservableCollection<VideoFeeds> _videoFeed;
        public ObservableCollection<VideoFeeds> VideoFeed
        { get { return _videoFeed; }
            set { Set(ref _videoFeed, value);
            } }
        //private ICommand addCommand;
        //public ICommand AddCommand
        //{
        //    get
        //    {
        //        return addCommand;
        //    }
        //    set
        //    {
        //        addCommand = value;
        //    }
        //}
        //public DelegateCommand NewAction { get; private set; }
        public AsyncCommand AddAsyncCommand { get; private set; }
        public AsyncCommand LoadAsyncCommand { get; private set; }
        public AsyncCommand UpdateAsyncCommand { get; private set; }
        public AsyncCommand DeleteAsyncCommand { get; private set; }

        VideoFeeds VideoToAdd = new VideoFeeds() {Id= 4, VideoTitle="Produit Test", VideoUrl="UrlTesteur" };
        public VideoFeeds VideoToUpdate = new VideoFeeds() { Id = 3, VideoTitle = "Modification Produit Test", VideoUrl = "UrlTesteur" };
        private VideoFeeds p_SelectedItem;
        public VideoFeeds SelectedItem
        {
            get { return p_SelectedItem; }

            set
            {
                Set(ref p_SelectedItem, value);
            }
        }
        public MainPageViewModel()
        {
            _videoFeed = new ObservableCollection<VideoFeeds>();
            //addCommand = new RelayCommand(AddingVideo);
            //NewAction = new DelegateCommand(GetData);
            LoadAsyncCommand = new AsyncCommand(GetData);
            AddAsyncCommand = new AsyncCommand(CreateVideo);
            UpdateAsyncCommand = new AsyncCommand(UpdateVideo);
            DeleteAsyncCommand = new AsyncCommand(DeleteVideo);
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (suspensionState.Any())
            {
                
            }
            await Task.CompletedTask;
        }
        private async Task GetData()
        {
            var data = await Business.VideoManager.GetAll();
            if (data != null)
                _videoFeed = data.ToObservableCollection();
             this.OnPropertyChanged("VideoFeed");
        }
        public async Task CreateVideo()
        {
            var datatotest = p_SelectedItem;
            var data = await Business.VideoManager.CreateVideo(p_SelectedItem);
            if (data != null)
                _videoFeed = data.ToObservableCollection();
            this.OnPropertyChanged("VideoFeed");
        }
        public async Task UpdateVideo()
        {
            var data = await Business.VideoManager.UpdateVideo(VideoToUpdate);
            if (data != null)
                _videoFeed = data.ToObservableCollection();
            this.OnPropertyChanged("VideoFeed");
        }
        public async Task DeleteVideo()
        {
            var data = await Business.VideoManager.DeleteVideo(VideoToUpdate.Id);
            if (data != null)
                _videoFeed = data.ToObservableCollection();
            this.OnPropertyChanged("VideoFeed");
        }
    }
}

