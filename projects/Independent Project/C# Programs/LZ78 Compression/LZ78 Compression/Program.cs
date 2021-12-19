using System;

namespace LZ78_Compression {
    class Program {
        static void Main(string[] args) {
            /**
             *  LZ78 Compression:
             *  The LZ78 is a lossless data compression algorithm that is given a string of
             *  characters and compresses into truples. Like LZ77 compression, it was invented
             *  by Abraham Lempel and Jacob Ziv in 1978. Instead of using a slidiing window, the
             *  LZ78 algorithm uses a dictionary because it allows for faster decompression. And,
             *  the biggest advantage is the reduced number of string comparisons in each 
             *  encoding step. The output is a list of tuples each containing an index and symbol.
             *  > LZ78 Properties:
             *    * The dictionary, or "dict", maps a specific index to a particular string of 
             *      characters.
             *    * The outputs, or "output", is a list tuples created during the encoding
             *      process, and is used to decode.
             *    * The "encodedText" is uncompressed text, and the "decodedText" is compressed
             *      text.
             *      
             *  Ex: LZ78 Encoding & Decoding 
             *  
             *      Encoding "ABBCBCABABCAABCAAB":
             *      
             *                      |-------------------------|
             *                      |       Dictionary        |
             *      |---------------|------------|------------|
             *      |     Ouput     |    Index   |   String   |
             *      |---------------|------------|------------|
             *      |     (0,A)     |      1     |      A     |
             *      |---------------|------------|------------|
             *      |     (0,B)     |      2     |      B     |
             *      |---------------|------------|------------|
             *      |     (2,C)     |      3     |      BC    |
             *      |---------------|------------|------------|
             *      |     (3,A)     |      4     |     BCA    |
             *      |---------------|------------|------------|
             *      |     (2,A)     |      5     |      BA    |
             *      |---------------|------------|------------|
             *      |     (4,A)     |      6     |     BCAA   |
             *      |---------------|------------|------------|
             *      |     (6,B)     |      7     |    BCAAB   |
             *      |---------------|------------|------------|
             *      
             *      Decoding List<Tuple>:
             *      
             *      A = (0,A)
             *      A B = (0,B)
             *      A B BC = (2,C)
             *      A B BC BCA = (3,A)
             *      A B BC BCA BA = (2,A)
             *      A B BC BCA BA BCAA = (4,A)
             *      A B BC BCA BA BCAA BCAAB = (6,B)
             *      
             *      "ABBCBCABABCAABCAAB" <- Trim Spaces
             *  
             *  LZ78 Compression Methods
             *  - Encode(text): This method encodes a given text, and returns the encoded text.
             *  - Decode(text): This method decodes a given encoded text, and returns the 
             *                  original text.
             */
        }
    }
}
