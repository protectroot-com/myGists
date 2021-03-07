using System;
using System.IO;
using System.Collections.Generic;
//source..https://stackoverflow.com/questions/1393178/unauthorizedaccessexception-cannot-resolve-directory-getfiles-failure
namespace whatever
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = GetAllAccessibleFiles(@"d:\"); //choose your drive letter and root directory
            for (int i=0;i<results.Count;i++)
            {
                Console.WriteLine(results[i]);
            }
        }
        
        public static List<string> GetAllAccessibleFiles(string rootPath, List<string> alreadyFound = null)
        {
            if (alreadyFound == null)
                alreadyFound = new List<string>();
            DirectoryInfo di = new DirectoryInfo(rootPath);
            var dirs = di.EnumerateDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                if (!((dir.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden))
                {
                    alreadyFound = GetAllAccessibleFiles(dir.FullName, alreadyFound);
                }
            }

            var files = Directory.GetFiles(rootPath);
            foreach (string s in files)
            {
                alreadyFound.Add(s);
            }
            return alreadyFound;
        }
    }
}
