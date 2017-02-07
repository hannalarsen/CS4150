using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 2, 10, 7, 1 };
            MergeSort(a);
        }

        public static void MergeSort(int[] A)
        {
            MergeSort(A, 0, A.Length - 1);
        }

        public static int[] MergeSort(int[] ar, int lo, int hi)
        {
            int mid = 0;
            if (hi - lo >= 1)
            {
                mid = (lo + hi) / 2;


                MergeSort(ar, lo, mid);
                MergeSort(ar, mid + 1, hi);
            }
            if (ar[mid] > ar[mid + 1])
            {
                merge(ar, lo, mid, hi);
            }
            return ar;  
        }

        private static int[] merge(int[] a, int lo, int mid, int hi)
        {
            int[] b = new int[hi + 1];
            int k = 0;
            int i = k = lo;
            int j = mid + 1;
            while (i <= mid && j <= hi) {
                if (a[i] <= a[j])
                {
                    b[k++] = b[i++];
                }
                else
                { b[k++] = a[j++]; }
            }
            while (i <= mid) {
                b[k++] = a[i++];
            }
            while (j <= hi)
            {
                b[k++] = a[j++];
            }
            for (i = lo; i <= hi; i++)
            { a[i] = b[i];
            }
            return a;
        }
    }
}
