using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Decision4
    {
        public string ID { get; }
        public int Duration { get; }
        public State NextState { get; }

        public Decision4(string id, int duration, State nextState)
        {
            ID = id;
            Duration = duration;
            NextState = nextState;

            nextState.IsStartingState = false;
        }

        public override string ToString()
        {
            return ID;
        }
    }
}
