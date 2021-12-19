using System;
using System.Collections.Generic;

namespace LRU_Cache{
    class Program{
        static void Main(string[] args){
            /** 
             *  LRU Cache:
             *  A Least Recently Used (LRU) Cache organizes items in order of use, allowing
             *  you to quickly identify which item hasn't been used for the longest amount
             *  of time. The following is a good analogy for a LRU Cache: "Picture a clothes 
             *  rack, where clothes are always hung up on one side... To find the least-recently 
             *  used item, look at the item on the other end of the rack." Under the hood, an LRU 
             *  cache is implemented by pairing a doubly linked list with a hashmap. 
             *  > LRU Cache Properties:
             *    * LRU caches store items in order from most-recently used to least-recently 
             *      used. That means both can be accessed in O(1) time.
             *    * Each time an item is accessed, updating the cache takes O(1) time.
             *    * An LRU cache tracking 'n' items requires a linked list of length 'n', and a
             *      hash map holding 'n' items. That's O(n) space, but it's still two data 
             *      structures (as opposed to one).
             *    * The cache is initialized with a positive capacity.
             *    
             *  Ex: Doubly Linked List with Hashmap 
             *  
             *      Code:
             *      
             *      LRUCache c = new LRUCache(3);  // 3 is the max capacity.
             *      c.Put(0, 60);
             *      c.Put(1, 61);
             *      c.Put(2, 62);
             *      c.Put(3, 63);
             *      
             *      Data Structure Visualization:
             *      
             *         Hashmap           LinkedList
             *      ------------       
             *      | 1 |[1,61]|    null<-[head]-><-[3,63]-><-[2,62]-><-[1,61]-><-[tail]->null
             *      ------------
             *      | 2 |[2,62]|
             *      ------------
             *      | 3 |[3,63]|
             *      ------------
             *      
             *      Code (Continue):
             *      
             *      c.Get(1);
             *      
             *      Data Structure Visualization:
             *      
             *         Hashmap           LinkedList
             *      ------------       
             *      | 1 |[1,61]|    null<-[head]-><-[1,61]-><-[3,63]-><-[2,62]-><-[tail]->null
             *      ------------
             *      | 2 |[2,62]|
             *      ------------
             *      | 3 |[3,63]|
             *      ------------
             *      
             *  LRU Cache Methods:
             *  - Put(key,value): Set or insert the value if the key is not already present. When
             *                    the cache reached its capacity, it should invalidate the least 
             *                    recently used item before inserting a new item.
             *  - Get(key): Get the value (Will always be positive) of the key if the key exists
             *              in the cache, otherwise return null. 
             */
        }
    }
}
