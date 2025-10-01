namespace LeetCodeSolutions._3000._400._0;

/***
URL: https://leetcode.com/problems/design-task-manager
Number: 3408
Difficulty: Medium
 */
public class DesignTaskManager
{
    public class TaskManager
    {
        private readonly PriorityQueue<Task, (int Priority, int taskId)> Tasks = new(new TaskComparer());
        private readonly Dictionary<int, Task> TaskMap = [];

        public TaskManager(IList<IList<int>> tasks)
        {
            foreach (var task in tasks)
            {
                // [userId, taskId, priority]
                var thisTask = new Task(task[0], task[1], task[2]);

                Tasks.Enqueue(thisTask, (thisTask.Priority, thisTask.TaskId));
                TaskMap.Add(thisTask.TaskId, thisTask);
            }
        }

        public void Add(int userId, int taskId, int priority)
        {
            var thisTask = new Task(userId, taskId, priority);

            Tasks.Enqueue(thisTask, (priority, taskId));
            TaskMap.Add(thisTask.TaskId, thisTask);
        }

        public void Edit(int taskId, int newPriority)
        {
            if (!TaskMap.TryGetValue(taskId, out var thisTask))
                return;

            thisTask.Priority = newPriority;
            Tasks.Enqueue(thisTask, (newPriority, taskId));
        }

        public void Rmv(int taskId)
        {
            TaskMap.Remove(taskId);
        }

        public int ExecTop()
        {
            while (Tasks.TryDequeue(out var topTask, out var priority))
            {
                if (topTask.Priority != priority.Priority)
                {
                    continue;
                }

                if (!TaskMap.TryGetValue(topTask.TaskId, out var current))
                {
                    continue;
                }

                if (topTask.UserId != current.UserId)
                {
                    continue;
                }

                TaskMap.Remove(topTask.TaskId);
                return topTask.UserId;
            }

            return -1;
        }

        private class Task(int userId, int taskId, int priority)
        {
            public int UserId { get; } = userId;
            public int TaskId { get; } = taskId;
            public int Priority { get; set; } = priority;
        }

        private class TaskComparer : IComparer<(int priority, int taskId)>
        {
            public int Compare((int priority, int taskId) a, (int priority, int taskId) b)
            {
                var priorityCompare = b.priority.CompareTo(a.priority);

                if (priorityCompare != 0)
                {
                    return priorityCompare;
                }

                // tie-break by TaskId ASC
                return b.taskId.CompareTo(a.taskId);
            }
        }
    }
}
