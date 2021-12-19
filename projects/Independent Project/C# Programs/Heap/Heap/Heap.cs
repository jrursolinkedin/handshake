using System;

namespace Heap{
    class Heap{
        // Member variables.
        private int[] array;
        private int heapSize;

        // Default Constructor.
        public Heap() {
            array = new int[0];
            heapSize = 0;
        }

        // Parameter Constructor.
        public Heap(int size) {
            array = new int[size];
            heapSize = 0;
        }

        public void SetHeapSize(int size) {
            // Sets the heap size.
            array = new int[size];
            heapSize = 0;
        }

        public void Push(int value) {
            // Check whether heap is filled.
            if (heapSize == array.Length) {
                Console.WriteLine("Heap is filled");
            }
            // Check whether heap is empty.
            else if (heapSize == 0) {
                array[0] = value;
                heapSize++;
            } 
            // Else, heap has elements.
            else {
                array[heapSize] = value;
                heapSize++;
                ShiftUp(heapSize - 1);
            }
        }

        public void Pop() {
            // Check whether heap is empty.
            if (heapSize == 0) {
                Console.WriteLine("Heap is empty");
            } 
            // Check whether there is 1 element in heap.
            else if (heapSize == 1) {
                array[0] = 0;
                heapSize--;
            } 
            // Else, has more than 1 element.
            else {
                heapSize--;
                array[0] = array[heapSize];
                array[heapSize] = 0;
                ShiftDown(0);
            }
        }

        public int Peek() {
            // Returns the first element in heap.
            if (heapSize == 0) {
                Console.WriteLine("Heap is empty");
                return 0;
            }
            else {
                return array[0];
            }
        }

        public int Size() {
            // Returns the size of heap.
            return heapSize;
        }

        public bool IsFull() {
            // Checks whether heap is filled.
            return (heapSize == array.Length);
        }

        public bool IsEmpty() {
            // Checks whether heap is empty.
            return (heapSize == 0);
        }

        public void BuildHeap(int[] copyArray){
            // Check whether heap is has elements.
            if (heapSize > 0) {
                // Clear heap.
                Array.Resize(ref array, copyArray.Length);
                heapSize = 0;
                // Copy elements in heap.
                for (int i = 0; i < array.Length; i++) {
                    array[i] = copyArray[i];
                    heapSize++;
                }
            }
            // Then, heapify the heap.
            for (int i = ((heapSize - 1) / 2); i >= 0; i--) {
                MinHeapify(i);
            }
        }

        private void MinHeapify(int index){
            // Get left and right indexes.
            int leftIndex = 2 * index;
            int rightIndex = (2 * index) + 1;
            int smallest = index;
            // Find the smallest index.
            if (leftIndex < heapSize && array[leftIndex] < array[index]) {
                smallest = leftIndex;
            } 
            else {
                smallest = index;
            }
            if (rightIndex < heapSize && array[rightIndex] < array[smallest]) {
                smallest = rightIndex;
            }
            // Check whether parent is not the smallest.
            if (smallest != index) {
                // Swap values.
                int temp = array[index];
                array[index] = array[smallest];
                array[smallest] = temp;
                // Recursive call.
                MinHeapify(smallest);
            }
        }

        private void ShiftUp(int index) {
            // Recursively compare index to its parent index
            // and switch values if condition is met.
            if (index != 0) {
                int parentIndex = GetParentIndex(index);
                if (array[parentIndex] > array[index]) {
                    // Swap values.
                    int temp = array[parentIndex];
                    array[parentIndex] = array[index];
                    array[index] = temp;
                }
                // Recursive call.
                ShiftUp(parentIndex);
            }
        }

        private void ShiftDown(int index) {
            // Recursively compare index to its left and right
            // indexes and switch values if condition is met.
            if (index <= heapSize) {
                int leftIndex = GetLeftChildIndex(index);
                int rightIndex = GetRightChildIndex(index);
                if (leftIndex < heapSize) {
                    if (array[index] > array[leftIndex]) {
                        // Swap values.
                        int temp = array[leftIndex];
                        array[leftIndex] = array[index];
                        array[index] = temp;
                    }
                }
                if (rightIndex < heapSize) {
                    if (array[index] > array[rightIndex]) {
                        // Swap values.
                        int temp = array[rightIndex];
                        array[rightIndex] = array[index];
                        array[index] = temp;
                    }
                }
                // Recursive calls.
                ShiftDown(leftIndex);
                ShiftDown(rightIndex);
            }
        }

        private int GetParentIndex(int index) {
            // Returns parent index of specific index.
            return (index - 1) / 2;
        }

        private int GetLeftChildIndex(int index) {
            // Returns left child index of specific index.
            return (2 * index) + 1;
        }

        private int GetRightChildIndex(int index) {
            // Returns right child index of speific index.
            return (2 * index) + 2;
        }
    }
}
