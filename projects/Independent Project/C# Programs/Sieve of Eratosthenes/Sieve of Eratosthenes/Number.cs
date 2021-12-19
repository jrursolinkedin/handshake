using System;
using System.Collections.Generic;
using System.Text;

namespace Sieve_of_Eratosthenes {
    class Number {
        // Member variables.
        private int num;
        private bool marked;

        // Default Constructor.
        public Number() {
            num = 0;
            marked = false;
        }

        // Parameter Constructor.
        public Number(int n, bool m) {
            num = n;
            marked = m;
        }

        // Accessor or Getters:

        public int GetNumber() {
            return num;
        }

        public bool IsMarked() {
            return marked;
        }

        // Mutators or Setters:

        public void SetNumber(int n) {
            num = n;   
        }

        public void SetMark(bool m) {
            marked = m;
        }
    }
}
