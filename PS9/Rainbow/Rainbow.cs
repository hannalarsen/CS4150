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
            int minPenalty = Int32.MaxValue;
            for (int i = 0; i < N; i++)
            {
                minPenalty = Math.Min(minPenalty, Penalty(i, cache));
            }
            return minPenalty;
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

            int minPenalty = Int32.MaxValue;
            int currentMin = Int32.MaxValue;
            int c = 0;
            for (int j = i+1; j < distance.Length; j++)
            {
                int d = distance[j] - distance[i];
                c = (400 - d) * (400 - d);
                if (c < minPenalty)
                {
                    //currentMin = c;
                    minPenalty = Math.Min(minPenalty, Penalty(j, cache));
                }
            }
            cache[i] = minPenalty + c;
            return minPenalty + c;
        }
    }
}
