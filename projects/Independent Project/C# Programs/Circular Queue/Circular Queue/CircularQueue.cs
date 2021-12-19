using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Circular_Queue {
    class CircularQueue {
        // Member variables.
        private ArrayList queue;
        // Index pointers and capacity size.
        private int front, rear, size;

        // Parameter Constructor.
        public CircularQueue(int sz) {
            size = sz;
            front = rear = -1;
            // Setting the ArrayList to a fix size.
            queue = new ArrayList(size);
        }

        public void EnQueue(object key) {
            // Check whether queue is not full.
            if (!(front == 0 && rear == (size - 1)) && !(rear == ((front - 1) % (size - 1)))) {
                // Empty queue.
                if (front == -1) {
                    front = rear = 0;
                    queue.Insert(rear, key);
                }
                // Reversing the indexes.
                else if ((rear == (size - 1)) && (front != 0)) {
                    rear = 0;
                    queue[rear] = key;
                }
                // Adding to queue.
                else {
                    rear += 1;
                    // Check whether to assign or insert
                    // a new key.
                    if (front <= rear) {
                        queue.Insert(rear, key);
                    }
                    else {
                        queue[rear] = key;
                    }
                }
            }
        }

        public object DeQueue() {
            // Check whether queue is empty.
            if (front != -1) {
                object temp = queue[front];
                // One key in queue.
                if (front == rear) {
                    front = rear = -1;
                }
                // Incrementing "front" back to index 0.
                else if (front == (size - 1)) {
                    front = 0;
                }
                // Increment "front" index.
                else {
                    front += 1;
                }
                return temp;
            }
            else {
                // Default Return.
                return null;
            }
        }

        public void Print() {
            Console.WriteLine("-----");
            Console.WriteLine("Front Index: " + front);
            Console.WriteLine("Rear Index: " + rear);
            Console.WriteLine("Capacity: " + size);
            Console.WriteLine("Keys: ");
            if (front != -1) {
                if (rear >= front) {
                    for (int i = front; i <= rear; i++) {
                        Console.WriteLine(queue[i]);
                    }
                }
                else {
                    for (int j = front; j < size; j++) {
                        Console.WriteLine(queue[j]);
                    }
                    for (int k = 0; k <= rear; k++) {
                        Console.WriteLine(queue[k]);
                    }
                }
            }
            else {
                Console.WriteLine("Empty Queue");
            }
            Console.WriteLine("-----");
        }
    }
}
