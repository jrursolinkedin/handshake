using System;
using System.Collections.Generic;

namespace PageRank {
    class Program {
        static void Main(string[] args) {
            /**
             *  PageRank Algorithm:
             *  PageRank is an algorithm that Google uses to work out which order to diplay
             *  search results. It was developed Sergey Bin and larry Page at Standard 
             *  University in 1996. A web page with a higher PageRank score is display higher 
             *  than other pages in a search engine listing, which means more visitors and 
             *  potentially more customers or money generated from a web page. The PageRank is
             *  an iterative algorithm which means you repeat the calculation for each page 
             *  multiple times until values eventually settleon the final PageRank scores for
             *  each page.
             *  > PageRank Formula:
             *    Equation: PR(A) = (1 - df) + df(PR(p1)/C(p1)) + ... + df(PR(pn)/C(pn))
             *    df = Damping Factor
             *    p1, p2, ... , pn = Linked Outward pages
             *    PR(page #) = Page Ranking
             *    C(page #) = Number of Outward Links
             *    
             *  Ex: Ranking for Pages A, B, and C
             *      
             *      Page Link Structure:
             *      A: B, C
             *      B: A, C
             *      C: A
             *      Iterations: 2
             *      Damping Factor: 0.85
             *      
             *      Iteration 0:
             *      PR(A) = 1
             *      PR(B) = 1
             *      PR(C) = 1
             *      
             *      Iteration 1:
             *      PR(A) = (1-d) + d(PR(B)/C(B) + PR(C)/C(C))
             *      PR(A) = 0.150 + 0.85(1.000/2 + 1.000/1) = 1.425
             *      PR(B) = (1-d) + d(PR(A)/C(A))
             *      PR(B) = 0.150 + 0.85(1.425/2) = 0.756
             *      PR(C) = (1-d) + d(PR(A)/C(A) + PR(B)/C(B))
             *      PR(C) = 0.150 + 0.85(1.425/2 + 0.756/2) = 1.077
             *      
             *      Iteration 2:
             *      PR(A) = (1-d) + d(PR(B)/C(B) + PR(C)/C(C))
             *      PR(A) = 0.150 + 0.85(0.756/2 + 1.077/1) = 1.386
             *      PR(B) = (1-d) + d(PR(A)/C(A))
             *      PR(B) = 0.150 + 0.85(1.386/2) = 0.739
             *      PR(C) = (1-d) + d(PR(A)/C(A) + PR(B)/C(B))
             *      PR(C) = 0.150 + 0.85(1.386/2 + 0.739/2) = 1.053
             *      
             *      Results:
             *      |----------------|-----------|-----------|-----------|
             *      |   Iteration    |   PR(A)   |   PR(B)   |   PR(C)   |
             *      |----------------|-----------|-----------|-----------|
             *      |       1        |   1.425   |   0.756   |   1.077   |
             *      |----------------|-----------|-----------|-----------|
             *      |       2        |   1.386   |   0.739   |   1.053   |
             *      |----------------|-----------|-----------|-----------|
             *   
             *   
             *  Ranking Methods:
             *  - RunRanking(): This method calculates the ranking for each of the web pages.
             *  - DisplayResults(): This method displays everything, such as the original page
             *                      link structure, the ranking score for each of the pages, 
             *                      and all the other attributes.
             *  - GetNumIterations(): Gets the number of iterations.
             *  - GetDampingFactor(): Gets the damping factor value.
             *  - SetNumIterations(int value): Sets the number of iterations to the given value.
             *  - SetDampingFactor(double value): Sets the damping factor to the given value.
             */
        }
    }
}
