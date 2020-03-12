using System.Linq;
using System.Collections.Generic;
using System;

namespace Task2
{
    public static class Logic
    {
        public static bool DoesTheMatrixHaveTheSaddlePoint(List<List<int>> matrix,
            out int playerADecision, out int playerBDecision)
        {
            List<int> rowMins = new List<int>();
            List<int> rowIndexes = new List<int>();

            foreach (List<int> row in matrix)
            {
                rowMins.Add(row.Min());
                rowIndexes.Add(row.IndexOf(row.Min()));
            }

            int playerARow = rowMins.IndexOf(rowMins.Max());
            int playerAColumn = rowIndexes[playerARow];


            List<int> columnMaxes = new List<int>();
            List<int> columnIndexes = new List<int>();

            foreach (List<int> column in Helper.Helper.TransposeMatrix(matrix))
            {
                columnMaxes.Add(column.Max());
                columnIndexes.Add(column.IndexOf(column.Max()));
            }

            int playerBColumn = columnMaxes.IndexOf(columnMaxes.Min());
            int playerBRow = columnIndexes[playerBColumn];


            playerADecision = playerARow + 1;
            playerBDecision = playerBColumn + 1;

            if (playerARow == playerBRow && playerAColumn == playerBColumn)
                return true;

            return false;
        }

        public static int MatrixConst(ref List<List<int>> matrix)
        {
            int minValue = matrix.Select(x => x.Min()).ToList().Min();

            if (minValue < 0)
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    for (int j = 0; j < matrix[0].Count; j++)
                        matrix[i][j] += Math.Abs(minValue);
                }

                return Math.Abs(minValue);
            }
            else
                return 0;
        }



        public static int PlayerAStrategy(List<List<int>> matrix)
        {

            return 0;
        }
    }
}
