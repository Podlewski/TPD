using System.Linq;
using System.Collections.Generic;
using System;

namespace Helper
{
    public static class Helper
    {
        public static void PrintData(List<List<int>> matrix, List<int> rowIndexes = null,
            List<int> columnIndexes = null)
        {
            for (int i = 0; i < matrix[0].Count; i++)
            {
                if (columnIndexes == null)
                    Console.Write("\tB" + (i + 1));
                else
                    Console.Write("\tB" + columnIndexes[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < matrix.Count; i++)
            {
                if (rowIndexes == null)
                    Console.Write("A" + (i + 1));
                else
                    Console.Write("A" + rowIndexes[i]);

                for (int j = 0; j < matrix[0].Count; j++)
                    Console.Write("\t" + matrix[i][j]);

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static List<List<int>> DeepCopyMatrix(List<List<int>> matrix)
        {
            List<List<int>> copiedMatrix = new List<List<int>>();

            foreach (var row in matrix)
            {
                List<int> tmpRow = new List<int>();

                foreach (var item in row)
                    tmpRow.Add(item);

                copiedMatrix.Add(tmpRow);
            }

            return copiedMatrix;
        }

        public static List<List<int>> TransposeMatrix(List<List<int>> matrix)
        {
            int rows = matrix[0].Count;
            int columns = matrix.Count;

            List<List<int>> transposedMatrix = new List<List<int>>();

            for (int i = 0; i < rows; i++)
            {
                List<int> tmpRow = new List<int>();

                for (int j = 0; j < columns; j++)
                {
                    tmpRow.Add(matrix[j][i]);
                }

                transposedMatrix.Add(tmpRow);
            }

            return transposedMatrix;
        }

        public static List<List<int>> OpportunityLossTable(List<List<int>> data)
        {
            List<List<int>> opportunityLossTable = new List<List<int>>();
            List<int> maxValues = new List<int>();

            foreach (List<int> column in TransposeMatrix(data))
                maxValues.Add(column.Max());

            foreach (List<int> row in data)
            {
                List<int> opportunityLossRow = new List<int>();

                for (int i = 0; i < row.Count; i++)
                    opportunityLossRow.Add(maxValues[i] - row[i]);

                opportunityLossTable.Add(opportunityLossRow);
            }

            return opportunityLossTable;
        }

        public static List<int>GetIndexes(int listCount, List<int> removed = null)
        {
            List<int> result = new List<int>();

            if(removed == null)
            {
                for (int i = 0; i < listCount; i++)
                    result.Add(i + 1);
            }

            else
            {
                for (int i = 0; i < listCount; i++)
                {
                    if(!removed.Contains(i))
                        result.Add(i + 1);
                }
                    
            }

            return result;
        }

        private static List<int> CorrectRemoved(List<int> removed)
        {
            List<int> correctedRemoved = new List<int>();

            for(int i = 0; i < removed.Count; i++)
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
    }
}
