using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SubImage_Manager.Scripts
{
    public class FileHandler
    {
        public static List<string> StringToList(string rawString)
        {
            List<string> styleLines = new List<string>();

            using (System.IO.StringReader reader = new System.IO.StringReader(rawString))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    styleLines.Add(line);
                }
            }

            return styleLines;
        }
    }
}