using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //int i = null; // ERROR
            //DateTime dateTime = null; // ERROR

            Nullable<DateTime> dateTime = null; // OK

            // short syntax
            DateTime? date = null;

            
            Console.WriteLine($"date.GetValueOrDefault(): {date.GetValueOrDefault()}");
            Console.WriteLine($"date.HasValue: {date.HasValue}");
            //Console.WriteLine($"date.Value: {date.Value}"); // throws exception

                        

            DateTime? date1 = new DateTime(2067, 5, 18);
            DateTime date2 = date1.GetValueOrDefault();
            DateTime? date3 = date2;

            Console.WriteLine($"date3: {date3}");

            DateTime? date4 = null;

            DateTime date5 = date4 ?? DateTime.Today;

            // it is actually a shortened version of
            //DateTime date5 = (date4 != null) ? date4.GetValueOrDefault() : DateTime.Today;

            Console.WriteLine($"date5: {date5}");


        }
    }
}
