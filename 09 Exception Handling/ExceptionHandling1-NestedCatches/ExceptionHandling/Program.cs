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
            //var calculator = new Calculator();
            //int result = calculator.Divide(10, 0); //throws DivideByZero Exception
            //Console.WriteLine(result);       

            var calculator = new Calculator();
            var path = @"c:/test/log.txt";

            try
            {
                var streamReader = new StreamReader(path);
                
                try
                {                    
                    Console.WriteLine($"Displaying the contents of {path}");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine(streamReader.ReadToEnd());
                    Console.WriteLine("---------------------------------------------");
                    
                    Console.WriteLine(calculator.Divide(10, 0));
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"A DivideByZeroException occured in {ex.Source}: {ex.Message}");
                }
                catch (ArithmeticException ex)
                {
                    Console.WriteLine($"An arithmetic exception occured in {ex.Source}: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An exception occured in {ex.Source}: {ex.Message}");
                    //throw;
                }
                finally
                {
                    Console.WriteLine("Code in 'Finally' is always executed. We can release allocated resources in here.");
                    streamReader.Dispose();
                }

            }
            catch (Exception)
            {
                Console.WriteLine($"Cannot find the specified stream: {path}");
                //throw;
            }


        }
    }
}
