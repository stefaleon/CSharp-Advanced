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
            var path = @"c:/test/log1.txt";            

            try
            {
                using (var streamReader = new StreamReader(path))
                {
                    Console.WriteLine($"Displaying the contents of {path}");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine(streamReader.ReadToEnd());
                    Console.WriteLine("---------------------------------------------");
                } 
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured in {ex.Source}: {ex.Message}");
                Console.WriteLine($"Cannot find the specified stream: {path}");
            }
            finally
            {   
                Console.WriteLine("The streamReader disposal is taken care of by the 'using' statement. The 'finally' block is not required");
            }

        }




    }
}

