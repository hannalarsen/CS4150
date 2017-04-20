using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Salesman
    {
        int n;
        int[,] matrix;
        bool[] visited;
        int optimal;
        int lowerBound;
        int[] currentPath;
        static void Main(string[] args)
        {
            Salesman s = new Salesman();
            s.GetInfo();
            Console.WriteLine(s.MinCost());
        }

        public void GetInfo()
        {
            string line = "";
            string[] currentLine;
            int count = -1;
            while ((line = Console.ReadLine()) != null && line != "")
            {
                currentLine = line.Split();
                if (count == -1)
                {
                    n = Convert.ToInt32(currentLine[0]);
                    matrix = new int[n,n];
                    count++;
                    continue;
                }
                for (int i = 0; i < n; i++)
                {
                    matrix[count, i] = Convert.ToInt32(currentLine[i]);
                }
                count++;
            }
        }

        public int MinCost()
        {
            if (n == 2)
            {
                return matrix[0, 1] + matrix[1, 0];
            }
            currentPath = new int[n + 1];
            lowerBound = 0;
            for (int i = 0; i < n; i++)
            {
                lowerBound += FindMinEdge1(i) + FindMinEdge2(i);
            }
            lowerBound = Convert.ToInt32(lowerBound * 0.5);
            optimal = int.MaxValue;
            visited = new bool[n];
            visited[0] = true;
            Optimize(lowerBound, 0, 1, currentPath);
            return optimal;
        }

        private void Optimize(int currentBound, int currentWeight, int l, int[] path)
        {
            if (l == n)
            {
                int currentBest = currentWeight + matrix[path[n - 1], path[0]];
                if (currentBest < optimal)
                {
                    optimal = currentBest;
                }
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (path[l-1] != i && visited[i] == false)
                {
                    int t = currentBound;
                    currentWeight += matrix[path[l - 1], i];
                    if (l == 1)
                    {
                        currentBound -= ((FindMinEdge1(path[l - 1]) + FindMinEdge1(i)) / 2);
                    }
                    else
                    {
                        currentBound -= ((FindMinEdge2(path[l - 1]) + FindMinEdge1(i)) / 2);
                    }
                    if (currentBound + currentWeight < optimal)
                    {
                        path[l] = i;
                        visited[i] = true;
                        Optimize(currentBound, currentWeight, l + 1, path);
                    }
                    currentWeight -= matrix[path[l - 1], i];
                    currentBound = t;
                    visited[l] = false;
                }
            }
        }

        private int FindMinEdge1(int i)
        {
            int min = int.MaxValue;
            for (int j = 0; j < n; j++)
            {
                if (matrix[i,j] < min && i != j)
                {
                    min = matrix[i, j];
                }
            }
            return min;
        }

        private int FindMinEdge2(int i)
        {
            int f = int.MaxValue;
            int s = int.MaxValue;
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                {
                    continue;
                }
                if (matrix[i,j] <= f)
                {
                    s = f;
                    f = matrix[i, j];
                }
                else if (matrix[i,j] <= s && matrix[i,j] != f)
                {
                    s = matrix[i, j];
                }
            }
            return s;
        }
    }
}
