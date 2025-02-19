using Newtonsoft.Json;
using Slot3_LiskovSubstitutionPrincipleDemo.Model;

namespace Slot3_LiskovSubstitutionPrincipleDemo.Utilities
{
    internal class Utilities
    {
        static string ReadFile(string filename)
        {
            return File.ReadAllText(filename);
        }
        internal static List<Book> ReadData()
        {
            var cadJSON = ReadFile("Data/BookStore_01.json");
            return JsonConvert.DeserializeObject<List<Book>>(cadJSON);
        }
        internal static List<Book> ReadData(string extra)
        {
            List<Book> books = ReadData();
            var filename = "Data/BookStore_02.json";
            var cadJSON = ReadFile(filename);
            books.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJSON));
            if(extra == "topic")
            {
                filename = "Data/BookStore_03.json";
                cadJSON = ReadFile(filename);
                books.AddRange(JsonConvert.DeserializeObject<List<TopicBook>>(cadJSON));
            }
            return books;
        }
    }
}
