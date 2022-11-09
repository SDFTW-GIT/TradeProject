﻿using System;
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
        public static string[] GetFileContentsArray(string path)
        {
            string[] content = new string[GetCount(path)];
            int count = 0;

            try
            {
                using (StreamReader streamReader = new(path))
                {
                    string line = string.Empty;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        content[count] = line;
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }

            return content;
        }

        public static string GetFileContents(string path)
        {
            string content = string.Empty;

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

        public static int GetCount(string path)
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

        public static string GetEntry(string path, int index)
        {
            int count = 0;
            int lines = GetCount(path);
            string entry = string.Empty;

            try
            {
                using (StreamReader streamReader = new(path))
                {
                    string line = string.Empty;

                    while ((line = streamReader.ReadLine()) != null && count < lines )
                    {
                        if (index == count)
                            entry = line;
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }

            return entry;
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
            string[] preContents = GetFileContentsArray(path);

            string[] newContents = new string[preContents.Length + 1];
            for(int i = 0; i < preContents.Length; i++)
            {
                newContents[i] = preContents[i];
            }
            newContents[newContents.Length - 1] = content;

            WriteFile(path, newContents);
        }
    }
}
