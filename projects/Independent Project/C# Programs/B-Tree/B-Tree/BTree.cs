using System;
using System.Collections.Generic;
using System.Text;

namespace B_Tree{
    class BTree{
        // Member variables.
        private int order;
        private Node root;

        // Parameter Constructor.
        public BTree(int ord) {
            order = ord;
            root = new Node(order);
            root.SetNumKeys(0);
            root.SetIsLeaf(true);
        }

        public bool Contain(int key){
            // Finds node within the tree.
            if (Search(root, key) != null) {
                // Found.
                return true;
            }
            else {
                // Not found.
                return false;
            }
        }

        private Node Search(Node tempRoot, int key) {
            if (tempRoot != null) {
                // Looks for key within the "tempRoot" node.
                int index;
                for (index = 0; index < tempRoot.GetNumKeys() && !(key < tempRoot.GetKey(index)); index++) {
                    if (key == tempRoot.GetKey(index)) {
                        return tempRoot;
                    }
                }
                // Recursive call.
                return Search(tempRoot.GetChild(index), key);
            }
            else {
                // Return null by default.
                return tempRoot;
            }
        }

        public void Insert(int key) {
            Node tempRoot = root;
            // "tempRoot" has the maximum number of keys.
            if (tempRoot.GetNumKeys() == (2 * order) - 1) {
                Node temp = new Node(order);
                root = temp;
                temp.SetIsLeaf(false);
                temp.SetNumKeys(0);
                temp.SetChild(0, tempRoot);
                InsertValue(temp, key);
            }
            // "tempRoot" still has spots opened for keys.
            else {
                InsertValue(tempRoot, key);
            }
        }

        private void InsertValue(Node current, int key) {
            // Check whether or not the "current" node is a leaf node.
            if (current.GetIsLeaf()) {
                int index = 0;
                for (index = (current.GetNumKeys() - 1); index >= 0 && key < current.GetKey(index); index--) {
                    current.SetKey((index + 1), current.GetKey(index));
                }
                current.SetKey((index + 1), key);
                current.SetNumKeys(current.GetNumKeys() + 1);
            }
            // Not a leaf node.
            else {
                // Update the counter variable, "i".
                int index = 0;
                for (index = (current.GetNumKeys() - 1); index >= 0 && key < current.GetKey(index); index--) {}
                index++;

                // Split temporary node, "temp", if it is 
                // at max capacity.
                Node temp = current.GetChild(index);
                if (temp.GetNumKeys() == (2*order)-1) {
                    // Split method.
                    Split(current, index, temp);
                    if (current.GetKey(index) < key) {
                        index++;
                    }
                }
                // Recursive check the other children.
                InsertValue(current.GetChild(index), key);
            }
        }

        public void Remove(int key) {
            // Check whether or not the key is in the tree.
            Node check = Search(root, key);
            if (check != null) {
                Remove(root, key);
            }
        }

        private void Remove(Node tempRoot, int key) {
            // Find position of the key.
            int pos = tempRoot.Find(key);
            // Key is within "tempRoot" node.
            if (pos != -1) {
                // Case 1: "tempRoot" is a leaf.
                if (tempRoot.GetIsLeaf()) {
                    int i = 0;
                    for (i = 0; i < tempRoot.GetNumKeys() && tempRoot.GetKey(i) != key; i++) {}
                    for (; i < tempRoot.GetNumKeys(); i++) {
                        if (i != 2 * order - 2) {
                            tempRoot.SetKey(i, tempRoot.GetKey(i + 1));
                        }
                    }
                    tempRoot.SetNumKeys(tempRoot.GetNumKeys() - 1);
                }
                // Case 2: "tempRoot" is not a leaf.
                else if (!tempRoot.GetIsLeaf()) {
                    Node pred = tempRoot.GetChild(pos);
                    Node nextNode = tempRoot.GetChild(pos + 1);
                    int predKey = 0;
                    // Case 2.1: "pred" number of keys >= order.
                    if (pred.GetNumKeys() >= order) {
                        bool found = false;
                        while (!found) {
                            if (pred.GetIsLeaf()) {
                                Console.WriteLine(pred.GetNumKeys());
                                predKey = pred.GetKey(pred.GetNumKeys() - 1);
                                found = true;
                            }
                            else {
                                pred = pred.GetChild(pred.GetNumKeys());
                            }
                        }
                        // Recursive call.
                        Remove(pred, predKey);
                        tempRoot.SetKey(pos, predKey);
                    }
                    // Case 2.2: "nextNode" number of keys >= order.
                    else if (nextNode.GetNumKeys() >= order) {
                        int nextKey = nextNode.GetKey(0);
                        if (!nextNode.GetIsLeaf()) {
                            bool found = false;
                            nextNode = nextNode.GetChild(0);
                            while (!found) {
                                if (nextNode.GetIsLeaf()) {
                                    nextKey = nextNode.GetKey(nextNode.GetNumKeys() - 1);
                                    found = true;
                                }
                                else {
                                    nextNode = nextNode.GetChild(nextNode.GetNumKeys());
                                }
                            }
                        }
                        // Recursive call.
                        Remove(nextNode, nextKey);
                        tempRoot.SetKey(pos, nextKey);
                    }
                    // Case 2.3: Neither of the above two cases.
                    else {
                        int temp = pred.GetNumKeys() + 1;
                        pred.SetKey(pred.GetNumKeys(), tempRoot.GetKey(pos));
                        pred.SetNumKeys(pred.GetNumKeys() + 1);
                        // Set keys for "pred".
                        for (int i = 0, j = pred.GetNumKeys(); i < nextNode.GetNumKeys(); i++) {
                            pred.SetKey(j, nextNode.GetKey(i));
                            j++;
                            pred.SetNumKeys(pred.GetNumKeys() + 1);
                        }
                        // Set children for "pred".
                        for (int i = 0; i < (nextNode.GetNumKeys() + 1); i++) {
                            pred.SetChild(temp, nextNode.GetChild(i));
                            temp++;
                        }
                        tempRoot.SetChild(pos, pred);
                        // Set keys for "tempRoot".
                        for (int i = pos; i < tempRoot.GetNumKeys(); i++) {
                            if (i != (2 * order - 2)) {
                                tempRoot.SetKey(i, tempRoot.GetKey(i + 1));
                            }
                        }
                        // Set children for "tempRoot".
                        for (int i = (pos + 1); i < (tempRoot.GetNumKeys() + 1); i++) {
                            if (i != (2 * order - 1)) {
                                tempRoot.SetChild(i, tempRoot.GetChild(i + 1));
                            }
                        }
                        // Fix the "tempRoot" position.
                        tempRoot.SetNumKeys(tempRoot.GetNumKeys() - 1);
                        if (tempRoot.GetNumKeys() == 0) {
                            if (tempRoot == root) {
                                root = tempRoot.GetChild(0);
                            }
                            tempRoot = tempRoot.GetChild(0);
                        }
                        // Recursive call.
                        Remove(pred, key);
                    }
                }
            }
            // Key is not within "tempRoot" node.
            else {
                // Traverse through the next subtree to find key.
                for (pos = 0; pos < tempRoot.GetNumKeys() && !(tempRoot.GetKey(pos) > key); pos++) {}
                Node tmp = tempRoot.GetChild(pos);
                if (tmp != null && tmp.GetNumKeys() >= order) {
                    // Recursive call.
                    Remove(tmp, key);
                }
                else {
                    Node nb = null;
                    int devider = -1;  
                    // Case 1: Check the right child of position node,
                    if (pos != tempRoot.GetNumKeys() && tempRoot.GetChild(pos + 1).GetNumKeys() >= order) {
                        devider = tempRoot.GetKey(pos);
                        nb = tempRoot.GetChild(pos + 1);
                        tempRoot.SetKey(pos, nb.GetKey(0));
                        tmp.SetKey(tmp.GetNumKeys(), devider);
                        tmp.SetNumKeys(tempRoot.GetNumKeys() + 1);
                        tmp.SetChild(tmp.GetNumKeys(), nb.GetChild(0));
                        // Set keys for "nb".
                        for (int i = 1; i < nb.GetNumKeys(); i++) {
                            nb.SetKey((i - 1), nb.GetKey(i));
                        }
                        // Set children for "nb".
                        for (int i = 1; i <= nb.GetNumKeys(); i++) {
                            nb.SetChild((i - 1), nb.GetChild(i));
                        }
                        nb.SetNumKeys(nb.GetNumKeys() - 1);
                        // Recursive call.
                        Remove(tmp, key);
                    }
                    // Case 2: Check the left child of position node.
                    else if (pos != 0 && tempRoot.GetChild(pos - 1).GetNumKeys() >= order) {
                        devider = tempRoot.GetKey(pos - 1);
                        nb = tempRoot.GetChild(pos - 1);
                        tempRoot.SetKey((pos - 1), nb.GetKey(nb.GetNumKeys() - 1));
                        Node child = nb.GetChild(nb.GetNumKeys());
                        nb.SetNumKeys(nb.GetNumKeys() - 1);
                        // Set keys for "tmp".
                        for (int i = tmp.GetNumKeys(); i > 0; i--) {
                            tmp.SetKey(i, tmp.GetKey(i - 1));
                        }
                        tmp.SetKey(0, devider);
                        // Set children for "tmp".
                        for (int i = (tmp.GetNumKeys() + 1); i > 0; i--) {
                            tmp.SetChild(i, tmp.GetChild(i - 1));
                        }
                        tmp.SetChild(0, child);
                        tmp.SetNumKeys(tmp.GetNumKeys() + 1);
                        // Recursive call.
                        Remove(tmp, key);
                    }
                    // Case 3: Neither of the above cases.
                    else {
                        Node lt = null;
                        Node rt = null;
                        bool last = false;
                        // Case 3.1: Position doesn't equal number of keys
                        // in "tempRoot".
                        if (pos != tempRoot.GetNumKeys()) {
                            devider = tempRoot.GetKey(pos);
                            lt = tempRoot.GetChild(pos);
                            rt = tempRoot.GetChild(pos + 1);
                        }
                        // Case 3.2: Position equal number of keys in "tempRoot".
                        else {
                            devider = tempRoot.GetKey(pos - 1);
                            rt = tempRoot.GetChild(pos);
                            lt = tempRoot.GetChild(pos - 1);
                            last = true;
                            pos--;
                        }
                        // Set keys for "tempRoot".
                        for (int i = pos; i < (tempRoot.GetNumKeys() - 1); i++) {
                            tempRoot.SetKey(i, tempRoot.GetKey(i + 1));
                        }
                        // Set children for "tempRoot".
                        for (int i = (pos + 1); i < tempRoot.GetNumKeys(); i++) {
                            tempRoot.SetChild(i, tempRoot.GetChild(i + 1));
                        }
                        tempRoot.SetNumKeys(tempRoot.GetNumKeys() - 1);
                        lt.SetKey(lt.GetNumKeys(), devider);
                        lt.SetNumKeys(lt.GetNumKeys() + 1);
                        for (int i = 0, j = lt.GetNumKeys(); i < (rt.GetNumKeys() + 1); i++, j++) {
                            if (i < rt.GetNumKeys()) {
                                lt.SetKey(j, rt.GetKey(i));
                            }
                            lt.SetChild(j, rt.GetChild(i));
                        }
                        lt.SetNumKeys(lt.GetNumKeys() + rt.GetNumKeys());
                        // Case 3.3: The number of keys within "tempRoot" equal 0.
                        if (tempRoot.GetNumKeys() == 0) {
                            if (tempRoot == root) {
                                root = tempRoot.GetChild(0);
                            }
                            tempRoot = tempRoot.GetChild(0);
                        }
                        // Recursive call.
                        Remove(lt, key);
                    }
                }
            }
        }

        private void Split(Node current, int index, Node child) {
            Node temp = new Node(order);
            // Set isLeaf and numKeys for "temp".
            temp.SetIsLeaf(child.GetIsLeaf());
            temp.SetNumKeys(order - 1);
            // Set keys for "temp".
            for (int j = 0; j < (order - 1); j++) {
                temp.SetKey(j, child.GetKey(j + order));
            }
            // Set children for "temp".
            if (!temp.GetIsLeaf()) {
                for (int j = 0; j < order; j++) {
                    temp.SetChild(j, child.GetChild(j + order));
                }
            }
            // Set children for "temp".
            child.SetNumKeys(order - 1);
            for (int j = current.GetNumKeys(); j >= (index + 1); j--) {
                current.SetChild((j + 1), current.GetChild(j));
            }
            current.SetChild((index + 1), temp);
            // Set keys for "temp".
            for (int j = (current.GetNumKeys() - 1); j >= index; j--) {
                current.SetKey((j + 1), current.GetKey(j));
            }
            current.SetKey(index, child.GetKey(order - 1));
            // Set numKeys for "temp".
            current.SetNumKeys(current.GetNumKeys() + 1);
        }

        public void Display() {
            // Recursvie method.
            Display(root);
        }

        private void Display(Node tempRoot) {
            if (tempRoot != null) {
                // Print all the keys within the node.
                for (int i = 0; i < tempRoot.GetNumKeys(); i++) {
                    Console.Write(tempRoot.GetKey(i) + " ");
                }
                Console.WriteLine();
                // Now, go to print all the children.
                if (!tempRoot.GetIsLeaf()) {
                    for (int i = 0; i < (tempRoot.GetNumKeys() + 1); i++) {
                        // Recursive call for each child node.
                        Display(tempRoot.GetChild(i));
                    }
                }
            }
        }
    }
}
