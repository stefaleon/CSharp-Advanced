using System;
using System.Collections.Generic;

namespace ExceptionHandling
{
    public class FetchVideoApi
    {
        public List<Video> GetVideos(string user)
        {
            try
            {   //access web service
                //read data
                //create list of Video objects
                throw new Exception("Some low level error occured.");
            }
            catch (Exception ex)
            {
                
                throw new FetchVideoApiException("Cannot fetch the videos.", ex);
            }

            return new List<Video>();
        }
    }
}
