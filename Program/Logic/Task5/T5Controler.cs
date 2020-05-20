using System;
using System.Collections.Generic;

using static Logic.Logic;

namespace Logic
{
    public partial class Controler
    {
        public static void Task5(List<int> roundRobinParamteres)
        {
            int processesCount = roundRobinParamteres[0];
            int quantum = roundRobinParamteres[1];
            int minBurstTime = roundRobinParamteres[2];
            int maxBurstTime = roundRobinParamteres[3];
            Queue<KeyValuePair<int, int>> processes =
                new Queue<KeyValuePair<int, int>>();

            Console.WriteLine("Processes: " + processesCount);
            Console.WriteLine("Quantum: " + quantum);
            Console.WriteLine("Min burst time: " + minBurstTime);
            Console.WriteLine("Max burst time: " + maxBurstTime);

            Console.WriteLine("\nProcesses:");
            Random random = new Random();
            for (int i = 0; i < processesCount; i++)
            {
                KeyValuePair<int, int> process = new KeyValuePair<int, int>
                    (i + 1, random.Next(minBurstTime, maxBurstTime + 1));
                Console.WriteLine(process.Key + " " + process.Value);
                processes.Enqueue(process);
            }

            Console.WriteLine("\nRound robin:");
            int expropriations = RoundRobin(processes, quantum);

            Console.WriteLine("\nExpropriations: " + expropriations);
        }
    }
}
