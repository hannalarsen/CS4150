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
            int cost = 0;
            HashSet<int> visited = new HashSet<int>();
            if (n == 2)
            {
                return matrix[0, 1] + matrix[1, 0];
            }
            int i = 0;       
            int count = 0;
            visited.Add(i);
            while (count < n)
            {
                int minIndex = 0;
                int min = 1000;
                for (int j = 0; j < n; j++)
                {
                    if (count == n - 1)
                    {
                        cost += matrix[i, 0];
                        count++;
                        break;
                    }
                    if (j == i)
                    {
                        if (j == n-1)
                        {
                            cost += min;
                            i = minIndex;
                            visited.Add(minIndex);
                            count++;
                        }
                        continue;
                    }
                    if (matrix[i, j] < min)
                    {
                        if (visited.Contains(j))
                        {
                            continue;
                        }
                        min = matrix[i, j];
                        minIndex = j;
                    }
                    if (j == n - 1)
                    {
                        cost += min;
                        i = minIndex;
                        visited.Add(minIndex);
                        count++;
                    }
                }
            }
            return cost;
        }
    }
}
