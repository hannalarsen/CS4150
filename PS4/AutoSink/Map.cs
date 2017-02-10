using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSink
{
    public class Map
    {
        private Dictionary<string, int> cities;
        private List<string> tripStart;
        private List<string> tripEnd;
        private List<string> startCity;
        private List<string> destination;
        private Graph map;
        static void Main(string[] args)
        {
            Map a = new Map();
            a.GetInfo();
            a.CreateGraph();
            a.FindMinToll(a.tripStart, a.tripEnd);
            foreach (string s in a.FindMinToll(a.tripStart, a.tripEnd))
            {
                Console.WriteLine(s);
            }

        }

        public void GetInfo()
        {
            cities = new Dictionary<string, int>();
            tripStart = new List<string>();
            tripEnd = new List<string>();
            startCity = new List<string>();
            destination = new List<string>();
            int n = 0;
            int h = 0;
            int t = 0;
        Graph g = new Graph();
            try
            {
                string line = "";
                char[] spaces = { ' ' };
                int ncount = 0;
                int hcount = 0;
                int tcount = 0;
                string[] currentLine;
                while ((line = Console.ReadLine()) != null && line.Length > 0)
                {
                    currentLine = line.Split(spaces);
                    // Number of cities
                    if (ncount == 0)
                    {
                        n = Convert.ToInt32(currentLine[0]);
                        ncount++;
                    }
                    // Adds cities and tolls
                    else if (ncount <= n)
                    {
                        cities.Add(currentLine[0], Convert.ToInt32(currentLine[1]));
                        ncount++;
                    }
                    // Number of highways
                    else if (ncount == n + 1)
                    {
                        h = Convert.ToInt32(currentLine[0]);
                        ncount++;
                    }
                    // Adds highways
                    else if (ncount > n + 1 && hcount < h)
                    {
                        string from = currentLine[0];
                        string to = currentLine[1];
                        startCity.Add(from);
                        destination.Add(to);
                        hcount++;
                    }
                    // Number of trips
                    else if (hcount == h)
                    {
                        t = Convert.ToInt32(currentLine[0]);
                        hcount++;
                    }
                    else if (hcount > h && tcount <= t)
                    {
                        tripStart.Add(currentLine[0]);
                        tripEnd.Add(currentLine[1]);
                        tcount++;
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

        public void CreateGraph()
        {
            try
            {
                map = new Graph();
                foreach (string n in cities.Keys)
                {
                    int value;
                    cities.TryGetValue(n, out value);
                    Vertex v = new Vertex(n, value);
                    map.AddVertex(v);
                }
                for (int i = 0; i < startCity.Count; i++)
                {
                    string start = startCity.ElementAt(i);
                    string dest = destination.ElementAt(i);
                    map.AddNeighbor(map.FindVertex(start), (map.FindVertex(dest)));
                }
                TopoSort(map);
            }
            catch (Exception e)
            { }
        }

        Dictionary<Vertex, bool> visited;
        List<Vertex> sorted;

        /// <summary>
        /// Returns a list of vertices in reverse topologically sorted order
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public List<Vertex> TopoSort(Graph g)
        {
            try
            {
                visited = new Dictionary<Vertex, bool>();
                sorted = new List<Vertex>();
                foreach (Vertex v in g.GetVertices())
                {
                    visited.Add(v, false);
                }

                foreach (Vertex v in g.GetVertices())
                {
                    bool value;
                    visited.TryGetValue(v, out value);
                    if (value == false)
                    {
                        Explore(g, v);

                    }
                }
            }
            catch (Exception e)
            { }
            return sorted;
        }

        private void Explore(Graph g, Vertex v)
        {
            visited[v] = true;
            foreach (Vertex v1 in g.GetNeighbors(v))
            {
                bool value2;
                visited.TryGetValue(v1, out value2);
                if (value2 == false)
                {
                    Explore(g, v1);
                }
            }
            sorted.Add(v);

        }
        public List<string> FindMinToll(List<string> start, List<string> end)
        {
            List<string> tolls = new List<string>();
            try
            {
                TopoSort(map);

                for (int i = 0; i < start.Count; i++)
                {
                    string minToll = "NO";
                    string startCity = start.ElementAt(i);
                    string endCity = end.ElementAt(i);
                    int tempGoal = sorted.IndexOf(map.FindVertex(endCity));
                    // If start and end destinations are the same
                    if (startCity == endCity)
                    {
                        minToll = "0";
                        tolls.Add(minToll);
                    }

                    // If cities are inaccessible to each other
                    else if (sorted.IndexOf(map.FindVertex(startCity)) < sorted.IndexOf(map.FindVertex(endCity)))
                    {
                        tolls.Add(minToll);
                    }

                    // If destination is a neighbor of start
                    else if (map.GetNeighbors(map.FindVertex(startCity)).Contains(map.FindVertex(endCity)))
                    {
                        int toll2;
                        cities.TryGetValue(endCity, out toll2);
                        int sum = toll2;
                        minToll = sum.ToString();
                        tolls.Add(minToll);
                    }

                    else
                    {
                        int j = 0;
                        int finish = sorted.IndexOf(map.FindVertex(startCity));
                        int begin = sorted.IndexOf(map.FindVertex(endCity));
                        // Gets total costs
                        //sorted.IndexOf(map.FindVertex(endCity))
                        for (j = begin; j < finish; j++)
                        {
                            int toll = sorted.ElementAt(j).GetToll();
                            if (sorted.ElementAt(j).GetCityName() == endCity)
                            {
                                sorted.ElementAt(j).TotalCost(toll);
                            }

                            else if (map.GetNeighbors(sorted.ElementAt(j)).Count == 0)
                            {
                                sorted.ElementAt(j).TotalCost(toll);
                            }
                            else
                            {
                                //int tempGoalCost = sorted.ElementAt(tempGoal).GetTotalCost();
                                //int currentCost = 0;
                                //if (tempGoal == 0)
                                //{
                                //    tempGoalCost = sorted.ElementAt(begin).GetTotalCost();
                                //    tempGoal = j;
                                //    sorted.ElementAt(j).TotalCost(tempGoalCost + toll);

                                //}
                                //else
                                //{
                                //    if (j < finish && map.GetNeighbors(sorted.ElementAt(j)).Contains(map.FindVertex(endCity)))
                                //    {
                                //        currentCost = toll + map.FindVertex(endCity).GetTotalCost();

                                //        if (currentCost <= tempGoalCost)
                                //        {
                                //            tempGoalCost = currentCost;
                                //            tempGoal = j;
                                //            sorted.ElementAt(j).TotalCost(tempGoalCost);
                                //        }
                                //    }

                                //    if (j < finish && map.GetNeighbors(sorted.ElementAt(j)).Contains(sorted.ElementAt(tempGoal)))
                                //    {
                                //        currentCost = map.GetNeighbors(sorted.ElementAt(j)).ElementAt(0).GetTotalCost();
                                //        foreach (Vertex v in map.GetNeighbors(sorted.ElementAt(j)))
                                //        {
                                //            currentCost = Math.Min(currentCost, v.GetTotalCost());
                                //            currentCost += toll;
                                //            sorted.ElementAt(j).TotalCost(currentCost);
                                //        }
                                //        if (currentCost < tempGoalCost)
                                //        {
                                //            tempGoal = j;
                                //            tempGoalCost = currentCost;
                                //            sorted.ElementAt(j).TotalCost(tempGoalCost + toll);
                                //        }
                                //    }
                                //}

                                int tempGoalCost = sorted.ElementAt(tempGoal).GetTotalCost();
                                if (j < finish && map.GetNeighbors(sorted.ElementAt(j)).Contains(map.FindVertex(endCity)))
                                {
                                    int potentialCost = toll + map.FindVertex(endCity).GetTotalCost();
                                    if (j != begin)
                                    {
                                        if (potentialCost < tempGoalCost)
                                        {
                                            tempGoalCost = potentialCost;
                                            tempGoal = j;
                                            sorted.ElementAt(j).TotalCost(tempGoalCost);
                                        }
                                    }
                                }
                                if (j < finish && map.GetNeighbors(sorted.ElementAt(j)).Contains(sorted.ElementAt(tempGoal)))
                                {
                                    tempGoal = j;
                                   sorted.ElementAt(j).TotalCost(tempGoalCost + toll);

                                }
                        }
                        }
                        int totalToll = sorted.ElementAt(tempGoal).GetTotalCost();
                        tolls.Add(totalToll.ToString());
                    }
                }   
            }
            catch (Exception e)
            { }
            return tolls;
        }

        public class Graph
        {
            List<Vertex> Vertices;
            Dictionary<Vertex, List<Vertex>> g;
            public Graph()
            {
                Vertices = new List<Vertex>();
                g = new Dictionary<Vertex, List<Vertex>>();
            }

            public List<Vertex> GetVertices()
            {
                return g.Keys.ToList<Vertex>();
            }
            public Vertex FindVertex(string name)
            {

                foreach (Vertex v in g.Keys)
                {
                    if (v.GetCityName() == name)
                    {
                        return v;
                    }
                }
                return null;
            }

            public void AddNeighbor(Vertex v1, Vertex v2)
            {
                List<Vertex> value;
                g.TryGetValue(v1, out value);
                value.Add(v2);

            }

            public List<Vertex> GetNeighbors(Vertex v1)
            {
                List<Vertex> value;
                g.TryGetValue(v1, out value);
                return value;
            }

            public void AddVertex(Vertex v)
            {
                g.Add(v, new List<Vertex>());
            }

        }

        public class Vertex
        {
            private string cityName;
            private int toll;
            private int totalCost;
            public Vertex(string c, int t)
            {
                cityName = c;
                toll = t;
            }

            public string GetCityName()
            {
                return cityName;
            }

            public int GetToll()
            {
                return toll;
            }

            public void TotalCost(int prevCost)
            {
                totalCost = prevCost;
            }

            public int GetTotalCost()
            {
                return totalCost;
            }
        }
    }

}
