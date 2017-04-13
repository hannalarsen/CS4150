using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpidermansWorkout
{
    class Spiderman
    {
        List<List<int>> workouts;
        StringBuilder sequence;
        int minHeight;
        int maxHeight;
        static void Main(string[] args)
        {
            Spiderman s = new Spiderman();
            s.GetInfo();
            foreach (List<int> l in s.workouts)
            {
                Console.WriteLine(s.OptimalSequence(l));
            }
        }

        public void GetInfo()
        {
            string line = "";
            string[] currentLine;
            int count = 0;
            workouts = new List<List<int>>();
            while ((line = Console.ReadLine()) != null && line != "")
            {
                currentLine = line.Split();
                if (count == 0 || count % 2 != 0)
                {
                    count++;
                    continue;
                }
                else
                {
                    List<int> seq = new List<int>();
                    foreach (string s in currentLine)
                    {
                        int i = Convert.ToInt32(s);
                        seq.Add(i);
                    }
                    workouts.Add(seq);
                    count++;
                }
            }
        }

        public StringBuilder OptimalSequence(List<int> seq) 
        {
            sequence = new StringBuilder();
            minHeight = 0;
            Dictionary<int, int> cache = new Dictionary<int, int>();
            foreach (int n in seq)
            {
                maxHeight += n;
            }
            if (seq.Count % 2 != 0)
            {
                sequence.Append("IMPOSSIBLE");
                return sequence;
            }
            else
            {
                Height(seq, 0, 0, cache);
                cache[0] = 0;
                for (int i = 0; i < cache.Count-1; i++)
                {
                    if (cache[i + 1] > cache[i])
                    {
                        sequence.Append("U");
                    }
                    else
                    {
                        sequence.Append("D");
                    }
                }
                return sequence;
            }

        }

        private int Height(List<int> l, int i , int h, Dictionary<int, int> cache)
        {
            int result;
            if(cache.TryGetValue(i, out result))
            {
                return result;
            }
            if (i == l.Count)
            {
                if (h == 0)
                {
                    cache[i] = 0;
                    return 0;
                }
                else
                {
                    return int.MaxValue;
                }
            }

            if (h - l[i] < 0)
            {
                h= Height(l, i + 1, h + l[i], cache) + l[i];
            }
            else if (h + l[i] > maxHeight/2)
            {
                h = Height(l, i + 1, h - l[i], cache) - l[i];               
            }
            else
            {
                Math.Min(Height(l, i + 1, h + l[i], cache), Height(l, i + 1, h - l[i], cache));           
            }
            cache[i] = h;
            minHeight = Math.Max(minHeight, h);
            return minHeight;
        }
    }
}
