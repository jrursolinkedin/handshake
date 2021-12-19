using System;
using System.Collections.Generic;
using System.Text;

namespace LZ78_Compression {
    class Tuple {
        // Member variables.
        private readonly int index = 0;
        private readonly char symbol = ' ';

        // Parameter Constructor.
        public Tuple(int idx, char sym) {
            index = idx;
            symbol = sym;
        }

        // Accessors or Getters:

        public int GetIndex() {
            return index;
        }

        public char GetSymbol() {
            return symbol;
        }
    }
}
