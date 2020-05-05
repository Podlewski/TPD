using System.Collections.Generic;

namespace Logic
{
    public class Path
    {
        public List<Activity> Activities { get; }
        public int Duration
        {
            get
            {
                int duration = 0;
                foreach (Activity activity in Activities)
                    duration += activity.Duration;

                return duration;
            }
        }
        public List<Activity> LastActivityPredecessors
        {
            get
            {
                return Activities[Activities.Count - 1].Predecessors;
            }
        }
        public bool PathFinished
        {
            get
            {
                if (Activities[Activities.Count - 1].Predecessors.Count == 0)
                    return true;

                return false;
            }
        }

        
        public Path()
        {
            Activities = new List<Activity>();
        }

        public Path(Path path)
        : this()
        {
            foreach (Activity activity in path.Activities)
                Activities.Add(activity);
        }

        public void AddActivity(Activity activity)
        {
            Activities.Add(activity);
        }

        public override string ToString()
        {
            string result = "Path:";

            for (int i = Activities.Count - 1; i >= 0; i--) 
                result += " " + Activities[i].ID;

            return result += "\nTotal duration: " + Duration;
        }
    }
}
