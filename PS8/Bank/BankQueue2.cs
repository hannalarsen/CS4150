using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankQueue2
    {
        private List<Person> queue;
        private int T;
        public static void Main(string[] args)
        {
            BankQueue2 b = new BankQueue2();
            b.GetInfo2();
            Console.WriteLine(b.FindMax2().ToString());
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

            queue.Sort((i1, i2) => i2.GetPrice().CompareTo(i2.GetPrice()));

            foreach (Person p in queue)
            {
                if (timeElapsed < T)
                {
                    if (p.GetTime() <= timeElapsed)
                    {
                        sum += p.GetPrice();
                        timeElapsed++;
                    }
                }
            }
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
