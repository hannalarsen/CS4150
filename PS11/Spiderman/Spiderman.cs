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
        int heightAbove;
        int minHeight;
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
            heightAbove = 0;
            minHeight = 0;
            Dictionary<int, int> cache = new Dictionary<int, int>();
            if (seq.Count % 2 != 0)
            {
                sequence.Append("IMPOSSIBLE");
                return sequence;
            }
            if (Height(seq, 0, 0, sequence, cache) == 0)
            {
                return sequence;
            }
            else
            {
                sequence.Clear();
                sequence.Append("IMPOSSIBLE");
                return sequence;
            }
        }

        private int Height(List<int> l, int i , int h, StringBuilder s, Dictionary<int, int> cache)
        {
            int result;
            if(cache.TryGetValue(i, out result))
            {
                return result;
            }
            if (i == l.Count - 1)
            {
                h -= l[i];
                cache[i] = h;
                return h;
            }
                if (h == 0 || h - l[i] < 0)
                {
                    h += l[i];
                    cache[i] = h;
                    return Height(l, i + 1, h, s, cache);
                }
                else
                {
                int p1 = Height(l, i + 1, h + l[i], s, cache);
                int p2 = Height(l, i + 1, h - l[i], s, cache);
                return Math.Min(p1, p2);
                }
        }
    }
}
