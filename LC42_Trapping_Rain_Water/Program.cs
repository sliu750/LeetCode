public class LC42
{
    public static int Trap(int[] height)
    {
        int n = height.Length;
        // trivial case- we need at least 3 bars to trap water (with 2 of them being the boundaries)
        if (n < 3)
        {
            return 0;
        }

        int leftIndex = 0;
        int rightIndex = n - 1;
        int leftMaxHeight = -1;
        int rightMaxHeight = -1;

        int trappedWaterAmount = 0;
        while (rightIndex > leftIndex)
        {
            if (height[leftIndex] <= height[rightIndex])
            {
                // Either update leftMaxHeight, or update amount of water trapped.
                if (height[leftIndex] > leftMaxHeight)
                {
                    leftMaxHeight = height[leftIndex];
                }
                else
                {
                    trappedWaterAmount += leftMaxHeight - height[leftIndex];
                }
                leftIndex++;
            }
            else
            {
                // Either update rightMaxHeight, or update amount of water trapped.
                if (height[rightIndex] > rightMaxHeight)
                {
                    rightMaxHeight = height[rightIndex];
                }
                else
                {
                    trappedWaterAmount += rightMaxHeight - height[rightIndex];
                }
                rightIndex--;
            }
        }

        return trappedWaterAmount;
    }

    public static void test1()
    {
        Console.WriteLine("\nStarting test 1");
        int[] height = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
        int amountTrapped = LC42.Trap(height);
        Console.WriteLine(amountTrapped);
        Console.WriteLine("Finished test 1\n");
    }

    public static void test2()
    {
        Console.WriteLine("\nStarting test 2");
        int[] height = [4, 2, 0, 3, 2, 5];
        int amountTrapped = LC42.Trap(height);
        Console.WriteLine(amountTrapped);
        Console.WriteLine("Finished test 2\n");
    }

    public static void test3()
    {
        Console.WriteLine("\nStarting test 3");
        int[] height = [2, 1, 4, 0, 0, 0, 6, 2, 4, 2, 3, 1, 3, 2, 6];
        int amountTrapped = LC42.Trap(height);
        Console.WriteLine(amountTrapped);
        Console.WriteLine("Finished test 3\n");
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("----------STARTING TESTS----------");

        LC42.test1();
        LC42.test2();
        LC42.test3();

        Console.WriteLine("----------FINISHED TESTS----------");
    }
}


