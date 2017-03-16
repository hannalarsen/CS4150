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
        int count;
        static void Main(string[] args)
        {
            Calculations c = new Calculations();
            //c.GetInfo();
            c.test(2, 32, 5);
            Console.WriteLine(c.count.ToString());
        }

        public int test(int x, int y, int N)
        {
            int result;
            count = 0;
            if (y == 0)
                return 1;
            else
            {
                result = test(x, (y / 2), N);
                if ((y % 2) == 0)
                {
                    count++;
                    return (result * result) % N;
                }
                else
                {
                    count = count + 2;
                    return (x * (result * result)) % N;
                }
            }
        }
        public void GetInfo()
        {
            long a = 0;
            long b = 0;
            long N = 0;

            string line = "";
            string[] currentLine;
            string calculation;

            while ((line = Console.ReadLine()) != null && line != "")
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
                        Console.WriteLine(RSAKey(a, b));
                        break;
                }
            }
        }

        private long Mod(long a, long m)
        {
            long remainder = a % m;
            if ((m > 0 && remainder < 0) || (m < 0 && remainder > 0))
                return remainder + m;
            return remainder;
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
            //ITERATIVE (v2)

            long result = 1;
            x = x % N;
            while (y > 0)
            {
                if (y % 2 != 0)
                {
                    result = (result * x) % N;
                }
                y = y >> 1;
                x = (x * x) % N;
            }
            return result;

            // ITERATIVE (v1)

            //long result = 1;
            //string bits = Convert.ToString(y, 2);
            //foreach (char b in bits)
            //{
            //    if (b == '1')
            //    {
            //        //result = x * (result * result) % N;
            //        result = Mod((x * (result * result)), N);

            //    }
            //    else
            //    {
            //        //result = (result * result) % N;
            //        result = Mod((result * result), N);
            //    }
            //}

            // RECURSIVE
        
            //long result;
            //if (y == 0)
            //    return 1;
            //else
            //{
            //    result = Exp(x, (y / 2), N);
            //    if ((y % 2) == 0)
            //    {
            //        return (result * result) % N;
            //    }
            //    else
            //    {
            //        return (x * (result * result)) % N;
            //    }
            //}
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
            if (GCD(a, N) != 1)
            {
                return "none";
            }
            else
            {
                long n = N;
                long temp;
                long quotient;
                long x0 = 0;
                long result = 1;

                if (N == 1)
                {
                    return "0";
                }

                while (a > 1)
                {
                    quotient = a / N;
                    temp = N;
                    N = a % N;
                    a = temp;
                    temp = x0;
                    x0 = result - quotient * x0;
                    result = temp;
                }

                if (result < 0)
                {
                    result += n;
                }
                return result.ToString();

            }

            //long[] eeResults = new long[3];
            //eeResults = ExtendedEuclids(a, N);

            //if (eeResults[2] == 1)
            //{
            //    return (eeResults[0] % N).ToString();
            //}
            //else
            //{
            //    return "none";
            //}
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
                temp = ExtendedEuclids(b, a % b);
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
        public string IsPrime(long N)
        {
            string result = "no";
            int prime = 0;
            
            if (Exp(2, (N-1), N) == (1 % N))
            {
                prime++;
            }
            if (Exp(3, (N - 1), N) == (1 % N))
            {
                prime++;
            }
            if (Exp(5, (N - 1), N) == (1 % N))
            {
                prime++;
            }

            if(prime == 3)
            {
                result = "yes";
            }
            return result;
        }

        /// <summary>
        /// Print the modulus, public exponent, and private exponent of the RSA key pair 
        /// derived from p and q. The public exponent must be the smallest positive integer that works; 
        /// q must be positive and less than N.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public StringBuilder RSAKey(long p, long q)
        {
            StringBuilder result = new StringBuilder();
            long N = p * q;
            result.Append(N.ToString() + " ");

            long phi = (p - 1) * (q - 1);
            long e = 2;
            while(e < phi)
            {
                if (GCD(e, phi) == 1)
                {
                    result.Append(e.ToString() + " ");
                    break;
                }
                else
                {
                    e++;
                }
            }
            result.Append(Inverse(e, phi));

            return result;
        }
    }
}
