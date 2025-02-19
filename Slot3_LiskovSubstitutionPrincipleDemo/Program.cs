using Slot3_LiskovSubstitutionPrincipleDemo.Model;

namespace Slot3_LiskovSubstitutionPrincipleDemo
{
    internal class Program
    {
        static List<Book> bookList;
        static void PrintBooks(List<Book> books)
        {
            Console.WriteLine("List of Books");
            Console.WriteLine("------------------------");
            foreach(var item in books)
            {
                Console.WriteLine($"{item.Title.PadRight(39, ' ')} " +
                    $"{item.Author.PadRight(20, ' ')}{item.Price}");
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Please, press 'yes' to read an extra file, ");
            Console.WriteLine("'topic' to include topic books or any other key for a single file");
            var ans = Console.ReadLine();
            bookList = ((ans.ToLower() != "yes") && (ans != "topic")) ? Utilities.Utilities.ReadData() : Utilities.Utilities.ReadData(ans);
            PrintBooks(bookList);
        }
    }
}
