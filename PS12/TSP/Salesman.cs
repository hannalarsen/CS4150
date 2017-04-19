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
        }

        public void GetInfo()
        {
            string line = "";
            string[] currentLine;
            int count = 0;
            while ((line = Console.ReadLine()) != null && line != "")
            {
                currentLine = line.Split();
                if (count == 0)
                {
                    n = Convert.ToInt32(currentLine[0]);
                    matrix = new int[n,n];
                    count++;
                    continue;
                }
                for (int i = 0; i < n; i++)
                {
                    matrix[count - 1, i] = Convert.ToInt32(currentLine[i]);
                }
                count++;
            }
        }
    }
}
