using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSink
{
    public class Graph
    {
        List<Vertex> Vertices;
        List<Edge> Edges;
        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }

        public List<Vertex> GetVertices()
        {
            return Vertices;
        }
        public Vertex FindVertex(string name)
        {
            foreach(Vertex v in Vertices)
            {
                if (v.GetCityName() == name)
                {
                    return v;
                }
            }
            return null;
        }

        public List<Edge> GetEdges()
        {
            return Edges;
        }

        public void AddVertex(Vertex v)
        {
            if (!Vertices.Contains(v))
            {
                Vertices.Add(v);
            }
        }

        public List<Vertex> TopoSort()
        {
            List<Vertex> sorted = new List<Vertex>();
            Stack<Vertex> stack = new Stack<Vertex>();
            bool[] visited = new bool[Vertices.Count];

            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }

            for (int i = 0; i < Vertices.Count; i++)
            {
                if (visited[i] == false)
                {
                    TopoHelper(i, visited, Vertices.ElementAt(i), stack);
                }
            }

            while (stack.Count > 0)
            {
                sorted.Add(stack.Pop());
            }
            return sorted;
        }

        private void TopoHelper(int i, bool[] b, Vertex v, Stack<Vertex> s)
        {
            b[i] = true;
            //int j = i;
            //while (j < Vertices.Count)
            //{
            //    j++;
            //    if (j <= Vertices.Count - 1)
            //    {

            //        if (!b[j])
            //        {
            //            TopoHelper(j, b, s);
            //        }
            //    }
            //}
            IEnumerator<Vertex> iterator = v.GetNeighbors().GetEnumerator();
            while (iterator.MoveNext())
            {
                i = v.GetNeighbors().IndexOf(iterator.Current);
                if (!b[i])
                {
                    //v = v.GetNeighbors().ElementAt(i);
                    TopoHelper(i, b, iterator.Current, s);
                }
            }
            s.Push(v);
        }
    }

    public class Edge
    {
        public Edge(Vertex v1, Vertex v2)
        {
            v1.AddNeighbor(v2);
        }

    }
    public class Vertex
    {
        private string cityName;
        private int toll;
        private List<Vertex> neighbors;
        public Vertex(string c, int t)
        {
            cityName = c;
            toll = t;
            neighbors = new List<Vertex>();
        }

        public string GetCityName()
        {
            return cityName;
        }

        public int GetToll()
        {
            return toll;
        }

        public void AddNeighbor(Vertex v)
        {
            neighbors.Add(v);
        }

        public List<Vertex> GetNeighbors()
        {
            return neighbors;
        }
    }
}
