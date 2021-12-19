using System;
using System.Collections.Generic;
using System.Text;

namespace AVL_Tree{
    class Node{
        // Member variables.
        private Node leftNode;
        private Node rightNode;
        private object key;
        private int bFactor;

        // Default Constructor.
        public Node() {
            leftNode = null;
            rightNode = null;
        }

        // Parameter Constructor.
        public Node(object k) {
            leftNode = null;
            rightNode = null;
            key = k;
        }

        // Getters or Accessors:

        public Node GetLeftNode() {
            return leftNode;
        }

        public Node GetRightNode() {
            return rightNode;
        }

        public object GetKey() {
            return key;
        }

        public int GetBFactor() {
            return bFactor;
        }

        // Setters or Mutators:

        public void SetLeftNode(Node l) {
            leftNode = l;
        }

        public void SetRightNode(Node r) {
            rightNode = r;
        }

        public void SetKey(object k) {
            key = k;
        }

        public void SetBFactor(int b) {
            bFactor = b;
        }
    }
}
