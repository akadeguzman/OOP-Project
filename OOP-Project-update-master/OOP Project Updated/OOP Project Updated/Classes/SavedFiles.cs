using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace OOP_Project_Updated.Classes
{
    class SavedFiles
    {
        public static void savedData(object obj, string filename)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);

            sr.Serialize(writer, obj);
            writer.Close();
        }
    }
}
