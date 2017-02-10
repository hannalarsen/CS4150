using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AutoSink;

namespace AutoSinkTests
{
    [TestClass]
    public class Tests
    {
        Dictionary<string, int> cities;
        List<string> highwayStart;
        List<string> highwayEnd;
        List<string> tripStart;
        List<string> tripEnd;
        [TestMethod]
        public void Test1()
        {
            Map a = new Map();
            cities = new Dictionary<string, int>();
            highwayStart = new List<string>();
            highwayEnd = new List<string>();
            tripStart = new List<string>();
            tripEnd = new List<string>();
            cities.Add("Sourceville", 5);
            cities.Add("sinkcity", 10);
            cities.Add("easton", 20);
            cities.Add("weston", 15);
            highwayStart.Add("Sourceville");
            highwayStart.Add("Sourceville");
            highwayStart.Add("weston");
            highwayStart.Add("aaston");
            highwayEnd.Add("easton");
            highwayEnd.Add("weston");
            highwayEnd.Add("sinkcity");
            highwayEnd.Add("sinkcity");
            tripStart.Add("Sourceville");
            tripStart.Add("easton");
            tripStart.Add("sinkcity");
            tripStart.Add("weston");
            tripStart.Add("weston");
            tripStart.Add("sinkcity");
            tripEnd.Add("sinkcity");
            tripEnd.Add("sinkcity");
            tripEnd.Add("sinkcity");
            tripEnd.Add("weston");
            tripEnd.Add("Sourceville");
            tripEnd.Add("Sourceville");ss
            a.CreateGraph();
            Assert.AreEqual("25", a.FindMinToll(tripStart, tripEnd)[0]);
            Assert.AreEqual("10", a.FindMinToll(tripStart, tripEnd)[1]);
            Assert.AreEqual("0", a.FindMinToll(tripStart, tripEnd)[2]);
            Assert.AreEqual("0", a.FindMinToll(tripStart, tripEnd)[3]);
            Assert.AreEqual("NO", a.FindMinToll(tripStart, tripEnd)[4]);
            Assert.AreEqual("NO", a.FindMinToll(tripStart, tripEnd)[5]);
        }
    }
}
