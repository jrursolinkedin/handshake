using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman_Tree{
    class Character{
        private char character;
        // How many times the character shows up in string.
        private int frequency;
        // Code associated with the characters.
        private string code;

        // Default Constructor.
        public Character() {
            character = '\0';
            frequency = 0;
            code = "";
        }

        // Parameter Constructor.
        public Character(char c, int f) {
            character = c;
            frequency = f;
            code = "";
        }

        // Getters and Accessors:

        public char GetCharacter() {
            return character;
        }

        public int GetFrequency() {
            return frequency;
        }

        public string GetCode() {
            return code;
        }

        // Setters and Mutators:

        public void SetCharacter(char c) {
            character = c;
        }

        public void SetFrequency(int f) {
            frequency = f;
        }

        public void SetCode(string cd) {
            code = cd;
        }
    }
}
