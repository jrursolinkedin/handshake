using System;
using System.Collections.Generic;
using System.Text;

namespace Fenwick_Tree {
    class FenwickTree {
        // Member variables.
        private int maxSize;
        private int[] fenTree;

        // Default Constructor.
        public FenwickTree() {
            maxSize = 1000;
            fenTree = new int[maxSize];
        }

        // Parameter Constructor.
        public FenwickTree(int mSize) {
            maxSize = mSize;
            fenTree = new int[maxSize];
        }

        public void ConstructTree(int[] arr) {
            // Builds the "fenTree" with the given array.
            maxSize = (arr.Length + 1);
            fenTree = new int[maxSize];
            Array.Fill(fenTree, 0);
            for (int idx = 0; idx < (maxSize - 1); idx++) {
                UpdateTree(idx, arr[idx]);
            }
        }

        public void UpdateTree(int index, int val) {
            // Populate "fanTree" by...
            index++;
            while (index <= (maxSize-1)) {
                fenTree[index] += val;
                // Formula to get the parent index.
                index = index + (index & (-index));
            }
        }

        public int GetSum(int index) {
            int sum = 0;
            index++;
            while (index > 0) {
                sum += fenTree[index];
                // Formula to get the parent index.
                index = index - (index & (-index));
            }
            return sum;
        }

        public int RangeSum(int leftIndex, int rightIndex) {
            // Simple way to get a sum of a range.
            return GetSum(rightIndex) - GetSum(leftIndex - 1);
        }
    }
}
