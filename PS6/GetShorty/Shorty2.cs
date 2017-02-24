using System;
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
        int n;
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
                        n = Convert.ToInt32(currentLine[0]);
                        if (m == 0)
                        {
                            return;
                        }
                        g1 = new Graph2();
                        weights = new Dictionary<string, double>();
                        for (int i = 0; i < n; i++)
                        {
                            g1.Add(i.ToString());
                            weights.Add(i.ToString(), 0);
                        }
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
            g.AddNeighbor(v1, v2, f);
            g.AddNeighbor(v2, v1, f);

        }

        public double FindBestPath(Graph2 g)
        {
            try
            {
                string start = "0";

                // Dijkstra's (modified)
                weights[start] = 1;

                PriorityQueue2 pq = new PriorityQueue2(n);
                pq.InsertOrChange(start, 1);

                while (!pq.IsEmpty())
                {
                    string u = pq.DeleteMax();
                    foreach (Edge2 e in g.GetNeighbors(u))
                    {
                        if (weights[e.GetEndVertex()] < weights[u] * e.GetFactor())
                        {
                            weights[e.GetEndVertex()] = (weights[u] * e.GetFactor());
                            pq.InsertOrChange(e.GetEndVertex(), weights[e.GetEndVertex()]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            double best = weights[(n - 1).ToString()];
            return best;
        }



        private class PriorityQueue2
        {
            private List<KeyValuePair<string, double>> nodes;
            private int[] indexes;

            public PriorityQueue2(int n)
            {
                nodes = new List<KeyValuePair<string, double>>();
                indexes = new int[n];
                for (int i = 0; i < indexes.Length; i++)
                {
                    indexes[i] = -1;
                }
            }

            public bool IsEmpty()
            {
                if (nodes.Count == 0)
                {
                    return true;
                }
                return false;
            }

            public void InsertOrChange(string v, double w)
            {
                int i = Convert.ToInt32(v);
                int size = nodes.Count;
                KeyValuePair<string, double> kvp = new KeyValuePair<string, double>(v, w);
                if (indexes[i] > -1)
                {
                    nodes[indexes[i]] = kvp;
                    indexes[i] = nodes.IndexOf(kvp);
                    if (size > 1)
                    {
                        HeapifyUp(size - 1);
                    }
                    
                }
                else
                {
                    nodes.Add(kvp);
                    indexes[i] = nodes.IndexOf(kvp);
                    size++;
                    if (size > 1)
                    {
                        HeapifyUp(size - 1);
                        
                    }
                    
                }
            }

            private void HeapifyUp(int i)
            {
                KeyValuePair<string, double> current = nodes.ElementAt(i);
                KeyValuePair<string, double> parent = nodes.ElementAt((i - 1) / 2);
                if (i == 0)
                {
                    return;
                }

                if (current.Value > parent.Value)
                {
                    nodes[(i - 1) / 2] = current;
                    nodes[i] = parent;
                    indexes[Convert.ToInt32(current.Key)] = (i - 1) / 2;
                    indexes[Convert.ToInt32(parent.Key)] = i;
                    HeapifyUp((i) / 2);
                }
            }

            public string DeleteMax()
            {
                KeyValuePair<string, double> max = nodes.ElementAt(0);
                
                string maxKey = max.Key;
                nodes.Remove(nodes.ElementAt(0));
                indexes[Convert.ToInt32(maxKey)] = -1;
                int last = nodes.Count - 1;
                if (nodes.Count > 0)
                {
                    //nodes[0] = nodes.ElementAt(last);
                    //indexes[Convert.ToInt32(nodes.ElementAt(last).Key)] = 0;
                    
                    if (last > 0)
                    {
                        HeapifyDown(last);
                    }
                    last--;
                }
                return maxKey;
            }

            private void HeapifyDown(int n)
            {
                int i = 0;
                KeyValuePair<string, double> current = nodes.ElementAt(i);
                if (i == n)
                {
                    return;
                }

                if (current.Value < nodes.ElementAt((2 * i) + 1).Value)
                {
                    nodes[i] = nodes.ElementAt((2 * i) + 1);
                    nodes[(2 * i) + 1] = current;

                    indexes[Convert.ToInt32(current.Key)] = nodes.IndexOf(current);
                    indexes[Convert.ToInt32(nodes.ElementAt(i).Key)] = nodes.IndexOf(nodes.ElementAt(i));
                    i = i * 2;
                    HeapifyDown(i);
                }
                else if (current.Value < nodes.ElementAt(2 * i).Value)
                {
                    nodes[i] = nodes.ElementAt(2 * i);
                    nodes[2 * i] = current;

                    indexes[Convert.ToInt32(current.Key)] = nodes.IndexOf(current);
                    indexes[Convert.ToInt32(nodes.ElementAt(i).Key)] = nodes.IndexOf(nodes.ElementAt(i));
                    i = i * 2;
                    HeapifyDown(i);
                }
            }


            //private class PriorityQueue2
            //{
            //    private Dictionary<string, double> ar;


            //    public PriorityQueue2()
            //    {
            //        ar = new Dictionary<string, double>();

            //    }

            //    public bool IsEmpty()
            //    {
            //        if (ar.Count == 0)
            //        {
            //            return true;
            //        }
            //        return false;
            //    }

            //    public void InsertOrChange(string v, double w)
            //    {
            //        try
            //        {
            //            ar.Add(v, w);
            //        }
            //        catch (ArgumentException e)
            //        {
            //            ar[v] = w;
            //        }
            //    }

            //    public string DeleteMax()
            //    {
            //        //double max = ar.Values.First();
            //        //string maxKey = ar.Keys.First();
            //        //foreach (KeyValuePair<string, double> kvp in ar)
            //        //{
            //        //    if (kvp.Value > max)
            //        //    {
            //        //        max = kvp.Value;
            //        //        maxKey = kvp.Key;
            //        //    }
            //        //}
            //        //ar.Remove(maxKey);
            //        //return maxKey;

            //        double max = ar.Max(kvp => kvp.Value);
            //        return ar.Where(kvp => kvp.Value == max).First().Key;
            //    }
            //}
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

            public double GetFactor()
            {
                return weight;
            }
        }
    }

}
