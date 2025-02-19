namespace Slot3_ServiceCollectionClassDemo.Model
{
    public class XMLWriter : IXMLWriter
    {
        public void WriteXML()
        {
            Console.WriteLine("<message>Writting in XML Format</message>");
        }
    }
    public class JSONWriter : IJSONWriter
    {
        public void WriteJSON()
        {
            Console.WriteLine("{'message' : 'Writting in JSON Format'}");
        }
    }
}
