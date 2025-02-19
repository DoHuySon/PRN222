using Slot3_OpenClosedPrincipleDemo.Model;

namespace Slot3_OpenClosedPrincipleDemo
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
            Console.WriteLine("Please, press 'yes' to read an extra file, ");
            Console.WriteLine("or any other key for a single file");
            var ans = Console.ReadLine();
            bookList = (ans.ToLower() != "yes") ? Utilities.Utilities.ReadData() : Utilities.Utilities.ReadDataExtra();
            PrintBooks(bookList);

        }
    }
}
