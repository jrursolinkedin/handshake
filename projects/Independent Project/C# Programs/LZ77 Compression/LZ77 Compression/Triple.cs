using System;
using System.Collections.Generic;
using System.Text;

namespace LZ77_Compression {
    class Triple {
        // Member variables.
        private int offset;
        private int length;
        private char symbol;

        // Parameter Constructor.
        public Triple(int off, int len, char sym) {
            offset = off;
            length = len;
            symbol = sym;
        }

        // Getters or Accessors:

        public int GetOffset() {
            return offset;
        }

        public int GetLength() {
            return length;
        }

        public char GetSymbol() {
            return symbol;
        }

        // Setters or Mutators:

        public void SetOffset(int off) {
            offset = off;
        }

        public void SetLength(int len) {
            length = len;
        }

        public void SetSymbol(char sym) {
            symbol = sym;
        }
    }
}
