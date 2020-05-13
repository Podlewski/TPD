using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public static partial class Logic
    {
        private static void FindOptimalDecisionForState(State state)
        {
            if (!state.IsFinalState)
            {
                if (state.Decisions.Count == 1)
                    state.OptimalDecisions = state.Decisions;
                else
                {
                    List<KeyValuePair<Decision4, int>> decisions =
                        new List<KeyValuePair<Decision4, int>>();

                    foreach (Decision4 decision in state.Decisions)
                    {
                        int duration = decision.Duration;
                        duration += decision.NextState.OptimalDuration;

                        decisions.Add(new KeyValuePair<Decision4, int>(decision, duration));
                    }

                    decisions.Sort((p1, p2) => p1.Value.CompareTo(p2.Value));

                    foreach (var decision in decisions)
                    {
                        if (decision.Value == decisions[0].Value)
                            state.OptimalDecisions.Add(decision.Key);
                    }
                }
            }
        }

        public static void FindOptimalDecisions(List<State> states)
        {
            foreach (State state in states)
                FindOptimalDecisionForState(state);
        }

        public static List<State> GetStartingStates(List<State> states)
        {
            List<State> result = new List<State>();

            foreach (State state in states)
            {
                if (state.IsStartingState)
                    result.Add(state);
            }

            return result.OrderBy(s => s.OptimalDuration).ToList();
        }
    }
}
