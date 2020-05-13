using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class State
    {
        public string ID { get; }
        public List<Decision4> Decisions { get; }
        public List<Decision4> OptimalDecisions { get; set; }


        public bool IsStartingState { get; set; }
        public bool IsFinalState
        {
            get
            {
                if (Decisions.Count == 0)
                    return true;

                return false;
            }
        }

        public int OptimalDuration
        {
            get
            {
                if (IsFinalState)
                    return 0;

                return OptimalDecisions[0].Duration + OptimalDecisions[0]
                    .NextState.OptimalDuration;
            }
        }

        public State(string id, List<Decision4> decisions)
        {
            ID = id;
            Decisions = decisions;
            OptimalDecisions = new List<Decision4>();

            if (!IsFinalState)
                IsStartingState = true;
        }

        public override string ToString()
        {
            return ID;
        }
    }
}
