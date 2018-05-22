using System;

namespace Events
{
    partial class Program
    {
        public class TextMessageService
        {
            public void OnVideoEncoded(object source, VideoEventArgs args)
            {
                Console.WriteLine($"TextMessageService: Sending a text message about {args.Video.Title}...");
            }
        }
    }
}
