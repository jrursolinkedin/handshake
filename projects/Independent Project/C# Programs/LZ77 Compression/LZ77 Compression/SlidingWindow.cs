using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LZ77_Compression {
    class SlidingWindow {
        // Member variables.
        private List<char> searchBuffer;
        private List<char> lookUpBuffer;
        private List<Triple> output;
        private string text;

        // Default Constructor.
        public SlidingWindow() {
            searchBuffer = new List<char>();
            lookUpBuffer = new List<char>();
            output = new List<Triple>();
            text = "";
        }

        // Parameter Constructor.
        public SlidingWindow(string txt) {
            searchBuffer = new List<char>();
            lookUpBuffer = new List<char>();
            output = new List<Triple>();
            text = txt;
            Populate(txt);
        }

        public void Populate(string txt) {
            // Populate "text" and "lookUpBuffer".
            text = txt;
            for (int i = 0; i < txt.Length; i++) {
                lookUpBuffer.Add(txt[i]);
            }
            lookUpBuffer.TrimExcess();
            // Populate the triples...
            bool completed = false;
            while (!completed) {
                bool found = false;
                string lineSearch = new string(searchBuffer.ToArray());
                string lineCheck = "";
                // Check whether "loopUpBuffer" is empty.
                if (lookUpBuffer.Count != 0) {
                    // Find the triple.
                    for (int j = 0; j < lookUpBuffer.Count && !found; j++) {
                        lineCheck += lookUpBuffer[j].ToString();
                        // Check the search buffer.
                        if (!lineSearch.Contains(lineCheck) || j == (lookUpBuffer.Count - 1)) {
                            found = true;
                        }
                    }
                    // Case 1: No match.
                    if (lineCheck.Length == 1) {
                        output.Add(new Triple(0, 0, lineCheck[0]));
                        searchBuffer.Add(lineCheck[0]);
                        lookUpBuffer.RemoveAt(0);
                        lookUpBuffer.TrimExcess();
                    }
                    // Case 2: There was a match.
                    else {
                        found = false;
                        char endSymbol = lineCheck[lineCheck.Length - 1];
                        lineCheck = lineCheck.Substring(0, (lineCheck.Length - 1));
                        for (int k = (lineSearch.Length - 1); k >= 0 && !found; k--) {
                            if (lineSearch[k] == lineCheck[0]) {
                                if ((k + lineCheck.Length) <= lineSearch.Length) {
                                    if (lineSearch.Substring(k, lineCheck.Length).CompareTo(lineCheck) == 0) {
                                        // Add triple!
                                        output.Add(new Triple((lineSearch.Length - k), lineCheck.Length, endSymbol));
                                        // Move symbols inside "lookUpBuffer" to "searchBuffer".
                                        for (int m = 0; m < lineCheck.Length; m++) {
                                            searchBuffer.Add(lineCheck[m]);
                                        }
                                        searchBuffer.Add(endSymbol);
                                        for (int n = 0; n < (lineCheck.Length + 1); n++) {
                                            lookUpBuffer.RemoveAt(0);
                                            lookUpBuffer.TrimExcess();
                                        }
                                        found = true;
                                    }
                                }
                            }
                        }
                    }
                }
                else {
                    // Exit out of loop condition.
                    completed = true;
                }
            }
        }

        public void Encode(string txt) {
            // Clear member variables.
            searchBuffer.Clear();
            lookUpBuffer.Clear();
            output.Clear();
            // Encode the string parameter.
            Populate(txt);
        }

        public string Decode() {
            // Calls the overloaded method.
            return Decode(output);
        }

        public string Decode(List<Triple> tripList) {
            // Populates "txt" and returns it.
            string txt = "";
            for (int i = 0; i < tripList.Count; i++) {
                // Single symbol triple.
                if (tripList[i].GetOffset() == 0 && tripList[i].GetLength() == 0) {
                    txt += tripList[i].GetSymbol().ToString();
                }
                // Multiple symbol triple.
                else {
                    // Cuts the substring from "txt".
                    string txtTemp = txt.Substring(txt.Length - tripList[i].GetOffset(), tripList[i].GetLength());
                    txt += txtTemp + tripList[i].GetSymbol().ToString();
                }
            }
            return txt;
        }

        public void Print() {
            Console.WriteLine("------------");
            // Print "searchBuffer".
            Console.WriteLine("Search Buffer: ");
            for (int i = 0; i < searchBuffer.Count; i++) {
                if (i == (searchBuffer.Count - 1)) {
                    Console.WriteLine(searchBuffer[i]);
                }
                else {
                    Console.Write(searchBuffer[i] + " , ");
                }
            }
            // Print "lookUpBuffer".
            Console.WriteLine();
            Console.WriteLine("Look Up Buffer: ");
            for (int j = 0; j < lookUpBuffer.Count; j++) {
                if (j == (lookUpBuffer.Count - 1)) {
                    Console.WriteLine(lookUpBuffer[j]);
                }
                else {
                    Console.Write(lookUpBuffer[j] + " , ");
                }
            }
            // Print "output".
            Console.WriteLine();
            Console.WriteLine("Output (Triple's): ");
            for (int k = 0; k < output.Count; k++) {
                Console.WriteLine("<" + output[k].GetOffset() + "," + output[k].GetLength() + "," + output[k].GetSymbol() + ">");
            }
            // Print "text" original text.
            Console.WriteLine();
            Console.WriteLine("Text: ");
            Console.WriteLine("'" + text + "'");
            // Print Compression Rate:
            Console.WriteLine();
            Console.WriteLine("Compression Rate: ");
            double per = ((double)(output.Count * (5 + 2 + 3)) / (text.Length * 8));
            Console.WriteLine((per * 100) + " %");
            Console.WriteLine("------------");
        }
    }
}
