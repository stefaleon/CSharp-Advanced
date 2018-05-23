using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            Console.WriteLine("-------------- all books ");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}, {book.Price}");
            }


            // LINQ Extension Methods

            var cheapBooks = books
                .Where(b => b.Price < 20)
                .OrderBy(b => b.Title);

            var cheapBooksStrings = books
                .Where(b => b.Price < 20)
                .OrderBy(b => b.Title)
                .Select(b => b.Title);

            Console.WriteLine("-------------- get books (objects) with LINQ Extension Methods");
            foreach (var book in cheapBooks)
            {
                Console.WriteLine($"{book.Title}, {book.Price}");
            }
            Console.WriteLine("-------------- get titles with LINQ Extension Methods");
            foreach (var book in cheapBooksStrings)
            {
                Console.WriteLine(book);
            }



            // LINQ Query Operators
            var cheapBooksWithQuery =
                from b in books
                where b.Price < 20
                orderby b.Title
                select b;

            Console.WriteLine("-------------- get books (objects) with LINQ Query Operators");
            foreach (var book in cheapBooksWithQuery)
            {
                Console.WriteLine($"{book.Title}, {book.Price}");
            }

            var theBook = new Book { Title = "I dont exist", Price = 0 };

            Console.WriteLine("-------------- Single");
            theBook = books.SingleOrDefault(b => b.Title == "Zoo");
            Console.WriteLine($"{theBook.Title}, {theBook.Price}");

            Console.WriteLine("-------------- SingleOrDefault");
            theBook = books.SingleOrDefault(b => b.Title == "zoo");
            Console.WriteLine(theBook ==  null);


            Console.WriteLine("-------------- First");
            theBook = books.FirstOrDefault(b => b.Price == 6.99m);
            Console.WriteLine($"{theBook.Title}, {theBook.Price}");

            var orderedBooks = books.OrderBy(b => b.Title);

            Console.WriteLine("-------------- First of ordered");
            theBook = orderedBooks.FirstOrDefault(b => b.Price == 6.99m);
            Console.WriteLine($"{theBook.Title}, {theBook.Price}");


            Console.WriteLine("-------------- FirstOrDefault");
            theBook = books.FirstOrDefault(b => b.Price == 123.99m);
            Console.WriteLine(theBook ==  null);


            Console.WriteLine("-------------- Skip, Take");
            var pagedBooks = books.Skip(3).Take(4);
            foreach (var book in pagedBooks)
            {
                Console.WriteLine($"{book.Title}, {book.Price}");
            }

            Console.WriteLine("-------------- Count");            
            Console.WriteLine($"there are {books.Count} books");

            Console.WriteLine("-------------- Sum");
            Console.WriteLine($"you need {books.Sum(b => b.Price)} dollars to buy all the books");


        }
    }
}
