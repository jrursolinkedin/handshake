using System;
using System.Collections.Generic;
using System.Text;

namespace LRU_Cache{
    class Node{
        // Member variables.
        private object key;
        private object val;
        private Node prev;
        private Node next;

        // Default Constructor.
        public Node() {
            key = null;
            key = null;
            prev = null;
            next = null;
        }

        // Parameter Constructor.
        public Node(object k, object v) {
            key = k;
            val = v;
            prev = null;
            next = null;
        }

        // Gettters or Accessors:

        public object GetKey() {
            return key;
        }

        public object GetVal() {
            return val;
        }

        public Node GetPrev() {
            return prev;
        }

        public Node GetNext() {
            return next;
        }

        // Setters or Mutators:

        public void SetKey(object k) {
            key = k;        
        }

        public void SetVal(object v) {
            val = v;
        }

        public void SetPrev(Node p) {
            prev = p;
        }

        public void SetNext(Node n) {
            next = n;
        }
    }
}
