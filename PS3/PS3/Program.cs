using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS3
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            int[] A = { 1, 5, 8, 9, 10, 12, 20 };
            int[] B = { 2, 6, 8, 10, 15, 30, 42 };
            p.select(A, B, 10);
        }

        // A and B are each sorted into ascending order, and 0 <= k < |A|+|B| 
        // Returns the element that would be stored at index k if A and B were
        // combined into a single array that was sorted into ascending order.
        public int select(int[] A, int[] B, int k)
        {
            return select(A, 0, A.Length -1, B, 0, B.Length -1, k);
        }

public int select(int[] A, int loA, int hiA, int[] B, int loB, int hiB, int k)
        {
            // A[loA..hiA] is empty
            if (hiA < loA)
                return B[k - loA];
            // B[loB..hiB] is empty
            if (hiB < loB)
                return A[k - loB];
            // Get the midpoints of A[loA..hiA] and B[loB..hiB]
            int i = (loA + hiA) / 2;
            int j = (loB + hiB) / 2;
    // Figure out which one of four cases apply
    if (A[i] > B[j])
                // left half
                if (k <= i + j)
                    return select(A, loA, i-1, B, j+1, hiB, k);
                else
                    // right half
                    return select(A, loA, hiA, B, j+1, hiB, k);
            else
        if (k <= i + j)
                // left half A
                return select(A, loA, i, B, loB, j-1, k);
            else
                // right half array A
                return select(A, i+1, hiA, B, j, hiB, k);
        }
    }
}
