﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetShorty
{
    public class Shorty2
    {
        Dictionary<string, double> weights;
        private Graph2 g1;
        public static void Main(string[] args)
        {
            Shorty2 s = new Shorty2();
            s.GetInfo();
        }

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
                        m = Convert.ToInt32(currentLine[1]);
                        if (m == 0)
                        {
                            return;
                        }
                        g1 = new Graph2();
                        weights = new Dictionary<string, double>();

                        continue;
                    }

                    if (mCount < m)
                    {
                        AddToGraph(g1, currentLine[0], currentLine[1], Convert.ToDouble(currentLine[2]));
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

        public void AddToGraph(Graph2 g, string v1, string v2, double f)
        {
            if (!g.GetVertices().Contains(v1))
            {
                g.Add(v1);
                weights.Add(v1, 1);
            }
            if(!g.GetVertices().Contains(v2))
            {
                g.Add(v2);
                weights.Add(v2, 1);
            }

            g.AddNeighbor(v1, v2, f);
            
        }

        public double FindBestPath(Graph2 g)
        {
            double best = 1.0;
            try
            {
                string start = "0";

                // Dijkstra's (modified)
                //foreach (string u in weights.Keys)
                //{
                //    weights[u] = 1.0;
                //}
                //start.SetDist(1);

                PriorityQueue2 pq = new PriorityQueue2();
                pq.InsertOrChange(start, 1);

                while (!pq.IsEmpty())
                {
                    string u = pq.DeleteMax();
                    foreach (Edge2 e in g.GetNeighbors(u))
                    {
                        if (weights[e.GetEndVertex()] > best * e.GetWeight())
                        {
                            weights[e.GetEndVertex()] = (weights[u] * e.GetWeight());
                            //e.GetEndVertex().SetPrev(u);
                            pq.InsertOrChange(e.GetEndVertex(), weights[e.GetEndVertex()]);
                            best = weights[e.GetEndVertex()];
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            return best;
        }






        private class PriorityQueue2
        {
            private Dictionary<string, double> ar;


            public PriorityQueue2()
            {
                ar = new Dictionary<string, double>();

            }

            public bool IsEmpty()
            {
                if (ar.Count == 0)
                {
                    return true;
                }
                return false;
            }

            public void InsertOrChange(string v, double w)
            {
                try
                {
                    ar.Add(v, w);
                }
                catch (ArgumentException e)
                {
                    ar[v] = w;
                }
            }

            public string DeleteMax()
            {
                double max = ar.Values.First();
                string maxKey = ar.Keys.First();
                foreach (KeyValuePair<string, double> kvp in ar)
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
    }


    public class Graph2
    {
        private Dictionary<string, List<Edge2>> g;

        public Graph2()
        {
            g = new Dictionary<string, List<Edge2>>();
        }

        public void Add(string n)
        {
            g.Add(n, new List<Edge2>());
        }

        public void AddNeighbor(string v1, string v2, double w)
        {
            Edge2 e1 = new Edge2(v2, w);
            List<Edge2> value;
            g.TryGetValue(v1, out value);
            value.Add(e1);
        }

        public List<Edge2> GetNeighbors(string v1)
        {
            List<Edge2> value;
            g.TryGetValue(v1, out value);
            return value;
        }

        public ICollection<string> GetVertices()
        {
            return g.Keys;
        }


    }
    public class Edge2
    {
        private string end;
        private double weight;

        public Edge2(string v2, double d)
        {
            end = v2;
            weight = d;
        }

        public string GetEndVertex()
        {
            return end;
        }

        public double GetWeight()
        {
            return weight;
        }
    }


}
