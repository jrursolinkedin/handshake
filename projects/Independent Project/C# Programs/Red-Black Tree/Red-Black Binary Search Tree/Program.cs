using System;

namespace Red_Black_Tree{
    class Program{
        static void Main(string[] args){
            /**
             *  Red & Black Tree:
             *  A red and black tree is a self balancing bineary search tree data 
             *  structure. Red and black trees have the same time complexity as AVL
             *  trees, O(log(n)) for worst, average, and best case. However, these trees
             *  are a little bit faster and more efficient when it comes to insertion
             *  and deletion. Since we don't have to traverse the tree for imbalances, we
             *  simply look at parent node color and perform a fix. Red and black trees have
             *  the following properties.
             *  > Binary Tree:
             *   * The left subtree of a node contains only nodes with keys lesser
             *     than  node's key.
             *   * The right subtree of a node contains only nodes with keys 
             *     greater than the node's key.
             *   * The left and right subtree must be a binary search tree.
             *  > Red & Black Tree:
             *   * Root is always black.
             *   * A red node can only have black children; therefore, there cannot 
             *     be two adjacent red nodes.
             *   * The number of black nodes in each path should be the same.
             *   * Same rotations as AVL tree.
             *   
             *                            Tree:                 Node:
             *                            [9,B]                [key,R]
             *                           /     \               /      \
             *                       [5,R]     [12,(R)]        v       v
             *                       /   \      /    \        LEFT    RIGHT
             *                   [4,B] [6,B] [11,B] [14,B] 
             *                   /  \  /  \  /   \  /   \
             *                           ..null..
             *                       
             *   Red & Black Tree Methods:
             *   - Insert(object key): Adds a node to the correct location.
             *   - InsertFixUp(Node currentNode): This method is called in Insert() and
             *                                    it is where we will determine if there
             *                                    are any violations in the tree; and 
             *                                    performs necessary rotations/re-colouring. 
             *   - Search(object key): Calls Find() and returns a node with the same value.
             *   - Find(Node temp, object key): Performs the search recursively.
             *   - GetParent(Node temp, Node temp): Returns the parent of a given node. 
             *                                      Returns null if the node is not in the 
             *                                      tree, tree is empty, or the given node
             *                                      is the root.
             *   - Print(): Prints the tree following the inorder traversal.
             *   
             */
        }
    }
}
