using System;

namespace Splay_Tree {
    class Program {
        static void Main(string[] args) {
            /**
             *  Splay Tree:
             *  A Splay Tree is a self balancing binary search tree with the addiyional
             *  property that recently accessed elements are quick to access again. It is
             *  the most common tree used in the industry. Like other self balancing binary
             *  tree's, the Splay Tree performs basic operations such as insertion, search, 
             *  and deletion with O(log(n)) time complexity.
             *  > Splay Tree Properties:
             *    * Same properties as a binary search tree.
             *    * Nodes that are inserted or searched are moved to the root position.
             *    * When deleting from a Splay tree, there are two common algorithms: 
             *      Top-Down Splaying and Bottum-Up Splaying.
             *    * A Splay Tree uses the "Splay" method to move a node to the root 
             *      position.
             *    * The "Splay" method uses two rotations to splay a node, left and right
             *      rotation.
             *    * Left Rotation (Zag Rotation):
             *        [P]                                  [X]
             *       /   \       Rotate Left at P         /   \
             *      A    [X]          ----->            [P]    C
             *          /   \                          /   \
             *         B     C                        A     B
             *    
             *    * Right Rotation (Zig Rotation):
             *            [P]                            [X]
             *           /   \    Rotate Right at P     /   \
             *         [X]    C         ----->         A    [P]
             *        /   \                                /   \
             *       A     B                              B     C
             *       
             *  Ex: Adding to Splay Tree
             *      * Code:
             *        Insert(10);
             *        Insert(5);
             *        Insert(15);
             *        
             *      * Visualization Output:
             *        [10]            [5]              [15]
             *       /    \   -->    /   \     -->    /    \
             *     nl     nl       nl    [10]      [10]    nl
             *                                    /    \
             *                                 [5]     nl
             *                                /   \
             *                              nl    nl
             *                              
             *  Ex: Searching through Splay Tree
             *      * Code (continue):
             *        Search(5);
             *        
             *      * Visualization Output:
             *         [5]
             *        /   \
             *       nl   [10]
             *           /    \
             *          nl    [15]
             *          
             *  Ex: Deleting from Splay Tree
             *      * Code (continue):
             *        Delete(10);
             *        
             *      * Visualization Output:
             *         [5]
             *        /   \
             *       nl   [15]
             *       
             *  Splay Tree Methods:
             *  - Insert(key): Inserts a key into the Splay Tree. Calls the "Splay"
             *                 method to rearrange the tree.
             *  - DeleteTDS(key): Deletes a key from the Splay Tree. Uses the top-down
             *                    splaying algorithm.
             *  - DeleteBUS(key): Deletes a key from the Splay Tree. Uses the bottom-up
             *                    splaying algorithm.
             *  - Search(key): Searches the Splay Tree for a given key and returns the node.
             *                 If the key is within the tree, it will splay the node to the
             *                 root position and return the node. If the key is not within 
             *                 the tree, it will return null.
             */
        }
    }
}
