using System;
using System.Collections.Generic;
using System.Text;

namespace Stack{
    class Node{
        // Member variables.
        private object data;
        private Node next;

        // Default Constructor.
        public Node(){
            next = null;
        }

        // Parameter Constructor.
        public Node(object d, Node n){
            data = d;
            next = n;
        }

        // Getters or Accessors:

        public object GetData(){
            return data;
        }

        public Node GetNext(){
            return next;
        }

        // Setters or Mutators:

        public void SetData(object d){
            data = d;
        }

        public void SetNext(Node n){
            next = n;
        }
    }
}
