using System;

namespace Queue{
    class Queue{
        // Member variables.
        private Node back;
        private Node front;

        // Default Constructor.
        public Queue() {
            back = front = null;
        }

        // Parameter Constructor.
        public Queue(object val) {
            back = front = new Node(val, null);
        }

        public void Enqueue(object val) {
            // Check whehter queue is empty.
            if (back == null) {
                back = front = new Node(val, null);
            } 
            // Else, queue has one or more elements.
            else {
                // Adds element to back of queue.
                Node temp = new Node(val, null);
                temp.SetNext(back);
                back = temp;
            }
        }

        public void Dequeue() {
            // Check whether queue is empty.
            if (back != null) {
                // Check whether queue has one element.
                if (back == front) {
                    back = front = null;
                }
                // Else, queue has more than one element.
                else {
                    // Performs FIFO (First-In-First-Out).
                    // Or, deleted element in front of queue.
                    Node temp = back;
                    while (temp.GetNext() != front) {
                        temp = temp.GetNext();
                    }
                    temp.SetNext(null);
                    front = temp;

                }
            }
        }

        public object Peek() {
            // Returns element value at front of queue.
            return front.GetData();
        }

        public int Size() {
            // Returns the number of elements in the queue.
            Node temp = back;
            int size = 0;
            while (temp != null) {
                temp = temp.GetNext();
                size++;
            }
            return size;
        }

        public bool IsEmpty() {
            // Returns whether queue is empty.
            if (back == null) {
                return true;
            }
            else {
                return false;
            }
        }

        public void Clear() {
            // Deletes the queue from memory.
            back = front = null;
        }
    }
}
