using System;

namespace Skip_List{
    class Program{
        static void Main(string[] args){
            /** 
             *  Skip List:
             *  A skip list is a linked-list data structure which allows for fast 
             *  search. It consists of a base list holding the elements, together 
             *  with a tower of lists maintaining a linked hierarchy of subsequences,
             *  each skipping over fewer elements. While many are skeptical of a of 
             *  skip list performance, due to their poor cache behavior when compared to 
             *  B-Trees; however, a good implementation of a skip list can easily 
             *  outperform B-Trees. 
             *  > Skip List Properties:
             *    * Probabilistic data structure (Random - "Coin flips").
             *    * O(log(n)) insertion and search time complexity.
             *    
             *  Ex: Common Implementation for Skip List
             *  
             *      L3: 7 -------------------> 25 -------------> 53 -> null
             *          |                      |                 |
             *          v                      v                 v
             *      L2: 7 -------> 15 -------> 25 -------> 42 -> 53 -> null
             *          |          |           |           |     |
             *          v          v           v           v     v
             *      L1: 7 -> 11 -> 15 -> 22 -> 25 -> 30 -> 42 -> 53 -> null
             *  
             *  Ex: How I Implemented My Skip List
             *  
             *             7
             *           /   \
             *         7      \
             *        /  \     \
             *       7    \     \
             *        \    \     \
             *         11   \     \
             *               15    \
             *              /       \
             *            15         \
             *              \         \
             *               22       25
             *                      /   \
             *                    25     \
             *                   /  \     \
             *                 25    \     \
             *                   \    \     \
             *                    30   42    \
             *                        /       \
             *                      42        53
             *                               /
             *                             53
             *                            / 
             *                          53
             *                          
             *  Skip List Methods:
             *  - Insert(int key): Adds a key to the skip list and performs the 
             *                     necessary rebalancing.
             *  - Search(int key): Finds a key within the skip list and returns the 
             *                     node. If the key isn't in the skip list, it returns
             *                     null.
             *  - Display(): Print the whole entire skip list.
             */          
        }
    }
}
