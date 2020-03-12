using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Control
    {
        public static void PrintData(List<List<int>> data)
        {
            char symbol = 'A';

            foreach(List<int> row in data)
            {
                Console.Write(symbol);

                foreach (int value in row)
                    Console.Write("\t" + value);

                Console.WriteLine();
                symbol = (char)(symbol + 1);
            }

            Console.WriteLine();
        }

        public static void Task1(List<List<int>> data)
        {
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
            PrintData(data);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Minimax Criterion: " + Logic.Minimax(data));
                    break;

                case 2:
                    Console.WriteLine("Wald (Maximin) Criterion: " + Logic.Maximin(data));
                    break;

                case 3:
                    Console.WriteLine("Maximax (Optimistic) Criterion: " + Logic.Maximax(data));
                    break;

                case 4:
                    Console.WriteLine("Hurwitz Criterion: " +
                        Logic.Hurwitz(data, Logic.HurwitzFactor()));
                    break;
 
                case 5:
                    Console.WriteLine("Bayes-Laplace Criterion: " +
                        Logic.BayesLaplace(data, Logic.BayesLaplaceFactors(data.Count)));
                    break;
 
                case 6:
                    Console.WriteLine("Savage Criterion: " + Logic.Savage(data));
                    break;

                default:
                    float hurwitzFactor = Logic.HurwitzFactor();
                    List<float> bayesLaplaceFactors = Logic.BayesLaplaceFactors(data.Count);

                    Console.WriteLine();

                    Console.WriteLine("Minimax Criterion: \t\t" + Logic.Minimax(data));
                    Console.WriteLine("Wald (Maximin) Criterion: \t" + Logic.Maximin(data));
                    Console.WriteLine("Maximax (Optimistic) Criterion: " + Logic.Maximax(data));
                    Console.WriteLine("Hurwitz Criterion: \t\t" + Logic.Hurwitz(data, hurwitzFactor));
                    Console.WriteLine("Bayes-Laplace Criterion: \t" +
                        Logic.BayesLaplace(data, bayesLaplaceFactors));
                    Console.WriteLine("Savage Criterion: \t\t" + Logic.Savage(data));
                    break;
            }

            
        }
    }
}
