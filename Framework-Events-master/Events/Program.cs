using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
       
        static void Main(string[] args)
        {

            VideoEncoder encode = new VideoEncoder();
            Video video = new Video("My cool video");

            // 4 registrating the method to the Publisher
            encode.VideoEncoded += VideoEncodedEventHandler;

            encode.Encode(video);

        }
        public static void AfterVideoEncoded(Video video)
        {
            Console.WriteLine($"my delegate -- {video} was encoded! yeah!");
        }

        // 3 void [what-happend]-EventHandler (object sender, EventArgs e)
        public static void VideoEncodedEventHandler(object sender, VideoEventArgs e)
        {
            Console.WriteLine(sender);
            Console.WriteLine($"MAIN -------- Video was encoded!!!! {e.Video}");
        }
    }
}
