using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class VideoRepository : BaseRepository, IDisposable
    {
        public async Task<List<VideoFeeds>> GetAllVideos()
        {
            var obj = await base.GetAsync<List<VideoFeeds>>("TestEF","Video");
            return obj;
        }
        public async Task<List<VideoFeeds>> CreateVideo(VideoFeeds Video)
        {
            var obj = await base.PostAsync<VideoFeeds, List<VideoFeeds>>(Video, "AddVideo", "Video");
            return obj;
        }
        public async Task<List<VideoFeeds>> DeleteVideo(int VideoId)
        {
            string VideoIdString = VideoId.ToString();
            var obj = await base.DeleteAsync<List<VideoFeeds>>(VideoIdString, "DeleteVideo", "Video");
            return obj;
        }
        public async Task<List<VideoFeeds>> UpdateVideo(VideoFeeds video)
        {
            var obj = await base.PutAsync<VideoFeeds, List<VideoFeeds>>(video, "UpdateVideo", "Video");
            return obj;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
