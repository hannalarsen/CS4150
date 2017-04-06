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
    }
}
