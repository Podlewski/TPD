﻿using System;
using System.Collections.Generic;
using System.IO;

namespace TUI
{
    class Program
    {
        private static int task = 0;
        private const int maxPosibbleTask = 5;

        private static string path;
        private static List<List<string>> matrix;
        private static List<int> roundRobinParamteres;

        static void ChooseTask()
        {
            if (maxPosibbleTask > 1)
            {
                string text = "Choose task to process, from 1 to " + maxPosibbleTask.ToString() + " (or press Enter to open last): ";
                string output;

                Console.Write(text);
                output = Console.ReadLine();

                if (output == "")
                    task = maxPosibbleTask;

                else
                    task = Int32.Parse(output);

            }
        }

        static void ChoosePath()
        {
            if (task != 5)
            {
                Console.Write("Enter file path (or press Enter to open default): ");
                path = Console.ReadLine();

                if (path == "")
                    path = "..//../..//Data//Task" + task + ".txt";

                matrix = new List<List<string>>();

                using (TextReader reader = File.OpenText(path))
                {
                    string wholeFile = reader.ReadToEnd();
                    string[] lines = wholeFile.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                    foreach (string line in lines)
                    {
                        List<string> tmpRow = new List<string>();
                        string[] numbers = line.Split(' ');

                        foreach (string number in numbers)
                            tmpRow.Add(number);

                        matrix.Add(tmpRow);
                    }
                }
            }
            else
            {
                roundRobinParamteres = new List<int>();

                Console.Write("Processes: ");
                roundRobinParamteres.Add(int.Parse(Console.ReadLine()));
                Queue<KeyValuePair<int, int>> processes =
                    new Queue<KeyValuePair<int, int>>();

                Console.Write("Quantum: ");
                roundRobinParamteres.Add(int.Parse(Console.ReadLine()));

                Console.Write("Min burst time: ");
                roundRobinParamteres.Add(int.Parse(Console.ReadLine()));

                Console.Write("Max burst time: ");
                roundRobinParamteres.Add(int.Parse(Console.ReadLine()));
            }
        }

        static void DoTask()
        {
            Console.Clear();

            switch (task)
            {
                case 1:
                    Logic.Controler.Task1(matrix);
                    break;

                case 2:
                    Logic.Controler.Task2(matrix);
                    break;

                case 3:
                    Logic.Controler.Task3(matrix);
                    break;

                case 4:
                    Logic.Controler.Task4(matrix);
                    break;

                case 5:
                    Logic.Controler.Task5(roundRobinParamteres);
                    break;
            }
        }

        static int GetStartingStep()
        {
            Console.WriteLine("\nWhat to do now?");
            Console.WriteLine("\t0) Choose task & data");
            Console.WriteLine("\t1) Choose data");
            Console.WriteLine("\t2) Run again with same data");
            Console.WriteLine("\t3) Close program");

            Console.Write("\nChoice: ");
            return int.Parse(Console.ReadLine());
        }

        static void Main()
        {
            // this should be done better i quess
            int startingStep = 0;

            do
            {
                Console.Clear();

                if (startingStep <= 0)
                    ChooseTask();

                if (startingStep <= 1)
                    ChoosePath();

                DoTask();
                startingStep = GetStartingStep();

            } while (startingStep <= 2);
        }
    }
}
