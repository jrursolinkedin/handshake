using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace Doubly_Linked_List{
    class DoublyLinkedList{
        // Member variables.
        private Node head;
        private Node tail;

        // Default Constructor.
        public DoublyLinkedList(){
            head = tail = null;
        }

        // Parameter Constructor.
        public DoublyLinkedList(int n){
            head = tail = new Node(n, null, null);
        }

        public void Add(object val) {
            // Empty list...
            if (head == null) {
                head = tail = new Node(val, null, null);
            }
            // Else, list has one or more nodes...
            else {
                Node tempNode = tail;
                tail.SetNext(new Node(val, null, null));
                tail = tail.GetNext();
                tail.SetPrev(tempNode);
            }
        }

        public void Remove(object val) {
            // Checks whether list is empty or value is within
            // the list.
            if (head != null && Search(val)) {
                // Deleted node is the only node in the list.
                if (head == tail && head.GetData().Equals(val)) {
                    head = tail = null;
                } 
                // Deleted node is the head in the list.
                else if (head.GetData().Equals(val)) {
                    Node tempH = head;
                    head = head.GetNext();
                    head.SetPrev(null);
                    tempH.SetNext(null);
                } 
                // Delted node is the tail in the list.
                else if (tail.GetData().Equals(val)) {
                    Node tempT = head;
                    while (tempT.GetNext() != tail) {
                        tempT = tempT.GetNext();
                    }
                    tail.SetPrev(null);
                    tempT.SetNext(null);
                    tail = tempT;
                } 
                // Deleted node is in the middle of the tree.
                else {
                    Node tempT = head;
                    // Travels through the list.
                    while ((tempT.GetNext() != null) && !(tempT.GetNext().GetData().Equals(val))) {
                        tempT = tempT.GetNext();
                    }
                    Node tempD = tempT.GetNext();
                    Node tempN = tempD.GetNext();
                    tempD.SetPrev(null);
                    tempD.SetNext(null);
                    tempT.SetNext(tempN);
                    tempN.SetPrev(tempT);
                }
            }
        }

        public object Get(int index){
            // Finds a specific index within the list.
            if (head != null && index <= (Size() - 1)) {
                Node tempT = head;
                // Travels through the list.
                for (int i = 0; i < index; i++) {
                    tempT = tempT.GetNext();
                }
                return tempT.GetData();
            }
            // Default return value.
            return -1;
        }

        public int Size() {
            // Gets the of the list.
            Node temp = head;
            int size = 0;
            while (temp != null) {
                size++;
                temp = temp.GetNext();
            }
            return size;
        }

        public bool IsEmpty(){
            // Checks whether the list is empty.
            if (head == null) {
                return true;
            } 
            else {
                return false;
            }
        }

        public void Clear(){
            // Deletes the list from memory.
            head = tail = null;
        }

        private bool Search(object val) {
            // Determines whether a specific value exists
            // in the list.
            Node temp = head;
            while (temp != null) {
                if (temp.GetData().Equals(val)) {
                    return true;
                }
                temp = temp.GetNext();
            }
            return false;
        }
    }
}
