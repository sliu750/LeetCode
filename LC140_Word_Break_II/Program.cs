public class LC140
{
    static int NUM_LETTERS = 26; // There are 26 lowercase letters in the English alphabet.

    // This method computes the hash of a string. For example, the hash of "cat" is c * 26^2 + a * 26^1 + t * 26^0
    public static int hash(string s)
    {
        int n = s.Length;
        int result = 0;
        int currFactor = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            result += currFactor * (int)s[i];
            currFactor *= NUM_LETTERS;
        }
        return result;
    }

    // This solution uses backtracking.
    public static void rSolveBT(string s, HashSet<int> wordSet, int cutIndex, IList<string> currList, IList<string> answer)
    {
        // base case
        if (cutIndex == s.Length)
        {
            answer.Add(string.Join(" ", currList));
            return;
        }

        // backtracking
        string currSubstring = null;
        for (int i = cutIndex + 1; i <= s.Length; i++)
        {
            // Check if the hash of the substring of s from indices cutIndex to i (both inclusive) belongs in wordSet.
            currSubstring = s.Substring(cutIndex, i - cutIndex);
            if (wordSet.Contains(LC140.hash(currSubstring)))
            {
                currList.Add(currSubstring);

                // Recurse on the substring to the right of the cut.
                LC140.rSolveBT(s, wordSet, i, currList, answer);

                // Remove the last added string from currAnswer.
                currList.RemoveAt(currList.Count - 1);
            }
        }
    }

    public static IList<string> WordBreakBT(string s, IList<string> wordDict)
    {
        // Compute the hash of every string in wordDict, and add them to a set.
        HashSet<int> wordSet = new HashSet<int>();
        foreach (string word in wordDict)
        {
            wordSet.Add(LC140.hash(word));
        }

        IList<string> currList = new List<string>();
        IList<string> answer = new List<string>();
        LC140.rSolveBT(s, wordSet, 0, currList, answer);

        return answer;
    }

    public static void printList(IList<string> stringList)
    {
        foreach (string str in stringList)
        {
            Console.WriteLine(str);
        }
    }

    public static void test1BT()
    {
        Console.WriteLine("\nStarting test 1 (backtracking)");

        string s = "catsanddog";
        IList<string> wordDict = ["cat", "cats", "and", "sand", "dog"];
        IList<string> answer = LC140.WordBreakBT(s, wordDict);
        LC140.printList(answer);

        Console.WriteLine("Finished test 1 (backtracking)\n");
    }

    public static void test2BT()
    {
        Console.WriteLine("\nStarting test 2 (backtracking)");

        string s = "pineapplepenapple";
        IList<string> wordDict = ["apple", "pen", "applepen", "pine", "pineapple"];
        IList<string> answer = LC140.WordBreakBT(s, wordDict);
        LC140.printList(answer);

        Console.WriteLine("Finished test 2 (backtracking)\n");
    }

    public static void test3BT()
    {
        Console.WriteLine("\nStarting test 3 (backtracking)");

        string s = "catsandog";
        IList<string> wordDict = ["cats", "dog", "sand", "and", "cat"];
        IList<string> answer = LC140.WordBreakBT(s, wordDict);
        LC140.printList(answer);

        Console.WriteLine("Finished test 3 (backtracking)\n");
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("----------STARTING TESTS (BACKTRACKING)----------");

        LC140.test1BT();
        LC140.test2BT();
        LC140.test3BT();

        Console.WriteLine("----------FINISHED TESTS (BACKTRACKING)----------");
    }
}
