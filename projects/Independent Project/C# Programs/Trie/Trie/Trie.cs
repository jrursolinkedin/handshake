using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Trie{
    class Trie{
        // Member variable.
        private Node root;

        // Default Constructor.
        public Trie(){
            root = new Node();
        }

        public void Add(string word){
            // Adds a word to the trie.
            int index;
            Node pCrawl = root;
            // Traverses through each character in the word.
            for (int i = 0; i < word.Length; i++) {
                index = (word[i] - 'a');
                if (pCrawl.GetChildren(index) == null) {
                    pCrawl.SetChildren(index, new Node());
                }
                pCrawl = pCrawl.GetChildren(index);
            }
            pCrawl.SetEndOfWord(true);
        }

        public bool Search(String word){
            // Returns whether a word exists in the trie.
            int index;
            Node pCrawl = root;
            for (int i = 0; i < word.Length; i++) {
                index = word[i] - 'a';
                if (pCrawl.GetChildren(index) == null) {
                    return false;
                }
                pCrawl = pCrawl.GetChildren(index);
            }
            return (pCrawl != null && pCrawl.GetEndOfWord());
        }

        public void Display() {
            // Prints the trie.
            StringBuilder sb = new StringBuilder();
            // Recursive call.
            DisplayHelper(root, sb, 0);
        }

        private void DisplayHelper(Node node, StringBuilder str, int level) {
            // Recursive function for traversing the trie.
            if (node.GetEndOfWord()) {
                Console.WriteLine(str.ToString());
                str.Replace(str.ToString(), "");
            }
            for (int i = 0; i < 26; i++) {
                if (node.GetChildren(i) != null) {
                    str.Insert(level, char.ToString((char)(i + 'a')));
                    DisplayHelper(node.GetChildren(i), str, (level + 1));
                }
            }
        }
    }
}
