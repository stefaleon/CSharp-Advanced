using System;

namespace Events
{
    partial class Program
    {
        public class EmailService
        {
            public void OnVideoEncoded(object source, VideoEventArgs args)
            {
                Console.WriteLine($"EmailService: Sending an email about {args.Video.Title}...");
            }
        }
    }
}
