using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankQueue
{
    class Program
    {
        int N;
        int T;
        MaxHeap queue;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.GetInfo();
            Console.WriteLine(p.FindMax().ToString());
        }

        public void GetInfo()
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
                    queue = new MaxHeap();
                    count++;
                    continue;
                }

                c = Convert.ToInt32(currentLine[0]);
                t = Convert.ToInt32(currentLine[1]);

                p = new Person(c, t);
                queue.Add(p);
            }
        }

        public int FindMax()
        {
            int timeLeft = T;
            int currentTime = 0;
            int timeElapsed = 0;
            int sum = 0;
            Person current;

            while (timeLeft >= 0 && queue.Count() > 0)
            {
                current = queue.DeleteMax();
                currentTime = current.GetTime();
                timeLeft--;
                sum += current.GetPrice();
                timeElapsed++;
                if (currentTime <= timeElapsed)
                {
                    queue.DeleteInvalid(timeElapsed);

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

    class MaxHeap
    {
        List<Person> nodes;

        public MaxHeap()
        {
            nodes = new List<Person>();
        }

        public int Count()
        {
            return nodes.Count;
        }

        public void Add(Person p)
        {
            int size = nodes.Count;
            nodes.Add(p);
            size++;

            if (size > 1)
            {
                HeapifyUp(size - 1);
            }
        }

        private void HeapifyUp(int i)
        {
            while (i > 0)
            {
                int iParent = (i - 1) / 2;
                if (nodes[i].GetPrice() > nodes[iParent].GetPrice())
                {
                    Swap(i, iParent);
                    i = iParent;
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(int p1, int p2)
        {
            Person temp = nodes[p1];
            nodes[p1] = nodes[p2];
            nodes[p2] = temp;
        }

        public Person DeleteMax()
        {
            Person max = nodes[0];
            nodes[0] = nodes[nodes.Count - 1];
            nodes.RemoveAt(nodes.Count - 1);
            HeapifyDown(0);
            return max;
        }

        public void DeleteInvalid(int t)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].GetTime() <= t)
                {
                    nodes.RemoveAt(i);
                }
            }
            HeapifyUp(nodes.Count - 1);
        }

        private void HeapifyDown(int n)
        {

            if (n >= nodes.Count)
            {
                return;
            }

            while (true)
            {
                int largest = n;
                int left = 2 * n + 1;
                int right = 2 * n + 2;

                if (left < nodes.Count && (nodes[largest].GetPrice() < nodes[left].GetPrice()))
                {
                    largest = left;
                }

                if (right < nodes.Count && (nodes[largest].GetPrice() < nodes[right].GetPrice()))
                {
                    largest = right;
                }

                if (largest != n)
                {
                    Swap(largest, n);
                    n = largest;
                }
                else
                {
                    break;
                }
            }

        }
    }


}
