using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {   
            var path = @"c:/test/log.txt";
            StreamReader streamReader = null;

            try
            {
                streamReader = new StreamReader(path);
                Console.WriteLine($"Displaying the contents of {path}");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine(streamReader.ReadToEnd());
                Console.WriteLine("---------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured in {ex.Source}: {ex.Message}");
                Console.WriteLine($"Cannot find the specified stream: {path}");
            }
            finally
            {                
                if (streamReader != null)
                {
                    Console.WriteLine("Disposing streamReader...");
                    streamReader.Dispose();
                }
                else
                {
                    Console.WriteLine("streamReader was null");
                }
                Console.WriteLine("Exiting the 'finally' block...");
            }

        }




    }
}

