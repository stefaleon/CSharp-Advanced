using System.Collections.Generic;

namespace Linq
{
    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book() { Title = "Book1", Price = 15 },
                new Book() { Title = "Book2", Price = 23 },                
                new Book() { Title = "Zoo", Price = 6.99m },
                new Book() { Title = "CSharp for Pros", Price = 6.99m },
                new Book() { Title = "Book3", Price = 29.99m },
                new Book() { Title = "Antipope", Price = 6.99m },
                new Book() { Title = "Antilope", Price = 7.99m },
                new Book() { Title = "Book4", Price = 6.99m }
            };

        }
    }   
}
