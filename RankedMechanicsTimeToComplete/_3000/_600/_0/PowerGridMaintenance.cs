namespace LeetCodeSolutions._3000._600._0;

/***
URL: https://leetcode.com/problems/power-grid-maintenance
Number: 3607
Difficulty: Medium
*/
public class PowerGridMaintenance
{
    public int[] ProcessQueries(int c, int[][] connections, int[][] queries)
    {
        var graph = new Graph();

        for (var i = 0; i < c; i++)
        {
            var v = new Vertex(i + 1);

            graph.AddVertex(i + 1, v);
        }

        foreach (var conn in connections)
        {
            graph.AddEdge(conn[0], conn[1]);
        }

        var powerGrids = new List<PriorityQueue<int, int>>();

        for (int i = 1, powerGridId = 0; i <= c; i++)
        {
            var v = graph.GetVertexValue(i);

            if (v.powerGridId == -1)
            {
                var powerGrid = new PriorityQueue<int, int>();

                Traverse(v, powerGridId, powerGrid, graph);
                powerGrids.Add(powerGrid);
                powerGridId++;
            }
        }

        var ans = new List<int>();

        foreach (var q in queries)
        {
            int op = q[0], x = q[1];

            if (op == 1)
            {
                var vertex = graph.GetVertexValue(x);

                if (!vertex.offline)
                {
                    ans.Add(x);
                }
                else
                {
                    var powerGrid = powerGrids[vertex.powerGridId];

                    while (powerGrid.Count > 0 && graph.GetVertexValue(powerGrid.Peek()).offline)
                    {
                        powerGrid.Dequeue();
                    }

                    ans.Add(powerGrid.Count > 0 ? powerGrid.Peek() : -1);
                }
            }
            else if (op == 2)
            {
                graph.GetVertexValue(x).offline = true;
            }
        }

        return ans.ToArray();
    }

    private void Traverse(Vertex u, int powerGridId, PriorityQueue<int, int> powerGrid, Graph graph)
    {
        u.powerGridId = powerGridId;
        powerGrid.Enqueue(u.vertexId, u.vertexId);

        foreach (var vid in graph.GetConnectedVertices(u.vertexId))
        {
            var v = graph.GetVertexValue(vid);

            if (v.powerGridId == -1)
            {
                Traverse(v, powerGridId, powerGrid, graph);
            }
        }
    }

    private class Vertex
    {
        public int vertexId;
        public bool offline = false;
        public int powerGridId = -1;

        public Vertex() { }

        public Vertex(int id)
        {
            this.vertexId = id;
        }
    }

    private class Graph
    {
        private Dictionary<int, List<int>> adj;
        private Dictionary<int, Vertex> vertices;

        public Graph()
        {
            this.adj = [];
            this.vertices = [];
        }

        public void AddVertex(int id, Vertex value)
        {
            this.vertices[id] = value;
            this.adj[id] = [];
        }

        public void AddEdge(int u, int v)
        {
            this.adj[u].Add(v);
            this.adj[v].Add(u);
        }

        public Vertex GetVertexValue(int id)
        {
            return this.vertices[id];
        }

        public List<int> GetConnectedVertices(int id)
        {
            return this.adj[id];
        }
    }

    private class PowerGridMaintance2
    {
        public int[] ProcessQueries(int c, int[][] connections, int[][] queries)
        {
            var connectedStationsSet = new Dictionary<int, HashSet<int>>();

            foreach (var connection in connections)
            {
                var station1 = connection[0];
                var station2 = connection[1];

                if (!connectedStationsSet.TryGetValue(station1, out var s1Stations))
                {
                    s1Stations = [];
                }

                foreach (var station in s1Stations.ToList())
                {
                    connectedStationsSet[station].Add(station2);
                }

                s1Stations.Add(station2);
                connectedStationsSet[station1] = s1Stations;

                if (!connectedStationsSet.TryGetValue(station2, out var s2Stations))
                {
                    s2Stations = [];
                }

                foreach (var station in s2Stations.ToList())
                {
                    connectedStationsSet[station].Add(station1);
                }

                s2Stations.Add(station1);
                connectedStationsSet[station2] = s2Stations;
            }

            var connectedStations = new Dictionary<int, List<int>>();

            foreach (var (station, set) in connectedStationsSet)
            {
                var thisList = set.ToList();
                thisList.Sort();

                connectedStations[station] = thisList;
            }

            var answer = new List<int>();
            var disabledStations = new HashSet<int>();

            for (var i = 0; i < queries.Length; i++)
            {
                var operation = queries[i][0];
                var station = queries[i][1];

                // Decommission station
                if (operation == 2)
                {
                    disabledStations.Add(station);
                    continue;
                }

                if (operation == 1)
                {
                    if (!disabledStations.Contains(station))
                    {
                        answer.Add(station);
                        continue;
                    }

                    if (!connectedStations.TryGetValue(station, out var sStations))
                    {
                        answer.Add(-1);
                        continue;
                    }

                    var thisAns = -1;

                    foreach (var sStation in sStations)
                    {
                        if (!disabledStations.Contains(sStation))
                        {
                            thisAns = sStation;
                            break;
                        }
                    }

                    answer.Add(thisAns);
                }
            }

            return [.. answer];
        }
    }
}
