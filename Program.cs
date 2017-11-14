using System;
using System.IO;
namespace studentrecordscsv
{
    class Program
    {

        static string[] records = new string[5];
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Welcome to the student records");
                Console.WriteLine("Select an Option");
                Console.WriteLine("Press 1: To read a file");
                Console.WriteLine("Press 2: To retrive a student");
                Console.WriteLine("Press 3: To break the file");
                Console.WriteLine("Press 4: To Write to the file");
                Console.WriteLine("Enter your option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    Console.WriteLine("Enter a filename that you wish to see :");
                    var filename = Console.ReadLine();
                    Read(filename);
                }
                Console.ReadKey();
                if (option == 2)
                {
                    Console.Write("Enter the row your student is on :");
                    int retrieve = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("The student that you have chosen is :");
                    Console.WriteLine(records[retrieve]);
                    Console.ReadKey();
                }
                if (option == 3)
                {
                    break;
                }
                if (option == 4)
                {
                    Writing();
                }
            }
        }
        private static void Read(string filename)
        {
            using (
                StreamReader reader = new StreamReader(filename))
            {
                int i = 0;
                while (!reader.EndOfStream)
                {
                    records[i] = reader.ReadLine();
                    i++;
                }
            }
            foreach (var record in records)
            {
                Console.WriteLine(record.Replace(",","\t"));
            }
        }
        private static void Writing()
        {
            using (StreamWriter writer = new StreamWriter("outputFile.txt"))
            {
                foreach (var record in records)
                {
                    writer.WriteLine(record);
                }
                writer.Flush();
            }
        }
    }
}