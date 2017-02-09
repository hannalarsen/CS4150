using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSink
{
    public class AutoSink
    {
        private Dictionary<string, int> cities;
        private int n;
        private int h;
        private int t;
        private List<string> tripStart;
        private List<string> tripEnd;
        private List<string> startCity;
        private List<string> destination;
        private Graph  map;
        static void Main(string[] args)
        {
            AutoSink a = new AutoSink();
            a.GetInfo();
            a.CreateGraph();
        }

        public void GetInfo()
        {
            cities = new Dictionary<string, int>();
            tripStart = new List<string>();
            tripEnd = new List<string>();
            startCity = new List<string>();
            destination = new List<string>();
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
                    if(ncount == 0)
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
                    else if (ncount == n+1)
                    {
                        h = Convert.ToInt32(currentLine[0]);
                        ncount++;
                    }
                    // Adds highways
                    else if (ncount > n+1 && hcount < h)
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
                    else if (hcount > h && tcount < t)
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
            map = new Graph();
            foreach(string n in cities.Keys)
            {
                int value;
                cities.TryGetValue(n, out value);
                Vertex v = new Vertex(n, value);
                map.AddVertex(v);
            }
            for (int i = 0; i < startCity.Count; i ++)
            {
                string start = startCity.ElementAt(i);
                string dest = destination.ElementAt(i);
                map.FindVertex(start).AddNeighbor(map.FindVertex(dest));
            }
            map.TopoSort();
        }

        public List<string> FindMinToll(List<string> start, List<string> end)
        {
            List<string> tolls = new List<string>();
            List<Vertex> sortedCities = map.TopoSort();
            for (int i = 0; i < start.Count; i++)
            {
                string minToll = "NO";
                string startCity = start.ElementAt(i);
                string endCity = end.ElementAt(i);
                // If start and end destinations are the same
                if (startCity == endCity)
                {
                    minToll = "0";
                    tolls.Add(minToll);
                }

                // If cities are inaccessible to each other
                else if (sortedCities.IndexOf(map.FindVertex(startCity)) > sortedCities.IndexOf(map.FindVertex(endCity)))
                {
                    tolls.Add(minToll);
                }


            }
            return tolls;
        }

        //public List<Vertex> TopoSort()
        //{
        //    List<Vertex> sorted = new List<Vertex>();
        //    Stack<Vertex> stack = new Stack<Vertex>();
        //    bool[] visited = new bool[map.GetVertices().Count];

        //    for (int i = 0; i < visited.Length; i++)
        //    {
        //        visited[i] = false;
        //    }

        //    for (int i = 0; i < map.GetVertices().Count; i++)
        //    {
        //        if (visited[i] == false)
        //        {
        //            TopoHelper(i, visited, stack);
        //        }
        //    }

        //    while (stack.Count > 0)
        //    {
        //        sorted.Add(stack.Pop());
        //    }
        //    return sorted;
        //}

        //private void TopoHelper(int i, bool[] b, Stack<Vertex> s)
        //{
        //    b[i] = true;

        //}
    }
}
