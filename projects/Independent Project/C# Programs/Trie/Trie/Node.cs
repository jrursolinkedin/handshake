using System;
using System.Collections.Generic;
using System.Text;

namespace Trie{
    class Node{
        // Member variables.
        private static readonly int ALPHABET_SIZE = 26;
        private bool endOfWord;
        private Node[] children;

        // Default Constructor.
        public Node() {
            endOfWord = false;
            children = new Node[ALPHABET_SIZE];
            for (int i = 0; i < children.Length; i++) {
                children[i] = null;
            }
        }

        // Getters or Accessors:

        public int GetAlphabetSize() {
            return ALPHABET_SIZE;
        }

        public Node GetChildren(int index) {
            return children[index];
        }

        public bool GetEndOfWord() {
            return endOfWord;
        }

        // Setters or Mutators:

        public void SetChildren(int index, Node newNode) {
            children[index] = newNode;
        }

        public void SetEndOfWord(bool bValue) {
            endOfWord = bValue;
        }
    }
}
