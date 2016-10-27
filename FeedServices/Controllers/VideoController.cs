using FeedServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FeedServices.Controllers
{
    public class VideoController : ApiController
    {
        public List<VideoFeedsAziz> Videos = new List<VideoFeedsAziz>();
        void Load()
        {
            Videos.Add(new VideoFeedsAziz() { Id = 1, VideoTitle = "NettoyantTEST de salle de bain", VideoUrl = "URL1" });
            Videos.Add(new VideoFeedsAziz() { Id = 2, VideoTitle = "Nettoyant multi-usages", VideoUrl = "URL2" });
            Videos.Add(new VideoFeedsAziz() { Id = 3, VideoTitle = "Nettoyant cuvette des WC", VideoUrl = "URL3" });
        }
        [HttpGet]
        public List<string> Test()
        {
            List<string> testlist = new List<string>();
            testlist.Add("this is a test");
            return testlist;
        }
        //http://localhost:59916/api/video/testEF 
        [HttpGet]
        public List<VideoFeedsAziz> TestEF()
        {
            Load();
            return Videos;
        }
        [HttpPost]
        public List<VideoFeedsAziz> AddVideo(VideoFeedsAziz VideoToAdd)
        {
            Load();
            try
            {
                Videos.Add(VideoToAdd);
                return Videos;
            }
            catch
            {
                return null;
            }
        }
        [HttpDelete]
        public List<VideoFeedsAziz> DeleteVideo(int id)
        {
            Load();
            var Found = Videos.FirstOrDefault(o => o.Id == id);

            if (Found == null)
            {
                return null;
            }
            else
            {
                Videos.Remove(Found);
                return Videos;
            }
        }
        [HttpPut]
        public List<VideoFeedsAziz> UpdateVideo(VideoFeedsAziz VideoToUpdate)
        {
            Load();
            int id = VideoToUpdate.Id;
            var Found = Videos.FirstOrDefault(o => o.Id == id);

            if (Found == null)
            {
                return null;
            }
            else
            {
                foreach (VideoFeedsAziz obj in Videos)
                {
                    if (obj.Id == id)
                    {
                        obj.VideoTitle = VideoToUpdate.VideoTitle;
                        obj.VideoUrl = VideoToUpdate.VideoUrl;
                        break;
                    }
                }
                return Videos;
            }
        }
    }
}

