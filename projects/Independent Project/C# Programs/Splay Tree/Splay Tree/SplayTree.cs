using System;
using System.Collections.Generic;
using System.Text;

namespace Splay_Tree {
    class SplayTree {
        // Member variable.
        private Node root;

        // Default Constructor.
        public SplayTree() {
            root = null;
        }

        // Parameter Constructor.
        public SplayTree(object k) {
            root = new Node(k);
        }

        public void Insert(object k) {
            // Empty tree...
            if (root == null) {
                root = new Node(k);
            }
            // One or more nodes in tree...
            else {
                bool found = false;
                Node temp = root;
                // Place new node in tree.
                while (!found) {
                    if (GetAsciiValue(k) < GetAsciiValue(temp.GetKey())) {
                        if (temp.GetLeft() == null) {
                            temp.SetLeft(new Node(k));
                            temp = temp.GetLeft();
                            found = true;
                        }
                        else {
                            temp = temp.GetLeft();
                        }
                    }
                    else {
                        if (temp.GetRight() == null) {
                            temp.SetRight(new Node(k));
                            temp = temp.GetRight();
                            found = true;
                        }
                        else {
                            temp = temp.GetRight();
                        }
                    }
                }
                // Rearrange the tree with new node as root.
                Splay(temp);
            }
        }

        public void DeleteTDS(object k) {
            // Top-Down Splaying Deletion Algorithm.
            // Check whether the tree is empty and if the key exists
            // in tree.
            if (root != null && Search(root, k) != null) {
                // Splay the node being deleted.
                Node delNode = Search(root, k);
                Splay(delNode);
                // Only one node...
                if (root.GetLeft() == null && root.GetRight() == null) {
                    root = null;
                }
                // No right node...
                else if (root.GetLeft() != null && root.GetRight() == null) {
                    root = root.GetLeft();
                }
                // No left node...
                else if (root.GetLeft() == null && root.GetRight() != null) {
                    root = root.GetRight();
                }
                // Merging the left and right subtree's...
                else {
                    Node leftSubtree = root.GetLeft();
                    Node rightSubtree = root.GetRight();
                    root.SetLeft(null);
                    root.SetRight(null);
                    root = leftSubtree;
                    // Finding the key within the "leftSubtree".
                    bool foundMax = false;
                    while (!foundMax) {
                        if (leftSubtree.GetRight() != null) {
                            leftSubtree = leftSubtree.GetRight();
                        }
                        else {
                            foundMax = true;
                        }
                    }
                    Splay(leftSubtree);
                    root.SetRight(rightSubtree);
                }
            }
        }

        public void DeleteBUS(object k) {
            // Bottom-Up Splaying Deletion Algorithm.
            // Check whether the tree is empty and if the key exists
            // in tree.
            if (root != null && Search(k) != null) {
                Node delNode = Search(k);
                Node parNode = GetParent(root, delNode);
                // No children...
                if (delNode.GetLeft() == null && delNode.GetRight() == null) {
                    if (parNode != null) {
                        if (parNode.GetLeft() == delNode) {
                            parNode.SetLeft(null);
                        }
                        else {
                            parNode.SetRight(null);
                        }
                        Splay(parNode);
                    }
                    else {
                        root = null;
                    }
                }
                // One child (left child)...
                else if (delNode.GetLeft() != null && delNode.GetRight() == null) {
                    if (parNode != null) {
                        if (parNode.GetLeft() == delNode) {
                            parNode.SetLeft(delNode.GetLeft());
                            delNode.SetLeft(null);
                        }
                        else {
                            parNode.SetRight(delNode.GetLeft());
                            delNode.SetLeft(null);
                        }
                        Splay(parNode);
                    }
                    else {
                        root = delNode.GetLeft();
                        delNode.SetLeft(null);
                    }
                }
                // One child (right child)...
                else if (delNode.GetLeft() == null && delNode.GetRight() != null) {
                    if (parNode != null) {
                        if (parNode.GetLeft() == delNode) {
                            parNode.SetLeft(delNode.GetRight());
                            delNode.SetRight(null);
                        }
                        else {
                            parNode.SetRight(delNode.GetRight());
                            delNode.SetRight(null);
                        }
                        Splay(parNode);
                    }
                    else {
                        root = delNode.GetRight();
                        delNode.SetRight(null);
                    }
                }
                // Two children...
                else {
                    object tempKey;
                    Node successor = delNode.GetRight();
                    // Find successor.
                    while (successor.GetLeft() != null) {
                        successor = successor.GetLeft();
                    }
                    tempKey = successor.GetKey();
                    if (GetParent(root, successor).GetLeft() == successor) {
                        GetParent(root, successor).SetLeft(successor.GetRight());
                    }
                    else {
                        GetParent(root, successor).SetRight(successor.GetRight());
                    }
                    delNode.SetKey(tempKey);
                    if (parNode != null) {
                        Splay(parNode);
                    }
                }
            }
        }

        private void Splay(Node temp) {
            // Node msut be brought up to the root position.
            while (GetParent(root, temp) != null) {
                if (GetParent(root, GetParent(root, temp)) == null) {
                    // Right Rotation (Zig Rotation).
                    if (temp == GetParent(root, temp).GetLeft()) {
                        RightRotation(GetParent(root, temp));
                    }
                    // Left Rotation (Zag Rotation).
                    else {
                        LeftRotation(GetParent(root, temp));
                    }
                }
                // Right-Right Rotation (Zig-Zig Rotation).
                else if (temp == GetParent(root, temp).GetLeft() && GetParent(root, temp) == GetParent(root, GetParent(root, temp)).GetLeft()) {
                    RightRotation(GetParent(root, GetParent(root, temp)));
                    RightRotation(GetParent(root, temp));
                }
                // Left-Left Rotation (Zag-Zag Rotation).
                else if (temp == GetParent(root, temp).GetRight() && GetParent(root, temp) == GetParent(root, GetParent(root, temp)).GetRight()) {
                    LeftRotation(GetParent(root, GetParent(root, temp)));
                    LeftRotation(GetParent(root, temp));
                }
                // Right-Left Rotation (Zig-Zag Rotation).
                else if (temp == GetParent(root, temp).GetRight() && GetParent(root, temp) == GetParent(root, GetParent(root, temp)).GetLeft()) {
                    LeftRotation(GetParent(root, temp));
                    RightRotation(GetParent(root, temp));
                }
                // Left-Right Rotation (Zag-Zig Rotation).
                else {
                    RightRotation(GetParent(root, temp));
                    LeftRotation(GetParent(root, temp));
                }
            }
        }

        private Node GetParent(Node tempR, Node childNode) {
            // Recursive condition.
            if (root != null && childNode != root && tempR != null) {
                // Checking left...
                if (GetAsciiValue(childNode.GetKey()) < GetAsciiValue(tempR.GetKey())) {
                    if (tempR.GetLeft() == childNode) {
                        return tempR;
                    }
                    else {
                        // Recursive call.
                        return GetParent(tempR.GetLeft(), childNode);
                    }
                }
                // Checking right...
                else {
                    if (tempR.GetRight() == childNode) {
                        return tempR;
                    }
                    else {
                        // Recursive call.
                        return GetParent(tempR.GetRight(), childNode);
                    }
                }
            }
            else {
                // Default return value.
                return null;
            }
        }

        public Node Search(object k) {
            // Check whether tree is empty.
            if (root != null) {
                // Recursive method.
                Node foundNode = Search(root, k);
                // Splay the found node
                if (foundNode != null) {
                    Splay(foundNode);
                }
                return foundNode;
            }
            else {
                // Default return value.
                return null;
            }
        }

        private Node Search(Node tempR, object k) {
            // Recursive condition.
            if (tempR != null) {
                if (GetAsciiValue(k) == GetAsciiValue(tempR.GetKey())) {
                    return tempR;
                }
                if (GetAsciiValue(k) < GetAsciiValue(tempR.GetKey())) {
                    // Recursive call.
                    return Search(tempR.GetLeft(), k);
                }
                else {
                    // Recursive call.
                    return Search(tempR.GetRight(), k);
                }
            }
            else {
                // Default return value.
                return null;
            }
        }

        private void RightRotation(Node tempP) {
            Node parent = GetParent(root, tempP);
            bool right = true;
            // Setting parent's child to null.
            if (parent != null) {
                if (parent.GetLeft() == tempP) {
                    parent.SetLeft(null);
                    right = false;
                }
                else {
                    parent.SetRight(null);
                    right = true;
                }
            }
            // Right Rotation adjustments.
            Node child = tempP.GetLeft();
            tempP.SetLeft(child.GetRight());
            child.SetRight(tempP);
            // Setting "parent" or "root" to new node (child).
            if (parent != null) {
                if (right == false) {
                    parent.SetLeft(child);
                }
                else {
                    parent.SetRight(child);
                }
            }
            else {
                root = child;
            }
        }

        private void LeftRotation(Node tempP) {
            Node parent = GetParent(root, tempP);
            bool right = true;
            // Setting parent's child to null.
            if (parent != null) {
                if (parent.GetLeft() == tempP) {
                    parent.SetLeft(null);
                    right = false;
                }
                else {
                    parent.SetRight(null);
                    right = true;
                }
            }
            // Left Rotation adjustments.
            Node child = tempP.GetRight();
            tempP.SetRight(child.GetLeft());
            child.SetLeft(tempP);
            tempP = child;
            // Setting "parent" or "root" to new node (child).
            if (parent != null) {
                if (right == false) {
                    parent.SetLeft(child);
                }
                else {
                    parent.SetRight(child);
                }
            }
            else {
                root = child;
            }
        }

        public void Print() {
            Console.WriteLine("---------");
            if (root != null) {
                Print(root);
                Console.WriteLine("Root: " + root.GetKey());
            }
            Console.WriteLine("---------");
        }

        private void Print(Node tempR) {
            // Inorder Traversal.
            if (tempR != null) {
                // Recursive call.
                Print(tempR.GetLeft());
                Console.WriteLine(tempR.GetKey());
                // Recursive call.
                Print(tempR.GetRight());
            }
        }

        private int GetAsciiValue(object k) {
            byte[] charByte = Encoding.ASCII.GetBytes(k.ToString());
            int sum = 0;
            for (int i = 0; i < charByte.Length; i++) {
                sum += charByte[i];
            }
            return sum;
        }
    }
}
