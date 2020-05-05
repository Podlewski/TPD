using System;
using System.Collections.Generic;
using System.Linq;

using static Logic.Helper;
using static Logic.Logic;

namespace Logic
{
    public partial class Controler
    {
        public static void Task3(List<List<string>> stringMatrix)
        {
            Console.Clear();
            List<Activity> activities = new List<Activity>();

            foreach (List<string> line in stringMatrix)
            {
                string id = line[0];
                int duration = int.Parse(line[1]);
                List<Activity> predecessors = new List<Activity>();


                for (int i = 2; i < line.Count; i++)
                {
                    foreach (Activity activity in activities)
                    {
                        if (activity.ID == line[i])
                            predecessors.Add(activity);
                    }
                }

                activities.Add(new Activity(id, duration, predecessors));
            }

            foreach (Activity activity in activities)
                Console.WriteLine(activity);

            List<Activity> lastActivities = FindLastActivities(activities);

            List<Path> paths = FindEveryPath(lastActivities);
            Path criticalPath = FindCriticalPath(paths);

            Console.WriteLine("\n\nPaths: \n");

            foreach (Path path in paths)
                Console.WriteLine(path + "\n");

            Console.WriteLine("\nSolution: \n");
            Console.WriteLine(criticalPath);
        }
    }
}
