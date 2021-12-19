using System;
using System.Collections.Generic;
using System.Text;

namespace Graph{
    class Queue{
        // Member variables.
        private Vertex head;
        private Vertex tail;

        // Default Constructor.
        public Queue() {
            head = null;
        }

        // Parameter Constructor.
        public Queue(int d) {
            head = tail = new Vertex(d, null);
        }

        public void Enqueue(int d) {
            // Adds an element to the front of the list.
            if (head == null) {
                head = tail = new Vertex(d, null);
            } 
            else {
                Vertex temp = new Vertex(d, null);
                temp.SetNext(head);
                head = temp;
            }
        }

        public void Dequeue() {
            // Deletes an element from the front of the list.
            if (head != null) {
                if (head.GetNext() == null) {
                    head = tail = null;
                }
                else {
                    Vertex temp = head;
                    while (temp.GetNext() != tail) {
                        temp = temp.GetNext();
                    }
                    temp.SetNext(null);
                    tail = temp;
                }
            }
        }

        public void Clear() {
            // Clears the list from memory.
            if (head != null) { 
                Vertex temp = head;
                while (temp != null) {
                    temp = temp.GetNext();
                    head.SetNext(null);
                    head = temp;

                }
                head = tail = null;
            }
        }

        public int Peek() {
            // Returns element value at the front of list.
            return tail.GetData();
        }

        public bool IsEmpty() {
            // Returns whether the list is empty.
            if (Count() > 0) {
                return false;
            }
            else {
                return true;
            }
        }

        public int Count() {
            // Gets the number of elements within the list.
            Vertex temp = head;
            int size = 0;
            while (temp != null) {
                temp = temp.GetNext();
                size++;
            }
            return size;
        }
    }
}
