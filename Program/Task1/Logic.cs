using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public static class Logic
    {
        public static char SymbolFromIntCode(int number)
        {
            return (char)('A' + number);
        }

        #region Helpers

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

        public static List<List<int>> TransposeMatrix(List<List<int>> matrix)
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

        #endregion

        public static char Minimax(List<List<int>> data)
        {
            List<int> mins = new List<int>();

            foreach (List<int> row in data)
                mins.Add(row.Min());

            return SymbolFromIntCode(mins.IndexOf(mins.Max()));
        }

        public static char Maximin(List<List<int>> data)
        {
            List<int> maxes = new List<int>();

            foreach (List<int> row in data)
                maxes.Add(row.Max());

            return SymbolFromIntCode(maxes.IndexOf(maxes.Min()));
        }

        public static char Maximax(List<List<int>> data)
        {
            List<int> maxes = new List<int>();

            foreach (List<int> row in data)
                maxes.Add(row.Max());

            return SymbolFromIntCode(maxes.IndexOf(maxes.Max()));
        }

        public static char Hurwitz(List<List<int>> data, float factor)
        {
            List<float> hurwitzValues = new List<float>();

            foreach (List<int> row in data)
                hurwitzValues.Add((factor * row.Min()) + ((1 - factor) * row.Max()));

            return SymbolFromIntCode(hurwitzValues.IndexOf(hurwitzValues.Max()));
        }

        public static char BayesLaplace(List<List<int>> data, List<float> factors)
        {
            List<float> bayesLaplaceValues = new List<float>();

            foreach (List<int> row in data)
            {
                float bayesLaplaceValue = 0;

                for (int i = 0; i < row.Count; i++)
                    bayesLaplaceValue += factors[i] * row[i];

                bayesLaplaceValues.Add(bayesLaplaceValue);
            }

            return SymbolFromIntCode(bayesLaplaceValues.IndexOf(bayesLaplaceValues.Max()));
        }

        public static char Savage(List<List<int>> data)
        {
            data = OpportunityLossTable(data);

            List<int> maxes = new List<int>();

            foreach (List<int> row in data)
                maxes.Add(row.Max());

            return SymbolFromIntCode(maxes.IndexOf(maxes.Min()));
        }
    }
}
