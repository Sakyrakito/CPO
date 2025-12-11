using System;
using System.IO;
using System.Xml.Serialization;

namespace TrainBuilderApp
{
    public static class SaveToFileXML
    {
        public static void SaveToFile(Train train, string filePath)
        {
            var serializer = new XmlSerializer(typeof(Train));
            using var fs = new FileStream(filePath, FileMode.Create);
            serializer.Serialize(fs, train);
        }

        public static Train LoadFromFile(string filePath)
        {
            var serializer = new XmlSerializer(typeof(Train));
            using var fs = new FileStream(filePath, FileMode.Open);
            return (Train)serializer.Deserialize(fs);
        }
    }
}
