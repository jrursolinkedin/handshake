using System;

namespace Sieve_of_Eratosthenes {
    class Program {
        static void Main(string[] args) {
            /** 
             *  Sieve of Eratosthenes:
             *  This method is used to generate a list of primes up to some given number. It
             *  was established by Erastosthenes who was born in 276 BC. It is extremely simple 
             *  but elegant at the same time. Below is an explanation of how the algorithm works
             *  and an example.
             *  > Sieve of Eratosthenes Algorithm:
             *    FOR all numbers a: from 2 to sqrt(max)
             *      IF a is unmarked THEN
             *        a is prime
             *        FOR all multiple of a (a < max)
             *          mark multiple as composite  
             *    * All unmarked numbers are prime!
             *    
             *  Ex: 
             *       '^' = Marked
             *       ' ' = Unmarked
             *  
             *       - Given max = 16,
             *       
             *         limit = 16 (Sqrt(16) = 4)
             *         listNumbers = 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16
             *                     
             *                     
             *       - First iteration,
             *                       v
             *         listNumbers = 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16
             *                           ^   ^   ^   ^^    ^^    ^^    ^^
             *                           
             *       - Second iteration,
             *       
             *                         v
             *         listNumbers = 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16
             *                           ^   ^   ^ ^ ^^    ^^    ^^ ^^ ^^
             *                           
             *       - Third iteration, 
             *       
             *                           v
             *         listNumbers = 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16
             *                           ^   ^   ^ ^ ^^    ^^    ^^ ^^ ^^
             *                           
             *       - Since 5 !<= Sqrt(max),
             *       
             *         listPrimes = {2 , 3 , 5 , 7 , 11 , 13}
             *         
             *         
             *  PrimeGenerator Methods:
             *  - FindPrimes(int max): Finds all the primes up to the given value.
             *  - PrintPrimes(): Prints all the primes in ascending order.
             */
        }
    }
}
