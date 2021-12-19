using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace LZ77_Compression {
    class Program {
        static void Main(string[] args) {
            /**
             *  LZ77 Compression:
             *  The LZ77 is a lossless data compression algorithm that is given a string of
             *  characters and compresses into triples. It was invented by Abraham Lempel and
             *  Jacob Ziv in 1977. The LZ77 uses a sliding window with two buffers, a search
             *  buffer and a look up buffer. The output is stored in a list triples. A triple 
             *  contains the offset, length, and symbol (or character).
             *  > LZ77 Properties:
             *    * "lookUpBuffer" stores all the characters in "text".
             *    * The characters are stored in the "searchBuffer" have already been analyzed.
             *    * The sliding window moves all the characters from "lookUpBuffer" into the
             *      "searchBuffer".
             *    * The "output" contains all the triples.
             *  
             *  Ex: LZ77 Encoding & Decoding
             *  
             *      Encoding "abracadabrad":
             *      
             *      |---------------------------|---------------------------|--------------|
             *      |      Search Buffer        |       Look Up Buffer      |   Output     |
             *      |---------------------------|---------------------------| <offset,     |
             *      | 0 1 2 3 4 5 6 7 8 9 10 11 | 0 1 2 3 4 5 6 7 8 9 10 11 | length,char> |           |
             *      |---------------------------|---------------------------|--------------|
             *      |                           | a b r a c a d a b r a  d  |  <0,0,'a'>   |
             *      |---------------------------|---------------------------|--------------|
             *      |                        a  | b r a c a d a b r a d     |  <0,0,'b'>   |
             *      |---------------------------|---------------------------|--------------|
             *      |                     a  b  | r a c a d a b r a d       |  <0,0,'r'>   |
             *      |---------------------------|---------------------------|--------------|
             *      |                   a b  r  | a c a d a b r a d         |  <3,1,'c'>   |
             *      |---------------------------|---------------------------|--------------|
             *      |               a b r a  c  | a d a b r a d             |  <2,1,'d'>   |
             *      |---------------------------|---------------------------|--------------|
             *      |           a b r a c a  d  | a b r a d                 |  <7,4,'d'>   |
             *      |---------------------------|---------------------------|--------------|
             *      | a b r a c a d a b r a  d  |                           |              |
             *      |---------------------------|---------------------------|--------------|
             *      
             *      Decoding List<Output>:
             *      
             *      <0,0,'a'> = "" + "a" = "a"
             *      <0,0,'b'> = "" + "b" = "b"
             *      <0,0,'r'> = "" + "r" = "r"
             *      <3,1,'c'> = "a" + "c" = "ac"
             *      <2,1,'d'> = "a" + "d" = "ad"
             *      <7,4,'d'> = "abra" + "d" = "abrad"
             *      
             *      text = "a" + "b" + "r" + "ac" + "ad" + "abrad"
             *      text = "abracadabrad"
             *      
             *  LZ77 Compression Methods:
             *  - Encode(text): This method constructs the LZ77 compressor given a string of 
             *                  "text". It populates all the member variables.
             *  - Decode() or Decode(tripList): This method decodes the "text" from the list 
             *                                  of triples, "output", and returns it.   
             */
        }
    }
}
