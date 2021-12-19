using System;

namespace Trie{
    class Program{
        static void Main(string[] args){
            /**
             *  Trie:
             *  A trie is an efficient information re"trie"val data structure.
             *  Using trie, search complexities can be brought to optimal limit
             *  (key length).This data strucutre is mostly used to stored words
             *  in the English language. It isn't taught in schools, but it is 
             *  constantly being used in the industry.
             *                              
             *                               Trie:            Node:
             *                               [root]     Node[] = new Node[26]
             *                              /      \     Self Explanatory -^
             *                           [c]       [h]
             *                          /   \     / 
             *                       [a]    [h] [a]
             *                        |      |   |
             *                       [t]    [e] [t]
             *                        |      |   |
             *                      "cat"   [s] "hat"
             *                               |
             *                              [s]
             *                               |
             *                            "chess"
             *                              
             *  Trie Methods:
             *  - Add(string word): Inserts a word into the tree.
             *  - Search(string word): If the word is found in the tree, it 
             *                         returns true.
             *  - Display(): Displays all the words in the trie structure.
             */
        }
    }
}
