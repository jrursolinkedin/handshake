using System;
using System.Collections.Generic;
using System.Text;

namespace Doubly_Linked_List{
    class Node{
        // Member variables.
        private object data;
        private Node prev;
        private Node next;

        // Default Constructor.
        public Node(){
            prev = null;
            next = null;
        }

        // Parameter Constructor.
        public Node(object d, Node p, Node n){
            data = d;
            prev = p;
            next = n;
        }

        // Getters or Accessors:

        public object GetData(){
            return data;
        }
        public Node GetPrev(){
            return prev;
        }
        public Node GetNext(){
            return next;
        }

        // Setters or Mutators:

        public void SetData(object d){
            data = d;
        }

        public void SetPrev(Node p){
            prev = p;
        }

        public void SetNext(Node n){
            next = n;
        }
    }
}
