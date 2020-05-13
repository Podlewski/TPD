using System;
using System.Collections.Generic;

using static Logic.Helper;
using static Logic.Logic;

namespace Logic
{
    public partial class Controler
    {
        public static void Task4(List<List<string>> stringMatrix)
        {
            Console.Clear();
            List<State> states = new List<State>();

            foreach (List<string> line in stringMatrix)
            {


                string id = line[0];
                List<Decision4> decisions = new List<Decision4>();

                for (int i = 1; i < line.Count; i += 3)
                {
                    string dID = line[i];
                    int dDuration = int.Parse(line[i+1]);

                    State dState = null;

                    foreach (State state in states)
                    {
                        if (state.ID == line[i + 2])
                            dState = state;
                    }

                    decisions.Add(new Decision4(dID, dDuration, dState));
                }

                states.Add(new State(id, decisions));
            }

            FindOptimalDecisions(states);
            List<State> startingStates = GetStartingStates(states);

            if (startingStates.Count > 1)
            {
                Console.WriteLine("Best routes:");
                foreach (State state in startingStates)
                    PrintOptimalRoutes(state);

                Console.WriteLine("");
            }

            Console.WriteLine("Optimal route(s):");
            foreach (State state in startingStates)
            {
                if (state.OptimalDuration == startingStates[0].OptimalDuration)
                    PrintOptimalRoutes(state);
            }
        }
    }
}
