using System;
using System.Collections.Generic;
using System.Text;

namespace Skip_List{
    class Node{
        // Member variables.
        private int key;
        private Node left;
        private Node right;

        // Default Constructor.
        public Node() {
            key = 0;
            left = null;
            right = null;
        }

        // Parameter Constructor.
        public Node(int k) {
            key = k;
            left = null;
            right = null;
        }

        // Getters or Accessors:

        public int GetKey() {
            return key;
        }

        public Node GetLeft() {
            return left;
        }

        public Node GetRight() {
            return right;
        }

        // Setters or Mutators:

        public void SetKey(int k) {
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
