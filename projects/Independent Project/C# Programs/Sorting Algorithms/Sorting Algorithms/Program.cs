using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace Sorting_Algorithms{
    class Program{
        static void Main(string[] args){
            /**
            *   Sorting Algorithms:
            *   - Time Complexity: Amount of "time" it takes to run an algorithm.
            *   - Space Complexity: Amount of "space" it takes to run an algorithm.
            *   - Stable Sort: If two objects with equal keys appear in the same order
            *     in sorted output as they appear in the input array to be sorted.
            *     * Bubble
            *     * Merge
            *     * Insert
            *     * Radix
            *     * Bucket
            *   - Unstable Sort: The order of objects with the same key is not 
            *     maintained in the sorted order
            *     * Selection
            *     * Heap  <-[Omitted from program]
            *     * Quick
            *     * Shell
            *   
            *   * Sorting Algorithms (Time and Space Complexities):
            *        Name:         Worst:        Best:       Average:      Space:
            *    1.) Bubble        O(n)          O(n^2)      O(n^2)        O(1)
            *    2.) Selection     O(n^2)        O(n^2)      O(n^2)        O(1)
            *    3.) Insertion     O(n)          O(n^2)      O(n^2)        O(1)
            *    4.) Merge         O(nlog(n))    O(nlog(n))  O(nlog(n))    O(n)
            *    5.) Quick         O(nlog(n))    O(nlog(n))  O(n^2)        O(log(n))
            *    6.) Heap          O(nlog(n))    O(n)        O(nlog(n))    O(1)
            *    6.) Radix         O(n)          O(n)        O(n)          O(n)
            *    7.) Bucket        O(n^2)        O(n+k)      O(n)          O(n+k)  
            *    8.) Shell         O(n^2)        O(nlog(n))  O(nlog(n))    O(1)
            */
        }

        /**
         * Bubble Sort: Compares adjacent elements and swaps them if they are 
         * in the wrong order. (Stable)
         * * Advantages:
         *   - Popular and easily to implement
         *   - Space requirement is minimum
         * * Disadvantages:
         *   - Not good for large list of items
         *   - Not applicable in real life
         */
        public static void BubbleSort(int[] array) {
            // Traverse through te array.
            for (int i = 0; i < (array.Length - 1); i++) {
                // Flip elements if the follow condition.
                for (int j = 0; j < (array.Length - i - 1); j++) {
                    if (array[j] > array[j + 1]) {
                        int temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        /**
         *  Selection Sort: Works by repeatedly selecting the next smallest 
         *  element from the unosrted array and moving it to the front. (Unstable)
         *  * Advantages:
         *    - Good performance for small list of items
         *    - Space requirement is minimum
         *  * Disadvanatges:
         *    - Poor performance for large list of items 
         */
        public static void SelectionSort(int[] array) {
            // Traverse through the array.
            for (int i = 0; i < (array.Length - 1); i++) {
                int minIndex = i;
                // Find the minimum element and store its index.
                for (int j = (i + 1); j < array.Length; j++) {
                    if (array[minIndex] > array[j]) {
                        minIndex = j;
                    }
                }
                // Switch the two values.
                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
        }

        /**
         *  Insertion Sort: Insertion sort works by inserting elements from
         *  an unsorted array into a sorted subsection of the array, one 
         *  item at a time. (Stable)
         *  * Advantages:
         *    - Good performance for small list of items
         *    - Space requirement is minimum
         *  * Disadvanatges:
         *    - Poor performance for large list of items
         */
        public static void InsertionSort(int[] array) {
            // Traverse through array.
            for (int i = 1; i < array.Length; i++) {
                int key = array[i];
                int j = i - 1;
                // Check previous segment of array.
                while (j >= 0 && array[j] > key) {
                    array[j + 1] = array[j];
                    j--;
                }
                // Lastly, reassign the key.
                array[j + 1] = key;
            }
        }

        /**
         *  Merge Sort: Merge sort works by splitting the input in half, recursively
         *  sorting each half, and then merging the sorted halves back together. (Stable)
         *  * Advantages:
         *    - Good for handling data sets that can't fit in RAM
         *    - It can be applied to files of any size
         *  * Disadvantages:
         *    - Requires extra space
         */
        public static int[] MergeSort(int[] array) {
            // Check the default case.
            if (array.Length <= 1) {
                return array;
            }
            else {
                // Come up with left and right arrays.
                int[] left;
                int[] right;
                int midPoint = Convert.ToInt32(array.Length / 2);
                left = new int[midPoint];
                // If array length is even...
                if ((array.Length % 2) == 0) {
                    right = new int[midPoint];
                }
                // Else, array length is odd...
                else {
                    right = new int[midPoint+1];
                }
                // Assign array values to the left and right arrays.
                for (int i = 0; i < midPoint; i++) {
                    left[i] = array[i];
                }
                for (int j = 0; j < right.Length; j++) {
                    right[j] = array[midPoint + j];
                }
                // Recursive call.
                left = MergeSort(left);
                right = MergeSort(right);
                // Lastly, merge the left and right arrays.
                return Merge(left,right);
            }
        }

        public static int[] Merge(int[] left, int[] right) {
            // Come the left and right arrays into one array, "result".
            int[] result = new int[left.Length + right.Length];
            int leftIndex, rightIndex, resultIndex;
            leftIndex = rightIndex = resultIndex = 0;
            // Populates the result array with values.
            while (leftIndex < left.Length || rightIndex < right.Length) {
                // 1st Check...
                if (leftIndex < left.Length && rightIndex < right.Length) {
                    // Find minimum between the left and right arrays.
                    if (left[leftIndex] < right[rightIndex]) {
                        result[resultIndex] = left[leftIndex];
                        resultIndex++;
                        leftIndex++;
                    } 
                    else {
                        result[resultIndex] = right[rightIndex];
                        resultIndex++;
                        rightIndex++;

                    }
                } 
                // 2nd Check...
                else if (leftIndex < left.Length) {
                    result[resultIndex] = left[leftIndex];
                    resultIndex++;
                    leftIndex++;
                } 
                // 3rd Check...
                else if (rightIndex < right.Length) {
                    result[resultIndex] = right[rightIndex];
                    resultIndex++;
                    rightIndex++;
                }
            }
            // Lastly, return the combined array, "result".
            return result;
        }

        /**
         *  Quick Sort: Quicksort works by recursively dividing the input into 
         *  two smaller arrays around a pivot item: one half has items smaller
         *  than the pivot, the other has larger items. (Unstable)
         *  * Advantages:
         *    - Best sorting algorithm
         *    - Good for large list of items
         *  * Disadvantages:
         *    - Not good for lists that are already sorted
         *    - Radix sort is more efficient when it comes to integers
         */
        public static void QuickSort(int[] array, int low, int high) {
            // Recursive condition.
            if (low < high) {
                // Get pivot position.
                int pi = Partition(array, low, high);
                // Sort left side of array.
                QuickSort(array, low, (pi - 1));
                // Sort right side of array.
                QuickSort(array, (pi + 1), high);
            }
        }

        public static int Partition(int[] array, int low, int high) {
            // "pivot" is what we are comparing.
            int pivot = array[high];
            // "i" is where the pivot will be placed.
            int i = (low - 1);
            // Gets everything to the left of pivot less than
            // pivot, and everything to the tight of pivot is 
            // more than pivot.
            for (int j = low; j < high; j++) {
                // Moves element to the left.
                if (array[j] < pivot) {
                    i++;
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            // Switches the pivot between the left (Less) and
            // right (Greater) numbers.
            int temp1 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp1;
            // Return position of "i".
            return i + 1;
        }

        /**
         *  Radix Sort: Radix sort works by sorting the input numbers one digit
         *  at a time. (Stable)
         *  * Advantages:
         *    - Best time complexity
         *  * Disadvantages:
         *    - Not practical and it's slow in practice
         *    - Uses a lot of space 
         */
        public static void RadixSort(int[] array) {
            // Find largest element in the array.
            int max = GetMax(array);
            // Counting sort is performed based on place, such 
            // as the ones place, tens place, and etc.
            for (int place = 1; (max/place) > 0; place *= 10) {
                CountingSort(array, place);
            }
        }

        public static int GetMax(int[] array) {
            // Gets the max element within an array.
            int max = array[0];
            for (int i = 1; i < array.Length; i++) {
                if (array[i] > max) {
                    max = array[i];
                }
            }
            return max;
        }

        public static void CountingSort(int[] array, int place) {
            int[] output = new int[array.Length];
            // Range of the number is 0-9 for each place 
            // considered.
            int[] freq = new int[10];
            // Count number of occurrences in freq array.
            for (int i = 0; i < array.Length; i++) {
                freq[(array[i] / place) % 10]++;
            }
            // Change freq[i] so that freq[i] now contains 
            // actual position of this digit in output[].
            for (int i = 1; i < 10; i++) {
                freq[i] += freq[i - 1];
            }
            // Build the output array.
            for (int i = array.Length - 1; i >= 0; i--) {
                output[freq[(array[i] / place) % 10] - 1] = array[i];
                freq[(array[i] / place) % 10]--;
            }
            // Copy the output array to the input Array. Now
            // the Array will contain sorted array based on 
            // digit at specified place.
            for (int i = 0; i < array.Length; i++) {
                array[i] = output[i];
            }
        }

        /**
         *  Bucket Sort: ucket sort (a.k.a Bin Sort) is a sorting algorithm 
         *  that works by partitioning an array into a number buckets. Each
         *  bucket then sorted individually, either using a different sorting
         *  algorithm, or by recursively applying the bucket sorting algorithm.
         *  * Advantages:
         *    - Better at handling arrays with inputs that are uniformly
         *      distributed over a range.
         *    - Simpler implementation
         *  * Disadvantages:
         *    - If all the elements are allocated in the same bucket, the
         *      algorithm performs at its worst case.
         */
        public static void BucketSort(int[] array) {
            // Find min and max values.
            int minValue = array[0];
            int maxValue = array[0];
            for (int i = 1; i < array.Length; i++) {
                if (array[i] > maxValue) {
                    maxValue = array[i];
                }
                if (array[i] < minValue) {
                    minValue = array[i];
                }
            }
            // Initialize the buckets.
            List<int>[] bucket = new List<int>[maxValue - minValue + 1];
            for (int i = 0; i < bucket.Length; i++) {
                bucket[i] = new List<int>();
            }
            // Distribute input array values into buckets.
            for (int i = 0; i < array.Length; i++) {
                bucket[array[i] - minValue].Add(array[i]);
            }
            // Place back into the array.
            int k = 0;
            for (int i = 0; i < bucket.Length; i++) {
                if (bucket[i].Count > 0) {
                    for (int j = 0; j < bucket[i].Count; j++) {
                        array[k] = bucket[i][j];
                        k++;
                    }
                }
            }
        }

        /**
         *  Shell Short: Shell sort is a generalized version of the insertion
         *  sort algorithm. It first sorts elements that are far apart from 
         *  each other and successively reduces the interval between the 
         *  elements to be sorted.The interval between the elements is reduced
         *  based on the sequence used. 
         *  * Advantages:
         *    - Performs best on medium size arrays.
         *    - Performs better compared to Bubble and Insertion sort.
         *  * Disadvantages:
         *    - Only efficient on medium size arrays.
         */
        public static void ShellSort(int[] array) {
            // This loop goes through all the intervals, or gaps, within
            // the array.
            for (int interval = array.Length / 2; interval > 0; interval /= 2) {
                // For each internal, this loop checks each possible combination.
                for (int i = interval; i < array.Length; i++) {
                    int temp = array[i];
                    int j;
                    // This loop does the sorting.
                    for (j = i; j >= interval && array[j - interval] > temp; j -= interval) {
                        array[j] = array[j - interval];
                    }
                    array[j] = temp;
                }
            }
        }
    }
}
