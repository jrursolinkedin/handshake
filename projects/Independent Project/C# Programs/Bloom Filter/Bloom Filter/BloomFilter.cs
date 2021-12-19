using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom_Filter {
    class BloomFilter {
        // Member variables.
        private bool[] container;
        private int containerSize;
        // For resizing and checking "false positives".
        private List<object> elements;

        // Default Constructor.
        public BloomFilter() {
            // Default size is 100.
            containerSize = 100;
            // Assign every index to false.
            container = new bool[containerSize];
            for (int i = 0; i < containerSize; i++) {
                container[i] = false;
            }
            elements = new List<object>();
        }

        // Parameter Constructor.
        public BloomFilter(int size) {
            containerSize = size;
            // Assign every index to false.
            container = new bool[containerSize];
            for (int i = 0; i < containerSize; i++) {
                container[i] = false;
            }
            elements = new List<object>();
        }

        public void Insert(object key) {
            elements.Add(key);
            // Assign the hashed indexes to true.
            container[HashOne(key)] = true;
            container[HashTwo(key)] = true;
            // Check whether to resize bloom filter.
            if (Resize() == true) {
                // Quadruple size.
                containerSize *= 4;
                container = new bool[containerSize];
                // Assign every index to false.
                for (int i = 0; i < containerSize; i++) {
                    container[i] = false;
                }
                // Reinsert elements in bloom filter.
                for (int j = 0; j < elements.Count; j++) {
                    container[HashOne(elements[j])] = true;
                    container[HashTwo(elements[j])] = true;
                }
            }
        }

        public bool Query(object key) {
            // Check if key hashes to true value.
            if (container[HashOne(key)] == true && container[HashTwo(key)] == true) {
                // Now, check "elements" because 
                // it is false positive.
                if (elements.Contains(key) == true) {
                    return true;
                }
            }
            // Returns false by default.
            return false;
        }

        private int HashOne(object key) {
            // Get ascii value of "key".
            ASCIIEncoding ascii = new ASCIIEncoding();
            Byte[] bytes = ascii.GetBytes(key.ToString());
            // Add up all the ascii values.
            int sum = 0;
            for (int i = 0; i < bytes.Length; i++) {
                sum += bytes[i];
            }
            // Returns "sum" mod "containerSize" to get index.
            return (sum % containerSize);
        }

        private int HashTwo(object key) {
            // Get ascii value of "key".
            ASCIIEncoding ascii = new ASCIIEncoding();
            Byte[] bytes = ascii.GetBytes(key.ToString());
            // Add up all the ascii values.
            int sum = 0;
            for (int i = 0; i < bytes.Length; i++) {
                sum += bytes[i];
            }
            // Performs calculation on "sum".
            sum = (int)(Math.Pow((double)((3 * sum) + 2), 2));
            // Returns "sum" mod "containerSize" to get index.
            return (sum % containerSize);
        }

        private bool Resize() {
            // Adds up all the true indexes.
            int numTrue = 0;
            for (int i = 0; i < containerSize; i++) {
                if (container[i] == true) {
                    numTrue++;
                }
            }
            // Resizing condition.
            // Determines performance of bloom filter!
            if (numTrue > (int)(containerSize * (0.10))) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
