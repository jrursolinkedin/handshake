using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman_Tree{
    class HuffmanTree {
        private Node root;
        // Easilier to make the tree from a given list of nodes.
        private LinkedList<Node> list;

        // Default Constructor.
        public HuffmanTree() {
            root = null;
            list = new LinkedList<Node>();
        }

        /** Adds a node to the list member variable.
         */
        public void AddList(Node newNode) {
            // Must add the nodes to the list before constructing the tree.
            list.AddLast(newNode);
        }

        /** Builds the tree data structure with all the given nodes
         *  within the list.
         *  + RecursiveBuildTree()
         */
        public void BuildTree() {
            // Temporary list for building the tree from the leaf subtree's.
            LinkedList<Node> tempList = new LinkedList<Node>();
            // Constructs the subtree's for all the character nodes.
            while (list.Count != 0) {
                if (list.Count > 1) {
                    Node leftChild = list.First.Value;
                    list.RemoveFirst();
                    Node rightChild = list.First.Value;
                    list.RemoveFirst();
                    Node parent = new Node('\0', (leftChild.GetFrequency() + rightChild.GetFrequency()));
                    parent.SetLeftNode(leftChild);
                    parent.SetRightNode(rightChild);
                    tempList.AddLast(parent);
                }
                else {
                    Node child = list.First.Value;
                    list.RemoveFirst();

                    tempList.AddLast(child);
                }
            }
            // Reinstantiate the list.
            list.Clear();
            list = tempList;
            // Build the tree with the given character nodes within the list.
            RecursiveBuildTree(list);
            root = list.First.Value;
            // Generates all the character nodes with binary codes.
            GenerateCodes(root, "");
        }

        private void RecursiveBuildTree(LinkedList<Node> tempList) {
            // Contruct the tree by the following steps...
            if (tempList.Count != 1) {
                // Take first two nodes from list.
                Node rightSubtree = tempList.First.Value;
                tempList.RemoveFirst();
                Node leftSubtree = tempList.First.Value;
                tempList.RemoveFirst();
                // Make a subtree of the given nodes.
                Node parent = new Node('\0', (leftSubtree.GetFrequency() + rightSubtree.GetFrequency()));
                parent.SetLeftNode(leftSubtree);
                parent.SetRightNode(rightSubtree);

                // Add back to list and continue until one node is left.
                tempList.AddFirst(parent);
                RecursiveBuildTree(tempList);
            }
        }

        /** Recursively assigns all the character (or leaf) nodes a
         *  binary code value.
         */
        private void GenerateCodes(Node tempRoot, string code) {
            // Generate all the binary codes for each of the character (leaf) nodes.
            if (tempRoot != null) {
                // At leaf node.
                if (tempRoot.GetLeftNode() == null && tempRoot.GetRightNode() == null) {
                    tempRoot.SetCode(code);
                    GenerateCodes(null, code);
                }
                else {
                    // Recursively go to the left and right.
                    GenerateCodes(tempRoot.GetRightNode(), (code + "1"));
                    GenerateCodes(tempRoot.GetLeftNode(), (code + "0"));
                }
            }
        }

        /** Finds a character (or leaf) node with the given
         *  character value and returns the node.
         *  + RecursiveSearch()
         */
        public Node Search(char Character) {
            // Check if the tree is empty.
            if (root != null) {
                return RecursiveSearch(root, Character);
            }
            else {
                return null;
            }
        }

        private Node RecursiveSearch(Node temp, char character) {
            // Looks through the tree to find the node with the given character.
            if (temp != null) {
                if (temp.GetCharacter().CompareTo(character) == 0) {
                    // Found node and returns it.
                    return temp;
                }
                else {
                    // Check the left and right...
                    Node left = RecursiveSearch(temp.GetLeftNode(), character);
                    Node right = RecursiveSearch(temp.GetRightNode(), character);

                    // Checks which side has the node and returns it.
                    if (left == null) {
                        return right;
                    }
                    else {
                        return left;
                    }
                }
            }
            else {
                return null;
            }
        }

        /** Finds the string (or line or data) that corresponds 
         *  with the given binary code and returns it.
         *  + RecursiveGetString()
         */
        public string GetString(string code) {
            // Check whether the tree is empty.
            if (root != null) {
                return RecursiveGetString(root, code, 0, "");
            }
            else {
                return "";
            }
        }

        private string RecursiveGetString(Node temp, string code, int index, string sentence) {
            // At character node.
            if (temp.GetLeftNode() == null && temp.GetRightNode() == null) {
                // Returns updated sentence...
                return RecursiveGetString(root, code, index, (sentence + temp.GetCharacter().ToString()));
            }
            // Checks if the index is within the array (string) boundries. 
            else if (index != code.Length) {
                // Go the left...
                if (code[index].CompareTo('0') == 0) {
                    return RecursiveGetString(temp.GetLeftNode(), code, (index + 1), sentence);
                }
                // Go to right...
                else if (code[index].CompareTo('1') == 0) {
                    return RecursiveGetString(temp.GetRightNode(), code, (index + 1), sentence);
                }
                else {
                    return sentence;
                }
            }
            else {
                // Once finished, return sentence.
                return sentence;
            }
        }
    }
}
