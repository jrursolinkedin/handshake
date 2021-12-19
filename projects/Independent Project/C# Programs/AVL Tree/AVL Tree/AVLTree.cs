using System;
using System.Collections.Generic;
using System.Text;

namespace AVL_Tree{
    class AVLTree{
        // Member variable.
        private Node root;

        // Default Constructor.
        public AVLTree() {
            root = null;
        }

        // Parameter Constructor.
        public AVLTree(object k) {
            root = new Node(k);
            // Should assign the balance factor of root to 0.
            BalanceTree(root);
        }

        public void Insert(object k) {
            Node newNode = new Node(k);
            // Empty tree...
            if (root == null) {
                root = newNode;
            }
            // Tree with one or more nodes...
            else {
                root = RecursiveInsert(root, newNode);
            }
            // Assigns the balance factor for each node. 
            BalanceTree(root);
        }

        private Node RecursiveInsert(Node currentNode, Node newNode) {
            // Case 1: CurrentNode is equal to null.
            if (currentNode == null) {
                currentNode = newNode;
                return currentNode;
            }
            // Case 2: Moving to the left.
            else if (GetAsciiValue(newNode.GetKey()) < GetAsciiValue(currentNode.GetKey())) {
                currentNode.SetLeftNode(RecursiveInsert(currentNode.GetLeftNode(), newNode));
                int balanceFactor = MaxDepth(currentNode.GetLeftNode()) - MaxDepth(currentNode.GetRightNode());
                if (balanceFactor > 1) {
                    if ((MaxDepth(currentNode.GetLeftNode().GetLeftNode()) - MaxDepth(currentNode.GetLeftNode().GetRightNode())) > 0) {
                        currentNode = RotateLL(currentNode);
                    }
                    else {
                        currentNode = RotateLR(currentNode);
                    }
                }
                else if (balanceFactor < -1) {
                    if ((MaxDepth(currentNode.GetRightNode().GetLeftNode()) - MaxDepth(currentNode.GetRightNode().GetRightNode())) > 0) {
                        currentNode = RotateRL(currentNode);
                    }
                    else {
                        currentNode = RotateRR(currentNode);
                    }
                }
            }
            // Case 3: Moving to the right.
            else if (GetAsciiValue(newNode.GetKey()) > GetAsciiValue(currentNode.GetKey())) {
                currentNode.SetRightNode(RecursiveInsert(currentNode.GetRightNode(), newNode));
                int balanceFactor = MaxDepth(currentNode.GetLeftNode()) - MaxDepth(currentNode.GetRightNode());
                if (balanceFactor > 1) {
                    if ((MaxDepth(currentNode.GetLeftNode().GetLeftNode()) - MaxDepth(currentNode.GetLeftNode().GetRightNode())) > 0) {
                        currentNode = RotateLL(currentNode);
                    }
                    else {
                        currentNode = RotateLR(currentNode);
                    }
                }
                else if (balanceFactor < -1) {
                    if ((MaxDepth(currentNode.GetRightNode().GetLeftNode()) - MaxDepth(currentNode.GetRightNode().GetRightNode())) > 0) {
                        currentNode = RotateRL(currentNode);
                    }
                    else {
                        currentNode = RotateRR(currentNode);
                    }
                }
            }

            return currentNode;
        }

        public void Delete(object k) {
            // Check if tree is empty and if the any node has the key value.
            if (root != null && RecursiveSearch(root, k) != null) {
                root = RecursiveDelete(root, k);
                // Assigns the balance factor for each node. 
                BalanceTree(root);
            }
        }
        
        private Node RecursiveDelete(Node currentNode, object k) {
            Node parent;
            // Case 1: CurrentNode is equals to null.
            if (currentNode == null) {
                return null;
            }
            // Case 2: Moving to the left.
            else if (GetAsciiValue(k) < GetAsciiValue(currentNode.GetKey())) {
                currentNode.SetLeftNode(RecursiveDelete(currentNode.GetLeftNode(), k));
                if ((MaxDepth(currentNode.GetLeftNode()) - MaxDepth(currentNode.GetRightNode())) == -2) {
                    if ((MaxDepth(currentNode.GetRightNode().GetLeftNode()) - MaxDepth(currentNode.GetRightNode().GetRightNode())) <= 0) {
                        currentNode = RotateRR(currentNode);
                    }
                    else {
                        currentNode = RotateRL(currentNode);
                    }
                }
            }
            // Case 3: Moving to the Right.
            else if (GetAsciiValue(k) > GetAsciiValue(currentNode.GetKey())) {
                currentNode.SetRightNode(RecursiveDelete(currentNode.GetRightNode(), k));
                if ((MaxDepth(currentNode.GetLeftNode()) - MaxDepth(currentNode.GetRightNode())) == 2) {
                    if ((MaxDepth(currentNode.GetLeftNode().GetLeftNode()) - MaxDepth(currentNode.GetLeftNode().GetRightNode())) >= 0) {
                        currentNode = RotateLL(currentNode);
                    }
                    else {
                        currentNode = RotateLR(currentNode);
                    }
                }
            }
            // Case 4: If the key is found.
            else if (currentNode.GetRightNode() != null) {
                // Deleting the successor node.
                parent = currentNode.GetRightNode();
                while (parent.GetLeftNode() != null) {
                    parent = parent.GetLeftNode();
                }
                currentNode.SetKey(parent.GetKey());
                currentNode.SetRightNode(RecursiveDelete(currentNode.GetRightNode(), parent.GetKey()));
                if ((MaxDepth(currentNode.GetLeftNode()) - MaxDepth(currentNode.GetRightNode())) == 2) {
                    if ((MaxDepth(currentNode.GetLeftNode().GetLeftNode()) - MaxDepth(currentNode.GetLeftNode().GetRightNode())) >= 0) {
                        currentNode = RotateLL(currentNode);
                    }
                    else { 
                        currentNode = RotateLR(currentNode); 
                    }
                }
            }
            // Case 5: "if current.left != null".
            else {
                return currentNode.GetLeftNode();
            }

            return currentNode;
        }

        public Node Search(object k){
            // Returns the node of a given value.
            return RecursiveSearch(root, k);
        }

        private Node RecursiveSearch(Node temp, object k){
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
                return RecursiveSearch(temp.GetRightNode(), k);
            }
            // Node to the left (recursively)...
            else if (GetAsciiValue(k) < GetAsciiValue(temp.GetKey())) {
                return RecursiveSearch(temp.GetLeftNode(), k);
            }
            else {
                return null;
            }
        }

        private void BalanceTree(Node temp) {
            // Recursive method for balancing the tree.
            if (temp != null) {
                // Sets balance factor.
                temp.SetBFactor(MaxDepth(temp.GetLeftNode()) - MaxDepth(temp.GetRightNode()));
                // Recursive call to left and right.
                BalanceTree(temp.GetLeftNode());
                BalanceTree(temp.GetRightNode());
            }
        }

        private int MaxDepth(Node currentNode) {
            // Returns the maximum depth of the tree.
            if (currentNode == null) {
                return 0;
            }
            else {
                // Sets left and right to a recursive call.
                int leftDepth = MaxDepth(currentNode.GetLeftNode());
                int rightDepth = MaxDepth(currentNode.GetRightNode());

                // Finds max depth value between left and right.
                if (leftDepth > rightDepth) {
                    return (leftDepth + 1);
                }
                else {
                    return (rightDepth + 1);
                }
            }
        }

        private Node RotateRR(Node parent){
            // Performs Right-Right Rotation...
            Node pivot = parent.GetRightNode();
            parent.SetRightNode(pivot.GetLeftNode());
            pivot.SetLeftNode(parent);
            return pivot;
        }

        private Node RotateLL(Node parent){
            // Performs Left-Left Rotation...
            Node pivot = parent.GetLeftNode();
            parent.SetLeftNode(pivot.GetRightNode());
            pivot.SetRightNode(parent);
            return pivot;
        }

        private Node RotateLR(Node parent){
            // Performs Left-Right Rotation...
            Node pivot = parent.GetLeftNode();
            parent.SetLeftNode(RotateRR(pivot));
            return RotateLL(parent);
        }

        private Node RotateRL(Node parent){
            // Performs Right-Left Rotation...
            Node pivot = parent.GetRightNode();
            parent.SetRightNode(RotateLL(pivot));
            return RotateRR(parent);
        }

        public void Print(){
            // Prints the tree.
            PrintInOrder(root);
            Console.WriteLine("Root: " + root.GetKey());
        }

        private void PrintInOrder(Node temp){
            // Prints in following order: 
            // Left Child -> Parent -> Right Child
            if (root != null) {
                if (temp.GetLeftNode() != null) {
                    PrintInOrder(temp.GetLeftNode());
                }

                Console.WriteLine(temp.GetKey() + "(" + temp.GetBFactor() + ")");

                if (temp.GetRightNode() != null) {
                    PrintInOrder(temp.GetRightNode());
                }
            }
        }

        private int GetAsciiValue(object d){
            // Returns the asscii value of given value.
            byte[] charByte = Encoding.ASCII.GetBytes(d.ToString());
            int sum = 0;
            for (int i = 0; i < charByte.Length; i++) {
                sum += charByte[i];
            }
            return sum;
        }
    }
}
