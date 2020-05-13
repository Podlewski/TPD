using System.Linq;
using System.Collections.Generic;
using System;

namespace Logic
{
    public static class Helper
    {
        public static void PrintData1(List<List<int>> data)
        {
            char symbol = 'A';

            foreach (List<int> row in data)
            {
                Console.Write(symbol);

                foreach (int value in row)
                    Console.Write("\t" + value);

                Console.WriteLine();
                symbol = (char)(symbol + 1);
            }

            Console.WriteLine();
        }

        public static void PrintData2(List<List<int>> matrix, List<int> rowIndexes = null,
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

        public static List<List<int>> MatrixToInteger(List<List<string>> matrix)
        {
            List<List<int>> intMatrix = new List<List<int>>();

            foreach (List<string> line in matrix)
            {
                List<int> tmpRow = new List<int>();

                foreach (string number in line)
                    tmpRow.Add(int.Parse(number));

                intMatrix.Add(tmpRow);
            }

            return intMatrix;
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

        public static bool IsMatrixNegative(ref List<List<int>> matrix,
            out int increasingValue)
        {
            int minValue = matrix.Select(x => x.Min()).ToList().Min();

            if (minValue < 0)
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    for (int j = 0; j < matrix[0].Count; j++)
                        matrix[i][j] += Math.Abs(minValue);
                }

                increasingValue = Math.Abs(minValue);
                return true;
            }
            else
            {
                increasingValue = 0;
                return false;
            }
        }

        public static void PrintOptimalRoutes(State state)
        {
            PrintRoute("", state.OptimalDuration, state);
        }

        private static void PrintRoute(string route, int duration, State state)
        {
            if(state.IsFinalState)
                Console.WriteLine(route + state.ID + " (" + duration + ")");

            else
            {
                foreach (var dec in state.OptimalDecisions)
                    PrintRoute(route + state.ID + " ", duration, dec.NextState);
            }
        }
    }
}
