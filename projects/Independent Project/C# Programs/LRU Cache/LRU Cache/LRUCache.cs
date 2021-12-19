using System;
using System.Collections.Generic;
using System.Text;

namespace LRU_Cache{
    class LRUCache{
        // The "head" and "tail" are just pointers.
        // They do not contains any cache data!
        private Node head;
        private Node tail;
        // Acts as a HashMap to get O(1) time complexity.
        private Dictionary<object, Node> nodeMap;
        // Cache is limited to cache capacity.
        private int cacheCapacity;

        // Parameter Constructor.
        public LRUCache(int cap) {
            // Set HashMap and linked list.
            nodeMap = new Dictionary<object, Node>();
            nodeMap.EnsureCapacity(cap);
            cacheCapacity = cap;
            head = new Node();
            tail = new Node();
            head.SetNext(tail);
            tail.SetPrev(head);
        }

        public object Get(object k) {
            // Null is default return value.
            object result = null;
            // Finds value of key.
            if (nodeMap.ContainsKey(k)) {
                Node node = nodeMap[k];
                result = node.GetVal();
                // Resets priority within linked list.
                Remove(node);
                Add(node);
            }
            return result;
        }

        public void Put(object k, object v) {
            if (nodeMap.ContainsKey(k)) {
                // Resets the value of node.
                Node node = nodeMap[k];
                Remove(node);
                node.SetVal(v);
                Add(node);
            }
            else {
                // Check max capacity.
                if (nodeMap.Count == cacheCapacity) {
                    // Remove tailing node.
                    nodeMap.Remove(tail.GetPrev().GetKey());
                    Remove(tail.GetPrev());
                }
                // Adds the new node to Linked List and Hashmap.
                Node newNode = new Node(k, v);
                nodeMap[k] = newNode;
                Add(newNode);
            }
        }

        private void Add(Node newNode) {
            // Adds "newNode" to the front of the list.
            Node headNext = head.GetNext();
            head.SetNext(newNode);
            // Set "newNode" between "head" and "headNext".
            newNode.SetPrev(head);
            newNode.SetNext(headNext);
            // Correct previous pointer.
            headNext.SetPrev(newNode);
        }

        private void Remove(Node delNode) {
            // Create previous and next pointers.
            Node nextNode = delNode.GetNext();
            Node prevNode = delNode.GetPrev();
            // Set pointers to each other.
            nextNode.SetPrev(prevNode);
            prevNode.SetNext(nextNode);
        }
    }
}
