package StringMatching;
import java.util.ArrayList;

public class PermutationsFinder {
    // Find starting indices of permutations of integers 1 to m (where m is any positive integer). Assume that nums only contains -1 and integers 1 through m.
    public static ArrayList<Integer> findPermutationIndices(int[] nums, int m)
    {
        if (nums.length == 0 || m > nums.length)
        {
            return new ArrayList<Integer>();
        }
        ArrayList<Integer> permIndices = new ArrayList<Integer>();
        int[] counts = new int[m + 1]; // Note that we never modify or use the first number (index 0) in counts.
        int uniqueCounts = 0;

        // Calculate the initial values in counts.
        for (int i = 0; i < m; i++)
        {
            if (1 <= nums[i] && nums[i] <= m)
            {
                // If it is the first time a particular number is added to counts, then it adds to the number of unique numbers.
                if (counts[nums[i]] == 0)
                {
                    uniqueCounts++;
                }
                counts[nums[i]]++;
            }
        }
        if (uniqueCounts == m)
        {
            permIndices.add(0);
        }

        // Go through the rest of nums.
        for (int i = m; i < nums.length; i++)
        {
            // Examine a new number of nums.
            if (1 <= nums[i] && nums[i] <= m)
            {
                if (counts[nums[i]] == 0)
                {
                    uniqueCounts++;
                }
                counts[nums[i]]++;
            }
            // Because a permutation of m contains exactly m numbers. Thus when we move down by 1, we have to take out the oldest element from our last group of m numbers.
            if (1 <= nums[i - m] && nums[i - m] <= m)
            {
                // If there is only 1 of the element we take out, then that element no longer exists in our current group of m numbers, so uniqueCounts must decrease by 1.
                if (counts[nums[i - m]] == 1)
                {
                    uniqueCounts--;
                }
                counts[nums[i - m]]--;
            }
            if (uniqueCounts == m)
            {
                permIndices.add(i - m + 1);
            }
        }
        return permIndices;
    }
}
