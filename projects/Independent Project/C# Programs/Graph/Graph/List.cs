using System;
using System.Collections.Generic;
using System.Text;

namespace Graph{
    class List{
        // Member variables.
        private Edge head;

        // Default Constructor.
        public List(){
            head = null;
        }

        // Parameter Constructor.
        public List(int s, int d, int c){
            head = new Edge(s, d, c, null);
        }

        public void Add(int s, int d, int c){
            // Checks whether list is emptry.
            if (head == null) {
                head = new Edge(s, d, c, null);
            } 
            // Else, list has one ore more nodes.
            else {
                Edge temp = head;
                // Travels through list.
                while (temp != null) {
                    if (temp.GetNext() == null) {
                        temp.SetNext(new Edge(s, d, c, null));
                        temp = temp.GetNext().GetNext();
                    } 
                    else {
                        temp = temp.GetNext();
                    }
                }
            }
        }

        public void Delete(int s, int d){
            // Checks whether list is empty.
            if (head != null) {
                // Deleted node is at the head of list.
                while (head != null && head.GetSource() == s && head.GetDestination() == d) {
                    Edge tempH = head;
                    head = head.GetNext();
                    tempH.SetNext(null);
                }
                // Deleted node is at the middle or tail of list.
                Edge temp = head;
                while (temp != null) {
                    if (temp.GetNext() != null) {
                        if (temp.GetNext().GetSource() == s && temp.GetNext().GetDestination() == d) {
                            Edge tempM = temp.GetNext();
                            temp.SetNext(tempM.GetNext());
                            tempM.SetNext(null);
                        } 
                        else {
                            temp = temp.GetNext();
                        }
                    } 
                    else {
                        temp = temp.GetNext();
                    }
                }
            }
        }

        public Edge GetIndex(int index){
            // Gets the specific value of given index.
            if (index <= (Size() - 1)) {
                Edge temp = head;
                for (int i = 0; i < index; i++) {
                    temp = temp.GetNext();
                }
                return temp;
            }
            return null;
        }

        public int Size(){
            // Gets the size of the list.
            int size = 0;
            Edge temp = head;
            while (temp != null) {
                size++;
                temp = temp.GetNext();
            }
            return size;
        }
    }
}
