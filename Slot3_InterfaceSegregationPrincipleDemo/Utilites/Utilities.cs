    using Newtonsoft.Json;
using Slot3_InterfaceSegregationPrincipleDemo.Model;

namespace Slot3_InterfaceSegregationPrincipleDemo.Utilites
{
    internal class Utilities
    {
        internal static string ReadFile(string filename)
        {
            return File.ReadAllText(filename);
        }
        internal static List<Video> ReadData(string fileId)
        {
            var filename = "Data/Bookstore" + fileId + ".json";
            var cadJSON = ReadFile(filename);
            return JsonConvert.DeserializeObject<List<Video>>(cadJSON);
        }
    }
}
