
//DAy5 ADv C#


using static day5.LibraryEngine;

namespace day5
{
    
    public delegate string mydel(Book b);

    
    public class Book
    {
    
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        

       
        public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate, decimal _Price)
        {
            ISBN = _ISBN;
            Title = _Title;
            Authors = _Authors;
            PublicationDate = _PublicationDate;
            Price = _Price;
        }

        
        public override string ToString()
        {
            return $"{Title} by {string.Join(", ", Authors)} ({PublicationDate}) - ${Price}";
        }

        

    }

    
    public class BookFunctions
    {
     
        public static string GetTitle(Book B)
        {
            return $"{B.Title}";
        }

     
        public static string GetAuthors(Book B)
        {
            return string.Join(',', B.Authors);
        }

        
        public static string GetPrice(Book B)
        {
            return $"{B.Price}";
        }
    }

   
    public class LibraryEngine
    {
   
        public static void ProcessBooks(List<Book> bList, mydel fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        // generic Func delegate
        public static void ProcessBooks(List<Book> bList, Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of books
            List<Book> list = new List<Book>() {
                new Book("1", "Book 1", new string[] {"hagar", "hwary"}, DateTime.Now ,2200),
                new Book("2", "Book 2", new string[] {"sohila", "essam"}, DateTime.Now, 400)
             };

            // Create a custom delegate
            mydel del = new mydel(BookFunctions.GetTitle);
            LibraryEngine.ProcessBooks(list, del);

           
            del += BookFunctions.GetAuthors;
            LibraryEngine.ProcessBooks(list, del);

            del += BookFunctions.GetPrice;
            LibraryEngine.ProcessBooks(list, del);

            // Use a generic Func delegate
            Func<Book, string> del2 = BookFunctions.GetTitle;
            LibraryEngine.ProcessBooks(list, del2);
            del2 += BookFunctions.GetAuthors;
            LibraryEngine.ProcessBooks(list, del2);

            
            Console.WriteLine("----------------------------------------");

            // Use a delegate with an anonymous method 
            Func<Book, string> del3 = delegate (Book b) { return b.ToString(); };
            LibraryEngine.ProcessBooks(list, del3);

            //  lambda expression 
            Book b = new Book("123", "Book 1", new string[] { "hagar", "sohila" }, DateTime.Now, 2200);
            Func<Book, string> del4 = b => { return $"{b.Price}"; };
            LibraryEngine.ProcessBooks(list, del4);
        }
    }
}
