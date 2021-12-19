using System;

namespace B_Tree{
    class Program{
        static void Main(string[] args){
            /** 
             *  B-Tree:
             *  A B-Tree is a special type of self-balancing search tree in
             *  which each node can contain more than one key and can have 
             *  more than two children. The B-Tree came about with the rise in
             *  the need for lesser time in accessing physcial storage, such
             *  as secondary storage (Access time is very slow!). B-Tree work a lot
             *  better than AVL and Red & Blck Trees when it comes to storing
             *  a large number of keys. A B-Tree must have the following properties:
             *  > B-Tree Properties:
             *    * All leaves are at the same level.
             *    * A B-Tree is defined by the term minimum degree ‘t’. The value 
             *      of t depends upon disk block size.
             *    * Every node except root must contain at least (ceiling)([t-1]/2) keys.
             *      The root may contain minimum 1 key.
             *    * All nodes (including root) may contain at most t – 1 keys.
             *    * Number of children of a node is equal to the number of keys in it plus 1.
             *    * All keys of a node are sorted in increasing order. The child between two 
             *      keys k1 and k2 contains all keys in the range from k1 and k2.
             *    * B-Tree grows and shrinks from the root which is unlike Binary Search Tree.
             *      Binary Search Trees grow downward and also shrink from downward.
             *    * Like other balanced Binary Search Trees, time complexity to search, insert
             *      and delete is O(log(n)).
             *      
             *  Ex: Adding (Building B-Tree)
             *  
             *      Order (m) = 2
             *      Keys # = 2(m) - 1 = 2(2) - 1 = 3
             *      Children # = 2(m) = 2(2) = 4
             *      
             *      1.) Add(10), Add(12), Add(14)
             *      
             *          [10|12|14]
             *      
             *      2.) Add(13)
             *      
             *          [10|12|13|14] -->    [12]
             *                              /    \
             *                           [10]    [13|14]
             *                       
             *      3.) Add(15), Add(16)
             *      
             *              [12]                          [12|14]
             *             /    \               -->      /   |   \
             *         [10]     [13|14|15|16]        [10]  [13]  [15|16]
             *     
             *      4.) Add(11), Add(9), Add(8)
             *      
             *                     [12|14]                      [9|12|14]__
             *                    /   |   \        -->        /   |   \    \
             *          [8|9|10|11]  [13]  [15|16]         [8] [10|11] [13] [15|16]
             *  
             *      5.) Add(17), Add(18)
             *                                              
             *              [9|12|14]__                         [12]
             *             /   |   \    \             -->     /      \
             *          [8] [10|11] [13] [15|16|17|18]     [9]       [14|16]__
             *                                           /   \      /   \    \
             *                                        [8]  [10|11] [13] [15] [17|18]
             *                                    
             *  B-Tree Methods:
             *  - Contain(int key): Returns true if the key is within the tree, or it
             *                      returns false if the kay is not within the tree.
             *  - Insert(int key): Adds a key within the tree and performs the necessary
             *                     rebalancing.
             *  - Remove(int key): Deletes a given key within the tree and performs the
             *                     necessary rebalancing.
             *  - Display(): Displays all the nodes in the B-Tree.
             */
        }
    }
}
