using System;
using System.Collections.Generic;

using static Helper.Helper;

namespace Task2
{
    public class Control
    {
        public static void Task2(List<List<int>> orginalMatrix)
        {
            Console.Clear();
            List<List<int>> matrix = DeepCopyMatrix(orginalMatrix);

            bool wereDominatedStrategiesRemoved = AreThereAnyDominatedStrategies(ref matrix,
                out List<int> removedRows, out List<int> removedColumns);

            List<int> rowIndexes = GetIndexes(orginalMatrix.Count, removedRows);
            List<int> columnIndexes = GetIndexes(orginalMatrix[0].Count, removedColumns);

            Console.WriteLine("Orginal matrix:");

            if (wereDominatedStrategiesRemoved)
            {
                PrintData(orginalMatrix);
                Console.WriteLine("Matrix after removing dominated strategies:");
            }

            PrintData(matrix, rowIndexes, columnIndexes);

            if (Logic.DoesTheMatrixHaveTheSaddlePoint(matrix, out int playerADecision, out int playerBDecision))
            {
                Console.WriteLine("Saddle point exists!\n");

                Console.WriteLine("Player A optimal decision: " + playerADecision);
                Console.WriteLine("Player B optimal decision: " + playerBDecision);
            }

            else
            {
                Console.WriteLine("Saddle point does not exists!\n");
                //Console.WriteLine("Removed dominated strategies: " + Helper.Helper.RemoveDominatedStrategies(ref matrix));
            }
        }

    }
}
