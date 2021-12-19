using System;
using System.Text;

namespace Hashmap{
    class Program{
        static void Main(string[] args){
            /**
             *  Hashmap:
             *  A hashmap is an array data structure  that stores an ordered
             *  collection and are accessed using an index. It takes a "key"
             *  input and generates a specific index within the array. If two 
             *  keys generate the same index, they get chained together within
             *  a list data structure.
             *  
             *   array[Hash("sjdh")] -> array[0]
             *   array[Hash("usda")] -> array[2]
             *   array[Hash("yesd")] -> array[1]
             *   array[Hash("wjsn")] -> array[1]
             *   
             *     Array:     List:
             *   [Index 0] -> {"sjdh"}
             *   [Index 1] -> {"yesd","wjsn"}
             *   [Index 2] -> {usda}
             *   
             *   Hashmap Methods:
             *   - Hash(object key): Generates an index for a specific key.
             *   - Put(object key, object data): Adds a node to the hashmap.
             *   - Take(object key, object data): deletes a specific node from
             *                                    the hashmap.
             *   - Get(): Gets data from a specific node.
             *   - Size(): Gets the number of array indexes that are occupied.
             *   - IsEmpty(): If the array is empty, it returns true.
             *   - PrintHashmap(): Prints out the hashmap.
             */
        }
    }
}
