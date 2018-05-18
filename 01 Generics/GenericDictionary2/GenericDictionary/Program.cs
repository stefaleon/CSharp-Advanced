using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var book1 = new Book { Isbn = "", Title = "Brave New World", Author = "Aldous Huxley" };

            var dictionary0 = new GenericDictionary<int, string>();
            dictionary0.AddItem(98, "This is value98 in dictionary0.");
            Console.WriteLine(dictionary0.GetTheValueForKey(98));

            Console.WriteLine();
            var dictionary1 = new GenericDictionary<int, Book>();            
            dictionary1.AddItem(1001, book1);
            dictionary1.AddItem(1002, new Book { Title = "Demons", Author = "Fyodor Dostoevsky" });
            Console.WriteLine(dictionary1.GetTheValueForKey(1001).Title);
            Console.WriteLine(dictionary1.GetTheValueForKey(1002).Title);
            dictionary1.AddItem(1001, new Book { Title = "Hep!" });
            Console.WriteLine(dictionary1.GetTheValueForKey(1001).Title);

            Console.WriteLine();
            //var dictionary2 = new GenericDictionary<string, Book>();            
            //dictionary2.AddItem("abcd1234", book1);
            //dictionary2.AddItem("some other string here", new Book { Title = "Some New Book" });
            //Console.WriteLine(dictionary2.GetTheValueForKey("abcd1234").Author);
            //Console.WriteLine(dictionary2.GetTheValueForKey("some other string here").Title);

            //Console.WriteLine();
            //var dictionary3 = new GenericDictionary<Book, string>();
            //dictionary3.AddItem(book1, "this is weird");
            //Console.WriteLine(dictionary3.GetTheValueForKey(book1));
            //Console.WriteLine(dictionary3.FindTheFirstKeyWithValue("this is weird").Title);

            //Console.WriteLine();
        }


       

            
    }
}
