using System;
using System.Linq;

namespace ExtensionMethods
{
    //public class RichString : String 
    //{ }
    // produces error because String is a sealed class so we cannot inherit from it



    public static class StringExtensions
    //write our extension methods here
    {
        // first argument must be "this" + the type we are extending, String here
        // represents the current object that we are applying this method on
        public static string Shorten(this String str, int numberOfWords)
        {
            if (numberOfWords <= 0)
                throw new ArgumentOutOfRangeException("Invalid argument: numberOfWords cannot be a negative number.");

            if (numberOfWords == 0)
                return "";

            var words = str.Split(" ");

            if (words.Length < numberOfWords)
                return str;

            return $"{ string.Join(" ", words.Take(numberOfWords)) } ...";
        }

    }
}
