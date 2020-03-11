using System;
using System.Collections.Generic;
using System.IO;

namespace TUI
{
    class Program
    {
        private static int task = 1;
        private const int posibbleTask = 1;

        private static string path;

        static void ChooseTask()
        {
            if(posibbleTask > 1)
            {
                string text = "Choose task to process (from 1 to " + posibbleTask.ToString() + "): ";

                Console.Write(text);
                task = Int32.Parse(Console.ReadLine());

                while (task > 0 && task < posibbleTask)
                {
                    Console.Write("Incorrect number! ");
                    Console.Write(text);
                    task = Int32.Parse(Console.ReadLine());
                }
            }
        }

        static void Main(string[] args)
        {
            ChooseTask();

            Console.Write("Enter file path (or press Enter to open default): ");
            path = Console.ReadLine();

            if (path == "")
                path = "..//../..//..//Data//Task" + task + ".txt";

            List<List<int>> data = new List<List<int>>();

            using (TextReader reader = File.OpenText(path))
            {
                string wholeFile = reader.ReadToEnd();
                string[] lines = wholeFile.Split(new[] {"\r\n", "\r", "\n" }, StringSplitOptions.None);

                foreach(string line in lines)
                {
                    List<int> tmpRow = new List<int>();
                    string[] numbers = line.Split(' ');

                    foreach (string number in numbers)
                        tmpRow.Add(int.Parse(number));

                    data.Add(tmpRow);
                }
            }

            string again;

            do
            {
                Console.Clear();

                switch (task)
                {
                    case 1:
                        Task1.Control.Task1(data);
                        break;
                }

                Console.Write("\nRun again with same data (Y/N)? ");
                again = Console.ReadLine();

            } while (again == "Y" || again == "y" || again == "Yes" || again == "yes" || again == "YES");


        }
    }
}
