using System;

namespace Heap{
    class Program{
        static void Main(string[] args){
            /**
             *  Heap:
             *  A heap is a special tree based data structure in which the
             *  tree is a complete binary tree. Generally, heaps can be of 
             *  two types:
             *   1.) Max-Heap
             *   2.) Min-Heap <-- In this program
             *   
             *   Min Heap Data Structure:         Array Data Structure:
             *           [10]
             *          /    \
             *      [15]     [30]         =>   [10 , 15 , 30 , 40 , 50 , 100 , 40]
             *     /   \    /    \             heapSize = 7
             *  [40] [50] [100]  [40]          
             * 
             *  Max Heap Data Structure:         Array Data Structure:
             *          [100]
             *          /    \
             *      [40]     [50]         =>   [100 , 40 , 50 , 10 , 15 , 50 , 40]
             *     /   \    /    \             heapSize = 7
             *  [10] [15] [50]  [40]    
             *  
             *  Heap Methods:
             *  - Push(int val): Adds an integer to the array and rearranges 
             *                   the integers.
             *  - Pop(): Removes the integer at the top of the heap.
             *  - Peek(): Returns the integer at the top of the heap.
             *  - Size(): Returns the number of integers inside the heap.
             *  - IsFull(): If the heap is full, it returns true.
             *  - IsEmpty(): If the heap is empty, it returns true.
             *  - BuildHeap(int[] array): This method builds a heap from a
             *                            given array.
             */
        }
    }
}
