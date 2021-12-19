using System;
using System.Collections.Generic;
using System.Text;

namespace PageRank {
    class Pages {
        // Member variables.
        private int numPages;
        private string[] pageNames;
        private List<int>[] outLinks;
        private List<int>[] inLinks;
        private bool[,] pageMatrix;

        // Default Constructor.
        public Pages() {
            numPages = 0;
            pageNames = new string[0];
            pageMatrix = new bool[0,0];
            outLinks = new List<int>[0];
            inLinks = new List<int>[0];
        }

        // Parameter Constructor.
        public Pages(string[] names, bool[,] mtrx) {
            numPages = names.Length;
            pageNames = names;
            pageMatrix = (bool[,])mtrx.Clone();
            outLinks = new List<int>[numPages];
            // Populate the outward links.
            for (int c = 0; c < pageMatrix.GetLength(1); c++) {
                outLinks[c] = new List<int>();
                for (int r = 0; r < pageMatrix.GetLength(0); r++) {
                    if (r != c && pageMatrix[r, c]) {
                        outLinks[c].Add(r);
                    }
                }
            }
            inLinks = new List<int>[numPages];
            // Populate the inward links.
            for (int c = 0; c < pageMatrix.GetLength(1); c++) {
                inLinks[c] = new List<int>();
                for (int r = 0; r < pageMatrix.GetLength(0); r++) {
                    if (r != c && outLinks[r].Contains(c)) {
                        inLinks[c].Add(r);
                    }
                }
            }
        }

        // Accessors or Getters:

        public int GetNumPages() {
            return numPages;
        }

        public string GetPageName(int idx) {
            return pageNames[idx];
        }

        public int GetOutwardSize(int idx) {
            return outLinks[idx].Count;
        }

        public int GetInwardSize(int idx) {
            return inLinks[idx].Count;
        }

        public List<int> GetOutwardLinks(int idx) {
            return outLinks[idx];
        }

        public List<int> GetInwardLinks(int idx) {
            return inLinks[idx];
        }
    }
}
