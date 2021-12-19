using System;
using System.Collections.Generic;
using System.Text;

namespace Graph{
    class Vertex{
        // Member variables.
        private int data;
        private Vertex next;

        // Default Constructor.
        public Vertex() {
            data = 0;
            next = null;
        }

        // Parameter Constructor.
        public Vertex(int d, Vertex n) {
            data = d;
            next = n;
        }

        // Getters or Accessors:

        public int GetData() {
            return data;
        }

        public Vertex GetNext() {
            return next;
        }

        // Setters or Mutators:

        public void SetData(int d){
            data = d;
        }

        public void SetNext(Vertex n){
            next = n;
        }
    }
}
