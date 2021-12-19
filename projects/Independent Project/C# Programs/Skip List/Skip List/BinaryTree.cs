using System;
using System.Collections.Generic;
using System.Text;

namespace Skip_List{
    class BinaryTree{
        // Member variable.
        private Node root;

        // Default Constructor.
        public BinaryTree() {
            root = null;
        }

        public void Insert(int key, int level) {
            // Case 1: Root is null.
            if (root == null) {
                root = new Node(key);
                Node tempR = root;
                for (int i = 0; i < (level - 1); i++) {
                    tempR.SetLeft(new Node(key));
                    tempR = tempR.GetLeft();
                }
            }
            // Case 2: One or more nodes.
            else {
                // Temporary root node.
                Node tempR = root;
                // Count the number of levels.
                int cnt = 0;
                while (tempR != null) {
                    cnt++;
                    tempR = tempR.GetLeft();
                }
                tempR = root;
                // Case 2.1: Not the top level.
                if (cnt != level) {
                    bool found = false;
                    // Find the level position in the tree.
                    for (int i = 0; i < (cnt - level); i++) {
                        found = false;
                        while (tempR.GetRight() != null && !found) {
                            if (key > tempR.GetRight().GetKey()) {
                                tempR = tempR.GetRight();
                            }
                            else {
                                found = true;
                            }
                        }
                        tempR = tempR.GetLeft();
                    }
                    found = false;
                    Node newNode = new Node(key);
                    // Nodes within the level.
                    if (tempR.GetRight() != null) {
                        while (tempR.GetRight() != null && !found) {
                            if (key < tempR.GetRight().GetKey()) {
                                newNode.SetRight(tempR.GetRight());
                                tempR.SetRight(newNode);
                                found = true;
                            }
                            else {
                                tempR = tempR.GetRight();
                                if (tempR.GetRight() == null) {
                                    tempR.SetRight(newNode);
                                    found = true;
                                }
                            }
                        }
                    }
                    // No nodes within the level.
                    else {
                        tempR.SetRight(newNode);
                    }
                    // Create the rest of the levels.
                    if (level != 1) {
                        for (int j = 0; j < (level - 1); j++) {
                            newNode.SetLeft(new Node(key));
                            newNode = newNode.GetLeft();
                        }
                    }
                }
                // Case 2.2: Top level.
                else {
                    bool found = false;
                    Node newNode = new Node(key);
                    // Insert a node into the right side of the tree.
                    while (tempR != null && !found) {
                        if (key < tempR.GetKey()) {
                            if (tempR == root) {
                                newNode.SetRight(tempR);
                                root = newNode;
                                found = true;
                            }
                            else {
                                Node prev = root;
                                while (prev.GetRight() != tempR) {
                                    prev = prev.GetRight();
                                }
                                newNode.SetRight(tempR);
                                prev.SetRight(newNode);
                                found = true;
                            }
                        }
                        else if(tempR.GetKey() < key) {
                            if (tempR.GetRight() != null) {
                                tempR = tempR.GetRight();
                            }
                            else {
                                tempR.SetRight(newNode);
                                found = true;
                            }
                        }
                    }
                    // Create the rest of the levels.
                    for (int j = 0; j < (level - 1); j++) {
                        newNode.SetLeft(new Node(key));
                        newNode = newNode.GetLeft();
                    }
                }
            }
        }

        public Node Search(int key) {
            // Check whether tree is empty.
            if (root != null) {
                // Call Recursive method.
                return Search(root, key);
            }
            else {
                // Default return.
                return null;
            }
        }

        private Node Search(Node tempR, int key) {
            if (tempR != null) {
                // Case 1: Found node.
                if (key == tempR.GetKey()) {
                    // Return the found node.
                    return tempR;
                }
                // Case 2: Node to the right...
                else if (tempR.GetRight() != null) {
                    if (key < tempR.GetRight().GetKey()) {
                        // Recursive call the left.
                        return Search(tempR.GetLeft(), key);
                    }
                    else {
                        // Recursive call the right.
                        return Search(tempR.GetRight(), key);
                    }
                }
                // Case 3: No node to the right...
                else if (tempR.GetRight() == null) {
                    // Recursive call the left.
                    return Search(tempR.GetLeft(), key);
                }
                // Case 4: Default - Return null.
                else {
                    // Default Return.
                    return null;
                }
            }
            else {
                // Default Return.
                return null;
            }
        }

        public void Print() {
            // Calling recursive method.
            Print(root);
        }

        private void Print(Node tempR) {
            // Prin the tree inorder traversal.
            if (tempR != null) {
                Print(tempR.GetLeft());
                Console.WriteLine(tempR.GetKey());
                Print(tempR.GetRight());
            }
        }
    }
}
