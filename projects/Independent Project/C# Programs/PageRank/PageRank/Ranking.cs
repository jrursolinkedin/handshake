using System;
using System.Collections.Generic;
using System.Text;

namespace PageRank {
    class Ranking {
        // Member variables.
        private int numIterations;
        private double dampFactor;
        private float[] pageRank;
        private Pages pageStorage;

        // Default Constructor.
        public Ranking() {
            numIterations = 0;
            dampFactor = 0;
            pageRank = new float[0];
            pageStorage = new Pages();
        }

        // Parameter Constructor.
        public Ranking(int n, double df, string[] names, bool[,] mtrx) {
            numIterations = n;
            dampFactor = df;
            pageRank = new float[names.Length];
            Array.Fill(pageRank, 1);
            pageStorage = new Pages(names, mtrx);
        }

        public void RunRanking() {
            // For each iterations, recalcuates the ranking for each page.
            for (int itr = 0; itr < numIterations; itr++) {
                for (int trav = 0; trav < pageRank.Length; trav++) {
                    // Equation: PR(A) = (1 - df) + df(PR(p1)/C(p1)) + ... + df(PR(pn)/C(pn)).
                    // df = Damping Factor
                    // p1, p2, ... , pn = Linked Outward pages.
                    // PR(page #) = Page Ranking.
                    // C(page n) = Number of Outward Links.
                    pageRank[trav] = Convert.ToSingle((1 - dampFactor));
                    for (int lCnt = 0; lCnt < pageStorage.GetInwardLinks(trav).Count; lCnt++) {
                        pageRank[trav] += Convert.ToSingle(dampFactor * Convert.ToSingle((double)pageRank[pageStorage.GetInwardLinks(trav)[lCnt]] / pageStorage.GetOutwardSize(pageStorage.GetInwardLinks(trav)[lCnt])));
                    }
                }
            }
        }

        // Accessors or Getters:

        public int GetNumIterations() {
            return numIterations;
        }

        public double GetDampingFactor() {
            return dampFactor;
        }

        // Mutators or Setters:

        public void SetNumIterations(int n) {
            numIterations = n;
        }

        public void SetDampingFactor(double df) {
            dampFactor = df;
        }

        public void DisplayResults() {
            // Display Pages.
            Console.WriteLine("-----------------");
            for (int pg = 0; pg < pageStorage.GetNumPages(); pg++) {
                Console.WriteLine(pageStorage.GetPageName(pg)+ ": ");
                Console.WriteLine("Outward Links: " + string.Join(", ", pageStorage.GetOutwardLinks(pg)));
                Console.WriteLine("Inward Links: " + string.Join(", ", pageStorage.GetInwardLinks(pg)));
                Console.WriteLine("-----------------");
            }
            // Display Rankings.
            Console.WriteLine("Number of Iterations: " + numIterations);
            Console.WriteLine("Damping Factor: " + dampFactor);
            Console.WriteLine("Number of Pages: " + pageStorage.GetNumPages());
            for (int i = 0; i < pageStorage.GetNumPages(); i++) {
                Console.WriteLine("Ranking of " + pageStorage.GetPageName(i) + ": " + pageRank[i]);
            }
            Console.WriteLine("-----------------");
        }
    }
}
