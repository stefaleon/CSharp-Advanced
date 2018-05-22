namespace Events
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var video = new Video { Title = "Video1" };
            var videoEncoder = new VideoEncoder();  // this is the event publisher

            // event subscribers
            var emailService = new EmailService();
            var textMessageService = new TextMessageService();
            
            // Register the event handlers
            // this event will be handled by different overrides of the OnVideoEncoded method
            // provided by various subscriber objects (emailService and textMessageService here)
            videoEncoder.VideoEncoded += emailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += textMessageService.OnVideoEncoded;
            
            // eventually call the main app which contains the event publisher
            videoEncoder.Encode(video);
        }
    }
}
