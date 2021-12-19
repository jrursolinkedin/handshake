using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Bloom_Filter {
    class Program {
        static void Main(string[] args) {
            /**
             *  Bloom Filter:
             *  A Bloom Filter is a data structure designed to tell you, rapidly
             *  and memory efficient, whether an element is present in a set. The
             *  price paid for efficency is that a Bloom Filter is a probabilistic
             *  data structure: it tells us that the element either definitely is
             *  not in the set or may be in the set ("False positive"). In order to
             *  prevent false positives, I stored the elements in a list. Multiple 
             *  hash functions are used to populate the Bloom Filter to elements.
             *  > Bloom Filter Properties:
             *    * Uses an array or list to store 0's and 1's (false and true).
             *    * The array or list assigns 0 at every index when Bloom Filter 
             *      is initialized.
             *    * When a key (element) hashes to an index, the index is assigned 1.
             *    * The Bloom Filter uses multiple hash functions to improve
             *      performance.
             *    * The Bloom filter is constantly being resized.
             *    
             *  Ex: Bloom Filter (Size = 5)
             *      
             *      h1(x) = x mod 5
             *      h2(x) = (2x+3) mod 5
             *      
             *      * Insert:
             *        
             *        Insert(x)     h1(x)    h2(x)      Filter
             *           9            4        1      |0|1|0|0|1| 
             *           11           1        0      |1|1|0|0|1|
             *           
             *      * Query (continue):
             *      
             *        Query(x)      h1(x)    h2(x)      Filter        State:
             *           15           0        3      |1|1|0|0|1|  "not present"(false)
             *           16           1        0      |1|1|0|0|1|    "present"(true)
             *                                                          ^
             *                                                          |
             *                                           This is really false positive!
             *                                           
             *  Bloom Filter Methods:
             *  - Insert(key): Inserts a key into the Bloom Filter. It performs the 
             *                 necessary hashing and resizing of filter.
             *  - Query(key): Checks whether the key hashes to true values and the
             *                list contains the key. If both of these are true, then
             *                the meothod returns true. Else, returns false.      
             */
        }
    }
}
