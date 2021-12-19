using System;
using System.Collections.Generic;
using System.Text;

namespace Graph{
    class Edge{
        // Member variables.
        private int source;
        private int destination;
        private int cost;
        private Edge next;

        // Default Constructor.
        public Edge() {
            source = 0;
            destination = 0;
            cost = 0;
            next = null;
        }

        // Parameter Constructor.
        public Edge(int s, int d, int c, Edge n){
            source = s;
            destination = d;
            cost = c;
            next = n;
        }

        // Getters or Accessors:

        public int GetSource() {
            return source;
        }

        public int GetDestination() {
            return destination;
        }

        public int GetCost() {
            return cost;
        }

        public Edge GetNext() {
            return next;
        }

        // Setters or Accessors:

        public void SetSource(int s) {
            source = s;
        }

        public void SetDestination(int d) {
            destination = d;
        }

        public void SetCost(int c) {
            cost = c;
        }

        public void SetNext(Edge n) {
            next = n;
        }
    }
}
