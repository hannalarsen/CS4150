using System;
using System.Collections;
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
                        Console.WriteLine(GCD(a, b).ToString());
                        break;
                    case "exp":
                        a = Convert.ToInt64(currentLine[1]);
                        b = Convert.ToInt64(currentLine[2]);
                        N = Convert.ToInt64(currentLine[3]);
                        Console.WriteLine(Exp(a, b, N).ToString());
                        break;
                    case "inverse":
                        a = Convert.ToInt64(currentLine[1]);
                        N = Convert.ToInt64(currentLine[2]);
                        Console.WriteLine(Inverse(a, N));
                        break;
                    case "isprime":
                        a = Convert.ToInt64(currentLine[1]);
                        Console.WriteLine(IsPrime(a));
                        break;
                    case "key":
                        a = Convert.ToInt64(currentLine[1]);
                        b = Convert.ToInt64(currentLine[2]);
                        //Console.WriteLine(RSAKey(a, b));
                        break;
                }
            }
        }

        /// <summary>
        /// Prints the greatest common divisor of a and b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public long GCD(long a, long b)
        {
            long result = 0;

            while (b > 0)
            {
                result = a % b;
                a = b;
                b = result;
            }
            return a;
        }

        /// <summary>
        /// Prints x^y mod N, which must be non-negative and less than N
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="N"></param>
        public long Exp(long x, long y, long N)
        {
            //long result = 1;
            //byte[] bytes = BitConverter.GetBytes(y);
            //BitArray bits = new BitArray(bytes.GroupBy(.ToArray());
            //foreach(bool b in bits)
            //{
            //    if (b == true)
            //    {
            //        result = x * (result ^ 2) % N;
            //    }
            //    else
            //    {
            //        result = (result ^ 2) % N;
            //    }
            //}
            long result;
            if (y == 0)
                return 1;
            else
            {
                result = Exp(x, (y / 2), N);
                if ((y % 2) == 0)
                {
                    return (result*result) % N;
                }
                else
                {
                    return (x * (result*result)) % N;
                }
            }
            //return result;
        }

        /// <summary>
        /// Prints a^-1 mod N, which must be non-negative and less than N.
        /// If the inverse does not exist, print "none".
        /// </summary>
        /// <param name="a"></param>
        /// <param name="N"></param>
        public string Inverse(long a, long N)
        {
            long[] eeResults = new long[3];
            eeResults = ExtendedEuclids(a, N);

            if (eeResults[2] == 1)
            {
                return (eeResults[0] % N).ToString();
            }
            else
            {
                return "none";
            }
        }

        private long[] ExtendedEuclids(long a, long b)
        {
            long[] result = new long[3];
            long[] temp = new long[3];
            if (b == 0)
            {
                result[0] = 1;
                result[1] = 0;
                result[2] = a;
                return result;
            }
            else
            {
                temp = ExtendedEuclids(b, (a % b));
                result[0] = temp[1];
                result[1] = temp[0] - (a / b) * temp[1];
                result[2] = temp[2];
                return result;
            }
        }

        /// <summary>
        /// Print “yes” if p passes the Fermat test for a=2, a=3, and a = 5
        /// Prints “no” otherwise.
        /// </summary>
        /// <param name="a"></param>
        public string IsPrime(long a)
        {
            string result = "no";
            return result;
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
            
        }
    }
}
