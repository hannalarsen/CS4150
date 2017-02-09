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
        Dictionary<Vertex, List<Vertex>> g;
        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
            g = new Dictionary<Vertex, List<Vertex>>();
        }

        public List<Vertex> GetVertices()
        {
            return g.Keys.ToList<Vertex>();
        }
        public Vertex FindVertex(string name)
        {
            //foreach(Vertex v in Vertices)
            //{
            //    if (v.GetCityName() == name)
            //    {
            //        return v;
            //    }
            //}

            foreach(Vertex v in g.Keys)
            {
                if(v.GetCityName() == name)
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

        public List<Edge> GetEdges()
        {
            return Edges;
        }

        public void AddVertex(Vertex v)
        {
            //if (!Vertices.Contains(v))
            //{
            //    Vertices.Add(v);
            //}
            g.Add(v, new List<Vertex>());
        }

    }

    public class Edge
    {
        public Edge(Vertex v1, Vertex v2)
        {
           // v1.AddNeighbor(v2);
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
            //neighbors = new List<Vertex>();
        }

        public string GetCityName()
        {
            return cityName;
        }

        public int GetToll()
        {
            return toll;
        }

        //public void AddNeighbor(Vertex v)
        //{
        //    //neighbors.Add(v);
            
        //}

        //public List<Vertex> GetNeighbors()
        //{
        //    return neighbors;
        //}
    }
}
