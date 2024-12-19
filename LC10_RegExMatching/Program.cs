using System;

namespace LC10
{
    class Program
    {
        // This method recursively determines if p is a regular expression for s.
        // Star (*) means that there can be zero, one, or multiple of the preceding character, and dot (.) means a single wildcard character.
        // e.g. a*.a* is a regular expression for aabaaa
        static bool isMatchRecursive(string s, string p)
        {
            return rIsMatch(s, 0, p, 0);
        }

        static bool rIsMatch(string s, int i, string p, int j) // i is the index in s and j is in the index in p that we are examining
        {
            // base cases

            if (i >= s.Length && j >= p.Length) // if we have reached the end of both s and p
            {
                return true;
            }

            if (j >= p.Length && i < s.Length) // if we have reached the end of p but not s
            {
                return false;
            }

            if (i >= s.Length && j < p.Length) // if we run out in s but not p
            {
                // Check if the rest of p is entirely sequences of a character followed by a '*' (e.g. 'b*b*a*').
                for (int idx = j; idx < p.Length; idx += 2)
                {
                    if (idx + 1 >= p.Length || p[idx + 1] != '*')
                    {
                        return false;
                    }
                }
                return true;
            }

            bool firstMatch = s[i] == p[j] || p[j] == '.';

            // Handle the case where the next character in p is '*'. 
            // We check both cases: the '*' and its preceding character (e.g. a*) correspond to the empty string in s, or they do not.
            if (p.Length > j + 1 && p[j + 1] == '*')
            {
                return rIsMatch(s, i, p, j + 2) || // move to the character in p immediately after the '*'
                 (firstMatch && rIsMatch(s, i + 1, p, j)); // assuming that the '*' and its preceding character actually correspond to something in s
            }

            // Proceed to check the next pair of characters as normal.
            if (firstMatch)
            {
                return rIsMatch(s, i + 1, p, j + 1);
            }

            return false;
        }

        static void testRecursive(string s, string p)
        {
            bool match = isMatchRecursive(s, p);
            Console.WriteLine(match);
        }

        static void Main(String[] args)
        {
            Console.WriteLine("STARTING\n");
            Console.WriteLine("Testing recursive method:\n");

            Console.Write("Test Case 1: ");
            string s1 = "aabaaa";
            testRecursive(s1, "a*.a*");

            Console.Write("\nTest Case 2: ");
            testRecursive(s1, ".a*b*a*a");

            Console.Write("\nTest Case 3: ");
            testRecursive(s1, ".a*b*a*");

            Console.Write("\nTest Case 4: ");
            testRecursive(s1, "......");

            Console.Write("\nTest Case 5: ");
            testRecursive(s1, "a*b*.b*a*b*a*a*b*b*a*");

            Console.Write("\nTest Case 6: ");
            testRecursive(s1, "aabaaaa");

            Console.Write("\nTest Case 7: ");
            testRecursive(s1, "baa*b*a*b*");

            Console.Write("\nTest Case 8: ");
            testRecursive(s1, ".a*a*b*a*a*.aa*b*b*b*a*b*");

            Console.Write("\nTest Case 9: ");
            testRecursive(s1, "..a.b*a*");

            Console.Write("\nTest Case 10: ");
            testRecursive(s1, ".....");

            Console.WriteLine("\nFINISHED");
        }
    }
}
