using System;
using System.Collections.Generic;

using static Helper.Helper;
using static Task2.Logic;

namespace Task2
{
    public class Control
    {
        public static void Task2(List<List<int>> orginalMatrix)
        {
            Console.Clear();
            List<List<int>> matrix = DeepCopyMatrix(orginalMatrix);

            Console.WriteLine("Orginal matrix:");

            if (AreThereAnyDominatedStrategies(ref matrix,
                out List<int> removedRows, out List<int> removedColumns))
            {
                PrintData(orginalMatrix);
                Console.WriteLine("Matrix after removing dominated strategies:");
            }

            List<int> rowIndexes = GetIndexes(orginalMatrix.Count, removedRows);
            List<int> columnIndexes = GetIndexes(orginalMatrix[0].Count, removedColumns);
            PrintData(matrix, rowIndexes, columnIndexes);

            if (IsMatrixNegative(ref matrix, out int increasingValue))
            {
                Console.WriteLine("After making matrix nonnegative:");
                PrintData(matrix, rowIndexes, columnIndexes);
            }

            if (DoesTheMatrixHaveTheSaddlePoint(matrix, out int playerADecision, out int playerBDecision))
            {
                Console.WriteLine("Saddle point exists!\n");

                Console.WriteLine("Player A optimal decision: " + playerADecision);
                Console.WriteLine("Player B optimal decision: " + playerBDecision);
            }

            else
            {
                Console.WriteLine("Saddle point does not exists!\n");
                

            }
        }

    }
}
