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
        int heightAbove;
        StringBuilder sequence;
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
            heightAbove = 0;
            maxHeight = seq.Max();
            sequence = new StringBuilder();
            if (seq.Count % 2 != 0)
            {
                sequence.Append("IMPOSSIBLE");
                return sequence;
            }
            if (Height(seq, sequence) == 0)
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

        private int Height(List<int> l, StringBuilder s)
        {
            int uCount = 0;
            for (int i = 0; i < l.Count; i++)
            {
                if (heightAbove == 0)
                {
                    heightAbove += l[i];
                    s.Append("U");
                    uCount++;
                }
                else if (i == l.Count - 1)
                {
                    heightAbove -= l[i];
                    s.Append("D");
                }
                else if (heightAbove + l[i] > maxHeight)
                {
                    heightAbove -= l[i];
                    s.Append("D");
                }
                else if (uCount < l.Count/2)
                {
                    heightAbove += l[i];
                    s.Append("U");
                    uCount++;
                }
                else
                {
                    heightAbove -= l[i];
                    s.Append("D");
                }
            }
            return heightAbove;
        }
    }
}
