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
        public Graph()
        {
            Vertices = new List<Vertex>();
        }

        public List<Vertex> GetVertices()
        {
            return Vertices;
        }

        public void AddVertex(Vertex v)
        {
            if (!Vertices.Contains(v))
            {
                Vertices.Add(v);
            }
        }
    }

    public class Vertex
    {
        private string cityName;
        private int toll;
        private LinkedList<Vertex> neighbors;
        public Vertex(string c)
        {
            cityName = c;
            //toll = t;
            neighbors = new LinkedList<Vertex>();
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
            neighbors.AddLast(v);
        }

        public LinkedList<Vertex> GetNeighbors()
        {
            return neighbors;
        }
    }
}
