using System;
using System.Collections.Generic;
using System.IO;

namespace TellerAPI.Services
{
    public class FileService
    {
        private readonly string _dataPath;

        public FileService()
        {
            _dataPath = Path.Combine(AppContext.BaseDirectory, "Data");
            if (!Directory.Exists(_dataPath))
                Directory.CreateDirectory(_dataPath);
        }

        public List<string> ReadFile(string fileName)
        {
            string path = Path.Combine(_dataPath, fileName);
            if (!File.Exists(path)) return new List<string>();
            return new List<string>(File.ReadAllLines(path));
        }

        public void WriteFile(string fileName, List<string> lines)
        {
            try
            {
                string path = Path.Combine(_dataPath, fileName);
                File.WriteAllLines(path, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file {fileName}: {ex.Message}");
            }
        }

        public void AppendLine(string fileName, string line)
        {
            try
            {
                string path = Path.Combine(_dataPath, fileName);
                File.AppendAllText(path, line + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error appending to file {fileName}: {ex.Message}");
            }
        }
    }
}