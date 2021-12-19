using System;

namespace Diffie_Hellman_Key_Exchange {
    class Program {
        static void Main(string[] args) {
            /**
             *  Diffie-Hellman Key Exchange:
             *  This algorithm is used for securely exchanging cryptographic keys over a public
             *  channel and it was the of the first public key protocols. It was invented by 
             *  Martin Hellman at Stanford University in the mid-1970s. The algorithm is important
             *  because it alllows two parties that have no prior knowledge of each other to 
             *  jointly establish a shared secret key over an insecure channel. The shared secret
             *  key can be used to encrypt subsequent commuincations using a symmetic cipher.
             *  > Diffie-Hellman Key Exchange Formulas:
             *    Generator: G
             *    Modulus: M
             *    Private Key 1: privK1
             *    Private Key 2: privK2
             *    Public Key 1: (G)^(privK1) mod M = pubK1
             *    Public Key 2: (G)^(privK2) mod M = pubK2
             *    Shared Secret: (pubK2)^(privK1) mod M || (pubK1)^(privK2) mod M = sharedSecret
             *    
             *  Ex: Alice $ Bob Example:
             *  
             *      - First, Alice and Bob was agree on a 'G' and 'M',
             *      
             *        G = 3
             *        M = 17
             *        
             *       - Next, Alice and Bob must generate random pirvate keys,
             *       
             *         Alice:
             *         privK1 = 15
             *         
             *         Bob:
             *         privK2 = 13
             *         
             *       - Now, Alice and Bob can generate their public keys,
             *       
             *         Alice:
             *         pubK1 = (G)^(privK1) mod M = (3)^(15) mod 17 = 6
             *         
             *         Bob:
             *         pubK2 = (G)^(privK2) mod M = (3)^(13) mod 17 = 12
             *         
             *       - Finally, let's see if Alice and Bob get the same shared secret,
             *       
             *         Alice:
             *         sharedSecret = (pubK2)^(privK1) mod M = (12)^(15) mod 17 = 10
             *         
             *         Bob:
             *         sharedSecret = (pubK1)^(privK2) mod M = (6)^(13) mod 17 = 10
             *         
             *         
             *  Diffie-Hellman Key Exchange:
             *  - GetGeneratorValue: Gets the generator value.
             *  - GetModlusValue: Gets the modulus value.
             *  - GetPublicKey1: Gets the public key for the first party.
             *  - GetPublicKey2: Gets the public key for the second party.
             */
        }
    }
}
