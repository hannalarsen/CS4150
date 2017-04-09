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
            if (Height(seq,0, sequence) == 0)
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

        private int Height(List<int> l, int i, StringBuilder s)
        {
            heightAbove = 0;
            for (int j = i; j < l.Count; j++)
            {
                if (heightAbove == 0)
                {
                    heightAbove += l[j];
                    s.Append("U");
                }
                else if (j == l.Count - 1)
                {
                    heightAbove -= l[j];
                    s.Append("D");
                }
                else
                {
                    int p1 = heightAbove + l[j];
                    int p2 = heightAbove - l[j];
                    if (p2 < 0)
                    {
                        heightAbove = p1;
                        s.Append("U");
                    }
                    else
                    {
                        heightAbove = p2;
                        s.Append("D");
                    }
                }
            }
            return heightAbove;
        }
    }
}
