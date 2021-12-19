using System;
using System.Collections.Generic;
using System.Text;

namespace Red_Black_Tree{
    class Node{
        // Member variables.
        private Node leftNode;
        private Node rightNode;
        private object key;
        private string color;

        // Default Constructor.
        public Node() {
            leftNode = null;
            rightNode = null;
            color = "red";
        }

        // Parameter Constructor.
        public Node(object k, string c) {
            leftNode = null;
            rightNode = null;
            key = k;
            color = c;
        }

        // Getters or Accesors:

        public Node GetLeftNode() {
            return leftNode;
        }

        public Node GetRightNode() {
            return rightNode;
        }

        public object GetKey() {
            return key;
        }

        public string GetColor() {
            return color;
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

        public void SetColor(string c) {
            color = c;
        }
    }
}
