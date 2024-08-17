using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Questions_16
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo info = new DirectoryInfo(".");
            DirectoryInfo currentdirectory = new DirectoryInfo(@"D:\WIRELESS COMMUNICATION");
            FileInfo[] files = currentdirectory.GetFiles("*");

            //Return the number of text files in the directory (*.txt).
            Console.WriteLine("Return the number of text files in the directory (*.txt). \n");
            FileInfo[] textFile = currentdirectory.GetFiles("*.txt");
            Console.WriteLine($"Text files in the directory having length {textFile.Length}");
            foreach(FileInfo file in textFile)
            {
                Console.WriteLine(file.Name);
                Console.WriteLine(file.Length);
            }
            
            Console.WriteLine(" \n Return the number of files per extension type.\n");
            // Return the number of files per extension type.
            Dictionary<string, int> fileDictionary = new Dictionary<string, int>();
            foreach(FileInfo file in files)
            {
                string[] arr = file.Name.Split('.');
                try
                {
                    fileDictionary[arr[1]] += 1;
                }
                catch (Exception )
                {
                    fileDictionary.Add(arr[1], 1);
                }
            }
            foreach(var index in fileDictionary)
            {
                Console.WriteLine($"Number of files per extension type: {index.Key} : {index.Value}");
            }
            Console.WriteLine("\nReturn the top 5 largest files, along with their file size (use anonymous types).\n");
            // Return the top 5 largest files, along with their file size (use anonymous types).
            var sizeOfArray = from a in files
                              orderby a.Length descending
                              select a;
            int j = 0;
            foreach(var file in sizeOfArray)
            {
                j++;
                if (j > 5)
                {
                    break;
                }
                Console.WriteLine($"File Name :{file.Name} \n\t File Size: {file.Length}");
            }
            Console.WriteLine("\n Return the file with maximum length.\n");
            // Return the file with maximum length.
            foreach(var file in sizeOfArray)
            {
                Console.WriteLine($"\t File: {file.Name} s with maximum length : {file.Length}");
                break;
            }
            Console.ReadLine();

        }
    }
}
