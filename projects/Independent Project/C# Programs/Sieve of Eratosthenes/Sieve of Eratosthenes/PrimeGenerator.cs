using System;
using System.Collections.Generic;
using System.Text;

namespace Sieve_of_Eratosthenes {
    class PrimeGenerator {
        // Member variables.
        private Number[] listNumbers;
        private List<int> listPrimes = new List<int>();
        private int limitNum;

        // Default Constructor.
        public PrimeGenerator() {
            FindPrimes(100);
        }

        // Parameter Constructor.
        public PrimeGenerator(int max) {
            FindPrimes(max);
        }

        public void FindPrimes(int max) {
            // Must have atleast 1 prime.
            if (2 <= max) {
                // Clear "listPrimes" and set limit.
                listPrimes.Clear();
                limitNum = max;
                // Instantiate "listNumbers" with all the numbers.
                listNumbers = new Number[limitNum - 1];
                for (int i = 0; i < listNumbers.Length; i++) {
                    listNumbers[i] = new Number(i + 2, false);
                }
                // Marked all the numbers that aren't prime.
                for (int i = 0; listNumbers[i].GetNumber() <= Math.Sqrt(limitNum); i++) {
                    // Check if prime.
                    if (!listNumbers[i].IsMarked()) {
                        for (int j = (i + 1); j < listNumbers.Length; j++) {
                            // Check if composite.
                            if ((listNumbers[j].GetNumber() % listNumbers[i].GetNumber()) == 0) {
                                listNumbers[j].SetMark(true);
                            }
                        }
                    }
                }
                // Populate the "listPrimes" with all the unmarked numbers (primes).
                for (int k = 0; k < listNumbers.Length; k++) {
                    if (!listNumbers[k].IsMarked()) {
                        listPrimes.Add(listNumbers[k].GetNumber());
                    }
                }
            }
            else {
                Console.WriteLine("Out of bounds error.");
            }
        }

        public void PrintPrimes() {
            // Print primes in ascending order.
            Console.WriteLine("----");
            for (int i = 0; i < listPrimes.Count; i++) {
                Console.WriteLine(listPrimes[i]);
            }
            Console.WriteLine("----");
        }
    }
}
