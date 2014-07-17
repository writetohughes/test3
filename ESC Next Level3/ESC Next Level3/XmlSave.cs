using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace ESC_Next_Level3
{
    public class XmlSave
    {
        // SaveData method
        public static void SaveData(object Iclass, string filename)
        {
            StreamWriter writer = null;
            
           try {
                XmlSerializer Xmlserializer = new XmlSerializer(Iclass.GetType());
               // using streamwriter to write the file
                writer = new StreamWriter(filename);
                Xmlserializer.Serialize(writer,Iclass);
            }
            finally {

                if (writer != null)
                    writer.Close();
                writer = null;
            }
        
        }
        
    }
    public class XmlLoad<T>
    {
        public static Type type;
        // constructor
        public XmlLoad()
        { 
           type=typeof(T);

        }
        // Load Data method
        public T LoadData(string filename)
        {
            T result;

            XmlSerializer xmlserializer = new XmlSerializer(type);
            //using filestream to open,read and close the file
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            result = (T)xmlserializer.Deserialize(fs);
            fs.Close();
            return result;
        
        }
    
    
    }
}
