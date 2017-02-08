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
            // Adds vertices
            foreach(string k in cities.Keys)
            {
                Vertex v = new Vertex(k);
                map.AddVertex(v);
            }
            foreach (Vertex v in map.GetVertices())
            {
                int i = 0;
                while (i < h)
                {
                    if (v.GetCityName() == startCity.ElementAt(i))
                    {

                    }
                    i++;
                }
                
            }
        }
    }
}
