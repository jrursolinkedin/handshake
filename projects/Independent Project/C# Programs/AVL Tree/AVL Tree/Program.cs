using System;

namespace AVL_Tree{
    class Program{
        static void Main(string[] args){
            /**
             *  AVL Tree:
             *  A an AVL tree is a self balancing binary search tree data structure
             *  The depth of an AVL tree on both sides cannot differ by more than 1.
             *  Anytime a node's balance factor is greater than 1 or less than -1, 
             *  rebalancing occurs. An AVL tree has a time complexity of O(log(n)) for 
             *  call cases: worst, average, and best. AVL tree properties:
             *  > Binary Tree:
             *   * The left subtree of a node contains only nodes with keys lesser
             *     than  node's key.
             *   * The right subtree of a node contains only nodes with keys 
             *     greater than the node's key.
             *   * The left and right subtree must be a binary search tree.
             *  > AVL Tree:
             *   * The balance factor for each node cannot differ by more than 1.
             *     Balance Factor = (Depth of left subtree) - (Depth of right subtree)
             *   * Involves the following rotations
             *     1.) Left-Left Rotation
             *          [C]
             *          /           [B]
             *        [B]  --->    /   \
             *        /         [A]    [C]
             *      [A]
             *      
             *     2.) Right-Right Rotation
             *         [A]
             *           \             [B]
             *           [B]  --->    /   \
             *             \       [A]    [C]
             *             [C]
             *             
             *     3.) Left-Right Rotation
             *         [C]           [C]
             *        /              /           [B]
             *      [A]    --->    [B]  --->    /   \
             *        \            /         [A]     [C]
             *         [B]       [C]
             *         
             *     4.) Right-Left Rotation
             *         [A]          [A]
             *            \           \            [B]
             *            [B]  --->   [B]  --->   /   \
             *            /             \      [A]     [C]
             *         [C]              [C]
             *   
             *                            Tree:                 Node:
             *                           [9,(0)]               [key,(-1,0,1)]
             *                           /     \                /         \
             *                       [5,(1)]   [12,(-1)]        v         v
             *                       /   \      /    \        LEFT      RIGHT
             *                  [4,(0)]  nul   nul   [14,(0)] 
             *                   /  \                 /   \
             *                 nul  nul             nul   nul
             *                   
             *                       
             *   Red & Black Binary Search Tree Methods:
             *   - Insert(object key): Adds a node to the correct location.
             *   - RecursiveInsert(Nd current, Nd new): This mehtod is called by Insert
             *                                          and adds a new node to the tree
             *                                          without violating any of the AVL
             *                                          tree rules.
             *   - Delete(object key): Removes a node from the tree.
             *   - RecursiveDelete(Nd current, Obj key): This method is called by Delete
             *                                           and deletes a new node from the tree
             *                                           without violating any of the AVL 
             *                                           tree rules.
             *   - Search(object key): Calls Find() and returns a node with the same value.
             *   - RecursiveSearch(Node temp, object key): Performs the search recursively.
             *   - BalanceTree(Node temp): This method is called by Insert and Delete. It assigns
             *                             a balance factor to each node.
             *   - MaxDepth(Node temp): This method gets the height (or depth) of a given node.
             *                          Important for finding the balance factor.
             *   - Print(): Prints the tree following the inorder traversal.
             */
        }
    }
}
