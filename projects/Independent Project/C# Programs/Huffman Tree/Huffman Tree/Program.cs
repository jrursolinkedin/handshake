using System;
using System.Text;

namespace Huffman_Tree{
    class Program{
        static void Main(string[] args){
            /** 
             *  Huffman Tree or Huffman Coding:
             *  A huffman tree is a binary binary in which each leaf of the tree
             *  corresponds to a valid character ('a', 'A', '1', '.'). The character 
             *  position in the tree is based on the character's frequency (# of times
             *  it shows up the string). The Huffman tree is used for text compression 
             *  without losing any data. It is the most efficient algorithm for 
             *  compressing (mathematically) without loss of data. The huffman tree has 
             *  the following properties below. 
             *  > Huffman Tree:
             *    * Left traversal has a value of 0.
             *    * Right traversal has a value of 1.
             *    * Leaf nodes to the right of the tree have lower frequencies.
             *    * Leaf nodes to the left of the tree have higher frequencies.
             *    
             *  - Example:
             *    
             *    Code:
             *    ----
             *    // "hello": 01101000 01100101 01101100 01101100 01101111
             *    // Total Bits: 8 * 5 = 40 bits
             *    string text = "hello";
             *    
             *    // bincode: 10 11 00 00 01
             *    // Total Bits: 2 * 5 = 10 bits
             *    String binCode = Encode(text);
             *    
             *    
             *     Table:
             *     -----
             *     character     frequency      code
             *     e             1              11
             *     h             1              10
             *     o             1              01
             *     l             2              00
             *     
             *     Tree:
             *     ----
             *     (Step 1)
             *     ['l']   ['o']   ['h']   ['e']
             *       2       1       1       1
             *     
             *     (Step 2)
             *          [3]          [2]
             *         /   \        /   \
             *      ['l'] ['o']  ['h'] ['e']
             *        2     1      1     1
             *        
             *     (Step 3)
             *                [5]
             *               /   \
             *              /     \
             *             /       \
             *            /         \ 
             *          [3]          [2]
             *         /   \        /   \
             *      ['l'] ['o']  ['h'] ['e']
             *        2     1      1     1 
             *        
             *     (Step 4)
             *                [5]
             *               /   \
             *             0/     \1
             *             /       \
             *            /         \ 
             *          [3]          [2]
             *        0/   \1      0/   \1
             *      ['l'] ['o']  ['h'] ['e']
             *        2     1      1     1   
             *       
             *  Huffman Tree Methods:
             *  - Populate(string txt): Populate the tree with a given string of text.
             *  - Encode(string txt): Returns a string of binary code from a given
             *                        line of text that is populated with a tree.
             *                        Uses the Populate() method.
             *  - Decode(string code): Returns a string of text from a given string of
             *                         binary code. Must call after calling N-Argument
             *                         Constructor or Populate().
             *  - PrintHuffmanTable(): Prints the Huffman table. The table contains 
             *                         all the characters with their frequency and
             *                         binary codes.
             */
        }
    }
}
