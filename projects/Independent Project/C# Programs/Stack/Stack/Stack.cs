using System;
using System.Collections.Generic;
using System.Text;

namespace Stack{
    class Stack{
        // Member variables.
        private Node bottom;
        private Node top;

        // Default Constructor.
        public Stack(){
            bottom = top = null;
        }

        // Parameter Constructor.
        public Stack(object val){
            bottom = top = new Node(val, null);
        }

        public void Push(object val){
            // Check whether the stack is empty.
            if (bottom == null) {
                bottom = top = new Node(val, null);
            } 
            // Else, the stack has one or more elements.
            else {
                top.SetNext(new Node(val, null));
                top = top.GetNext();
            }
        }

        public void Pop(){
            // Check whehter stack is empty.
            if (bottom != null) {
                // Check whether there is only one element
                // in the list.
                if (bottom == top) {
                    bottom = top = null;
                }
                // Else, more than one element in the stack.
                else {
                    // Performs LIFO (Last-In-First-Out)
                    Node temp = bottom;
                    while (temp.GetNext() != top) {
                        temp = temp.GetNext();
                    }
                    temp.SetNext(null);
                    top = temp;
                }
            }
        }

        public object Peek(){
            // Return the top element in the stack.
            return top.GetData();
        }

        public int Size(){
            // Return the number of elements in the stack.
            Node temp = bottom;
            int size = 0;
            while (temp != null) {
                temp = temp.GetNext();
                size++;
            }
            return size;
        }

        public bool IsEmpty(){
            // Return whether the stack is empty.
            if (bottom == null) {
                return true;
            } 
            else {
                return false;
            }
        }

        public void Clear(){
            // Deletes the stack from memory.
            bottom = top = null;
        }
    }
}
