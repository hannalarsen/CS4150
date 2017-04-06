using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery
{
    class Gallery
    {
        List<int[,]> galleries;
        List<int> kValues;
        int[,] g;
        int N;
        int k;
        static void Main(string[] args)
        {
            Gallery g1 = new Gallery();
            g1.GetInfo();
            for (int i = 0; i < g1.galleries.Count; i++)
            {
                Console.WriteLine(g1.MaxValue(g1.galleries[i], g1.kValues[i]));
            }
        }

        public void GetInfo()
        {
            string line = "";
            string[] currentLine;
            int count = 0;
            int i;
            int j;
            galleries = new List<int[,]>();
            kValues = new List<int>();
            while ((line = Console.ReadLine()) != null && line != "")
            {
                currentLine = line.Split();
                if (count == 0)
                {
                    N = Convert.ToInt32(currentLine[0]);
                    k = Convert.ToInt32(currentLine[1]);
                    kValues.Add(k);
                    g = new int[N,2];
                    count++;
                    continue;
                }
                if (count <= N)
                {
                    i = Convert.ToInt32(currentLine[0]);
                    j = Convert.ToInt32(currentLine[1]);
                    g[count - 1,0] = i;
                    g[count - 1, 1] = j;
                    count++;
                    continue;
                }
                if (count > N)
                {
                    galleries.Add(g);
                    count = 0;
                    continue;
                }
            }
        }
        //private int max;
        public int MaxValue(int[,] values, int k)
        {
            return MaxValue(values, 0, 1, k);
        }
        private int MaxValue(int[,] values, int r, int unClosable, int k)
        {
            if (r == N-1)
            {
                if (k == 0 || unClosable == -1)
                {
                    return values[r, 0] + values[r, 1];
                }
                else if (unClosable == 0)
                {
                    return values[r, 0];
                }
                else if (unClosable == 1)
                {
                    return values[r, 1];
                }
            }
            else {
                switch (unClosable)
                {
                    case 0:
                        {
                            if (k == N - r)
                            {
                                return values[r, 0] + MaxValue(values, r + 1, 0, k - 1);
                            }
                            else if (k < N - r)
                            {
                                return Math.Max((values[r, 0] + MaxValue(values, r + 1, 0, k - 1)),
                                    (values[r, 0] + values[r, 1] + MaxValue(values, r + 1, -1, k)));
                            }
                            break;
                        }
                    case 1:
                        {
                            if (k == N - r)
                            {
                                return values[r, 1] + MaxValue(values, r + 1, 1, k - 1);
                            }
                            else if (k < N - r)
                            {
                                return Math.Max((values[r, 1] + MaxValue(values, r + 1, 1, k - 1)),
                                    (values[r, 0] + values[r, 1] + MaxValue(values, r + 1, -1, k)));
                            }
                            break;
                        }
                    case -1:
                        {
                            if (k == N - r)
                            {
                                if (values[r, 0] >= values[r, 1])
                                {
                                    return values[r, 0] + MaxValue(values, r + 1, 0, k - 1);
                                }
                                else
                                {
                                    return values[r, 1] + MaxValue(values, r + 1, 1, k - 1);
                                }
                            }
                            else if (k < N - r)
                            {
                                int t1 = values[r, 0] + MaxValue(values, r + 1, 0, k - 1);
                                int t2 = values[r, 1] + MaxValue(values, r + 1, 1, k - 1);
                                int t3 = values[r, 0] + values[r, 1] + MaxValue(values, r + 1, -1, k);
                                return CompareVal(t1, t2, t3);
                            }
                            break;
                        }
                }
            }
            return 0;
        }

        private int CompareVal(int i, int j , int k)
        {
            int val = i;
            if (j > val)
            {
                val = j;
            }
            if (k > val)
            {
                val = k;
            }
            return val;
        }
    }
}
