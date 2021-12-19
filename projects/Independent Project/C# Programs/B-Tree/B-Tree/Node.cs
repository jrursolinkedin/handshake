using System;
using System.Collections.Generic;
using System.Text;

namespace B_Tree{
    class Node{
        // Member variables.
        private bool isLeaf;
        private int numKeys;
        private int[] keys;
        private Node[] children;

        // N-Argument Constructor.
        public Node(int ord) {
            isLeaf = true;
            keys = new int[(2*ord)-1];
            children = new Node[2*ord];
        }

        // Parameter Constructor.
        public int Find(int key) {
            // Finds the index of a specific key.
            for (int i = 0; i < numKeys; i++) {
                if (keys[i] == key) {
                    return i;
                }
            }
            // Returns -1 by default.
            return -1;
        }

        // Getters or Accessors:

        public bool GetIsLeaf() {
            return isLeaf;
        }

        public int GetNumKeys() {
            return numKeys;
        }

        public int GetKey(int index) {
            return keys[index];
        }

        public Node GetChild(int index) {
            return children[index];
        }

        // Setters or Mutators: 

        public void SetIsLeaf(bool bValue) {
            isLeaf = bValue;
        }

        public void SetNumKeys(int numValue) {
            numKeys = numValue;
        }

        public void SetKey(int index, int newKey) {
            keys[index] = newKey;
        }

        public void SetChild(int index, Node newNode) {
            children[index] = newNode;
        
        }
    }
}
