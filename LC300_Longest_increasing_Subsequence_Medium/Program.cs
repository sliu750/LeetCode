using System;

namespace LC300
{
    class Program
    {
        public static int LengthOfLIS(int[] nums) 
        {
            int[] lis = new int[nums.Length]; // lis[i] is the length of the longest increasing subsequence in nums ending at index i
            for (int i = 0; i < lis.Length; i++)
            {
                lis[i] = 1;
            }

            int maxLISLength = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i] && lis[j] + 1 > lis[i])
                    {
                        lis[i] = lis[j] + 1;
                    }
                }
                if (lis[i] > maxLISLength)
                {
                    maxLISLength = lis[i];
                }
            }
            return maxLISLength;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("STARTING");

            Console.Write("\nTest Case 1: ");
            int[] arr1 = [4, 10, 4, 3, 8, 9];
            int lengthOfLIS1 = LengthOfLIS(arr1);
            Console.WriteLine(lengthOfLIS1);

            Console.Write("\nTest Case 2: ");
            int[] arr2 = [1, 3, 2, 5, 5, 9, 7];
            int lengthOfLIS2 = LengthOfLIS(arr2);
            Console.WriteLine(lengthOfLIS2);

            Console.Write("\nTest Case 3: ");
            int[] arr3 = [7, 6, 5, 4, 3, 2, 1];
            int lengthOfLIS3 = LengthOfLIS(arr3);
            Console.WriteLine(lengthOfLIS3);

            Console.Write("\nTest Case 4: ");
            int[] arr4 = [100, 200, 300, 400, 500];
            int lengthOfLIS4 = LengthOfLIS(arr4);
            Console.WriteLine(lengthOfLIS4);

            Console.Write("\nTest Case 5: ");
            int[] arr5 = [10, 9, 2, 5, 3, 7, 101, 18];
            int lengthOfLIS5 = LengthOfLIS(arr5);
            Console.WriteLine(lengthOfLIS5);

            Console.WriteLine("\nFINISHED");
        }

    }
}

