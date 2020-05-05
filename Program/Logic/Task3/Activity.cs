using System.Collections.Generic;

namespace Logic
{
    public class Activity
    {
        public string ID { get; }
        public int Duration { get; }
        public List<Activity> Predecessors { get; }

        public Activity(string iD, int duration, List<Activity> predecessors)
        {
            ID = iD;
            Duration = duration;
            Predecessors = predecessors;
        }

        public override string ToString()
        {
            string result = ID + ": " + Duration + "\tPredecessors: ";

            if (Predecessors.Count > 0)
            {

                foreach (Activity predecessor in Predecessors)
                    result += predecessor.ID + ", ";

                result = result.Substring(0, result.Length - 2);
            }
            else
                result += "-";

            return result;
        }
    }
}
