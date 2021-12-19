using System;
using System.Collections.Generic;
using System.Text;

namespace Splay_Tree {
    class Node {
        // Member variables.
        private object key;
        private Node left;
        private Node right;

        // Default Constructor.
        public Node() {
            key = null;
            left = null;
            right = null;
        }

        // Parameter Constructor.
        public Node(object k) {
            key = k;
            left = null;
            right = null;
        }

        // Getters or Accessors:

        public object GetKey() {
            return key;
        }

        public Node GetLeft() {
            return left;
        }

        public Node GetRight() {
            return right;
        }

        // Setters or Mutators:

        public void SetKey(object k) {
            key = k;
        }

        public void SetLeft(Node l) {
            left = l;
        }

        public void SetRight(Node r) {
            right = r;
        }
    }
}
