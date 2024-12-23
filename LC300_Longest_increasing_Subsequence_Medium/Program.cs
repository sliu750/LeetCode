using System;

namespace LC300
{
    class Program
    {
        static int LengthOfLIS(int[] nums) 
        {
            int[] lis = new int[nums.Length];
            lis[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                lis[i] = nums[i] > nums[i - 1] ? lis[i - 1] + 1 : lis[i - 1];
            }
            return lis[nums.Length - 1];
        }

        static void Main(string[] args)
        {
            Console.WriteLine("STARTING");

            Console.Write("\nTest Case 1: ");
            int[] arr1 = [4,10,4,3,8,9];
            int lengthOfLIS1 = LengthOfLIS(arr1);
            Console.WriteLine(lengthOfLIS1);

            Console.WriteLine("\nFINISHED");
        }

    }
}

