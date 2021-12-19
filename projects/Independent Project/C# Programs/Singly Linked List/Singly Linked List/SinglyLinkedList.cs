using System;
using System.Collections.Generic;
using System.Text;

namespace Singly_Linked_List{
    class SinglyLinkedList{
        // Member variables.
        public Node head;
        public Node tail;

        // Default Constructor.
        public SinglyLinkedList() {
            head = tail = null;
        }

        // Parameter Constructor.
        public SinglyLinkedList(object val) {
            head = tail = new Node(val, null);
        }

        public void Add(object val) {
            // Check whehter list is empty.
            if (head == null) {
                head = tail = new Node(val, null);
            }
            // Else, list one or more elements.
            else {
                tail.SetNext(new Node(val, null));
                tail = tail.GetNext();
            }
        }

        public void Remove(object val) {
            // Check whether the value exists and the list is empty.
            if (head != null && Search(val)) {
                // Deleted node is the only element in list.
                if (head == tail && head.GetData().Equals(val)) {
                    head = tail = null;
                }
                // Deleted node is the head of the list.
                else if (head.GetData().Equals(val)) {
                    Node tempH = head;
                    head = head.GetNext();
                    tempH.SetNext(null);
                } 
                // Deleted node is the tail of the list.
                else if (tail.GetData().Equals(val)) {
                    Node tempT = head;
                    while (tempT.GetNext() != tail) {
                        tempT = tempT.GetNext();
                    }
                    tempT.SetNext(null);
                    tail = tempT;
                } 
                // Else, deleted node is between head and tail.
                else {
                    Node tempT = head;
                    while ((tempT.GetNext() != null) && !(tempT.GetNext().GetData().Equals(val))) {
                        tempT = tempT.GetNext();
                    }
                    Node tempD = tempT.GetNext();
                    tempT.SetNext(tempD.GetNext());
                    tempD.SetNext(null);
                }
            }
        }

        public object Get(int index) {
            // Returns the value of a specific element.
            if (head != null && index <= (Size()-1)) {
                Node tempT = head;
                for (int i = 0; i < index; i++) {
                    tempT = tempT.GetNext();
                }
                return tempT.GetData();
            }
            return -1;
        }

        public int Size() {
            // Returns the number of elements in the list.
            Node temp = head;
            int size = 0;
            while (temp != null) {
                size++;
                temp = temp.GetNext();
            }
            return size;
        }

        public bool IsEmpty() {
            // Returns whether the list is empty.
            if (head == null) {
                return true;
            }
            else {
                return false;
            }
        }

        public void Clear() {
            // Deletes the list from memory.
            head = tail = null;
        }

        private bool Search(object val) {
            // Returns whether a element value exists.
            Node tempT = head;
            while (tempT != null) {
                if (tempT.GetData().Equals(val)) {
                    return true;
                }
                tempT = tempT.GetNext();
            }
            return false;
        }
    }
}
