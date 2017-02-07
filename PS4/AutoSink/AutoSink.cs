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
        private Dictionary<string, string> trips;
        static void Main(string[] args)
        {
            AutoSink a = new AutoSink();
            Console.WriteLine(a.CreateMap());
        }

        public Dictionary<string, string> CreateMap()
        {
            cities = new Dictionary<string, int>();
            trips = new Dictionary<string, string>();
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
                    // Adds highways (makes graph)
                    else if (ncount > n+1 && hcount <= h)
                    {
                        int value;
                        
                        if(cities.ContainsKey(currentLine[0]))
                        {
                            cities.TryGetValue(currentLine[0], out value);
                            Vertex v1 = new Vertex(currentLine[0], value);
                            cities.TryGetValue(currentLine[1], out value);
                            Vertex v2 = new Vertex(currentLine[1], value);
                            if (!g.GetVertices().Contains(v1))
                            {
                                g.AddVertex(v1);
                            }
                            if(!v1.GetNeighbors().Contains(v2))
                            {
                                v1.AddNeighbor(v2);
                            }
                            hcount++;
                        }
                    }

                    else if (hcount == h+1)
                    {
                        t = Convert.ToInt32(currentLine[0]);
                        ncount++;
                    }
                    else if (hcount > h+1 && tcount <= t)
                    {
                        trips.Add(currentLine[0], currentLine[1]);
                        tcount++;
                    }
                }
            }
            catch (Exception e)
            {
            }
            return trips;
        }
    }
}
