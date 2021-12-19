using System;

namespace RSA_Encryption {
    class Program {
        static void Main(string[] args) {
            /**
             *  RSA Encryption:
             *  In 1977, Ron Rivest invented the RSA algorithm at MIT. The algorithm is used
             *  by modern computers to encrypt and decrypt messages. Since it is a cryptographic
             *  algorithm, it uses two different keys, a public key and a private key. The 
             *  algorithm is solely based on 'Prime Factorization'. Nobody knows how to compute
             *  the inverse RSA (decryption) without knowing the prime factors of the modulus n;
             *  therefore, it is almost impossible to break the RSA encryption.
             *  > RSA Encryption Formulas:
             *    Prime Number 1: p1
             *    Prime Number 2: p2
             *    Modulus: N = p1*p2
             *    Phi-Modulus: λ(n) = (p1-1)*(p2-1)
             *    Public Key: E <- Must be relatively prime to 'λ(n)' [(E,λ(n))=1]
             *    Private Key: D = (2*(λ(n))+1)/(E)
             *    
             *  Ex: Encrypt and Decrypt 'GOOD MORNING'?
             *  
             *      - Given the following,
             *      
             *        p1 = 7
             *        p2 = 13
             *        N = p1*p2 = 91
             *        λ(n) = (p1-1)*(p2-1) = 72
             *        E = 5
             *        D = (2*(λ(n))+1)/(E) = 29
             *        
             *      - Now, let's encrypt 'GOOD MORNING' using C = (M)^E mod N,
             *      
             *        Letters:
             *        G = 06
             *        O = 14
             *        D = 03
             *        M = 12
             *        R = 17
             *        N = 13
             *        I = 08
             *        
             *        Modulus Value:
             *        (06)^5 mod 91 = 41
             *        (14)^5 mod 91 = 14
             *        (03)^5 mod 91 = 61
             *        (12)^5 mod 91 = 38
             *        (17)^5 mod 91 = 75
             *        (13)^5 mod 91 = 13
             *        (08)^5 mod 91 = 08
             *        
             *        Encrypted Text:
             *        41 14 14 61 38 14 75 13 08 13 41
             *        
             *      - Next, let's decrypt the encrypted text using M = (C)^D mod N,
             *      
             *        Modulus Value:
             *        (41)^29 mod 91 = 06
             *        (14)^29 mod 91 = 14
             *        (61)^29 mod 91 = 03
             *        (38)^29 mod 91 = 12
             *        (75)^29 mod 91 = 17
             *        (13)^29 mod 91 = 13
             *        (08)^29 mod 91 = 08
             *        
             *        Decrypted Text:
             *        G O O D M O R N I N G
             *    
             *  
             *  RSA Methods:
             *  - Encrypt(pText): Converts plain text into cypher text.
             *  - Decrypt(cText): Converts cypher text into plain text.
             *  - GetModulus(): Gets the modulus value.
             *  - GetPublicKey(): Gets the public key.
             */
        }
    }
}
