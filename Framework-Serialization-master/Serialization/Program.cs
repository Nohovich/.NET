using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {

            // creating person
            Person p1 = new Person("Dannaa", "Shovevany");

            // creating XmlSerializer and passing the type we want to serialize
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Person));

            // opening the connection for us to serialize
            using (Stream file = new FileStream(@"C:\Projects\C#\framework\Serialization\xmlfile.xml", FileMode.Append)) // creating new file stream if needed
            {
                // uploading to file
                myXmlSerializer.Serialize(file, p1);

            } //closing file stream

            // opening the connection for us to deserialize
            using (Stream file = new FileStream(@"C:\Projects\C#\framework\Serialization\xmlfile.xml", FileMode.Append)) // creating new file stream
            {
                // downloading to file
                Person p2 = myXmlSerializer.Deserialize(file) as Person;

            } //closing file stream

            Console.WriteLine();
        }
    }
}
