using System;
using System.Text;

namespace Binary_Search_Tree{
    class Program{
        static void Main(string[] args){
            /**
             *  Binary Search Tree:
             *  A binary search tree is a node based tree data structure which 
             *  has the following properties:
             *   * The left subtree of a node contains only nodes with keys lesser
             *     than  node's key.
             *   * The right subtree of a node contains only nodes with keys 
             *     greater than the node's key.
             *   * The left and right subtree must be a binary search tree.
             *   
             *                           Tree:                 Node:
             *                            [9]                  [data]
             *                           /   \                /      \
             *                        [5]     [12]           v        v
             *                       /   \   /    \        LEFT      RIGHT
             *                    [4]   [6] [11]  [14]  
             *                       
             *   Binary Search Tree Methods:
             *   - Add(object val): Adds a node to the correct location.
             *   - Delete(object val): Deletes a specific node and fixes the
             *                         tree structure aftering removing node.
             *   - Search(object val): Returns a node with the same value.
             *   - GetRoot(): Returns the root of the tree.
             *   - InOrderTraversal(): Prints the tree following the inorder traversal.
             *   - PreOrderTraversal(): Prints the tree following the pre order traversal.
             *   - PostOrderTraversal(): Prints the tree following the post order traversal.
             */                
        }
    }
}
