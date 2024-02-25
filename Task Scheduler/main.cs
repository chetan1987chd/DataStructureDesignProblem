//Leet code : 621 // https://leetcode.com/problems/task-scheduler/description/


using System.Runtime.CompilerServices;

public class TaskScheduler
{    
    // Method to calculate the least interval between tasks
    public int LeastInterval(char[] tasks, int n) {
        int time = 0;
        PriorityQueue<int,int> taskPriorityQueue = new PriorityQueue<int, int>();
        Queue<(int,int)> scheduledTasks = new();
        Dictionary<char,int> charDict = new Dictionary<char, int>();

        // Count the frequency of each task
        foreach(char c in tasks)
        {
            if(!charDict.ContainsKey(c))
            {
                charDict.Add(c,0);
            }
            charDict[c]++;
        }

        // Enqueue tasks into the priority queue based on their frequency
        foreach(var kv in charDict)
        {
            taskPriorityQueue.Enqueue(kv.Value, -kv.Value);
        }

        // Process tasks until both the priority queue and scheduled tasks queue are empty
        while(taskPriorityQueue.Count>0 || scheduledTasks.Count>0)
        {
            time++;

            // Dequeue a task from the priority queue and enqueue it into the scheduled tasks queue
            if(taskPriorityQueue.TryDequeue(out int item, out int freq) && freq+1!=0)
            {
                scheduledTasks.Enqueue((freq+1,time+n));
            }

            // Check if the next task in the scheduled tasks queue is ready to be processed
            if(scheduledTasks.TryPeek(out var value) && value.Item2==time)
            {
                freq = scheduledTasks.Dequeue().Item1;
                taskPriorityQueue.Enqueue(freq,freq);
            }
        }
        
        // Return the total time taken
        return time;
    }
}
