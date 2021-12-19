using System;
using System.Collections.Generic;
using System.Text;

namespace Skip_List{
    class SkipList{
        // Member variables.
        private BinaryTree tree;
        private List<int> keyList;
        private List<int> levelList;
        private int levelSize;

        // Default Constructor.
        public SkipList() {
            tree = new BinaryTree();
            keyList = new List<int>();
            levelList = new List<int>();
            levelSize = 3;
        }

        // Parameter Constructor.
        public SkipList(int lvl) {
            tree = new BinaryTree();
            keyList = new List<int>();
            levelList = new List<int>();
            levelSize = lvl;
        }

        public void Insert(int key) {
            // Insert into lists.
            keyList.Add(key);
            levelList.Add(0);
            // Sort lists.
            for (int i = 0; i < (keyList.Count - 1); i++) {
                int minIndex = i;
                for (int j = (i + 1); j < keyList.Count; j++) {
                    if (keyList[minIndex] > keyList[j]) {
                        minIndex = j;
                    }
                }
                int temp1 = keyList[i];
                keyList[i] = keyList[minIndex];
                keyList[minIndex] = temp1;
                int temp2 = levelList[i];
                levelList[i] = levelList[minIndex];
                levelList[minIndex] = temp2;
            }
            // Case 1: First key.
            if (keyList.Count == 1) {
                levelList[0] = levelSize;
                tree.Insert(keyList[0], levelList[0]);
            }
            // Case 2: New key at the front of skip list.
            else if (levelList[0] == 0) {
                tree = new BinaryTree();
                levelList[0] = levelSize;
                tree.Insert(keyList[0], levelList[0]);
                Random rnd = new Random();
                for (int k = 1; k < keyList.Count; k++) {
                    levelList[k] = rnd.Next(1, (levelSize + 1));
                    tree.Insert(keyList[k], levelList[k]);
                }
            }
            // Case 3: New key added to the skip list.
            else {
                Random rnd = new Random();
                levelList[keyList.IndexOf(key)] = rnd.Next(1,(levelSize + 1));
                tree.Insert(keyList[keyList.IndexOf(key)], levelList[keyList.IndexOf(key)]);
            }
        }

        public Node Search(int key) {
            // Check whether tree has been instantiated.
            if (tree != null) {
                return tree.Search(key);
            }
            else {
                // Default return.
                return null;
            }
        }

        public void Display() {
            // List all the keys.
            Console.Write("Key List: ");
            for (int x = 0; x < keyList.Count; x++) {
                if (x == (levelList.Count - 1)) {
                    Console.WriteLine(keyList[x]);
                }
                else {
                    Console.Write(keyList[x] + " , ");
                }
            }
            // List all the levels (adajcent with keys).
            Console.Write("Level List: ");
            for (int y = 0; y < levelList.Count; y++) {
                if (y == (levelList.Count - 1)) {
                    Console.WriteLine(levelList[y]);
                }
                else {
                    Console.Write(levelList[y] + " , ");
                }
            }
            // Print the level size. 
            Console.WriteLine("Level Size: " + levelSize);
            // Create a border.
            string line = "";
            for (int z = 0; z < (11 + (keyList.Count * 8) + 8); z++) {
                line += "-";
            }
            Console.WriteLine(line);
            // Print all the keys within the skip list.
            for (int i = levelSize; i > 0; i--) {
                Console.Write("| Level " + i + ": ");
                for (int j = 0; j < keyList.Count; j++) {
                    if (levelList[j] >= i) {
                        string text;
                        if (j != 0) {
                            text = ">" + keyList[j].ToString();
                        }
                        else {
                            text = keyList[j].ToString();
                        }
                        int spaces = 8 - text.Length;
                        for (int k = 0; k < spaces; k++) {
                            text += "-";
                        }
                        if (j == (keyList.Count - 1)) {
                            text += "> null |";
                        }
                        Console.Write(text);
                    }
                    else {
                        if (j == (keyList.Count - 1)) {
                            Console.Write("--------> null |");
                        }
                        else {
                            Console.Write("--------");
                        }
                    }
                }
                Console.WriteLine();
            }

            // Print border.
            Console.WriteLine(line);
        }
    }
}
