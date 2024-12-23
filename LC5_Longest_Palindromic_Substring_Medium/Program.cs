using System;

namespace LC35
{
    class Program
    {
        public static string LongestPalindrome(string s) {
            int sLength = s.Length;
            // M[i, j] is the longest palindromic substring in the substring of s from i to j (inclusive)
            string[, ] M = new string[sLength, sLength]; 
            
            // edge cases
            for (int i = 0; i < sLength; i++)
            {
                M[i, i] = s[i].ToString();
            }

            // Populate the rest of M.
            for (int i = sLength - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < sLength; j++)
                {
                    if (s[i] != s[j])
                    {
                        // Use the longer of the left and lower neighbors of M[i, j].
                        M[i, j] = M[i, j - 1].Length >= M[i + 1, j].Length ? M[i, j - 1] : M[i + 1, j];
                    }
                    else
                    {
                        M[i, j] = s.Substring(i, j - i + 1);
                    }
                }
            }

            return M[0, sLength - 1];
        }

        static void Main(string[] args)
        {
            Console.WriteLine("STARTING");

            Console.Write("\nTest Case 1: ");
            string s1 = "aacabdkacaa";
            string lps1 = LongestPalindrome(s1);
            Console.WriteLine(lps1);

            Console.WriteLine("\nFINISHED");
        }

    }
}
