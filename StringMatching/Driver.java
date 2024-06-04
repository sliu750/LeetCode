package StringMatching;

public class Driver {
    public static void main(String[] args) {
        String str_1 = "xyzabcdefxxcdefabxyzcdabcdefabpqxyz";
        String str_2 = "abcdefabcd";
        String str_3 = "abcdexefabcdefbcabcdefabcddefabcb";
        String[] words = {"ab", "cd", "ef"};
        int k = 2;
        int alphabetSize = 26;

        System.out.println("starting indices of permutations of words in str_1:");
        StringPermutationMatcher.findPermutationIndices(str_1, words, k, alphabetSize);
        System.out.println('\n' + "starting indices of permutations of words in str_2:");
        StringPermutationMatcher.findPermutationIndices(str_2, words, k, alphabetSize);
        System.out.println('\n' + "starting indices of permutations of words in str_3:");
        StringPermutationMatcher.findPermutationIndices(str_3, words, k, alphabetSize);
    }
}
