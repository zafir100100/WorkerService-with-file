using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WorkerService.Models;

namespace WorkerService.Repositories
{
    class FileRepository
    {
        public Root? ReadFile()
        {
            FileInfo file = new("ServerWorkerConfig.json");
            if (!file.Exists)
            {
                return null;
            }
            string Json =  System.IO.File.ReadAllText("ServerWorkerConfig.json");
            Root? root = JsonSerializer.Deserialize<Root>(Json);
            return root;
        }

        public void WriteFile(List<string> text, string path)
        {
            FileInfo file = new(path);
            if (!file.Exists)
            {
                return;
            }
            StreamWriter writer = file.CreateText();
            foreach (string line in text)
            {
                writer.WriteLine(line);
            }
            writer.Flush();
            writer.Close();
            writer.Dispose();
        }

        public static bool IsFileReady(string filename)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by another process.
            try
            {
                using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                    return inputStream.Length > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
