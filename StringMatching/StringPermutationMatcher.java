package StringMatching;

import java.util.ArrayList;
import java.util.HashMap;

public class StringPermutationMatcher {
    // Find the starting indices of permutations of all the strings in words within str. 
    // For example, if words = {"ab", "cd", "ef"}, then "abcdef", "cdabef", and "cdefab" are all examples of valid permutations of the strings in words.
    // IMPORTANT: Each string in words is of length k, and we only have to deal with lowercase English letters (i.e. alphabetSize = 26).
    public static void findPermutationIndices(String str, String[] words, int k, int alphabetSize)
    {
        if (str.length() < k * words.length || str.length() == 0 || words.length == 0)
        {
            return;
        }
        
        int factor = 1;
        int[] powers = new int[k]; // stores powers to compute hashes
        for (int i = k - 1; i >= 0; i--)
        {
            powers[i] = factor;
            factor *= alphabetSize;
        }

        // Calculate the hash of each string in words.
        HashMap<Integer, Integer> wordsHashes = new HashMap<Integer, Integer>(); // maps the hash of a string in words to (its index in words) + 1

        int currHash = 0;
        String currWord = null;
        for (int i = 0; i < words.length; i++) 
        {
            currWord = words[i];
            for (int j = 0; j < k; j++)
            {
                // e.g. 'a' in ASCII is 97, so we subtract 96 to represent 'a' as 1.
                currHash += ((int) currWord.charAt(j) - 96) * powers[j];
            }
            wordsHashes.put(currHash, i + 1);
            currHash = 0;
        }

        // Calculate the rolling hash of each group of k characters in str, applying rolling window. 
        int[] rollingHashes = new int[str.length() - k + 1];
        // Calculate the hash for the first group of k characters (from the leftmost) in str.
        currHash = 0;
        factor = 1;
        for (int i = 0; i < k; i++)
        {
            currHash += ((int) str.charAt(i) - 96) * powers[i];
        }
        rollingHashes[0] = currHash;

        // Now apply the rolling aspect of rolling hash.
        for (int i = k; i < str.length(); i++)
        {
            rollingHashes[i - k + 1] = (rollingHashes[i - k] - ((int) str.charAt(i - k) - 96) * powers[0]) * alphabetSize + ((int) str.charAt(i) - 96);
        }

        // Now we know the rolling hash of each group of k character in str, as well as the hash of each string in words. 
        int[] temp = new int[str.length() / k];
        int tempIndex = 0;
        for(int i = 0; i < k; i++) 
        {
            for (int j = i; j <= str.length() - k; j += k) 
            {
                if (wordsHashes.containsKey(rollingHashes[j]))
                {
                    temp[tempIndex] = wordsHashes.get(rollingHashes[j]);
                }
                tempIndex++;
            }
            ArrayList<Integer> permIndices = PermutationsFinder.findPermutationIndices(temp, words.length); 
            for (int idx : permIndices)
            {
                System.out.println(idx * k + i); // translate from temp back to original str indices
            }
            temp = new int[str.length() / k];
            tempIndex = 0;
        }
    }
}
