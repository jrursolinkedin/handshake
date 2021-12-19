using System; 
using System.Collections.Generic;
using System.Text;

namespace Huffman_Tree{
    class Node{
        // Two types of Nodes:
        // 1.) Character (or Leaf) Nodes: Have all member variables.
        // 2.) Non-Leaf Nodes: Don't have character and code variables.
        private char character;
        private int frequency;
        private string code;
        private Node leftN;
        private Node rightN;

        // Default Constructor.
        public Node() {
            character = '\0';
            frequency = 0;
            code = "";
            leftN = null;
            rightN = null;
        }

        // Parameter Constructor.
        public Node(char c, int f) {
            character = c;
            frequency = f;
            code = "";
            leftN = null;
            rightN = null;
        }

        // Getters or Accessors:

        public char GetCharacter() {
            return character;
        }

        public int GetFrequency() {
            return frequency;
        }

        public string GetCode() {
            return code;
        }

        public Node GetLeftNode() {
            return leftN;
        }

        public Node GetRightNode() {
            return rightN;
        }

        // Setters or Mutators:

        public void SetCharacter(char c) {
            character = c;
        }

        public void SetFrequency(int f) {
            frequency = f;
        }

        public void SetLeftNode(Node l) {
            leftN = l;
        }

        public void SetRightNode(Node r) {
            rightN = r;
        }

        public void SetCode(string cd) {
            code = cd;
        }
    }
}
