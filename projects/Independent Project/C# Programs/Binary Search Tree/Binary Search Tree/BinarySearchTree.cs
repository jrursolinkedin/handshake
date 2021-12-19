using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Search_Tree{
    class BinarySearchTree{
        // Member variables.
        private Node root;

        // Default Constructor.
        public BinarySearchTree() {
            root = null;
        }

        // Parameter Constructor.
        public BinarySearchTree(object val) {
            root = new Node(val, null, null);
        }

        public void Add(object val) {
            // Check if tree is empty.
            if (root != null) {
                Node tempR = root;
                // Loop for traversing tree.
                while (tempR != null) {
                    // Have two children...
                    if (tempR.GetLeft() != null && tempR.GetRight() != null) {
                        if (GetAsciiValue(val) < GetAsciiValue(tempR.GetData())) {
                            tempR = tempR.GetLeft();
                        } 
                        else {
                            tempR = tempR.GetRight();
                        }
                    } 
                    // Only has right child...
                    else if (tempR.GetLeft() == null && tempR.GetRight() != null) {
                        if (GetAsciiValue(val) < GetAsciiValue(tempR.GetData())) {
                            tempR.SetLeft(new Node(val, null, null));
                            tempR = tempR.GetLeft().GetLeft();
                        } 
                        else {
                            tempR = tempR.GetRight();
                        }
                    } 
                    // Only has left child...
                    else if (tempR.GetLeft() != null && tempR.GetRight() == null) {
                        if (GetAsciiValue(val) < GetAsciiValue(tempR.GetData())) {
                            tempR = tempR.GetLeft();
                        } 
                        else {
                            tempR.SetRight(new Node(val, null, null));
                            tempR = tempR.GetRight().GetRight();
                        }
                    } 
                    // Else, no children...
                    else {
                        if (GetAsciiValue(val) < GetAsciiValue(tempR.GetData())) {
                            tempR.SetLeft(new Node(val, null, null));
                            tempR = tempR.GetLeft().GetLeft();
                        } 
                        else {
                            tempR.SetRight(new Node(val, null, null));
                            tempR = tempR.GetRight().GetRight();
                        }
                    }
                }
            }
            // Else, tree is empty...
            else { 
                root = new Node(val, null, null);
            }
        }

		public void Delete(object val){
            // Check whether tree is empty and node value exists.
			if (root != null && Search(root, val) != null) {
                Node nodeDelete = Search(root, val);
                Node nodeParent = GetParent(root, nodeDelete.GetData());
                // Deleted node is the root...
                if (nodeParent == nodeDelete) {
                    if (nodeDelete.GetLeft() != null && nodeDelete.GetRight() != null) {
                        DeletingNodeWithTwoChildren(nodeDelete);
                    }
                    else if (nodeDelete.GetLeft() == null && nodeDelete.GetRight() != null) {
                        root = nodeDelete.GetRight();
                    }
                    else if (nodeDelete.GetLeft() != null && nodeDelete.GetRight() == null) {
                        root = nodeDelete.GetLeft();
                    }
                    else if (nodeDelete.GetLeft() == null && nodeDelete.GetRight() == null) {
                        root = null;
                    }
                } 
                // Else, deleted node is not the root.
                else {
                    if (nodeDelete.GetLeft() != null && nodeDelete.GetRight() != null) {
                        DeletingNodeWithTwoChildren(nodeDelete);
                    }
                    else if (nodeDelete.GetLeft() == null && nodeDelete.GetRight() != null) {
                        DeletingNodeWithOneChild(nodeDelete, nodeParent);
                    }
                    else if (nodeDelete.GetLeft() != null && nodeDelete.GetRight() == null) {
                        DeletingNodeWithOneChild(nodeDelete, nodeParent);
                    }
                    else if (nodeDelete.GetLeft() == null && nodeDelete.GetRight() == null) {
                        DeletingNodeWithNoChildren(nodeDelete, nodeParent);
                    }
                }
            }
		}

		private void DeletingNodeWithNoChildren(Node nodeDelete, Node nodeParent){
            // Deletes node with no children...
			if (nodeDelete != root && nodeDelete.GetLeft() == null && nodeDelete.GetRight() == null) {
				if (nodeParent.GetRight() != null) {
					if (nodeParent.GetRight() == nodeDelete) {
						nodeParent.SetRight(null);
					}
				}
				if (nodeParent.GetLeft() != null) {
					if (nodeParent.GetLeft() == nodeDelete) {
						nodeParent.SetLeft(null);
					}
				}
			}
		}

		private void DeletingNodeWithOneChild(Node nodeDelete, Node nodeParent){
            // Deletes node with one child...
			if ((nodeDelete.GetLeft() == null && nodeDelete.GetRight() != null) || (nodeDelete.GetLeft() != null && nodeDelete.GetRight() == null)) {
				if (nodeDelete.GetLeft() == null && nodeDelete.GetRight() != null) {
					if (nodeParent.GetRight() == nodeDelete) {
						nodeParent.SetRight(nodeDelete.GetRight());
						nodeDelete.SetRight(null);
					}
					else if (nodeParent.GetLeft() == nodeDelete) {
						nodeParent.SetLeft(nodeDelete.GetRight());
						nodeDelete.SetRight(null);
					}
				}
				else if (nodeDelete.GetLeft() != null && nodeDelete.GetRight() == null) {
					if (nodeParent.GetRight() == nodeDelete) {
						nodeParent.SetRight(nodeDelete.GetLeft());
						nodeDelete.SetLeft(null);
					}
					else if (nodeParent.GetLeft() == nodeDelete) {
						nodeParent.SetLeft(nodeDelete.GetLeft());
						nodeDelete.SetLeft(null);
					}
				}
			}
		}

		private void DeletingNodeWithTwoChildren(Node nodeDelete){
            // Deletes node with two children...
			if (nodeDelete.GetRight() != null && nodeDelete.GetRight() != null) {
				Node replacerNode = FindRightHighestNode(nodeDelete.GetRight());
				object replacerKey = replacerNode.GetData();
				if (replacerNode.GetLeft() == null && replacerNode.GetRight() == null) {
					DeletingNodeWithNoChildren(replacerNode, GetParent(root, replacerNode.GetData()));
				}
				else if ((replacerNode.GetLeft() == null && replacerNode.GetRight() != null) || (replacerNode.GetLeft() != null && replacerNode.GetRight() == null)) {
					DeletingNodeWithOneChild(replacerNode, GetParent(root, replacerNode.GetData()));
				}
				nodeDelete.SetData(replacerKey);
			}
		}

        private Node FindRightHighestNode(Node nodeDelete) {
            // Finds the node with highest value within the right subtree...
            if (nodeDelete.GetLeft() != null) {
                return FindRightHighestNode(nodeDelete.GetLeft());
            } 
            else {
                return nodeDelete;
            }
        }

        public Node Search(Node tempR, object val){
            // Finds a specific node with a given value...
            if (tempR != null) {
                if (GetAsciiValue(tempR.GetData()) < GetAsciiValue(val)) {
                    return Search(tempR.GetRight(), val);
                } 
                else if (GetAsciiValue(val) < GetAsciiValue(tempR.GetData())) {
                    return Search(tempR.GetLeft(), val);
                } 
                else if (GetAsciiValue(val) == GetAsciiValue(tempR.GetData())) {
                    return tempR;
                }
            }
            return null;
        }

        private Node GetParent(Node tempR, object val){
            // Finds the parent of a specifc node with a given value...
            if (tempR == null || Search(root, val) == null) {
                return null;
            }
            else if (GetAsciiValue(tempR.GetData()) == GetAsciiValue(val)) {
                return tempR;
            }
            else if (tempR.GetLeft() != null || tempR.GetRight() != null) {
                if (GetAsciiValue(tempR.GetLeft().GetData()) == GetAsciiValue(val)) {
                    return tempR;
                }
                else if (GetAsciiValue(tempR.GetRight().GetData()) == GetAsciiValue(val)) {
                    return tempR;
                }
            }
            if (GetAsciiValue(tempR.GetData()) < GetAsciiValue(val)) {
                return GetParent(tempR.GetRight(), val);
            }
            else if (GetAsciiValue(val) < GetAsciiValue(tempR.GetData())) {
                return GetParent(tempR.GetLeft(), val);
            }
            else {
                return null;
            }
        }

        public Node GetRoot() {
            // Returns the root node...
            if (root != null) {
                return root;
            }
            else {
                return null;
            }
        }

        public void InOrderTraversal(Node tempR) {
            // Prints the tree in order traversal...
            if (root != null) { 
                if (tempR.GetLeft() != null) {
                    InOrderTraversal(tempR.GetLeft());
                }
                Console.WriteLine(tempR.GetData());
                if (tempR.GetRight() != null) {
                    InOrderTraversal(tempR.GetRight());
                }
            }
        }

        public void PreOrderTraversal(Node tempR) {
            // Prints the tree in preorder traversal...
            if (root != null) {
                Console.WriteLine(tempR.GetData());
                if (tempR.GetLeft() != null) {
                    InOrderTraversal(tempR.GetLeft());
                }
                if (tempR.GetRight() != null) {
                    InOrderTraversal(tempR.GetRight());
                }
            }
        }

        public void PostOrderTraversal(Node tempR) {
            // Prints the tree in postorder traversal...
            if (root != null) {
                if (tempR.GetLeft() != null) {
                    InOrderTraversal(tempR.GetLeft());
                }
                if (tempR.GetRight() != null) {
                    InOrderTraversal(tempR.GetRight());
                }
                Console.WriteLine(tempR.GetData());
            }
        }

        private int GetAsciiValue(object d) {
            // Gets the ascii value of a given object.
            byte[] charByte = Encoding.ASCII.GetBytes(d.ToString());
            int sum = 0;
            for (int i = 0; i < charByte.Length; i++) {
                sum += charByte[i];
            }
            return sum;
        }
    }
}
