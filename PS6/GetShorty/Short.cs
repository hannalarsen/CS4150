using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetShorty
{
    public class Short
    {
        private int currentn;
        private Graph g1; 
        //public static void Main(string[] args)
        //{
        //    Short s = new Short();
        //    s.GetInfo();
        //}

        public void GetInfo()
        {
            try
            {
                string line = "";
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
                        m = Convert.ToInt32(currentLine[1]);
                        if (m == 0)
                        {
                            return;
                        }
                        g1 = new Graph();

                        //for (int i = 0; i < currentn; i++)
                        //{
                        //    Vertex v1 = new Vertex(i.ToString());
                        //    g1.AddVertex(v1);
                        //}

                        continue;
                    }

                    if (mCount < m)
                    {
                        CreateGraph(g1, currentLine[0], currentLine[1], Convert.ToDouble(currentLine[2]));
                        mCount++;
                    }
                    if (mCount == m)
                    {
                        Console.WriteLine(FindBestPath(g1).ToString("#0.0000"));
                    }
                }
            }
            catch (Exception e)
            { }
        }

        public void CreateGraph(Graph g, string start, string end, double factor)
        {
            Vertex startV = g.FindVertex(start);
            if (startV == null)
            {
                startV = new Vertex(start);
                g.AddVertex(startV);
            }
            Vertex endV = g.FindVertex(end);
            if (endV == null)
            {
                endV = new Vertex(end);
                g.AddVertex(endV);
            }
            g.AddNeighbor(startV, endV, factor);
        }

        public double FindBestPath(Graph g)
        {
            double best = 1.0;
            try
            {
                Vertex start = g.FindVertex("0");

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
                    Vertex u = pq.DeleteMax();
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
            try
            {
                v.SetDist(w);
                ar.Add(v, w);
            }
            catch (ArgumentException e)
            {
                double value;
                ar.TryGetValue(v, out value);
                v.SetDist(w);
                value = w;
            }
        }

        public Vertex DeleteMax()
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
