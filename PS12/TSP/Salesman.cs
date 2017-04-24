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
            Console.WriteLine(s.MinWeight());
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

        public int MinWeight()
        {
            if (n == 2)
            {
                return matrix[0, 1] + matrix[1, 0];
            }

            int[] optPath = new int[n];
            int[] costs = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    optPath[j] = j;
                }
                if (i > 0)
                {
                    optPath = Swap(optPath, 0, i);
                }
                int optimalLength = int.MaxValue;
                costs[i] = optimalLength = CalcMinWeight(optPath, 0, 0, optimalLength);
            }
            return costs.Min();
        }

        private int CalcMinWeight(int[] A, int i, int lengthSoFar, int minLength)
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
                    if (i + 1 != j)
                    {
                        A = Swap(A, i + 1, j);
                    }
                    int length = lengthSoFar + matrix[A[i], A[i + 1]];
                    if (length >= minLength)
                    {
                        continue;
                    }
                    else
                    {
                        minLength = Math.Min(minLength, CalcMinWeight(A, i + 1, length, minLength));
                    }
                    if (i + 1 != j)
                    {
                        A = Swap(A, i + 1, j);
                    }
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
    }
}
