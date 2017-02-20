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
        public static void Main(string[] args)
        {
            Short s = new Short();
            s.GetInfo();
            foreach (Graph g1 in s.graphs)
            {
                Console.WriteLine(s.FindBestPath(g1));
            }
        }

        public void GetInfo()
        {
            graphs = new List<Graph>();
            string line = "";
            char[] spaces = { ' ' };
            string[] currentLine;
            int m = 0;
            int mCount = 0;

            while ((line = Console.ReadLine()) != null && line != "")
            {
                currentLine = line.Split();
                if (currentLine.Length == 2)
                {
                    mCount = 0;
                    m = Convert.ToInt32(currentLine[1]);
                    if (m == 0)
                    {
                        return;
                    }
                    continue;
                }
                if (mCount < m)
                {
                    startVertices.Add(currentLine[0]);
                    endVertices.Add(currentLine[1]);
                    factors.Add(Convert.ToDouble(currentLine[2]));
                    mCount++;
                }
                else
                {
                    CreateGraph();
                }
            }
        }

        public void CreateGraph()
        {
            Graph g1 = new Graph();
            for (int i = 0; i < startVertices.Count; i++)
            {
                Vertex v1 = new Vertex(startVertices.ElementAt(i));
                Vertex v2 = new Vertex(endVertices.ElementAt(i));
                g1.AddVertex(v1);
                g1.AddVertex(v2);
                g1.AddNeighbor(v1, v2, factors.ElementAt(i));
            }
            graphs.Add(g1);
        }

        public double FindBestPath(Graph g)
        {
            foreach (Vertex u in g.GetVertices())
            {
                u.SetDist(double.PositiveInfinity);
                u.SetPrev(null);
            }
            Vertex start = g.FindVertex("0");
            start.SetDist(0);

            PriorityQueue pq = new PriorityQueue();
            pq.InsertOrChange(start, 0);

            while (!pq.IsEmpty())
            {
                Vertex u = pq.DeleteMin();
                foreach (Edge e in g.GetNeighbors(u))
                {

                }
            }
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
                value = w;
            }
            else
            {
                ar.Add(v, w);
            }
        }

        public Vertex DeleteMin()
        {
            Vertex min = ar.Min().Key;
            ar.Remove(ar.Min().Key);
            return min;
            
        }
    }





    public class Graph
    {
        private Dictionary<Vertex, List<Edge>> g;

        public Graph()
        {
            g = new Dictionary<Vertex, List<Edge>>();
        }

        public List<Vertex> GetVertices()
        {
            return g.Keys.ToList();
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
