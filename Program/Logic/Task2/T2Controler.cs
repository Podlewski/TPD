using System;
using System.Collections.Generic;

using static Logic.Helper;
using static Logic.Logic;

namespace Logic
{
    public partial class Controler
    {
        public static void Task2(List<List<string>> stringMatrix)
        {
            Console.Clear();
            List<List<int>> orginalMatrix = MatrixToInteger(stringMatrix);
            List<List<int>> matrix = DeepCopyMatrix(orginalMatrix);

            Console.WriteLine("Orginal matrix:");

            if (AreThereAnyDominatedStrategies(ref matrix,
                out List<int> removedRows, out List<int> removedColumns))
            {
                PrintData2(orginalMatrix);
                Console.WriteLine("Matrix after removing dominated strategies:");
            }

            List<int> rowIndexes = GetIndexes(orginalMatrix.Count, removedRows);
            List<int> columnIndexes = GetIndexes(orginalMatrix[0].Count, removedColumns);
            PrintData2(matrix, rowIndexes, columnIndexes);

            if (DoesTheMatrixHaveTheSaddlePoint(matrix, out int playerADecision, out int playerBDecision))
            {
                Console.WriteLine("Saddle point exists!\n");

                Console.WriteLine("Player A optimal decision: " + playerADecision);
                Console.WriteLine("Player B optimal decision: " + playerBDecision);
            }

            else
            {
                Console.WriteLine("Saddle point does not exists!\n");

                Tuple<double, List<double>> playerAsolution = PlayerAStrategy(matrix);
                Tuple<double, List<double>> playerBsolution = PlayerBStrategy(matrix);

                if (Math.Abs(playerAsolution.Item1 - playerBsolution.Item1) < 0.0001)
                {
                    Console.WriteLine("Game value: " + playerAsolution.Item1);

                    Console.WriteLine("\nPlayer A strategy:");
                    for (int i = 0; i < playerAsolution.Item2.Count; i++)
                        Console.Write("A" + rowIndexes[i] + ": " + playerAsolution.Item2[i] + "\t\t");

                    Console.WriteLine("\n\nPlayer B strategy:");
                    for (int i = 0; i < playerBsolution.Item2.Count; i++)
                        Console.Write("B" + columnIndexes[i] + ": " + playerBsolution.Item2[i] + "\t\t");

                    Console.WriteLine();
                }

                else
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine("Player A game value: " + playerAsolution.Item1);
                    Console.WriteLine("Player B game value: " + playerBsolution.Item1);
                }
            }
        }

    }
}
