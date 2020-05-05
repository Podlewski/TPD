using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static partial class Logic
    {
        public static List<Activity> FindLastActivities(List<Activity> activities)
        {
            List<Activity> lastActivities = new List<Activity>();

            foreach (Activity activity in activities)
                lastActivities.Add(activity);

            foreach (Activity activity in activities)
            {
                foreach (Activity predecessor in activity.Predecessors)
                    lastActivities.Remove(predecessor);
            }

            return lastActivities;
        }

        public static Path FindCriticalPath(List<Path> paths)
        {
            return paths.Aggregate((p1, p2) => p1.Duration > p2.Duration ? p1 : p2);
        }

        public static List<Path> FindEveryPath(List<Activity> possiblePaths)
        {
            List<Path> paths = new List<Path>();

            foreach (Activity activity in possiblePaths)
            {
                Path newPath = new Path();
                newPath.AddActivity(activity);
                FindPath(newPath, ref paths);
            }

            return paths;
        }

        private static void FindPath(Path currentPath, ref List<Path> paths)
        {
            if (currentPath.PathFinished)
                paths.Add(currentPath);

            else
            {
                foreach (Activity activity in currentPath.LastActivityPredecessors)
                {
                    Path newPath = new Path(currentPath);
                    newPath.AddActivity(activity);
                    FindPath(newPath, ref paths);
                }
            }
        }



    }
}
