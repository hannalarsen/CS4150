using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS3;
using System.Collections.Generic;
using System.IO;

namespace GalaxyTests
{
    [TestClass]
    public class GalaxyTests
    {
        Galaxy g;
        List<Star> stars;

        [TestMethod]
        public void TestCorrect1()
        {
            g = new Galaxy();
            stars = new List<Star>();
            long galacticDiam = 0;
            string line = "";
            int count = 0;
            char[] whitespace = { ' ', '\t' };
            string[] currentLine;
            try
            {
                using (StreamReader sr = File.OpenText(@"C:\Users\hannal\Documents\PS3Tests\test1.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        currentLine = line.Split(whitespace);
                        if (count == 0)
                        {
                            galacticDiam = Convert.ToInt64(currentLine[0]);
                            count++;
                            continue;
                        }
                        Star s = new Star(currentLine[0], currentLine[1]);
                        stars.Add(s);
                    }
                }
            }
            catch (Exception e)
            { }
            Assert.AreEqual("NO", g.FindStarMajority(stars, galacticDiam));
        }

        [TestMethod]
        public void TestCorrect2()
        {
            g = new Galaxy();
            stars = new List<Star>();
            long galacticDiam = 0;
            string line = "";
            int count = 0;
            char[] whitespace = { ' ', '\t' };
            string[] currentLine;
            try
            {
                using (StreamReader sr = File.OpenText(@"C:\Users\hannal\Documents\PS3Tests\test2.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        currentLine = line.Split(whitespace);
                        if (count == 0)
                        {
                            galacticDiam = Convert.ToInt64(currentLine[0]);
                            count++;
                            continue;
                        }
                        Star s = new Star(currentLine[0], currentLine[1]);
                        stars.Add(s);
                    }
                }
            }
            catch (Exception e)
            { }
            Assert.AreEqual("4", g.FindStarMajority(stars, galacticDiam));
        }

        [TestMethod]
        public void TestCorrect3()
        {
            g = new Galaxy();
            stars = new List<Star>();
            long galacticDiam = 0;
            string line = "";
            int count = 0;
            char[] whitespace = { ' ', '\t' };
            string[] currentLine;
            try
            {
                using (StreamReader sr = File.OpenText(@"C:\Users\hannal\Documents\PS3Tests\test3.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        currentLine = line.Split(whitespace);
                        if (count == 0)
                        {
                            galacticDiam = Convert.ToInt64(currentLine[0]);
                            count++;
                            continue;
                        }
                        Star s = new Star(currentLine[0], currentLine[1]);
                        stars.Add(s);
                    }
                }
            }
            catch (Exception e)
            { }
            Assert.AreEqual("5", g.FindStarMajority(stars, galacticDiam));
        }

        [TestMethod]
        public void TestCorrect4()
        {
            g = new Galaxy();
            stars = new List<Star>();
            long galacticDiam = 0;
            string line = "";
            int count = 0;
            char[] whitespace = { ' ', '\t' };
            string[] currentLine;
            try
            {
                using (StreamReader sr = File.OpenText(@"C:\Users\hannal\Documents\PS3Tests\test4.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        currentLine = line.Split(whitespace);
                        if (count == 0)
                        {
                            galacticDiam = Convert.ToInt64(currentLine[0]);
                            count++;
                            continue;
                        }
                        Star s = new Star(currentLine[0], currentLine[1]);
                        stars.Add(s);
                    }
                }
            }
            catch (Exception e)
            { }
            Assert.AreEqual("5", g.FindStarMajority(stars, galacticDiam));
        }

        [TestMethod]
        public void TestAllInGalaxy()
        {
            g = new Galaxy();
            stars = new List<Star>();
            long galacticDiam = 0;
            string line = "";
            int count = 0;
            char[] whitespace = { ' ', '\t' };
            string[] currentLine;
            try
            {
                using (StreamReader sr = File.OpenText(@"C:\Users\hannal\Documents\PS3Tests\AllInGalaxy.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        currentLine = line.Split(whitespace);
                        if (count == 0)
                        {
                            galacticDiam = Convert.ToInt64(currentLine[0]);
                            count++;
                            continue;
                        }
                        Star s = new Star(currentLine[0], currentLine[1]);
                        stars.Add(s);
                    }
                }
            }
            catch (Exception e)
            { }
            Assert.AreEqual("10", g.FindStarMajority(stars, galacticDiam));
        }

        [TestMethod]
        public void TestNoneInGalaxy()
        {
            g = new Galaxy();
            stars = new List<Star>();
            long galacticDiam = 0;
            string line = "";
            int count = 0;
            char[] whitespace = { ' ', '\t' };
            string[] currentLine;
            try
            {
                using (StreamReader sr = File.OpenText(@"C:\Users\hannal\Documents\PS3Tests\NoneInGalaxy.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        currentLine = line.Split(whitespace);
                        if (count == 0)
                        {
                            galacticDiam = Convert.ToInt64(currentLine[0]);
                            count++;
                            continue;
                        }
                        Star s = new Star(currentLine[0], currentLine[1]);
                        stars.Add(s);
                    }
                }
            }
            catch (Exception e)
            { }
            Assert.AreEqual("NO", g.FindStarMajority(stars, galacticDiam));
        }

        [TestMethod]
        public void TestHalfInGalaxy()
        {
            g = new Galaxy();
            stars = new List<Star>();
            long galacticDiam = 0;
            string line = "";
            int count = 0;
            char[] whitespace = { ' ', '\t' };
            string[] currentLine;
            try
            {
                using (StreamReader sr = File.OpenText(@"C:\Users\hannal\Documents\PS3Tests\HalfInGalaxy.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        currentLine = line.Split(whitespace);
                        if (count == 0)
                        {
                            galacticDiam = Convert.ToInt64(currentLine[0]);
                            count++;
                            continue;
                        }
                        Star s = new Star(currentLine[0], currentLine[1]);
                        stars.Add(s);
                    }
                }
            }
            catch (Exception e)
            { }
            Assert.AreEqual("NO", g.FindStarMajority(stars, galacticDiam));
        }
    }
}
