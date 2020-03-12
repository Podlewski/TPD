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

        private static List<int> CorrectRemoved(List<int> removed)
        {
            List<int> correctedRemoved = new List<int>();

            for (int i = 0; i < removed.Count; i++)
            {
                correctedRemoved.Add(removed[i]);

                for (int j = 0; j < i; j++)
                {
                    if (removed[j] >= removed[i])
                        correctedRemoved[i] += 1;
                }
            }

            return correctedRemoved;
        }

        public static bool AreThereAnyDominatedStrategies(ref List<List<int>> matrix,
            out List<int> removedRows, out List<int> removedColumns)
        {
            bool dominatedStrategyWasRemoved = false;
            bool dominatedStrategyWasRemovedInLoop;

            removedRows = new List<int>();
            removedColumns = new List<int>();

            do
            {
                dominatedStrategyWasRemovedInLoop = false;

                List<int> dominatedRows = new List<int>();

                for (int i = 0; i < matrix.Count; i++)
                {
                    Dictionary<int, int> dominantItemsCounter = new Dictionary<int, int>();
                    HashSet<int> dominantStrategies = new HashSet<int>();

                    for (int k = 0; k < matrix[i].Count; k++)
                    {
                        for (int j = 0; j < matrix.Count; j++)
                        {
                            if (matrix[i][k] <= matrix[j][k])
                            {
                                dominantItemsCounter.TryGetValue(j, out int currentCount);
                                dominantItemsCounter[j] = currentCount + 1;

                                if (matrix[i][k] < matrix[j][k])
                                    dominantStrategies.Add(j);
                            }
                        }
                    }

                    for (int j = 0; j < matrix.Count; j++)
                    {
                        dominantItemsCounter.TryGetValue(j, out int currentCount);

                        if (currentCount == matrix[i].Count && dominantStrategies.Contains(j))
                            dominatedRows.Add(i);
                    }
                }

                for (int i = 0; i < matrix.Count; i++)
                {
                    if (dominatedRows.Contains(i))
                    {
                        removedRows.Add(i);
                        matrix.RemoveAt(i);
                        dominatedStrategyWasRemoved = true;
                        dominatedStrategyWasRemovedInLoop = true;
                    }
                }

                List<int> dominatedColumns = new List<int>();

                for (int k = 0; k < matrix[0].Count; k++)
                {
                    Dictionary<int, int> dominantItemsCounter = new Dictionary<int, int>();
                    HashSet<int> dominantStrategies = new HashSet<int>();

                    for (int i = 0; i < matrix.Count; i++)
                    {
                        for (int l = 0; l < matrix[0].Count; l++)
                        {
                            if (matrix[i][k] <= matrix[i][l])
                            {
                                dominantItemsCounter.TryGetValue(l, out int currentCount);
                                dominantItemsCounter[l] = currentCount + 1;

                                if (matrix[i][k] < matrix[i][l])
                                    dominantStrategies.Add(l);
                            }
                        }
                    }

                    for (int l = 0; l < matrix[0].Count; l++)
                    {
                        dominantItemsCounter.TryGetValue(l, out int currentCount);

                        if (currentCount == matrix.Count && dominantStrategies.Contains(l))
                            dominatedColumns.Add(l);
                    }
                }

                for (int k = 0; k < matrix[0].Count; k++)
                {
                    if (dominatedColumns.Contains(k))
                    {
                        removedColumns.Add(k);

                        for (int i = 0; i < matrix.Count; i++)
                            matrix[i].RemoveAt(k);

                        dominatedStrategyWasRemoved = true;
                        dominatedStrategyWasRemovedInLoop = true;
                    }
                }

            } while (dominatedStrategyWasRemovedInLoop);

            removedRows = CorrectRemoved(removedRows);
            removedColumns = CorrectRemoved(removedColumns);

            return dominatedStrategyWasRemoved;
        }

        public static int PlayerAStrategy(List<List<int>> matrix)
        {

            return 0;
        }
    }
}
