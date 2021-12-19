using System;
using System.Collections.Generic;
using System.Text;

namespace LZ78_Compression {
    class LZ78Compressor {
        // Member variable.
        private Dictionary diction;

        // Default Constructor.
        public LZ78Compressor() {
            diction = new Dictionary();
        }

        // Parameter Constructor.
        public LZ78Compressor(string text) {
            diction = new Dictionary(text);
        }

        // Encodes a given text.
        public string Encode(string text) {
            return diction.Encode(text);
        }

        // Decodes a given encoded text.
        public string Decode(string text) {
            return diction.Decode(text);
        }

        // If you called N-Argument Constructor, then
        // you call this function to get the encoded message.
        public string GetEncodedMessage() {
            return diction.GetEncodedMessage();
        }

        // If you called N-Argument Constructor, then
        // you call this function to get the decoded message.
        public string GetDecodedMessage() {
            return diction.GetDecodedMessage();
        }
    }
}
