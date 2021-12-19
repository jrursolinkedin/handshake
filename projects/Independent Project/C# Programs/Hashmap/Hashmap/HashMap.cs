using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Hashmap{
    class HashMap {
        // Member variable.
        private List[] map;

        // Default Constructor.
        public HashMap() {
            map = new List[10];
            for (int i = 0; i < map.Length; i++) {
                map[i] = new List();
            }
        }

        // Parameter Constructor.
        public HashMap(int size) {
            map = new List[size];
            for (int i = 0; i < map.Length; i++) {
                map[i] = new List();
            }
        }

        private int Hash(object key) {
            // IMPORTANT: Returns the hash index given a specific key.
            byte[] encodedBytes = Encoding.ASCII.GetBytes(key.ToString());
            int sum = 7;
            for (int i = 0; i < encodedBytes.Length; i++) {
                sum += encodedBytes[i];
            }
            return sum%(map.Length);
        }

        public void Put(object key, object value) {
            // Add element to the hashmap.
            map[Hash(key)].Add(key,value);
            // Count how many spots are being used in hashmap.
            double spotsUsed = 0;
            for (int i = 0; i < map.Length; i++) {
                if (map[i].Size() > 0) { 
                    spotsUsed += 1.0;
                }
            }
            // Check the default load factor, 0.5.
            if ((spotsUsed/map.Length) >= .5) {
                // Store all elements of hashmap into "inputs".
                List inputs = new List();
                for (int ary = 0; ary < map.Length; ary++) {
                    for (int lst = 0; lst < map[ary].Size(); lst++) {
                        inputs.Add(map[ary].GetIndex(lst).GetKey() , map[ary].GetIndex(lst).GetData());
                    }
                }
                // Reinstantiate the hashmap with double its
                // original size.
                map = new List[map.Length * 2];
                for (int j = 0; j < map.Length; j++) {
                    map[j] = new List();
                }
                // Lastly, put all the elements back into the hashmap.
                for (int k = 0; k < inputs.Size(); k++) {
                    map[Hash(inputs.GetIndex(k).GetKey())].Add(inputs.GetIndex(k).GetKey() , inputs.GetIndex(k).GetData());
                }
            }
        }

        public void Take(object key, object value) {
            // Removes element from hashmap.
            map[Hash(key)].Remove(key, value);
            // Count how many spots are being used in hashmap.
            double spotsUsed = 0;
            for (int i = 0; i < map.Length; i++) {
                if (map[i].Size() > 0) {
                    spotsUsed += 1.0;
                }
            }
            // Check the default load factor, 0.5.
            if (((spotsUsed * 2) / map.Length) <= .5) {
                // Store all elements of hashmap into "inputs".
                List inputs = new List();
                for (int ary = 0; ary < map.Length; ary++) {
                    for (int lst = 0; lst < map[ary].Size(); lst++) {
                        inputs.Add(map[ary].GetIndex(lst).GetKey(), map[ary].GetIndex(lst).GetData());
                    }
                }
                // Reinstantiate the hashmap with double its
                // original size.
                map = new List[map.Length / 2];
                for (int j = 0; j < map.Length; j++) {
                    map[j] = new List();
                }
                // Lastly, put all the elements back into the hashmap.
                for (int k = 0; k < inputs.Size(); k++) {
                    map[Hash(inputs.GetIndex(k).GetKey())].Add(inputs.GetIndex(k).GetKey(), inputs.GetIndex(k).GetData());
                }
            }
        }

        public object Get(object key) {
            // Returns the value of a specific key.
            for (int lst = 0; lst < map[Hash(key)].Size(); lst++) {
                if (key.Equals(map[Hash(key)].GetIndex(lst).GetKey())) {
                    return map[Hash(key)].GetIndex(lst).GetData();
                }
            }
            return "null";
        }

        public int Size() {
            // Gets the size of the hashmap.
            int size = 0;
            for (int i = 0; i < map.Length; i++) {
                size += map[i].Size();
            }
            return size;
        }

        public bool IsEmpty() {
            // Returns whether the hashmap is empty.
            bool isEmpty = true;
            for (int i = 0; i < map.Length && isEmpty != false; i++) {
                if (map[i].Size() > 0) {
                    isEmpty = false;
                }
            }
            return isEmpty;
        }

        public void PrintHashMap() {
            // Print the hashmap.
            for (int index = 0; index < map.Length; index++) {
                Console.WriteLine("Index " + index + ": ");
                map[index].PrintList();
                Console.WriteLine();
            }
        }
    }
}
