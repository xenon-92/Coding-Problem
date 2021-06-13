using System;

namespace L3_powerof2
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var res = s.IsPowerof2(68);
            var res1 = s.IsPowerof2_Efficient(68);
            System.Console.WriteLine(res + " " + res1);
        }
    }


    class Solution
    {
        // if we see the binary repsention for power of 2 
        // there exists only one set bit and rest all are unset bits.
        // we apply Brian Kerningam's algorithm to check the number of bits present.
        //if the count of set bit is 1, we return true
        // remember 2^0 = 1
        public bool IsPowerof2(int n)
        {
            if (n == 0) return false;
            int res = 0;
            while (n > 0)
            {
                res += 1;
                n = n & (n - 1);
            }
            return res == 1 ? true : false;
        }

        // it based on Brian Kerningam's algorithm
        // if a number is power of 2, it will have 1 set bit and that set bit will be as 
        // right as possible
        // if we do and with its n-1;
        // all the unset bit will be set and set bit will be unset,
        //producing a result of 0
        // 1 0 0 0 0  ---> 16
        // 0 1 1 1 1  ---> 15
        // result ==0 for 16 & 15

        // 1 0 0 1 0  ---> 18
        // 1 0 0 0 1  ---> 17
        // result != 0 for 18 & 17
        public bool IsPowerof2_Efficient(int n)
        {
            if (n == 0) return false;
            return (n & (n - 1)) == 0;
        }
    }
}
