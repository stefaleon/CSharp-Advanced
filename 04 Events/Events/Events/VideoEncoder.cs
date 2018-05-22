using System;
using System.Threading;

namespace Events
{
    public class VideoEncoder
    {
        public event EventHandler<VideoEventArgs> VideoEncoded;
        public void Encode(Video video)
        {
            Console.WriteLine($"Encoding {video.Title}... (wait 2 secs)");

            // simulating the video encoding process with a 2sec delay...
            Thread.Sleep(2000);
            
            // video has been encoded, time to publish the VideoEncoded event
            // by calling the OnVideoEncoded publisher method
            // which will be called from the various event subscribers
            OnVideoEncoded(video);
        }
                
        protected virtual void OnVideoEncoded(Video video)
        // The virtual definition is provided here
        // overrides will be implemented in the subscribers (such as EmailService, TextMessageService ...)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() { Video = video });
        }

    }
}
