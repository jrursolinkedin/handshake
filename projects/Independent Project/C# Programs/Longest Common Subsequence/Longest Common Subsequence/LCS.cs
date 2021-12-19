using System;
using System.Collections.Generic;
using System.Text;

namespace Longest_Common_Subsequence {
    class LCS {
        // Member variables.
        private string string1;
        private string string2;
        private string print;
        private int length;

        // Default Constructor.
        public LCS() {
            string1 = "";
            string2 = "";
            print = "";
            length = 0;
        }

        // Parameter Constructor.
        public LCS(string s1, string s2) {
            string1 = s1;
            string2 = s2;
            print = PrintLCS(string1, string2);
            length = LengthLCS(string1, string2, string1.Length, string2.Length, "recursive");
        }

        // This method gets the length of LCS.
        public int LengthLCS(string s1, string s2, int l1, int l2, string method) {
            // Solves it recursively...
            if (method.Equals("recursive")) {
                // 1st Check: Check whether out of bounds.
                if ((l1 == 0) || (l2 == 0)) {
                    return 0;
                }
                // 2nd Check: Check whether the two characters are the same.
                if (s1[(l1 - 1)] == s2[(l2 - 1)]) {
                    return 1 + LengthLCS(s1, s2, (l1 - 1), (l2 - 1), "recursive");
                }
                // Default: Find max of two different directions.
                else {
                    return Math.Max(LengthLCS(s1, s2, (l1 - 1), l2, "recursive"), LengthLCS(s1, s2, l1, (l2 - 1), "recursive"));
                }
            }
            // Solves it iteratively...
            else {
                // This matrix will help us solve the problem.
                int[,] mtrx = new int[(s1.Length + 1), (s2.Length + 1)];
                // Traverse the matrix and populate it with values.
                for (int r = 1; r < mtrx.GetLength(0); r++) {
                    for (int c = 1; c < mtrx.GetLength(1); c++) {
                        // 1st Check: Check if same character.
                        if (s1[r - 1] == s2[c - 1]) {
                            mtrx[r, c] = mtrx[(r - 1), (c - 1)] + 1;
                        }
                        // Default: Find max of left or up.
                        else {
                            mtrx[r, c] = Math.Max(mtrx[(r - 1), c], mtrx[r, (c - 1)]);
                        }
                    }
                }
                // Return the length of LCS.
                return mtrx[s1.Length, s2.Length];
            }
        }

        // This method gets the string of the LCS.
        public string PrintLCS(string s1, string s2) {
            // This matrix will help us solve the problem.
            int[,] mtrx = new int[(s1.Length + 1), (s2.Length + 1)];
            // Traverse the matrix and populate it with values.
            for (int r = 1; r < mtrx.GetLength(0); r++) {
                for (int c = 1; c < mtrx.GetLength(1); c++) {
                    // 1st Check: Check if same character.
                    if (s1[r - 1] == s2[c - 1]) {
                        mtrx[r, c] = mtrx[(r - 1), (c - 1)] + 1;
                    }
                    // 2nd Check: Find max of left or up.
                    else {
                        mtrx[r, c] = Math.Max(mtrx[(r - 1), c], mtrx[r, (c - 1)]);
                    }
                }
            }
            // Create the LCS string.
            string lcs = "";
            int row = s1.Length;
            int col = s2.Length;
            while (0 < row && 0 < col) {
                // Going diagonal...
                if (s1[(row - 1)] == s2[(col - 1)]) {
                    lcs = s1[(row - 1)] + lcs;
                    row--;
                    col--;
                }
                // Going upward...
                else if (mtrx[(row - 1), col] > mtrx[row, (col - 1)]) {
                    row--;
                }
                // Going left...
                else {
                    col--;
                }
            }
            // Return LCS.
            return lcs;
        }

        // Getters or Accessors:

        public int GetLengthLCS() {
            return length;
        }

        public string GetPrintLCS() {
            return print;
        }
    }
}
