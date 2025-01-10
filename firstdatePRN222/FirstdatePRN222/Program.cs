using System.Net;

namespace FirstdatePRN222
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Uri info = new Uri("https://www.youtube.com/watch?v=FT4tLpLgJuY");
            //Uri page = new Uri("https://www.facebook.com/stories/134935354871680/UzpfSVNDOjEzMjA3MTE0MTU3ODQ5OTA=/?bucket_count=9&source=story_tray");
            //Console.WriteLine($"Host: {info.Host}");
            //Console.WriteLine($"Host: {info.Port}");
            //Console.WriteLine($"PathAndQuery: {info.PathAndQuery}");
            //Console.WriteLine($"Query: {info.Query}");
            //Console.WriteLine($"Fragment: {info.Fragment}");
            //Console.WriteLine($"Default HTTP port: {page.Port}");
            //Console.WriteLine($"IsBaseOf: {info.IsBaseOf(page)}");
            //Uri relative = info.MakeRelativeUri( page );
            //Console.WriteLine($"IsAbsoluteUri: {relative.IsAbsoluteUri}");
            //Console.WriteLine($"RelativeUri: {relative.ToString()}");
            //Console.ReadLine();


            WebRequest request = WebRequest.Create("https://www.facebook.com/Gaixinhpagekhongthieu");
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine("Status: " + response.StatusDescription);
            Console.WriteLine(new String('*', 50));
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            Console.WriteLine(new String('*', 50));
            reader.Close();
            stream.Close();
            response.Close();
        }
    }
}
