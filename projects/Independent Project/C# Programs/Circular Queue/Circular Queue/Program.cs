using System;

namespace Circular_Queue {
    class Program {
        static void Main(string[] args) {
            /**
             *  Circular Queue:
             *  A Circular Queue, also known as 'Ring Buffer', is a linear data structure
             *  where the operations are performed based on FIFO (First-In First-Out) 
             *  principle and the last position is connected back to the first position to 
             *  make a circle. There are two operations in a Circular Queue, Enqueue and
             *  Dequeue.
             *  > Circular Queue Properties:
             *    * New keys are always inserted at the rear position.
             *    * Keys are always deleted from the front psoition.
             *    * The 'front' variable keeps track of the beginning index, and the 'rear'
             *      variable keeps track of the ending index.
             *    * There is a fix 'size' to the circular queue.
             *    
             *  Ex: Adding & Deleting from Circular Queue
             *  
             *      * Code:
             *      
             *        CQ q = new CQ(5);
             *        q.Enqueue(14);
             *        q.Enqueue(22);
             *        q.Enqueue(13);
             *        q.Enqueue(-6);
             *        q.Dequeue();
             *        q.Dequeue();
             *        q.Enqueue(9);
             *        q.Enqueue(20);
             *        q.Enqueue(5);
             *        
             *      * Visualization (Output):
             *      
             *       [14]f,r           [14]f              [14]f              [14]f
             *      /    \            /    \             /    \             /    \
             *    []     []         []     [22]r       []     [22]        []     [22]
             *     |     |   --->    |      |    --->   |      |    --->   |      |  --->
             *    []_____[]         []_____[]          []_____[13]r     r[-6]____[13]
             *  
             *            []                  []                 []
             *           /  \                /  \               /  \
             *         []   [22]f          []   []          r[9]   []
             *   --->   |    |    --->      |   |     --->     |   |     --->
             *       r[-6]__[13]        r[-6]___[13]f       [-6]___[13]f
             *       
             *          r[20]                [20]
             *          /    \              /    \
             *       [9]     []          [9]     [5]r
             *   --->  |     |     --->    |      |
             *      [-6]_____[13]f       [-6]____[13]f
             *      
             *  Circular Queue Methods:
             *  - Enqueue(key): Inserts a key into the circular queue.
             *  - Dequeue(): Deletes a key from the root position of the circular queue.
             *  - Print(): Prints the Circular Queue with additional information about
             *             member variables.
             */
        }
    }
}
