using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic_Array {
    class DynamicArray {
        // Member variables.
        private int count;
        private int size;
        private object[] array;

        // Default Constructor.
        public DynamicArray() {
            count = 0;
            size = 1;
            array = new object[1];
            array[0] = null;
        }

        // Parameter Constructor.
        public DynamicArray(int s) {
            count = 0;
            size = s;
            array = new object[size];
            for (int i = 0; i < size; i++) {
                array[i] = null;
            }
        }

        public void Add(object data) {
            // Check whether array is filled.
            if (count == size) {
                // Double "array" size;
                Grow();
            }
            // Lastly, add element to "array" and
            // update "count".
            array[count] = data;
            count++;
        }

        public void AddAt(int index, object data) {
            // Check whether "index" is valid.
            if ((0 <= index) && (index <= count)) {
                // Check whether array is filled.
                if (count == size) {
                    // Double "array" size;
                    Grow();
                }
                // Lastly, add element to "array" at
                // specified "index" and update "count". 
                for (int i = count; i != index; i--) {
                    array[i] = array[(i - 1)];
                }
                array[index] = data;
                count++;
            }
            else {
                Console.WriteLine("Invalid Index.");
            }
        }

        public void Remove() {
            // Check whether "array" is not empty.
            if (count > 0) {
                // Remove last element in "array" and
                // update "count".
                array[(count - 1)] = null;
                count--;
            }
            // Check whether array is too small.
            if (size > 1 && (count < (size/2))) {
                // Shrinks "array" by half its size.
                Shrink();
            }
        }

        public void RemoveAt(int index) {
            // Check whether "index" is valid.
            if ((0 <= index) && (index < count)) {
                // Remove element from "array" at the
                // specified "index" and update "count".
                for (int i = index; i < count; i++) {
                    // Check whether out of bounds.
                    if ((i + 1) == size) {
                        array[i] = null;
                    }
                    else {
                        array[i] = array[i + 1];
                    }
                }
                count--;
                // Check whether array is too small.
                if (size > 1 && (count < (size / 2))) {
                    // Shrinks "array" by half its size.
                    Shrink();
                }
            }
            else {
                Console.WriteLine("Invalid Index.");
            }
        }

        private void Grow() {
            // Instantiate a "temp" array.
            // Double the size of the original array, "array".
            object[] temp = new object[(size * 2)];
            // Populate the array.
            for (int i = 0; i < temp.Length; i++) {
                if (i < size) {
                    temp[i] = array[i];
                }
                else {
                    temp[i] = null;
                }
            }
            // Update member variables.
            size = temp.Length;
            array = temp;
        }

        private void Shrink() {
            // Instantiate a "temp" array.
            // Half the size of the original array, "array".
            object[] temp = new object[(int)(size / 2)];
            // Populate the array.
            for (int i = 0; i < temp.Length; i++) {
                temp[i] = array[i];
            }
            // Update member variables.
            size = temp.Length;
            array = temp;
        }

        // Getters or Accessors:

        public int GetCount() {
            return count;
        }

        public int GetSize() {
            return size;
        }

        public object GetValue(int index) {
            // Check whether "index" is valid.
            if ((0 <= index) && (index < size)) {
                // Displays nothing if null.
                return array[index];
            }
            else {
                return (object)"Invalid Index";
            }
        }
    }
}
