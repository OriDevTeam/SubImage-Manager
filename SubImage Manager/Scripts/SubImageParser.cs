using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SubImage_Manager.Scripts
{
    class SubImageParser
    {
        public static bool ReadSubImageFile(string filePath, out SubImage subImage)
        {
            subImage = new SubImage(filePath);

            string rawTextFile;
            if (!ResourceManager.Instance.GetTextFile(filePath, out rawTextFile, true))
                return false;

            List<string> textFile = FileHandler.StringToList(rawTextFile);

            for (int i = 0; i < textFile.Count; i++)
            {
                SubImageProperty subImageProperty;
                if (!ParseConfigLine(i, textFile[i], out subImageProperty))
                    continue;

                subImage.properties.Add(subImageProperty);
            }

            return true;
        }

        static bool ParseConfigLine(int idx, string rawConfigLine, out SubImageProperty subImageProperty)
        {
            subImageProperty = new SubImageProperty();

            if (string.IsNullOrWhiteSpace(rawConfigLine))
                return false;

            int count = 0;
            foreach (char c in rawConfigLine)
                if (c == ' ') count++;

            if (count < 1)
            {
                LogManager.Instance.MsgError("Cannot parse config at line " + idx + " : " + rawConfigLine);
                return false;
            }

            if (count > 1)
            {
                for (int i = count; i > 1; i--)
                {
                    rawConfigLine = rawConfigLine.Remove(rawConfigLine.IndexOf(' '), 1);
                }
            }

            string[] propertyLine = rawConfigLine.Split(' ');

            subImageProperty = new SubImageProperty(propertyLine[0], propertyLine[1]);

            return true;
        }
    }

    public struct SubImage
    {
        public string name;
        public string path;
        public List<SubImageProperty> properties;

        public SubImage(string pathName)
        {
            path = pathName;
            name = Path.GetFileName(pathName);
            properties = new List<SubImageProperty>();
        }

    }

    public struct SubImageProperty
    {
        public string name;
        public object value;

        public SubImageProperty(string varName, object varValue)
        {
            name = varName;
            value = varValue;
        }
    }
}
