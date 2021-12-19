using System;
using System.Collections.Generic;
using System.Text;

namespace Priority_Queue{
    class PriorityQueue{
        // Member variables.
        private int max;
        private int[] array;
        private int nItems;

        // Default Constructor.
        public PriorityQueue() {
            max = 10;
            array = new int[max];
            nItems = 0;
        }

        // Parameter Constructor.
        public PriorityQueue(int size) {
            max = size;
            array = new int[max];
            nItems = 0;
        }

        public void Push(int val) {
            // Check whether priority queue is empty.
            if (nItems == 0) {
                array[0] = val;
                nItems++;
            } 
            // Check whether priority queue is filled.
            else if (nItems != max) {
                int i;
                // Adjust the queue qith priority condition.
                for (i = (nItems - 1); i >= 0; i--) {
                    // This is the condition.
                    if (val > array[i]) {
                        array[i + 1] = array[i];
                    } else {
                        break;
                    }
                }
                // Finally, add value to queue and
                // increment "nItems".
                array[i + 1] = val;
                nItems++;
            }
        }

        public void Pop() {
            // Pop the element with highest priority.
            array[nItems - 1] = 0;
            nItems--;
        }

        public int Peek() {
            // Return the value of element with highest 
            // priority.
            return array[nItems - 1];
        }

        public int Size() {
            // Return the number of elements in priority
            // queue.
            return nItems;
        }

        public bool IsFull() {
            // Returns whether priority queue is filled.
            return (nItems == max);
        }

        public bool IsEmpty(){
            // Returns whether priority queue is empty.
            return (nItems == 0);
        }
    }
}
