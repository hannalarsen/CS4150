using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2
{
    class Program
    {
        private List<Person> queue;
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
                int N = 0;
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

            queue.Sort((i1, i2) => i2.GetPrice().CompareTo(i1.GetPrice()));
            List<Person> optimal = new List<Person>();
            for(int i = 0; i < T; i++)
            {
                if (i >= queue.Count)
                {
                    break;
                }
                optimal.Add(queue[i]);
            }

            optimal.Sort((p1, p2) => (p1.GetTime().CompareTo(p2.GetTime())));
            foreach (Person p in optimal)
            {
                if (p.GetTime() >= timeElapsed)
                {
                    sum += p.GetPrice();
                    timeElapsed++;
                }
            }
            //queue.Sort(delegate (Person p1, Person p2)
            //{
            //    int comparePrice = p1.GetTime().CompareTo(p2.GetTime());
            //    if (comparePrice == 0)
            //    {
            //        return p2.GetPrice().CompareTo(p1.GetPrice());
            //    }
            //    return comparePrice;
            //});

                //foreach (Person p in queue)
                //{
                //    if (timeElapsed < T)
                //    {
                //        if (p.GetTime() >= timeElapsed)
                //        {
                //            sum += p.GetPrice();
                //            timeElapsed++;
                //        }
                //    }
                //}
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

