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
        private int minPenalty;
        private int currentPenalty;
        public static void Main(string[] args)
        {
            Rainbow r = new Rainbow();
            r.GetInfo();
            Console.WriteLine(r.MinPenalty());
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
            Dictionary<int, int> cache = new Dictionary<int, int>();
            //minPenalty = Int32.MaxValue;
            return Penalty(0, cache);
        }

        private int Penalty(int i, Dictionary<int, int> cache)
        {
            int result;
            if (cache.TryGetValue(i, out result))
            {
                return result;
            }
            if (i + 1 == N)
            {
                cache[i] = 0;
                return 0;
            }
            minPenalty = Int32.MaxValue;
           for (int j = i + 1; j < N; j++)
            {
                int d = distance[j] - distance[i];
                int p = (400 - d) * (400 - d);
                currentPenalty = p + Penalty(j, cache);
                if (j == i + 1)
                {
                    minPenalty = currentPenalty;
                }
                else
                {
                    minPenalty = Math.Min(minPenalty, currentPenalty);
                }
                
            }
            
            cache[i] = minPenalty;
            return minPenalty;
        }
    }
}
