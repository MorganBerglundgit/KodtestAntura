using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace KodtestAntura
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a filepath without file extension");
            var fileUrl = Console.ReadLine();
            var fileName = Path.GetFileNameWithoutExtension(fileUrl);
            var fileDirectory = fileUrl.TrimEnd(fileName.ToCharArray());
            try
            {
                var file = Directory.GetFiles(fileDirectory, $"{fileName}.*").FirstOrDefault();
                Console.WriteLine($"Filename occurrences {GetFileNameOccurrence(file).ToString()} in file {fileName}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int GetFileNameOccurrence(string file)
        {
            var occurrenceCounter = 0;
            var fileName = Path.GetFileNameWithoutExtension(file);

            using (var sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null) occurrenceCounter += Regex.Matches(line, fileName).Count;
            }

            return occurrenceCounter;
        }
    }
}