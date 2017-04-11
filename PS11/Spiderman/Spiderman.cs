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
            Dictionary<int, int> cache = new Dictionary<int, int>();
            if (seq.Count % 2 != 0)
            {
                sequence.Append("IMPOSSIBLE");
                return sequence;
            }
            if (Height(seq, 0, sequence, cache) == 0)
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

        private int Height(List<int> l, int i, StringBuilder s, Dictionary<int, int> cache)
        {
            int result;
            if (cache.TryGetValue(i, out result))
            {
                return result;
            }

            int minHeight = Int32.MaxValue;
            for (int j = i; j < l.Count; j++)
            {
                if 
            }
            cache[i] = minHeight;
            return minHeight;
        }
    }
}
