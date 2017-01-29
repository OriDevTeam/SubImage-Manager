using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace SubImage_Manager.Scripts
{
    class ResourceManager
    {
        //////////////////////////////////////////////////////////////////
        ///// Constructor

        public static readonly ResourceManager Instance = new ResourceManager();
        static bool wokeUp = false;

        static List<ResourceFileInfo> resourceFiles = new List<ResourceFileInfo>();

        public void WakeUp()
        {
            if (!wokeUp)
            {
                wokeUp = true;
            }
        }

        //////////////////////////////////////////////////////////////////
        ///// List Operations

        private int IndexOfResource(string path)
        {
            for (int i = 0; i < resourceFiles.Count; i++)
            {
                if (resourceFiles[i].name == path)
                {
                    return i;
                }
            }

            return -1;
        }

        //////////////////////////////////////////////////////////////////
        ///// Resource Loading

        private void LoadFile(string filePath)
        {
            ResourceFileInfo resInfo = new ResourceFileInfo();
            resInfo.name = filePath;

            if (!File.Exists(filePath))
            {
                LogManager.Instance.MsgError("The file " + filePath + " does not exist.");
                resInfo.resource = null;
            }
            else
            {
                try 
                {
                    byte[] file = System.IO.File.ReadAllBytes(filePath);
                    resInfo.resource = file;
                }
                catch (Exception e)
                {
                    LogManager.Instance.Error("Cannot load resource file: " + filePath + "\nError: " + e.Message);
                    resInfo.resource = null;
                    throw;
                }
            }

            resourceFiles.Add(resInfo);
        }

        //////////////////////////////////////////////////////////////////
        ///// Resource Methods

        private object GetResource(string path, bool refresh)
        {
            if (IndexOfResource(path) == -1)
                LoadFile(path);

            if (refresh)
                LoadFile(path);

            int idx = IndexOfResource(path);

            if (idx == -1)
                return null;

            return resourceFiles[idx].resource;
        }
        private object GetResource(string path)
        {
            return GetResource(path, false);
        }

        public Image GetImage(string path)
        {
            Image img;
            try
            {
                img = (Bitmap)((new ImageConverter()).ConvertFrom(GetResource(path)));
            }
            catch (Exception e)
            {
                LogManager.Instance.Error("Cannot convert image: " + path + "\nError: " + e.Message);
                img = null;
                throw;
            }

            return img;
        }

        public bool GetTextFile(string path, out string rawText, bool refresh)
        {
            try
            {
                rawText = BytesToStringConverted((byte[])GetResource(path, refresh));
            }
            catch (Exception e)
            {
                LogManager.Instance.MsgError("Cannot convert text file: " + path + "\nError: " + e.Message);
                rawText = string.Empty;
                return false;
            }

            return true;
        }
        public bool GetTextFile(string path, out string rawText)
        {
            return GetTextFile(path, out rawText, false);
        }

        static string BytesToStringConverted(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }

    class VariableManager
    {
        //////////////////////////////////////////////////////////////////
        ///// Constructor

        public static readonly VariableManager Instance = new VariableManager();
        static bool wokeUp = false;

        static List<VariableInfo> variables = new List<VariableInfo>();

        public void WakeUp()
        {
            if (!wokeUp)
            {
                wokeUp = true;
            }
        }

        //////////////////////////////////////////////////////////////////
        ///// List Operations

        private int IndexOfResource(string name)
        {
            for (int i = 0; i < variables.Count; i++)
            {
                if (variables[i].name == name)
                {
                    return i;
                }
            }

            return -1;
        }

        public void SetVariable(string name, object varValueObject)
        {
            int idx = IndexOfResource(name);

            if (idx == -1)
                variables.Add(new VariableInfo(name, varValueObject));
            else
                variables[idx] = new VariableInfo(name, varValueObject);
        }

        //////////////////////////////////////////////////////////////////
        ///// Variable Methods

        private object GetResource(string name)
        {
            int idx = IndexOfResource(name);

            if (idx == -1)
                return null;

            return variables[idx].value;
        }

        public bool GetInt(string name, out int value)
        {
            object obj = GetResource(name);

            if(obj == null)
            {
                value = 0;
                return false;
            }

            value = (int)obj;
            return true;
        }
    }


    public struct ResourceFileInfo
    {
        public string name;
        public byte[] resource;
    }

    public struct VariableInfo
    {
        public string name;
        public object value;

        public VariableInfo(string varName, object varValue)
        {
            name = varName;
            value = varValue;
        }
    }
}
