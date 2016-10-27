using Service.Models;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoApp.Business
{
    public class VideoManager
    {
        public static async Task<List<VideoFeeds>> GetAll()
        {
            using (VideoRepository rep = new VideoRepository())
            {
                var VideoList = await rep.GetAllVideos();
                return VideoList;
            }
        }
        //Post Manager
        public static async Task<List<VideoFeeds>> CreateVideo(VideoFeeds video)
        {
            using (VideoRepository rep = new VideoRepository())
            {
                var response = await rep.CreateVideo(video);
                return response;
            }

        }
        //delete
        public static async Task<List<VideoFeeds>> DeleteVideo(int VideoId)
        {
            using (VideoRepository rep = new VideoRepository())
            {
                var response = await rep.DeleteVideo(VideoId);
                return response;
            }
        }
        //update
        public static async Task<List<VideoFeeds>> UpdateVideo(VideoFeeds video)
        {
            using (VideoRepository rep = new VideoRepository())
            {
                var response = await rep.UpdateVideo(video);
                return response;
            }

        }
    }
}
