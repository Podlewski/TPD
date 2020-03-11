using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public static class Logic
    {
        #region Helpers

        public static char SymbolFromIntCode(int number)
        {
            return (char)('A' + number);
        }

        public static float HurwitzFactor()
        {
            float factor;

            Console.Write("Enter Hurwitz factor [0-1] (ex. \"0,2\"): ");
            factor = float.Parse(Console.ReadLine());

            while (factor < 0 || factor > 1)
            {
                Console.Write("Wrong number. Enter value from 0 to 1 (ex. \"0,2\"): ");
                factor = float.Parse(Console.ReadLine());
            }

            return factor;
        }

        public static List<float> BayesLaplaceFactors(int numberOfFactors)
        {
            List<float> factors = new List<float>();

            for (int i = 0; i < numberOfFactors; i++)
            {
                Console.Write("Enter " + (i + 1) + " Bayes-Laplace factor [0-1] (ex. \"0,2\"): ");
                float factor = float.Parse(Console.ReadLine());

                while (factor < 0 || factor > 1)
                {
                    Console.Write("Wrong number. Enter value from 0 to 1 (ex. \"0,2\"): ");
                    factor = float.Parse(Console.ReadLine());
                }

                factors.Add(factor);
            }

            return factors;
        }

        private static List<List<int>> TransposeMatrix(List<List<int>> matrix)
        {
            int rows = matrix[0].Count;
            int columns = matrix.Count;

            List<List<int>> transposedMatrix = new List<List<int>>();

            for (int i = 0; i < columns; i++)
            {
                List<int> tmpRow = new List<int>();

                for (int j = 0; j < rows; j++)
                {
                    tmpRow.Add(matrix[j][i]);
                }

                transposedMatrix.Add(tmpRow);
            }

            return transposedMatrix;
        }

        private static List<List<int>> OpportunityLossTable(List<List<int>> data)
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

        private static string StringResult(int foundValue, List<int> data)
        {
            string result = "";

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == foundValue)
                    result += SymbolFromIntCode(i) + ", ";
            }

            return result[0..^2];
        }

        private static string StringResult(float foundValue, List<float> data)
        {
            string result = "";

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == foundValue)
                    result += SymbolFromIntCode(i) + ", ";
            }

            return result[0..^2];
        }

        #endregion


        public static string Minimax(List<List<int>> data)
        {
            List<int> mins = new List<int>();

            foreach (List<int> row in data)
                mins.Add(row.Min());

            return StringResult(mins.Max(), mins);
        }

        public static string Maximin(List<List<int>> data)
        {
            List<int> maxes = new List<int>();

            foreach (List<int> row in data)
                maxes.Add(row.Max());

            return StringResult(maxes.Min(), maxes);
        }

        public static string Maximax(List<List<int>> data)
        {
            List<int> maxes = new List<int>();

            foreach (List<int> row in data)
                maxes.Add(row.Max());

            return StringResult(maxes.Max(), maxes);
        }

        public static string Hurwitz(List<List<int>> data, float factor)
        {
            List<float> hurwitzValues = new List<float>();

            foreach (List<int> row in data)
                hurwitzValues.Add((factor * row.Min()) + ((1 - factor) * row.Max()));

            return StringResult(hurwitzValues.Max(), hurwitzValues);
        }

        public static string BayesLaplace(List<List<int>> data, List<float> factors)
        {
            List<float> bayesLaplaceValues = new List<float>();

            foreach (List<int> row in data)
            {
                float bayesLaplaceValue = 0;

                for (int i = 0; i < row.Count; i++)
                    bayesLaplaceValue += factors[i] * row[i];

                bayesLaplaceValues.Add(bayesLaplaceValue);
            }

            return StringResult(bayesLaplaceValues.Max(), bayesLaplaceValues);
        }

        public static string Savage(List<List<int>> data)
        {
            data = OpportunityLossTable(data);

            List<int> maxes = new List<int>();

            foreach (List<int> row in data)
                maxes.Add(row.Max());

            return StringResult(maxes.Min(), maxes);
        }
    }
}
