using UnityEngine;
using System;

public class XMLWrite  
{  
    public class Book{  
        public String title;   
    }  
  
    public static void WriteXML(Book b, out string addressInsideDataPath){  
        System.Xml.Serialization.XmlSerializer writer =   
            new System.Xml.Serialization.XmlSerializer(typeof(Book));  
  
        var path = Application.dataPath + "/" + b.GetHashCode().ToString() + ".xml"; 
        addressInsideDataPath = path; 
        System.IO.FileStream file = System.IO.File.Create(path);  
  
        writer.Serialize(file, b);  
        file.Close();
    }  
}