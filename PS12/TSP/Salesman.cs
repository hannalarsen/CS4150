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
        //bool[] visited;
        //int optimal;
        //int lowerBound;
        //int count;
        //int[] currentPath;
        static void Main(string[] args)
        {
            Salesman s = new Salesman();
            s.GetInfo();
            Console.WriteLine(s.MinCost2());
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

        public int MinCost2()
        {
            if (n == 2)
            {
                return matrix[0, 1] + matrix[1, 0];
            }

            int[] optPath = new int[n];
            for (int i = 0; i < n; i++)
            {
                optPath[i] = i;
            }
            int optimalLength = int.MaxValue;
            optimalLength = CalcMinCost(optPath, 0, 0, optimalLength);
            return optimalLength;
            //int[] costs = new int[n];
            //for (int i = 0; i < n; i++)
            //{
            //    visited = new bool[n];
            //    lowerBound = 0;
            //    count = 0;
            //    costs[i] = CalculateCost2(i);
            //}
            //return costs.Min();
        }

        private int CalcMinCost(int[] A, int i, int lengthSoFar, int minLength)
        {
            if (i == n - 1)
            {
                minLength = Math.Min(minLength, lengthSoFar + matrix[A[n - 1], A[0]]);
                return minLength;
            }
            else
            {
                for (int j = i + 1; j < n; j++)
                {
                    A = Swap(A, A[i + 1], A[j]);
                    int length = lengthSoFar + matrix[A[i], A[i + 1]];
                    if (length >= minLength)
                    {
                        continue;
                    }
                    else
                    {
                        minLength = Math.Min(minLength, CalcMinCost(A, i + 1, length, minLength));
                    }
                    A = Swap(A, A[i + 1], A[j]);
                }
                return minLength;
            }
        }

        private int[] Swap(int[] A, int a1, int a2)
        {
            int temp = A[a1];
            A[a1] = A[a2];
            A[a2] = temp;
            return A;
        }
        //private int CalculateCost(int i)
        //{
        //    int cost = 0;
        //    int start = i;
        //    int currentMin = int.MaxValue;
        //    int nextIndex = i;
        //    int count = 0;
        //    visited = new bool[n];
        //    while (count < n)
        //    {
        //        visited[i] = true;
        //        if (count == n - 1)
        //        {
        //            cost += matrix[i, start];
        //            break;
        //        }
        //        for (int j = 0; j < n; j++)
        //        {
        //            if (j == i)
        //            {
        //                continue;
        //            }
        //            if (matrix[i,j] < currentMin && visited[j] == false)
        //            {
        //                currentMin = matrix[i, j];
        //                nextIndex = j;
        //            }
        //        }
        //        cost += currentMin;
        //        count++;
        //        currentMin = int.MaxValue;
        //        i = nextIndex;
        //    }
        //    return cost;
        //}

        //public int MinCost()
        //{
        //    if (n == 2)
        //    {
        //        return matrix[0, 1] + matrix[1, 0];
        //    }
        //    currentPath = new int[n + 1];
        //    lowerBound = 0;
        //    for (int i = 0; i < n; i++)
        //    {
        //        lowerBound += FindMinEdge1(i) + FindMinEdge2(i);
        //    }
        //    lowerBound = Convert.ToInt32(lowerBound * 0.5);
        //    optimal = int.MaxValue;
        //    visited = new bool[n];
        //    visited[0] = true;
        //    Optimize(lowerBound, 0, 1, currentPath);
        //    return optimal;
        //}

        //private void Optimize(int currentBound, int currentWeight, int l, int[] path)
        //{
        //    if (l == n)
        //    {
        //        int currentBest = currentWeight + matrix[path[n - 1], path[0]];
        //        if (currentBest < optimal)
        //        {
        //            optimal = currentBest;
        //        }
        //        return;
        //    }

        //    for (int i = 0; i < n; i++)
        //    {
        //        if (path[l-1] != i && visited[i] == false)
        //        {
        //            int t = currentBound;
        //            currentWeight += matrix[path[l - 1], i];
        //            if (l == 1)
        //            {
        //                currentBound -= ((FindMinEdge1(path[l - 1]) + FindMinEdge1(i)) / 2);
        //            }
        //            else
        //            {
        //                currentBound -= ((FindMinEdge2(path[l - 1]) + FindMinEdge1(i)) / 2);
        //            }
        //            if (currentBound + currentWeight < optimal)
        //            {
        //                path[l] = i;
        //                visited[i] = true;
        //                Optimize(currentBound, currentWeight, l + 1, path);
        //            }
        //            currentWeight -= matrix[path[l - 1], i];
        //            currentBound = t;
        //            visited[l] = false;
        //        }
        //    }
        //}

        //private int FindMinEdge1(int i)
        //{
        //    int min = int.MaxValue;
        //    for (int j = 0; j < n; j++)
        //    {
        //        if (matrix[i,j] < min && i != j)
        //        {
        //            min = matrix[i, j];
        //        }
        //    }
        //    return min;
        //}

        //private int FindMinEdge2(int i)
        //{
        //    int f = int.MaxValue;
        //    int s = int.MaxValue;
        //    for (int j = 0; j < n; j++)
        //    {
        //        if (i == j)
        //        {
        //            continue;
        //        }
        //        if (matrix[i,j] <= f)
        //        {
        //            s = f;
        //            f = matrix[i, j];
        //        }
        //        else if (matrix[i,j] <= s && matrix[i,j] != f)
        //        {
        //            s = matrix[i, j];
        //        }
        //    }
        //    return s;
        //}
    }
}
