using System;
using System.Collections.Generic;
using System.Text;

namespace Hashmap{
    class List{
        // Member variable.
        private Node head;

        // Default Constructor.
        public List() {
            head = null;
        }

        // Parameter Constructor.
        public List(object k, object d) {
            head = new Node(k, d,null);
        }

        public void Add(object k, object d) {
            // Check whether the list is empty.
            if (head == null) {
                head = new Node(k, d, null);
            }
            // Else, add the node at the end of list.
            else {
                Node temp = head;
                while (temp != null) {
                    if (temp.GetNext() == null) {
                        temp.SetNext(new Node(k, d, null));
                        temp = temp.GetNext().GetNext();
                    } 
                    else {
                        temp = temp.GetNext();
                    }
                }
            }
        }

        public void Remove(object k, object d) {
            // Check whether list is empty.
            if (head != null) {
                // Deleted node is the head of the list.
                while (head != null && head.GetKey().Equals(k) && head.GetData().Equals(d)) {
                    Node tempH = head;
                    head = head.GetNext();
                    tempH.SetNext(null);
                }
                // Deleted node is either in the middle or tail of list.
                Node temp = head;
                while (temp != null) {
                    if (temp.GetNext() != null) {
                        if (temp.GetNext().GetKey().Equals(k) && temp.GetNext().GetData().Equals(d)) {
                            Node tempM = temp.GetNext();
                            temp.SetNext(tempM.GetNext());
                            tempM.SetNext(null);
                        }
                        else {
                            temp = temp.GetNext();
                        }
                    } 
                    else {
                        temp = temp.GetNext();
                    }
                }
            }
        }

        public Node GetIndex(int index) {
            // Returns the node of a specific index.
            if (index <= (Size()-1)) {
                Node temp = head;
                for (int i = 0; i < index; i++) {
                    temp = temp.GetNext();
                }
                return temp;
            }
            // Default return value.
            return null;
        }

        public int Size() {
            // Returns the number of elements in list.
            int size = 0;
            Node temp = head;
            while (temp != null) {
                size++;
                temp = temp.GetNext();
            }
            return size;
        }

        public void PrintList() {
            // Prints the list.
            Node temp = head;
            while (temp != null) {
                Console.WriteLine(temp.GetKey() + " -> " + temp.GetData());
                temp = temp.GetNext();
            }
        }
    }
}
