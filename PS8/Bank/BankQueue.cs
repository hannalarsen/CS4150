
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Bank
//{
//    class BankQueue
//    {
//        private List<int>[] data;
//        private int T;
//        static void Main(string[] args)
//        {
//            BankQueue b = new BankQueue();
//            b.GetInfo();
//            Console.WriteLine(b.FindMax().ToString());
//        }

//        public void GetInfo()
//        {
//            string line = "";
//            string[] currentLine;
//            int count = 0;
//            int N = 0;
//            T = 0;
//            int c = 0;
//            int t = 0;

//            while ((line = Console.ReadLine()) != null && line != "")
//            {
//                currentLine = line.Split();
//                if (count == 0)
//                {
//                    N = Convert.ToInt32(currentLine[0]);
//                    T = Convert.ToInt32(currentLine[1]);
//                    data = new List<int>[T];
//                    count++;
//                    continue;
//                }

//                c = Convert.ToInt32(currentLine[0]);
//                t = Convert.ToInt32(currentLine[1]);

//                if (data[t] == null)
//                {
//                    data[t] = new List<int>();
//                }
//                data[t].Add(c);
//                count++;

//                if(count > N)
//                {
//                    break;
//                }
//            }
//        }

//        public int FindMax()
//        {
//            int sum = 0;
//            int timeElapsed = 0;
//            int currentIndex = 0;
//            int j = 0;
//            int longest = data[0].Count;
//            int longestIndex = 0;

//            for (int i = 0; i < data.Length; i++)
//            {
//                if (data[i] != null)
//                {
//                    data[i].Sort(new Comparison<int>((i1, i2) => i2.CompareTo(i1)));
//                }

//                if(data[i] != null && data[i].Count > longest)
//                {
//                    longest = data[i].Count - 1;
//                    longestIndex = i;
//                }
//            }

//            while (timeElapsed <= T)
//            {
//                if (currentIndex == data.Length)
//                {
//                    currentIndex = timeElapsed;
//                    j++;
//                }

//                if (j > longest)
//                {
//                    break;
//                }

//                if (data[currentIndex] == null || data[currentIndex].Count == 0)
//                {
//                    currentIndex++;
//                    continue;
//                }

//                sum += data[currentIndex][0];
//                data[currentIndex].RemoveAt(0);
//                timeElapsed++;
//                currentIndex++;
                 
//            }

//            return sum;
//        }
//    }
//}
