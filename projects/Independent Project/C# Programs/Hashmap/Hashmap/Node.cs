using System;
using System.Collections.Generic;
using System.Text;

namespace Hashmap{
    class Node{
        // Member variables.
        private object key;
        private object data;
        private Node next;

        // Default Constructor.
        public Node() {
            next = null;
        }

        // Parameter Constructor.
        public Node(object k, object d, Node n) {
            key = k;
            data = d;
            next = n;
        }

        // Getters or Accessors:

        public object GetKey() {
            return key;
        }

        public object GetData() {
            return data;
        }

        public Node GetNext() {
            return next;
        }

        // Setters or Mutators:

        public void SetKey(object k) {
            key = k;
        }

        public void SetData(object d) {
            data = d;
        }

        public void SetNext(Node n) {
            next = n;
        }
    }
}
