using System;
using System.Collections.Generic;
using System.Text;

using static Logic.Helper;

namespace Logic
{
    public partial class Controler
    {
        public static void Task1(List<List<string>> stringMatrix)
        {
            Console.Clear();
            List<List<int>> matrix = MatrixToInteger(stringMatrix);

            Console.WriteLine("Choose decision criteria: ");
            Console.WriteLine("\t0) Everything");
            Console.WriteLine("\t1) Minimax Criterion");
            Console.WriteLine("\t2) Wald (Maximin) Criterion");
            Console.WriteLine("\t3) Optimistic (Maximax) Criterion");
            Console.WriteLine("\t4) Hurwitz Criterion");
            Console.WriteLine("\t5) Bayes-Laplace Criterion");
            Console.WriteLine("\t6) Savage Criterion");

            Console.Write("\nChoice: ");

            int choice = Int32.Parse(Console.ReadLine());

            Console.Clear();
            PrintData1(matrix);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Minimax Criterion: " + Logic.Minimax(matrix));
                    break;

                case 2:
                    Console.WriteLine("Wald (Maximin) Criterion: " + Logic.Maximin(matrix));
                    break;

                case 3:
                    Console.WriteLine("Maximax (Optimistic) Criterion: " + Logic.Maximax(matrix));
                    break;

                case 4:
                    Console.WriteLine("Hurwitz Criterion: " +
                        Logic.Hurwitz(matrix, Logic.HurwitzFactor()));
                    break;

                case 5:
                    Console.WriteLine("Bayes-Laplace Criterion: " +
                        Logic.BayesLaplace(matrix, Logic.BayesLaplaceFactors(matrix[0].Count)));
                    break;

                case 6:
                    Console.WriteLine("Savage Criterion: " + Logic.Savage(matrix));
                    break;

                default:
                    float hurwitzFactor = Logic.HurwitzFactor();
                    List<float> bayesLaplaceFactors = Logic.BayesLaplaceFactors(matrix[0].Count);

                    Console.WriteLine();

                    Console.WriteLine("Minimax Criterion: \t\t" + Logic.Minimax(matrix));
                    Console.WriteLine("Wald (Maximin) Criterion: \t" + Logic.Maximin(matrix));
                    Console.WriteLine("Maximax (Optimistic) Criterion: " + Logic.Maximax(matrix));
                    Console.WriteLine("Hurwitz Criterion: \t\t" + Logic.Hurwitz(matrix, hurwitzFactor));
                    Console.WriteLine("Bayes-Laplace Criterion: \t" +
                        Logic.BayesLaplace(matrix, bayesLaplaceFactors));
                    Console.WriteLine("Savage Criterion: \t\t" + Logic.Savage(matrix));
                    break;
            }


        }
    }
}
