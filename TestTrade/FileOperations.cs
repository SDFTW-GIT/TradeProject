using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTrade
{
    public class FileOperations
    {
        //Read a CSV File
        public static void ReadFile(string path)
        {
            try
            {
                using (StreamReader streamReader = new(path))
                {
                    string line = string.Empty;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Write to CSV File
        public static void WriteFile(string path, string[] content) 
        {
            using(StreamWriter streamWriter = new(path))
            {
                foreach (string line in content)
                {
                    streamWriter.WriteLine(line);
                }
            }
        }
    }
}
