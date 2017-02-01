using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS3
{
    public class Galaxy
    {
        private static long galacticDiam;
        private string starNumber = "NO";
       

        static void Main(string[] args)
        {
            Galaxy g = new Galaxy();
            List<Star> st = g.GetStars();
            Console.WriteLine(g.FindStarMajority(st, galacticDiam));
        }

        public List<Star> GetStars()
        {
            List<Star> stars = new List<Star>();
            string line = "";
            int count = 0;
            char[] whitespace = { ' ', '\t' };
            string[] currentLine;
            try
            {
                while ((line = Console.ReadLine()) != null && line.Length > 0)
                {
                    currentLine = line.Split(whitespace);
                    if (count == 0)
                    {
                        galacticDiam = Convert.ToInt64(currentLine[0]);
                        count++;
                        continue;
                    }
                    Star s = new Star(currentLine.ElementAt(0), currentLine.ElementAt(1));
                    stars.Add(s);
                }
            }
            catch (Exception e)
            { }
            return stars;
        }

        public string FindStarMajority(List<Star> s, long gD)
        {
            List<Star> keptStars = new List<Star>();
            List<Star> discardedStars = new List<Star>();
            if (s.Count == 0)
            {
               return "NO";
            }
            if (s.Count == 1)
            {
                return "1";
            }
            else
            {
                for (int i = 0; i < s.Count; i++)
                {
                    int result = CalculateDistances(s.ElementAt(0), s.ElementAt(i), gD);
                    if (result == 1)
                    {
                        keptStars.Add(s.ElementAt(i));
                    }
                    else if (result == 0)
                    {
                        discardedStars.Add(s.ElementAt(0));
                        discardedStars.Add(s.ElementAt(1));
                    }
                }

                string x = FindStarMajority(discardedStars, gD);
                if(x == "NO")
                {

                }
                if (keptStars.Count > (s.Count / 2))
                {
                    starNumber = keptStars.Count.ToString();
                }
                else if (discardedStars.Count > (s.Count /2))
                {
                    starNumber = discardedStars.Count.ToString();
                }
            }
            return starNumber;
        }

        private int CalculateDistances(Star s1, Star s2, long gD)
        {
            long x1 = s1.GetXCoord();
            long y1 = s1.GetYCoord();
            long x2 = s2.GetXCoord();
            long y2 = s2.GetYCoord();
            long xDist = (x1 - x2) * (x1 - x2);
            long yDist = (y1 - y2) * (y1 - y2);
            

            // If star are in same Galaxy
            if ((xDist + yDist) <= (gD*gD))
            {
                return 1;
            }

            // If stars are in different galaxies
            else if ((xDist + yDist) > (gD*gD))
            {
                return 0;
            }

            return -1;
;        }
    }

   public class Star
    {
        long xCoord;
        long yCoord;

        public Star(string x, string y)
        {
            try
            {
                xCoord = Convert.ToInt64(x);
                yCoord = Convert.ToInt64(y);
            }
            catch (Exception e)
            { }
        }

        public long GetXCoord()
        {
            return xCoord;
        }

        public long GetYCoord()
        {
            return yCoord;
        }
    }



}
