using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetShorty
{
    public class Short
    {

        private List<Graph> graphs;
        private List<string> startVertices;
        private List<string> endVertices;
        private List<double> factors;
        private List<int> nList;
        private int currentn;
        private Graph g1; 
        public static void Main(string[] args)
        {
            Short s = new Short();
            s.GetInfo();
            for (int i = 0; i < s.graphs.Count; i++)
            {
                //s.currentn = s.nList.ElementAt(i);
                Console.WriteLine(s.FindBestPath(s.graphs.ElementAt(i)).ToString( "#0.0000"));
            }
        }

        public void GetInfo()
        {
            try
            {
                graphs = new List<Graph>();
                nList = new List<int>();
                string line = "";
                //char[] spaces = { ' ' };
                string[] currentLine;
                int m = 0;
                int mCount = 0;
                

                while ((line = Console.ReadLine()) != null && line != "")
                {
                    currentLine = line.Split();
                    if (currentLine.Length == 2)
                    {
                        mCount = 0;
                        currentn = Convert.ToInt32(currentLine[0]);
                        //nList.Add(currentn);
                        m = Convert.ToInt32(currentLine[1]);
                        g1 = new Graph();

                        for (int i = 0; i < currentn; i++)
                        {
                            Vertex v1 = new Vertex(i.ToString());
                            g1.AddVertex(v1);
                        }
                        //startVertices = new List<string>();
                        //endVertices = new List<string>();
                        //factors = new List<double>();
                        if (m == 0)
                        {
                            return;
                        }
                        continue;
                    }

                    if (mCount < m)
                    {
                        //startVertices.Add(currentLine[0]);
                        //endVertices.Add(currentLine[1]);
                        //factors.Add(Convert.ToDouble(currentLine[2]));
                        CreateGraph(g1, currentLine[0], currentLine[1], Convert.ToDouble(currentLine[2]));
                        mCount++;
                    }
                    if (mCount == m)
                    {
                        //CreateGraph();
                        graphs.Add(g1);
                    }
                }
            }
            catch (Exception e)
            { }
        }

        public void CreateGraph(Graph g, string start, string end, double factor)
        {
            //Graph g1 = new Graph();
            //for (int i = 0; i < currentn; i++)
            //{
            //    Vertex v1 = new Vertex(i.ToString());
            //    g1.AddVertex(v1);
            //}
            //for (int j = 0; j < startVertices.Count; j++)
            //{ 
            //    Vertex startV = g1.FindVertex(startVertices.ElementAt(j));
            //    Vertex endV = g1.FindVertex(endVertices.ElementAt(j));
            //    g1.AddNeighbor(startV, endV, factors.ElementAt(j));
            //}
            //graphs.Add(g1);

            Vertex startV = g.FindVertex(start);
            Vertex endV = g.FindVertex(end);
            g.AddNeighbor(startV, endV, factor);
            //return g;
        }

        public double FindBestPath(Graph g)
        {
            double best = 1.0;
            try
            {
                Vertex start = g.FindVertex("0");
               // Vertex end = g.FindVertex((currentn - 1).ToString());

                // Dijkstra's (modified)
                foreach (Vertex u in g.GetVertices())
                {
                    u.SetDist(1);
                    u.SetPrev(null);
                }
                start.SetDist(1);

                PriorityQueue pq = new PriorityQueue();
                pq.InsertOrChange(start, 1);

                while (!pq.IsEmpty())
                {
                    Vertex u = pq.DeleteMin();
                    //best = u.GetDist();
                    foreach (Edge e in g.GetNeighbors(u))
                    {
                        if (e.GetEndVertex().GetDist() > best * e.GetWeight())
                        {
                            e.GetEndVertex().SetDist(u.GetDist() * e.GetWeight());
                            e.GetEndVertex().SetPrev(u);
                            pq.InsertOrChange(e.GetEndVertex(), e.GetEndVertex().GetDist());
                            best = e.GetEndVertex().GetDist();
                        }
                    }
                }
            }
            catch (Exception e)
            { }
            return best;

        }
    }

    public class PriorityQueue
    {
        private Dictionary<Vertex, double> ar;

        public PriorityQueue()
        {
            ar = new Dictionary<Vertex, double>();
        }

        public bool IsEmpty()
        {
            if (ar.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void InsertOrChange(Vertex v, double w)
        {
            if (ar.ContainsKey(v))
            {
                double value;
                ar.TryGetValue(v, out value);
                v.SetDist(w);
                value = w;
            }
            else
            {
                v.SetDist(w);
                ar.Add(v, w);
            }
        }

        public Vertex DeleteMin()
        {
            double max = ar.Values.First();
            Vertex maxKey = ar.Keys.First();
            foreach (KeyValuePair<Vertex, double> kvp in ar)
            {
                if (kvp.Value > max)
                {
                    max = kvp.Value;
                    maxKey = kvp.Key;
                }
            }
            ar.Remove(maxKey);
            return maxKey;
        }
    }





    public class Graph
    {
        private Dictionary<Vertex, List<Edge>> g;

        public Graph()
        {
            g = new Dictionary<Vertex, List<Edge>>();
        }

        public ICollection<Vertex> GetVertices()
        {
            return g.Keys;
        }

        public Vertex FindVertex(string n)
        { 
            foreach (Vertex v in g.Keys)
            {
                if (v.GetName() == n)
                {
                    return v;
                }
            }
            return null;
        }

        public void AddVertex(Vertex v)
        {
            g.Add(v, new List<Edge>());
        }
        public List<Edge> GetNeighbors(Vertex v1)
        {
            List<Edge> value;
            g.TryGetValue(v1, out value);
            return value;
        }

        public void AddNeighbor(Vertex v1, Vertex v2, double w)
        {
            Edge e1 = new Edge(v2, w);
            List<Edge> value;
            g.TryGetValue(v1, out value);
            value.Add(e1);
        }

    }

    public class Edge
    {
        private Vertex end;
        private double weight;

        public Edge (Vertex v2, double d)
        {
            end = v2;
            weight = d;
        }

        public Vertex GetEndVertex()
        {
            return end;
        }

        public double GetWeight()
        {
            return weight;
        }
    }

    public class Vertex
    {
        private string vertexName;
        private Vertex prev;
        private double dist;

        public Vertex (string n)
        {
            vertexName = n;
            prev = null;
            dist = 2.0;
        }

        public string GetName()
        {
            return vertexName;
        }

        public void SetPrev(Vertex p)
        {
            prev = p;
        }

        public Vertex GetPrev()
        {
            return prev;
        }

        public void SetDist(double d)
        {
            dist = d;
        }

        public double GetDist()
        {
            return dist;
        }
    }
}
