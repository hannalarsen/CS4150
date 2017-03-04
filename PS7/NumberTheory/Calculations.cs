using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    class Calculations
    {
        static void Main(string[] args)
        {
            Calculations c = new Calculations();
            c.GetInfo();
        }

        public void GetInfo()
        {
            long a = 0;
            long b = 0;
            long N = 0;

            string line = "";
            string[] currentLine;
            string calculation;
            
            while ((line = Console.ReadLine()) != null && line !="")
            {
                currentLine = line.Split();
                calculation = currentLine[0];

                switch (calculation)
                {
                    case "gcd":
                        a = Convert.ToInt64(currentLine[1]);
                        b = Convert.ToInt64(currentLine[2]);
                        GCD(a, b);
                        break;
                    case "exp":
                        a = Convert.ToInt64(currentLine[1]);
                        b = Convert.ToInt64(currentLine[2]);
                        N = Convert.ToInt64(currentLine[3]);
                        Exp(a, b, N);
                        break;
                    case "inverse":
                        a = Convert.ToInt64(currentLine[1]);
                        N = Convert.ToInt64(currentLine[2]);
                        Inverse(a, N);
                        break;
                    case "isprime":
                        a = Convert.ToInt64(currentLine[1]);
                        IsPrime(a);
                        break;
                    case "key":
                        a = Convert.ToInt64(currentLine[1]);
                        b = Convert.ToInt64(currentLine[2]);
                        RSAKey(a, b);
                        break;
                }
            }
        }

        /// <summary>
        /// Prints the greatest common divisor of a and b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void GCD(long a, long b)
        {
            long result = 0;

            while (b > 0)
            {
                result = a % b;
                a = b;
                b = result;
            }
            Console.WriteLine(a.ToString());
        }

        /// <summary>
        /// Prints x^y mod N, which must be non-negative and less than N
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="N"></param>
        public void Exp(long x, long y, long N)
        {
            long result = 0;
            Console.WriteLine(result.ToString());
        }

        /// <summary>
        /// Prints a^-1 mod N, which must be non-negative and less than N.
        /// If the inverse does not exist, print "none".
        /// </summary>
        /// <param name="a"></param>
        /// <param name="N"></param>
        public void Inverse(long a, long N)
        {
            long result = 0;
            Console.WriteLine(result.ToString());
        }

        /// <summary>
        /// Print “yes” if p passes the Fermat test for a=2, a=3, and a = 5
        /// Prints “no” otherwise.
        /// </summary>
        /// <param name="a"></param>
        public void IsPrime(long a)
        {
            string result = "no";
            Console.WriteLine(result);
        }

        /// <summary>
        /// Print the modulus, public exponent, and private exponent of the RSA key pair 
        /// derived from p and q. The public exponent must be the smallest positive integer that works; 
        /// q must be positive and less than N.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void RSAKey(long p, long q)
        {
            long[] results = new long[3];
            foreach(long r in results)
            {
                Console.Write(r.ToString() + " ");
            }
        }
    }
}
