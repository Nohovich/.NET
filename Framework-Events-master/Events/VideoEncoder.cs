using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class VideoEncoder
    {


        // creating the event my self

        // EventHandler =  delegate void EventHandler(object sender, EventArgs e);

        // 1  - instance of the delegate (event)
        // subscribe to this!
        // event EventHandler [what-happend?]
        // delegate void EventHandler(object sender, VideoEventArgs e);
        public event EventHandler<VideoEventArgs> VideoEncoded;



        // 2 - On[what-happend?]
        public void OnVideoEncoded(Video video)
        {
            //VideoEventArgs { Video = video } 
            // shortcut for:
            //VideoEventArgs v = new VideoEventArgs();
            //v.Video = video;

            if (VideoEncoded != null)
            {
                VideoEncoded.Invoke(this, new VideoEventArgs { Video = video });
            }
        }

        public void Encode(Video video)
        {
            Console.WriteLine("Starting to Encode video ...");

            // starting to encode
            Console.WriteLine("Encoding video ...");

            OnVideoEncoded(video);
        }
    }
}
