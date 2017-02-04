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
            //List<Star> keptStars = new List<Star>();
            //Star y;
            //if (s.Count == 0)
            //{
            //    return "NO";
            //}
            //if (s.Count == 1)
            //{
            //    return "1";
            //}
            //else
            //{
            //    for (int i = 0; i < s.Count; i++)
            //    {
            //        int result1 = CalculateDistances(s.ElementAt(0), s.ElementAt(i), gD);
            //        if (result1 == 1)
            //        {
            //            keptStars.Add(s.ElementAt(i));
            //        }
            //    }
            //    //string x = FindStarMajority(keptStars, gD);
            //    if (keptStars.Count > (s.Count / 2))
            //    {
            //        starNumber = keptStars.Count.ToString();
            //    }
            //    if (starNumber == "NO")
            //    {
            //        keptStars = new List<Star>();
            //        if (s.Count % 2 > 0)
            //        {
            //            y = s.ElementAt(s.Count - 1);
            //            foreach (Star n in s)
            //            {
            //                int result2 = CalculateDistances(y, n, gD);
            //                if (result2 == 1)
            //                {
            //                    keptStars.Add(n);
            //                }
            //            }
            //        }               
            //    }
            //    if (keptStars.Count > (s.Count / 2))
            //    {
            //        starNumber = keptStars.Count.ToString();
            //    }
            //}
            //return starNumber;

            if(s.Count == 0)
            {
                return starNumber;
            }
            else if (s.Count == 1)
            {
                string MajorityStar = s.ElementAt(0).GetXCoord().ToString() + " " + s.ElementAt(0).GetYCoord().ToString();
                return MajorityStar;
            }
            else
            {
                List<Star> s1 = new List<Star>();
                List<Star> s2 = new List<Star>();
                for (int i = 0; i < s.Count/2; i++)
                {
                    s1.Add(s.ElementAt(i));
                }
                for(int j = s.Count/2; j < s.Count; j++)
                {
                    s2.Add(s.ElementAt(j));
                }
                string x = FindStarMajority(s1, gD);
                string y = FindStarMajority(s2, gD);
                char[] space = { ' ' };
                if (x == "NO" && y == "NO")
                {
                    return "NO";
                }

                else if (x == "NO")
                {
                    int count = 0;
                    string[] starCoords = y.Split(space);
                    Star yStar = new Star(starCoords[0], starCoords[1]);
                    foreach (Star n in s)
                    {
                        int result2 = CalculateDistances(yStar, n, gD);
                        if (result2 == 1)
                        {
                            count++;
                        }
                    }
                    if (count > s.Count / 2)
                    {
                        starNumber = count.ToString();
                        return y;
                    }
                    return starNumber;
                }
                else if (y == "NO") 
                {
                    int count = 0;
                    string[] starCoords = x.Split(space);
                    Star xStar = new Star(starCoords[0], starCoords[1]);
                    foreach (Star n in s)
                    {
                        int result2 = CalculateDistances(xStar, n, gD);
                        if (result2 == 1)
                        {
                            count++;
                        }
                    }
                    if (count > s.Count / 2)
                    {
                        starNumber = count.ToString();
                        return x;
                    }
                    return starNumber;
                }
                else
                {
                    int countX = 0;
                    int countY = 0;
                    string[] starCoordsX = x.Split(space);
                    string[] starCoordsY = x.Split(space);
                    Star xStar = new Star(starCoordsX[0], starCoordsX[1]);
                    Star yStar = new Star(starCoordsY[0], starCoordsY[1]);
                    foreach (Star n in s)
                    {
                        int resultX = CalculateDistances(xStar, n, gD);
                        int resultY = CalculateDistances(yStar, n, gD);
                        if (resultX == 1)
                        {
                            countX++;
                        }
                        if (resultY == 1)
                        {
                            countY++;
                        }
                    }
                    if (countX > s.Count/2)
                    {
                        starNumber = countX.ToString();
                        return x;
                    }
                    else if (countY > s.Count/2)
                    {
                        starNumber = countY.ToString();
                        return y;
                    }
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
            if ((xDist + yDist) <= (gD * gD))
            {
                return 1;
            }
            // If stars are in different galaxies
            else if ((xDist + yDist) > (gD * gD))
            {
                return 0;
            }
            return -1;            
        }
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
