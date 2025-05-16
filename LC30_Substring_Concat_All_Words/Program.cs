using System.Formats.Asn1;

public class LC30
{
    public static IList<int> FindSubstring(string s, string[] words)
    {
        if (s.Length < words.Length * words[0].Length) // if s is shorter than any permutation of words
        {
            return new List<int>();
        }

        IList<int> answer = new List<int>();
        int n = s.Length;
        int w = words.Length; // w = number of strings in words
        int m = words[0].Length; // m = length of each string in words

        // Create a frequency dictionary for all the strings in words.
        Dictionary<string, int> wordFreq = new Dictionary<string, int>();
        foreach (string word in words)
        {
            // Note: it's possible that the same string appears multiple times in words (e.g. Example 2).
            if (wordFreq.ContainsKey(word))
            {
                wordFreq[word]++;
            }
            else
            {
                wordFreq[word] = 1;
            }
        }

        // Examine every possible starting offset from 0 up to m - 1 characters.
        int leftIndex = 0;
        int rightIndex = 0;
        Dictionary<string, int> currentCount = null;
        String currWord = null;
        String leftWord = null;
        for (int i = 0; i < m; i++)
        {
            leftIndex = i;
            rightIndex = i;
            currentCount = new Dictionary<string, int>();

            while (rightIndex + m <= n) // Make sure that we don't go out of index.
            {
                currWord = s.Substring(rightIndex, m);
                rightIndex += m;

                if (wordFreq.ContainsKey(currWord))
                {
                    if (currentCount.ContainsKey(currWord))
                        currentCount[currWord]++;
                    else
                        currentCount[currWord] = 1;

                    // if currWord's count exceeds the expected frequency
                    while (currentCount[currWord] > wordFreq[currWord])
                    {
                        leftWord = s.Substring(leftIndex, m);
                        currentCount[leftWord]--;
                        leftIndex += m;
                    }

                    // Check if the window is a valid permutation of words, and if so, add left to answer.
                    if (rightIndex - leftIndex == w * m)
                    {
                        answer.Add(leftIndex);
                    }
                }
                else
                {
                    // Reset window.
                    currentCount.Clear();
                    leftIndex = rightIndex;
                }
            }
        }
        return answer;
    }

    public static void test1()
    {
        Console.WriteLine("Starting test 1");

        String s = "barfoothefoobarman";
        String[] words = words = ["foo", "bar"];
        IList<int> answer = LC30.FindSubstring(s, words);
        Console.WriteLine(string.Join(", ", answer));

        Console.WriteLine("Finished test 1\n");
    }

    public static void test2()
    {
        Console.WriteLine("Starting test 2");

        String s = "wordgoodgoodgoodbestword";
        String[] words = ["word", "good", "best", "word"];
        IList<int> answer = LC30.FindSubstring(s, words);
        Console.WriteLine(string.Join(", ", answer));

        Console.WriteLine("Finished test 2\n");
    }

    public static void test3()
    {
        Console.WriteLine("Starting test 3");

        String s = "barfoofoobarthefoobarman";
        String[] words = ["bar", "foo", "the"];
        IList<int> answer = LC30.FindSubstring(s, words);
        Console.WriteLine(string.Join(", ", answer));

        Console.WriteLine("Finished test 3\n");
    }

    public static void test4()
    {
        Console.WriteLine("Starting test 4");

        String s = "aaaaaaaaaa"; // Note: s consists of 10 a's
        String[] words = ["a", "a"];
        IList<int> answer = LC30.FindSubstring(s, words);
        Console.WriteLine(string.Join(", ", answer));

        Console.WriteLine("Finished test 4\n");
    }

    public static void test5()
    {
        Console.WriteLine("Starting test 5");

        String s = "helloworld"; 
        String[] words = ["world", "hello"];
        IList<int> answer = LC30.FindSubstring(s, words);
        Console.WriteLine(string.Join(", ", answer));

        Console.WriteLine("Finished test 5\n");
    }

    public static void test6()
    {
        Console.WriteLine("Starting test 6");

        String s = "applepie"; 
        String[] words = ["apple", "pies"];
        IList<int> answer = LC30.FindSubstring(s, words);
        Console.WriteLine(string.Join(", ", answer));

        Console.WriteLine("Finished test 6\n");
    }

    public static void test7()
    {
        Console.WriteLine("Starting test 7");

        String s = "abcdefgh"; 
        String[] words = ["f", "c", "g", "e", "d"];
        IList<int> answer = LC30.FindSubstring(s, words);
        Console.WriteLine(string.Join(", ", answer));

        Console.WriteLine("Finished test 7\n");
    }

    public static void test8()
    {
        Console.WriteLine("Starting test 8");

        String s = "papaya"; 
        String[] words = ["a"];
        IList<int> answer = LC30.FindSubstring(s, words);
        Console.WriteLine(string.Join(", ", answer));

        Console.WriteLine("Finished test 8\n");
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("----------STARTING TESTS----------\n");

        LC30.test1();
        LC30.test2();
        LC30.test3();
        LC30.test4();
        LC30.test5();
        LC30.test6();
        LC30.test7();
        LC30.test8();

        Console.WriteLine("\n----------FINISHED TESTS----------");
    }
}
