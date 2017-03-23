﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2
{
    class Program
    {
        private List<Person> queue;
        private int N;
        private int T;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.GetInfo2();
            Console.WriteLine(p.FindMax2());
        }
            

            public void GetInfo2()
            {
                string line = "";
                string[] currentLine;
                int count = 0;
                N = 0;
                T = 0;
                int c = 0;
                int t = 0;
                Person p;

                while ((line = Console.ReadLine()) != null && line != "")
                {
                    currentLine = line.Split();
                    if (count == 0)
                    {
                        N = Convert.ToInt32(currentLine[0]);
                        T = Convert.ToInt32(currentLine[1]);
                        queue = new List<Person>();
                        count++;
                        continue;
                    }

                    c = Convert.ToInt32(currentLine[0]);
                    t = Convert.ToInt32(currentLine[1]);

                    p = new Person(c, t);
                    queue.Add(p);
                }
            }

        public int FindMax2()
        {
            int sum = 0;
            int timeElapsed = 0;

            queue.Sort((p1, p2) => (p2.GetPrice().CompareTo(p1.GetPrice())));
            List<Person> optimal = new List<Person>();
            for (int i = 0; i < queue.Count; i++)
            {
                if (i > T)
                {
                    break;
                }
                optimal.Add(queue[i]);
            }

            optimal.Sort((o1, o2) => o1.GetTime().CompareTo(o2.GetTime()));
            int minIndex = 0;
            for (int i = 0; i < optimal.Count; i++)
            {
               if (optimal[minIndex].GetPrice() > optimal[i].GetPrice())
                {
                    minIndex = i;
                }
                if (timeElapsed >= T && optimal[i].GetTime() > optimal[minIndex].GetTime())
                {
                    sum -= optimal[minIndex].GetPrice();
                    sum += optimal[i].GetPrice();
                }
                else if (optimal[i].GetTime() >= timeElapsed)
                {
                    sum += optimal[i].GetPrice();
                    timeElapsed++;
                }
            }
            //queue.Sort(delegate (Person p1, Person p2)
            //{
            //    int comparePrice = p2.GetTime().CompareTo(p1.GetTime());
            //    if (comparePrice == 0)
            //    {
            //        return p1.GetPrice().CompareTo(p2.GetPrice());
            //    }
            //    return comparePrice;
            //});
        
            return sum;
            }
        }

        class Person
        {
            int price;
            int time;
            public Person(int p, int t)
            {
                price = p;
                time = t;
            }

            public int GetPrice()
            {
                return price;
            }

            public int GetTime()
            {
                return time;
            }
        }

    }

