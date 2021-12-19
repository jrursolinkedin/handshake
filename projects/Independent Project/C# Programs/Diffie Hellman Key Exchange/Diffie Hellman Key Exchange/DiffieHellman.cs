using System;
using System.Collections.Generic;
using System.Text;

namespace Diffie_Hellman_Key_Exchange {
    class DiffieHellman {
        // Member variables.
        private int generator;
        private int modulus;
        private int privatekeyOne;
        private int privateKeyTwo;
        private int publicKeyOne;
        private int publicKeyTwo;
        private int sharedSecret;

        // Default Constructor.
        public DiffieHellman() {
            // Generator and Modulus both must be prime.
            generator = 3;
            modulus = 17;
            // Use a pseudorandom algorithm to generate the private keys.
            Random ran = new Random();
            privatekeyOne = ran.Next(99, 9999);
            privateKeyTwo = ran.Next(99, 9999);
            // Generate the public key for each of the party.
            publicKeyOne = ModularExponentiation(generator, privatekeyOne, modulus);
            publicKeyTwo = ModularExponentiation(generator, privateKeyTwo, modulus);
            // Finally, find the shared secret between the two parties.
            if (ModularExponentiation(publicKeyTwo, privatekeyOne, modulus) == ModularExponentiation(publicKeyOne, privateKeyTwo, modulus)) {
                sharedSecret = ModularExponentiation(publicKeyTwo, privatekeyOne, modulus);
            }
            else {
                Console.WriteLine("Something went wrong with the key exchange.");
            }
        }

        // Parameter Constructor.
        public DiffieHellman(int gen, int mod) {
            // Generator and Modulus both must be prime.
            generator = gen;
            modulus = mod;
            // Use a pseudorandom algorithm to generate the private keys.
            Random ran = new Random();
            privatekeyOne = ran.Next(99, 9999);
            privateKeyTwo = ran.Next(99, 9999);
            // Generate the public key for each of the party.
            publicKeyOne = ModularExponentiation(generator, privatekeyOne, modulus);
            publicKeyTwo = ModularExponentiation(generator, privateKeyTwo, modulus);
            // Finally, find the shared secret between the two parties.
            if (ModularExponentiation(publicKeyTwo, privatekeyOne, modulus) == ModularExponentiation(publicKeyOne, privateKeyTwo, modulus)) {
                sharedSecret = ModularExponentiation(publicKeyTwo, privatekeyOne, modulus);
            }
            else {
                Console.WriteLine("Something went wrong with the key exchange.");
            }
        }

        private int ModularExponentiation(int baseV, int exponentV, int modulusV) {
            // Find all the modulus values for all the exponents up to the
            // given exoponent value, "exponentV"
            int runningExpo = 1;
            Dictionary<int, int> runningExpoMod = new Dictionary<int, int>();
            Stack<int> modValues = new Stack<int>();
            modValues.Push(Convert.ToInt32(Power(baseV, runningExpo)) % modulusV);
            while (runningExpo <= exponentV) {
                runningExpoMod.Add(runningExpo, modValues.Peek());
                modValues.Push(Convert.ToInt32(Power(modValues.Pop(), 2)) % modulusV);
                runningExpo *= 2;
            }
            // Find the binary representation for the exponenent Value.
            string binValue = ConvertDecimalToBinary(exponentV);
            // Reverse the binary representation.
            string reverse = "";
            for (int i = (binValue.Length - 1); i >= 0; i--) {
                reverse += binValue[i];
            }
            binValue = reverse;
            // Find the final moulus value from the corresponding modulus
            // values inside the "runningExpoMod".
            int finalSum = 1;
            for (int i = 0; i < binValue.Length; i++) {
                if (binValue[i] == '1') {
                    finalSum *= runningExpoMod[Convert.ToInt32(Power(2, i))];
                }
            }
            // Return final modulus value.
            return finalSum % modulusV;
        }

        private int Power(int baseV, int exponenetV) {
            // Finds the power from the given base and exponent.
            int result = 1;
            for (int i = 0; i < exponenetV; i++) {
                result *= baseV;
            }
            return result;
        }

        private string ConvertDecimalToBinary(int dec) {
            // Finds the binary representation to the decimal value.
            string binValue = "";
            while (dec != 0) {
                if (dec % 2 == 1) {
                    binValue = "1" + binValue;
                }
                else {
                    binValue = "0" + binValue;
                }
                dec /= 2;
            }
            return binValue;
        }

        // Accessors or Getters:

        public int GetGeneratorValue() {
            return generator;
        }

        public int GetModulusValue() {
            return modulus;
        }

        public int GetPublicKey1() {
            return publicKeyOne;
        }

        public int GetPublicKey2() {
            return publicKeyTwo;
        }
    }
}
