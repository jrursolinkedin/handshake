using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Search_Tree{
    class Node{
        // Member variables.
        private object data;
        private Node left;
        private Node right;

        // Default Constructor.
        public Node() {
            left = null;
            right = null;
        }

        // Parameter Constructor.
        public Node(object d, Node l, Node r) {
            data = d;
            left = l;
            right = r;
        }

        // Getters or Accessors:

        public object GetData() {
            return data;
        }

        public Node GetLeft() {
            return left;
        }

        public Node GetRight() {
            return right;
        }

        // Setters or Mutators:

        public void SetData(object d) {
            data = d;
        }

        public void SetLeft(Node l) {
            left = l;
        }

        public void SetRight(Node r) {
            right = r;
        }
    }
}
