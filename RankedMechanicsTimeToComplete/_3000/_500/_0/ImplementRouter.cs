namespace LeetCodeSolutions._3000._500._0;

/***
URL: https://leetcode.com/problems/implement-router
Number: 3508
Difficulty: Medium
 */
public class ImplementRouter
{
    public class Router
    {
        private readonly int MemoryLimit;
        private readonly Dictionary<int, List<int>> DestinationTimestamps;
        private readonly Dictionary<long, int[]> PacketDict;
        private readonly Queue<long> PacketQueue;

        public Router(int memoryLimit)
        {
            MemoryLimit = memoryLimit;
            PacketDict = [];
            DestinationTimestamps = [];
            PacketQueue = new Queue<long>();
        }

        public bool AddPacket(int source, int destination, int timestamp)
        {
            var key = Encode(source, destination, timestamp);

            if (PacketDict.ContainsKey(key))
            {
                return false;
            }

            if (PacketDict.Count >= MemoryLimit)
            {
                ForwardPacket();
            }

            PacketDict[key] = [source, destination, timestamp];
            PacketQueue.Enqueue(key);

            if (!DestinationTimestamps.TryGetValue(destination, out var timestamps))
            {
                timestamps = [];
                DestinationTimestamps[destination] = timestamps;
            }

            // Maintain sorted order for binary search
            var index = LowerBound(timestamps, timestamp);
            timestamps.Insert(index, timestamp);

            return true;
        }

        public int[] ForwardPacket()
        {
            if (PacketDict.Count == 0)
            {
                return [];
            }

            var key = PacketQueue.Dequeue();

            if (!PacketDict.TryGetValue(key, out var packet))
            {
                return [];
            }

            PacketDict.Remove(key);

            var destination = packet[1];
            var timestamps = DestinationTimestamps[destination];

            if (timestamps.Count > 0)
            {
                // Remove the oldest timestamp for that destination
                timestamps.RemoveAt(0);
            }

            return packet;
        }

        public int GetCount(int destination, int startTime, int endTime)
        {
            if (!DestinationTimestamps.TryGetValue(destination, out var timestamps) || timestamps.Count == 0)
            {
                return 0;
            }

            var left = LowerBound(timestamps, startTime);
            var right = UpperBound(timestamps, endTime);

            return right - left;
        }

        private static long Encode(int source, int destination, int timestamp)
        {
            return HashCode.Combine(source, destination, timestamp);
        }

        private static int LowerBound(List<int> list, int target)
        {
            int low = 0, high = list.Count;

            while (low < high)
            {
                var mid = (low + high) >> 1;

                if (list[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }

            return low;
        }

        private static int UpperBound(List<int> list, int target)
        {
            int low = 0, high = list.Count;

            while (low < high)
            {
                var mid = (low + high) >> 1;

                if (list[mid] <= target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }

            return low;
        }
    }
}
