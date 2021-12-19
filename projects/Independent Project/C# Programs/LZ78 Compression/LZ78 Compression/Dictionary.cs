using System;
using System.Collections.Generic;
using System.Text;

namespace LZ78_Compression {
    class Dictionary {
        // Member variables.
        private string encodedText;
        private string decodedText;
        private List<Tuple> output = new List<Tuple>();
        private Dictionary<int,string> dict = new Dictionary<int, string>();

        // Default Constructor.
        public Dictionary() {
            encodedText = "";
            decodedText = "";
        }

        // Parameter Constructor.
        public Dictionary(string text) {
            // Performs compression.
            encodedText = Encode(text);
            decodedText = Decode(encodedText);
        }

        // Encodes the message.
        public string Encode(string text) {
            // Create the dictionary and outputs.
            int index = 1;
            while (text.Length != 0) {
                // Find the substring.
                bool found = false;
                string subString = "";
                for (int i = 0; i < text.Length && !found; i++) {
                    subString += text[i];
                    if (!dict.ContainsValue(subString)) {
                        found = true;
                    }
                }
                // Cut the substring out of original text.
                text = text.Substring(subString.Length, (text.Length - subString.Length));
                // Add tuple to "output".
                if (subString.Length == 1) {
                    output.Add(new Tuple(0, subString[0]));
                }
                else {
                    int indexFound = 0;
                    for (int j = 0; j < dict.Count && indexFound == 0; j++) {
                        if (dict[j+1].Equals(subString.Substring(0, (subString.Length - 1)))) {
                            indexFound = (j + 1);
                        }
                    }
                    output.Add(new Tuple(indexFound, subString[subString.Length - 1]));
                }
                // Add values to "dict" or dictionary.
                dict.Add(index, subString);
                // Update index value.
                index++;
            }
            // Update "encodedMessage" value.
            string encodedMessage = "";
            for (int k = 0; k < output.Count; k++) {
                encodedMessage += "(" + output[k].GetIndex() + "," + output[k].GetSymbol() + ") , ";
                if (k == (output.Count - 1)) {
                    encodedMessage = encodedMessage.Substring(0, (encodedMessage.Length - 3));
                }
            }
            // Return "encodedMessage".
            return encodedMessage;
        }

        // Decodes the message.
        public string Decode(string text) {
            // Must call Encode() function before calling "Decode()".
            // Split "text" into the outputs.
            string[] outputs = text.Split(" , ");
            // Populate "decodedText" from output values.
            string decodedMessage = "";
            for (int i = 0; i < outputs.Length; i++) {
                if (outputs[i].Split(",")[0].Remove(0,1).Equals("0")) {
                    decodedMessage += outputs[i].Split(",")[1].Remove((outputs[i].Split(",")[1].Length-1), 1);
                }
                else {
                    decodedMessage += dict[Int16.Parse(outputs[i].Split(",")[0].Remove(0, 1))] + outputs[i].Split(",")[1].Remove((outputs[i].Split(",")[1].Length - 1), 1);
                }
            }
            // Return "decodedMessage".
            return decodedMessage;
        }

        // Getters or Accessors for Parameter Constructor.

        public string GetEncodedMessage() {
            return encodedText;
        }

        public string GetDecodedMessage() {
            return decodedText;
        }
    }
}
