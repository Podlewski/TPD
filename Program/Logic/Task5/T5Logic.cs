using System;
using System.Collections.Generic;

namespace Logic
{
    public static partial class Logic
    {
        public static int RoundRobin(Queue<KeyValuePair<int, int>> processes,
            int quantum)
        {
            int expropriations = 0;
            while (processes.Count != 0)
            {
                KeyValuePair<int, int> process = processes.Dequeue();

                Console.Write(process.Key);

                if (process.Value > quantum)
                {
                    expropriations++;
                    Console.Write('e');
                    processes.Enqueue(new KeyValuePair<int, int>(process.Key,
                        process.Value - quantum));
                }

                Console.Write(' ');
            }

            return expropriations;
        }
    }
}
