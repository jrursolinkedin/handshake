using System;
using System.Collections.Generic;
using System.Text;

namespace Red_Black_Tree{
    class RedBlackTree{
        // Member variable.
        private Node root;

        // Default Constructor.
        public RedBlackTree(){
            root = null;
        }

        // Parameter Constructor.
        public RedBlackTree(object k){
            root = new Node(k, "black");
        }

        public void Insert(object k){
            // Empty tree...
            if (root == null) {
                // Create new root node and fix-up.
                root = new Node(k, "red");
                InsertFixUp(root);
            }
            else {
                bool notFound = true;
                Node tempNode = root;
                // Find spot for the new node...
                while (notFound) {
                    // Moves right.
                    if (GetAsciiValue(tempNode.GetKey()) < GetAsciiValue(k)) {
                        if (tempNode.GetRightNode() != null) {
                            tempNode = tempNode.GetRightNode();
                        }
                        else {
                            tempNode.SetRightNode(new Node(k, "red"));
                            tempNode = tempNode.GetRightNode();
                            notFound = false;
                        }
                    }
                    // Moves left.
                    else if (GetAsciiValue(k) < GetAsciiValue(tempNode.GetKey())) {
                        if (tempNode.GetLeftNode() != null) {
                            tempNode = tempNode.GetLeftNode();
                        }
                        else {
                            tempNode.SetLeftNode(new Node(k, "red"));
                            tempNode = tempNode.GetLeftNode();
                            notFound = false;
                        }
                    }
                }
                // Find spot, fill spot, fix-up.
                InsertFixUp(tempNode);
            }
        }

        private void InsertFixUp(Node currentNode){
            // Case 1: Root
            if (currentNode == root) {
                if (currentNode.GetColor().Equals("red")) {
                    root.SetColor("black");
                }
            }
            // Case 2: Node's parent is red
            else if (GetParent(root, currentNode).GetColor().Equals("red")) {
                Node parent = GetParent(root, currentNode);
                Node grandparent = GetParent(root, parent);
                Node uncle = null;

                if (grandparent.GetRightNode() == parent) {
                    uncle = grandparent.GetLeftNode();
                }
                else {
                    uncle = grandparent.GetRightNode();
                }

                // Case 2a: Node's uncle is null or black
                if (uncle == null || uncle.GetColor().Equals("black")) {
                    // Left-Left Rotation...
                    if (grandparent.GetLeftNode() == parent && parent.GetLeftNode() == currentNode) {
                        if (grandparent != root) {
                            Node greatparent = GetParent(root, grandparent);
                            grandparent.SetLeftNode(null);

                            if (greatparent.GetRightNode() == grandparent) {
                                greatparent.SetRightNode(parent);
                            }
                            else {
                                greatparent.SetLeftNode(parent);
                            }

                            grandparent.SetLeftNode(parent.GetRightNode());
                            parent.SetRightNode(grandparent);

                            parent.SetColor("black");
                            grandparent.SetColor("red");
                        }
                        else {
                            grandparent.SetLeftNode(parent.GetRightNode());
                            parent.SetRightNode(grandparent);

                            parent.SetColor("black");
                            grandparent.SetColor("red");

                            root = parent;
                        }
                    }
                    // Right-Right Rotation...
                    else if (grandparent.GetRightNode() == parent && parent.GetRightNode() == currentNode) {
                        if (grandparent != root) {
                            Node greatparent = GetParent(root, grandparent);
                            grandparent.SetRightNode(null);

                            if (greatparent.GetRightNode() == grandparent) {
                                greatparent.SetRightNode(parent);
                            }
                            else {
                                greatparent.SetLeftNode(parent);
                            }

                            grandparent.SetRightNode(parent.GetLeftNode());
                            parent.SetLeftNode(grandparent);

                            parent.SetColor("black");
                            grandparent.SetColor("red");
                        }
                        else {
                            grandparent.SetRightNode(parent.GetLeftNode());
                            parent.SetLeftNode(grandparent);

                            parent.SetColor("black");
                            grandparent.SetColor("red");

                            root = parent;
                        }
                    }
                    // Left-Right Rotations
                    else if (grandparent.GetLeftNode() == parent && parent.GetRightNode() == currentNode) {
                        if (grandparent != root) {
                            Node greatparent = GetParent(root, grandparent);
                            parent.SetRightNode(null);

                            if (greatparent.GetRightNode() == grandparent) {
                                greatparent.SetRightNode(currentNode);
                            }
                            else {
                                greatparent.SetLeftNode(currentNode);
                            }

                            parent.SetRightNode(currentNode.GetLeftNode());
                            grandparent.SetLeftNode(currentNode.GetRightNode());
                            currentNode.SetLeftNode(parent);
                            currentNode.SetRightNode(grandparent);

                            currentNode.SetColor("black");
                            grandparent.SetColor("red");
                        }
                        else {
                            parent.SetRightNode(currentNode.GetLeftNode());
                            grandparent.SetLeftNode(currentNode.GetRightNode());
                            currentNode.SetLeftNode(parent);
                            currentNode.SetRightNode(grandparent);

                            currentNode.SetColor("black");
                            grandparent.SetColor("red");

                            root = currentNode;
                        }
                    }
                    // Right-Left Rotations
                    else {
                        if (grandparent != root) {
                            Node greatparent = GetParent(root, grandparent);
                            parent.SetLeftNode(null);

                            if (greatparent.GetRightNode() == grandparent) {
                                greatparent.SetRightNode(currentNode);
                            }
                            else {
                                greatparent.SetLeftNode(currentNode);
                            }

                            parent.SetLeftNode(currentNode.GetRightNode());
                            grandparent.SetRightNode(currentNode.GetLeftNode());
                            currentNode.SetRightNode(parent);
                            currentNode.SetLeftNode(grandparent);

                            currentNode.SetColor("black");
                            grandparent.SetColor("red");
                        }
                        else {
                            parent.SetLeftNode(currentNode.GetRightNode());
                            grandparent.SetRightNode(currentNode.GetLeftNode());
                            currentNode.SetRightNode(parent);
                            currentNode.SetLeftNode(grandparent);

                            currentNode.SetColor("black");
                            grandparent.SetColor("red");

                            root = currentNode;
                        }
                    }
                }
                // Case 2b: Node's uncle is red
                else {
                    parent.SetColor("black");
                    uncle.SetColor("black");
                    if (grandparent != root) {
                        grandparent.SetColor("red");
                    }

                }
            }
        }

        private Node GetParent(Node tempRoot, Node currentNode){
            // Returns a parent of a given node.
            if (root != currentNode && root != null) {
                // Moving to the right recursively...
                if (GetAsciiValue(tempRoot.GetKey()) < GetAsciiValue(currentNode.GetKey())) {
                    if (tempRoot.GetRightNode() != null) {
                        if (tempRoot.GetRightNode() == currentNode) {
                            return tempRoot;
                        }
                        else {
                            return GetParent(tempRoot.GetRightNode(), currentNode);
                        }
                    }
                }
                // Moving to the left recursively...
                else if (GetAsciiValue(currentNode.GetKey()) < GetAsciiValue(tempRoot.GetKey())) {
                    if (tempRoot.GetLeftNode() != null) {
                        if (tempRoot.GetLeftNode() == currentNode) {
                            return tempRoot;
                        }
                        else {
                            return GetParent(tempRoot.GetLeftNode(), currentNode);
                        }
                    }
                }
            }
            return null;
        }

        public Node Search(object k) {
            // Returns a node of specific value.
            return Find(root, k);
        }

        private Node Find(Node temp, object k){
            // Unable to find node.
            if (temp == null) {
                return null;
            }
            // Found node.
            else if (GetAsciiValue(temp.GetKey()) == GetAsciiValue(k)) {
                return temp;
            }
            // Node to the right (recursively)...
            else if (GetAsciiValue(temp.GetKey()) < GetAsciiValue(k)) {
                return Find(temp.GetRightNode(), k);
            }
            // Node to the left (recursively)...
            else if (GetAsciiValue(k) < GetAsciiValue(temp.GetKey())) {
                return Find(temp.GetLeftNode(), k);
            }
            else {
                return null;
            }
        }

        public void Print() {
            // Prints the tree.
            PrintInOrder(root);
        }

        private void PrintInOrder(Node temp){
            // Prints in following order: 
            // Left Child -> Parent -> Right Child
            if (root != null) {
                if (temp.GetLeftNode() != null) {
                    PrintInOrder(temp.GetLeftNode());
                }

                Console.WriteLine(temp.GetKey() + "(" + temp.GetColor() + ")");

                if (temp.GetRightNode() != null) {
                    PrintInOrder(temp.GetRightNode());
                }
            }
        }

        private int GetAsciiValue(object d){
            // Returns the ascii value of a given value.
            byte[] charByte = Encoding.ASCII.GetBytes(d.ToString());
            int sum = 0;
            for (int i = 0; i < charByte.Length; i++) {
                sum += charByte[i];
            }
            return sum;
        }
    }
}
