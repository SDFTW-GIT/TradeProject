using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TradeProject.Utilites
{
    public class FileOperations
    {
        //Read a CSV File
        public static string ReadFile(string path)
        {
            string content = null;

            try
            {
                using (StreamReader streamReader = new(path))
                {
                    string line = string.Empty;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        content += line;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }

            return content;
        }

        public static int GetLines(string path)
        {
            int lines = 0;

            try
            {
                using (StreamReader streamReader = new(path))
                {
                    string line = string.Empty;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        lines++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }

            return lines;
        }

        //Write to CSV File
        public static void WriteFile(string path, string[] content)
        {
            using (StreamWriter streamWriter = new(path))
            {
                foreach (string line in content)
                {
                    streamWriter.WriteLine(line);
                }
            }
        }

        public static void AddToFile(string path, string content)
        {
            WriteFile(path, (new string[] {ReadFile(path), content}));
        }
    }
}
