using System;
using System.Collections.Generic;
using System.Text;

namespace LZ77_Compression {
    class LZ77Compressor {
        private SlidingWindow window;

        // Default Constructor.
        public LZ77Compressor() {
            window = new SlidingWindow();
        }

        // Parameter Constructor.
        public LZ77Compressor(string txt) {
            window = new SlidingWindow(txt);
        }

        // Basic Methods:

        public void Encode(string txt) {
            window.Encode(txt);
        }

        public string Decode() {
            return window.Decode();
        }

        public string Decode(List<Triple> tripList) {
            return window.Decode(tripList);
        }
    }
}
