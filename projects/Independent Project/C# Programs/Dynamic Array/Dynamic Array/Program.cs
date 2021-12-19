using System;

namespace Dynamic_Array {
    class Program {
        static void Main(string[] args) {
            /** 
             *  Dynamic Array:
             *  A Dynamic Array automatically grows when we try to make an insertion
             *  and there is no more space left for the new item. Typically, a Dynamic
             *  array doubles in size whenever it fulfills this condition. The purpose 
             *  of doubling is to avoid resizing since it's expensive, O(n). In C++, a 
             *  dynamic array is known as a vector; and, in Java, it is known as an 
             *  ArrayList. 
             *  > Dynamic Array Complexities:
             *    - Time Complexity: O(1) <- Accessing elements
             *    - Space Complexity: O(n) <- Resizing or Insertion
             *    
             *  Ex: Dynamic Array Functions Visualization
             *  
             *      - Add(#) on [nul],
             *                
             *        Add(1)  [1]
             *        Add(2)  [1,2] <- Grow()!
             *        Add(3)  [1,2,3,nul] <- Grow()!
             *        Add(4)  [1,2,3,4]
             *        Add(5)  [1,2,3,4,5,nul,nul,nul] <- Grow()!
             *        
             *      - AddAt(#,#) on [1,2],
             *      
             *        AddAt(0,-1)  [-1,1,2,nul]
             *        AddAt(3,4)   [-1,1,2,4]
             *        AddAt(1,0)   [-1,0,1,2,4,nul,nul,nul] <- Grow()!
             *        
             *      - Remove() on [1,2,3,nul],
             *      
             *        Remove()  [1,2,nul,nul]
             *        Remove()  [1,nul] <- Shrink()!
             *        Remove()  [nul] <- Shrink()!
             *        
             *      - RemoveAt(#) on [1,2,3,nul]
             *      
             *        RemoveAt(0)  [2,3,nul,nul]
             *        RemoveAt(1)  [2,nul] <- Shrink()!
             *        RemoveAt(0)  [nul] <- Shrink()!
             *        
             *    
             *  Dynamic Array Methods:
             *  - Add(object data): Adds a given element at the end of the array.
             *  - Add(int index, object data): Adds a given element at a specified index.
             *  - Remove(): Removes the last element in the array.
             *  - Remove(int index): Removes element at a specified index.
             *  - GetCount(): Returns the number of elements inside the array.
             *  - GetSize(): Returns the size of the array.
             *  - GetValue(int index): Returns the value at a specified index.
             *  - Grow(): Doubles the size of the array.
             *  - Shrink(): Shrinks the size of the array by half.
             */
        }
    }
}
