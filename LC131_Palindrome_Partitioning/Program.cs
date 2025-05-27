public class LC131
{
    // This method checks if the substring of s from leftIndex to rightIndex (both inclusive) is a palindrome.
    public static bool isPalindrome(string s, int leftIndex, int rightIndex)
    {
        int left = leftIndex;
        int right = rightIndex;
        while (left < right)
        {
            if (s[left] != s[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
    public static void rSolve(string s, int cutIndex, IList<string> currList, IList<IList<string>> answer)
    {
        // base case
        if (cutIndex == s.Length)
        {
            answer.Add(new List<string>(currList));
            return;
        }
        // backtracking
        for (int i = cutIndex; i < s.Length; i++)
        {
            // Check if the substring of s from indices cutIndex to i (both inclusive) is a palindrome.
            if (LC131.isPalindrome(s, cutIndex, i))
            {
                currList.Add(s.Substring(cutIndex, i - cutIndex + 1)); // Note that this is the substring starting at cutIndex, and i characters long.
                // Recurse on the substring to the right of the cut.
                LC131.rSolve(s, i + 1, currList, answer);

                // Remove the last added string to currList.
                currList.RemoveAt(currList.Count - 1);
            }
        }
    }

    public static IList<IList<string>> Partition(string s)
    {
        int n = s.Length;
        // trivial case
        if (n == 1)
        {
            return new List<IList<string>> { new List<string> { s } };
        }
        IList<string> currList = new List<string>();
        IList<IList<string>> answer = new List<IList<string>>();
        LC131.rSolve(s, 0, currList, answer);
        return answer;
    }

    public static void printLists(IList<IList<string>> lists)
    {
        foreach (IList<string> innerList in lists)
        {
            Console.WriteLine(string.Join(", ", innerList));
        }
    }

    public static void test1()
    {
        Console.WriteLine("\nStarting test 1");
        string s = "a";
        IList<IList<string>> answer = LC131.Partition(s);
        LC131.printLists(answer);
        Console.WriteLine("Finished test 1\n");
    }
    
    public static void test2()
    {
        Console.WriteLine("\nStarting test 2");
        string s = "banana";
        IList<IList<string>> answer = LC131.Partition(s);
        LC131.printLists(answer);
        Console.WriteLine("Finished test 2\n");
    }

    public static void test3()
    {
        Console.WriteLine("\nStarting test 3");
        string s = "water";
        IList<IList<string>> answer = LC131.Partition(s);
        LC131.printLists(answer);
        Console.WriteLine("Finished test 3\n");
    }

    public static void test4()
    {
        Console.WriteLine("\nStarting test 4");
        string s = "halloween";
        IList<IList<string>> answer = LC131.Partition(s);
        LC131.printLists(answer);
        Console.WriteLine("Finished test 4\n");
    }

    public static void test5()
    {
        Console.WriteLine("\nStarting test 5");
        string s = "tattoo";
        IList<IList<string>> answer = LC131.Partition(s);
        LC131.printLists(answer);
        Console.WriteLine("Finished test 5\n");
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("----------STARTING TESTS----------");

        LC131.test1();
        LC131.test2();
        LC131.test3();
        LC131.test4();
        LC131.test5();

        Console.WriteLine("----------FINISHED TESTS----------");
    }
}