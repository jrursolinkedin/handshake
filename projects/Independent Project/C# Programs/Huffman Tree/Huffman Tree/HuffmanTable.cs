using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman_Tree{
    class HuffmanTable{
        // Purpose: Keeps track of the attributes associated
        // with each character.
        private Character[] table;
        // Purpose: Accessing the characters from the newly 
        // generated binary codes.
        private HuffmanTree tree;
        // Purpose: To exame the efficiency (or improvement)
        // from the compression.
        private int totalBitsBefore;
        private int totalBitsAfter;
        // Purpose: A back up of the given string to be 
        // compressed.
        private string text;

        // Default Constructor.
        public HuffmanTable(){
            tree = new HuffmanTree();
            totalBitsBefore = 0;
            totalBitsAfter = 0;
            text = "";
        }

        // Parameter Constructor.
        public HuffmanTable(string txt){
            tree = new HuffmanTree();
            Populate(txt);
        }

        /** Populates the table and the tree with a given
         *  string.
         */
        public void Populate(string txt) {
            // Update member variables.
            text = txt;
            totalBitsBefore = (txt.Length * 8);
            // Create a temporary list to store all the different characters.
            List<char> lst = new List<char>();
            // Get all the different letters and store in list.
            for (int i = 0; i < txt.Length; i++) {
                if (!(lst.Contains(txt[i]))) {
                    lst.Add(txt[i]);
                }
            }
            // Sort the letters within the list.
            for (int j = 0; j < (lst.Count-1); j++) {
                int minIndex = j;
                for (int k = j+1; k < lst.Count; k++) {
                    if (lst[k].CompareTo(lst[minIndex]) < 0) {
                        minIndex = k;
                    }
                }
                char tempC = lst[j];
                lst[j] = lst[minIndex];
                lst[minIndex] = tempC;

            }
            // Populate the Huffman table with all the letters.
            table = new Character[lst.Count];
            for (int l = 0; l < lst.Count; l++) {
                int freq = 0;
                for (int m = 0; m < txt.Length; m++) {
                    if (lst[l].CompareTo(txt[m]) == 0) {
                        freq++;
                    }
                }
                table[l] = new Character(lst[l], freq);
            }
            // Sort the table by frequences from lowest to highest.
            for (int v = 0; v < (table.Length); v++) {
                int minFreq = v;
                for (int w = v+1; w < table.Length; w++) {
                    if (table[w].GetFrequency() < table[minFreq].GetFrequency()) {
                        minFreq = w;
                    }
                }
                Character tempC = table[v];
                table[v] = table[minFreq];
                table[minFreq] = tempC;
            }
            // Add to list in the tree.
            for (int x = 0; x < table.Length; x++) {
                tree.AddList(new Node(table[x].GetCharacter(), table[x].GetFrequency()));
            }
            // Populate the tree with the given list values.
            tree.BuildTree();
            // Populate table with binary codes.
            totalBitsAfter = 0;
            for (int y = 0; y < table.Length; y++) {
                table[y].SetCode(tree.Search(table[y].GetCharacter()).GetCode());
                for (int z = 0; z < table[y].GetFrequency(); z++) {
                    totalBitsAfter += table[y].GetCode().Length;
                }
            }  
        }

        /** With some given text, it populates the table and the
         *  tree and returns the binary code associated with the
         *  text.
         */
        public string Encode(string txt) {
            // Update table and tree.
            Populate(txt);
            // Gets the binary code associated with the given text.
            string encodeText = "";
            for (int i = 0; i < txt.Length; i++) {
                for (int j = 0; j < table.Length; j++) {
                    if (table[j].GetCharacter().CompareTo(txt[i]) == 0) {
                        encodeText += table[j].GetCode();
                    }
                }
            }
            // Retruns binary code.
            return encodeText;
        }

        /** Given a string of binary code, it looks into the tree
         *  and gets all the characters. It concatenates all the 
         *  characters into a string and text and returns it.
         *  (Node): 1.) Must call the N-Argument Constructor or
         *              Populate() before calling this method!
         *          2.) Only binary code associated with the 
         *              characters inside table/tree.    
         */
        public string Decode(string code) {
            return tree.GetString(code);
        }

        /** Prints out information about the table, tree, and
         *  character attributes.
         */
        public void PrintHuffmanTable() {
            Console.WriteLine("------------------------");
            Console.WriteLine("Bits Before: " + totalBitsBefore);
            Console.WriteLine("Bits After: " + totalBitsAfter);
            double percent = 100*(1.00 - (double)totalBitsAfter / totalBitsBefore);
            Console.WriteLine("Saved " + percent + " %");
            Console.WriteLine("------------------------");
            Console.WriteLine(" Char  |  Freq   |  Code");
            Console.WriteLine("------------------------");
            for (int i = 0; i < table.Length; i++) {
                Console.WriteLine(" " + table[i].GetCharacter() + "        " + table[i].GetFrequency() + "         " + table[i].GetCode());
            }
        }
    }
}
