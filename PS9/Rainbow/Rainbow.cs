using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow
{
    class Rainbow
    {
        private int[] distance;
        private int N;
        public static void Main(string[] args)
        {
            Rainbow r = new Rainbow();
            r.GetInfo();
            r.MinPenalty();
        }

        public void GetInfo()
        {
            int count = 0;
            string line = "";
            int current = 0;
            while ((line = Console.ReadLine()) != null && line != "")
            {
                current = Convert.ToInt32(line);
                if (count == 0)
                {
                    N = current + 1;
                    distance = new int[N];
                    count++;
                }
                else
                {
                    distance[count - 1] = current;
                    count++;
                }
            }
        }

        public int MinPenalty()
        {
            int minPenalty = 0;
            for(int i = 0; i < distance.Length; i++)
            {
               
            }

            return minPenalty;
        }

    }
}
