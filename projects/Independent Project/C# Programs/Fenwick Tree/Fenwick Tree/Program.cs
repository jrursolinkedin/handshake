using System;

namespace Fenwick_Tree {
    class Program {
        static void Main(string[] args) {
            /**
             *  Fenwick Tree:
             *  A Fenwick Tree or a Binery Indexed Tree is a array data structure for 
             *  calculating the sum within a list of integers. I was created bt Peter 
             *  Fenwick in 1994. This data structure is important because it better at
             *  updating elements and calculating the prefix compared to a flat array
             *  of numbers. For both of these operations, it has a time compexity of
             *  O(log(n)) and a space complexity of O(n).
             *  
             *  Ex: 
             *       - Given the array,
             *       
             *       original[] = [2, 1, 1, 3, 2, 3, 4, 5, 6, 7, 8,  9]
             *                     0  1  2  3  4  5  6  7  8  9  10  11
             *       
             *       - Let's calculate,
             *       
             *       parent(0) = 0 <- Default Value
             *       parent(1) = original[(1-1)] = 2
             *       parent(2) = original[(1-1)] + original[(2-1)] = 3
             *       parent(3) = original[(3-1)] = 1
             *       parent(4) = original[(1-1)] + ... + original[4-1] = 7
             *       parent(5) = original[(5-1)] = 2 
             *       parent(6) = original[(5-1)] + original[6-1] = 5
             *       parent(7) = original[(7-1)] = 4 
             *       parent(8) = original[(1-1)] + ... + original[8-1] = 21
             *       parent(9) = original[(9-1)] = 6
             *       parent(10) = original[(9-1)] + original[10-1] = 13
             *       parent(11) = original[(11-1)] = 8
             *       parent(12) = original[(9-1)] + ... + original[12-1] = 30
             *       
             *       - Or, another way to calculate,
             *       
             *       original[]  Index   Binary   fenTree[]
             *           2         1      0001        2
             *           1         2      0010       2+1
             *           1         3      0011        1
             *           3         4      0100     2+1+1+3
             *           2         5      0101        2
             *           3         6      0110       3+2 
             *           4         7      0111        4
             *           5         8      1000  2+1+1+3+2+3+4+5
             *           6         9      1001        6
             *           7         10     1010       6+7
             *           8         11     1011        8
             *           9         12     1100     6+7+8+9
             *       
             *       - So,
             *       
             *       fenTree[] = [ 0, 2, 3, 1, 7, 2, 5, 4, 21, 6, 13, 8,  30]
             *                     0  1  2  3  4  5  6  7  8   9  10  11  12 
             *           
             *       - Now, let's get the sum of index 5,
             *       
             *       GetSum((5+1)) = fenTree[0110] + fenTree[0100] + fenTree[0000] = 5+7+0 = 12
             *      
             *       - Let's check,
             *      
             *       Sum(5) = original[0] + ... + original[5] = 2+1+1+3+2+3 = 12
             *       
             *       - Next, let's get the sum of index 7,
             *       
             *       GetSum((7+1)) = fenTree[1000] + fenTree[0000] = 21+0 = 21
             *       
             *       - Let's check,
             *       
             *       Sum(7) = original[0] + ... + original[7] = 2+1+1+3+2+3+4+5 = 21
             *       
             *       - Finally, let's try updating or adding,
             *       
             *       UpdateTree(index, value)
             *       
             *       UpdateTree(3,6)  -->  (3+1): fenTree[0100] + 6 = 7+6 = 13
             *                                16: fenTree[10000] <-- DNE
             *                                
             *       - So, after the update,
             *       
             *       fenTree[] = [ 0, 2, 3, 1, 13, 2, 5, 4, 21, 6, 13, 8,  30]
             *                     0  1  2  3   4  5  6  7  8   9  10  11  12 
             *                     
             *  FenwickTree Methods:
             *  - ConstructTree(array): Builds a Fenwick Tree based on the given array.
             *  - UpdateTree(index, value): This method adds a specific value to a given
             *                              index.
             *  - GetSum(index): This method gets the sum from index 0 to a given index.
             *  - RangeSum(lIndex,rIndex): This method gets the sum of a range.
             */
        }
    }
}
