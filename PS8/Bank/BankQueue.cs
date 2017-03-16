using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BankQueue
    {
        private List<int>[] data;
        static void Main(string[] args)
        {
        }

        public void GetInfo()
        {
            string line = "";
            string[] currentLine;
            int count = 0;
            int N = 0;
            int T = 0;
            int c = 0;
            int t = 0;

            while ((line = Console.ReadLine()) != null && line != "")
            {
                currentLine = line.Split();
                if (count == 0)
                {
                    N = Convert.ToInt32(currentLine[0]);
                    T = Convert.ToInt32(currentLine[1]);
                    data = new List<int>[T];
                    count++;
                    continue;
                }

                c = Convert.ToInt32(currentLine[0]);
                t = Convert.ToInt32(currentLine[1]);

                if (data[t] == null)
                {
                    data[t] = new List<int>();
                }
                data[t].Add(c);
                count++;

                if(count > N)
                {
                    break;
                }
            }
        }
    }
}
