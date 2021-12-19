using System;

namespace Longest_Common_Subsequence {
    class Program {
        static void Main(string[] args) {
            /**
             *  Longest Common Subsequence:
             *  The Longest Common Subsequence, or LCS, is a dynamic programming problem for 
             *  finding the longest subsequence common to all sequences in a set of sequences, 
             *  usually just two sequences. A subsequence is a sequence that appears in the same
             *  relative order, but not necessarily together in a sequence. It is a classic computer
             *  science problem, the basis of diff (a file comparison program that outputs the 
             *  differences between two files), and has applications in bioinformatics.
             *  > Longest Common Subsequence Operations:
             *    - Finding the Length of subsequence either recursively or iteratively.
             *    - Printing out the subsequence using the iterative method.
             *    
             *  Ex: Find the LCS of "MZJAWXU" and "XMJYAUZ" (Length and Print).
             *  
             *      - First, let's create a matrix,
             *      
             *        string s1 = "MZJAWXU"
             *        string s2 = "XMJYAUZ"
             *        int length; <- Length of LCS
             *        string print; <- Subsequence of LCS
             *        int[,] mtrx = new int[(s1.length+1), (s2.length+1)]
             *        
             *      - Now. let's populate the matrix,
             *        
             *                ---------------------------------
             *                | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 |
             *                ---------------------------------
             *                | Ø | M | Z | J | A | W | X | U |
             *        -----------------------------------------
             *        | 0 | Ø | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
             *        -----------------------------------------
             *        | 1 | X | 0 | 0 | 0 | 0 | 0 | 0 | 1 | 1 |
             *        -----------------------------------------
             *        | 2 | M | 0 | 1 | 1 | 1 | 1 | 1 | 1 | 1 |
             *        -----------------------------------------
             *        | 3 | J | 0 | 1 | 1 | 2 | 2 | 2 | 2 | 2 |
             *        -----------------------------------------
             *        | 4 | Y | 0 | 1 | 1 | 2 | 2 | 2 | 2 | 2 |
             *        -----------------------------------------
             *        | 5 | A | 0 | 1 | 1 | 2 | 3 | 3 | 3 | 3 |
             *        -----------------------------------------
             *        | 6 | U | 0 | 1 | 1 | 2 | 3 | 3 | 3 | 4 |
             *        -----------------------------------------
             *        | 7 | Z | 0 | 1 | 2 | 2 | 3 | 3 | 3 | 4<|--- LCS Length
             *        -----------------------------------------
             *        
             *        int length = mtrx[s1.length, s2.length] = 4
             *        
             *      - Finally, let's print the subsequence,
             *      
             *                ---------------------------------
             *                | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 |
             *                ---------------------------------
             *                | Ø | M | Z | J | A | W | X | U |
             *        -----------------------------------------
             *        | 0 | Ø ||0|| 0 | 0 | 0 | 0 | 0 | 0 | 0 |
             *        -----------------------------------------
             *        | 1 | X ||0|| 0 | 0 | 0 | 0 | 0 | 1 | 1 |
             *        -----------------------------------------
             *        | 2 | M | 0 ||1|||1|| 1 | 1 | 1 | 1 | 1 |
             *        -----------------------------------------
             *        | 3 | J | 0 | 1 | 1 ||2|| 2 | 2 | 2 | 2 |
             *        -----------------------------------------
             *        | 4 | Y | 0 | 1 | 1 ||2|| 2 | 2 | 2 | 2 |
             *        -----------------------------------------
             *        | 5 | A | 0 | 1 | 1 | 2 ||3|||3|||3|| 3 |
             *        -----------------------------------------
             *        | 6 | U | 0 | 1 | 1 | 2 | 3 | 3 | 3 ||4||
             *        -----------------------------------------
             *        | 7 | Z | 0 | 1 | 2 | 2 | 3 | 3 | 3 ||4||
             *        -----------------------------------------
             *        
             *        print = "U" + print
             *        print = "A" + print
             *        print = "J" + print
             *        print = "M" + print
             *        
             *      - Thus, 
             *      
             *        length = 4
             *        print = "MJAU"
             *        
             *   
             *  LCS Methods:
             *  - LengthLCS(s1,s2,l1,l2,meth): Given two strings as well as their lengths, this 
             *                                 will return the length (int) of the subsequence either
             *                                 recursively or iteratively.
             *  - PrintLCS(s1,s2): Given two strings, the method will perform the LCS algorithm
             *                     and return the subsequence (string).
             */
        }
    }
}
