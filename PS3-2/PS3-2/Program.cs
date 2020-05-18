using System;

namespace PS3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { 2,5,7,22};
            int[] B = new int[] { 7,8,9,15};

            int K = 5;

            Console.WriteLine(Select(A, B, K));

            Console.Read();

        }

        private static int Select(int[] A, int[] B, int K)
        {
            return Select(A, 0, A.Length - 1, B , 0, B.Length - 1, K);
        }

        private static int Select(int[] A, int loA, int hiA, int[] B, int loB, int hiB, int K)
        {
            if (hiA < loA)
                return B[K - loA];
            if (hiB < loB)
                return A[K - loB];

            int i = (loA + hiA) / 2;
            int j = (loB + hiB) / 2;

            if (A[i] > B[j])
            {
                if (K <= i + j)
                    return Select(A, loA, i-1, B, loB, hiB, K);
                else
                    return Select(A, loA, hiA, B, j+1, hiB, K);
            }
            else
            {
                if (K <= i + j)
                    return Select(A, loA, hiA, B, loB, j-1, K);
                else        
                    return Select(A, i+1, hiA, B, loB, hiB, K);
            }
        }
    }
}
     