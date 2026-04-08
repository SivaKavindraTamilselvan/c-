using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string csv_file = "Mall_Customers.csv";
        string output_file = "output.txt";

        try
        {
            string[] lines = File.ReadAllLines(csv_file);
            int line = lines.Length;
            int word = 0;
            foreach (string l in lines)
            {
                string[] words = l.Split(',');
                word += words.Length;
            }
            Console.WriteLine(line);
            Console.WriteLine(word);
            foreach (string l in lines)
            {
                Console.WriteLine(l);
            }
            File.WriteAllLines(output_file, lines);
            File.AppendAllText(output_file, $"Total Words {word}");
            File.AppendAllText(output_file, $"Total Lines {line}");
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File Not Found");
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }

    }
}