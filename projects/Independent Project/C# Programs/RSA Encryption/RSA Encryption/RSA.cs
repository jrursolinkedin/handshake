using System;
using System.Collections.Generic;
using System.Text;

namespace RSA_Encryption {
    class RSA {
        // Member variables.
        private int prime1;
        private int prime2;
        private int num;
        private int phiNum;
        private int publicKey;
        private int privateKey;

        // Default Constructor.
        public RSA() {
            prime1 = 7;
            prime2 = 13;
            // "num" must be a two digit number for this program.
            num = prime1 * prime2;
            phiNum = (prime1 - 1) * (prime2 - 1);
            // "publicKey" must be relatively prime to "phiNum".
            publicKey = 5;
            privateKey = (2 * (phiNum) + 1) / publicKey;
        }

        // Parameter Constructor. <- Not recommended.
        public RSA(int p1, int p2, int pK) {
            prime1 = p1;
            prime2 = p2;
            // "num" must be a two digit number for this program.
            num = prime1 * prime2;
            phiNum = (prime1 - 1) * (prime2 - 1);
            // "publicKey" must be relatively prime to "phiNum".
            publicKey = pK;
            privateKey = (2 * (phiNum) + 1) / publicKey;
        }

        public string Encrypt(string pText) {
            // Capitalize and trim all the places within the given string.
            pText = pText.ToUpper().Replace(" ", "");
            // Create an alphabet with the corresponding indexes.
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Dictionary<char, string> alphabet = new Dictionary<char, string>();
            for (int i = 0; i < letters.Length; i++) {
                if (i < 10) {
                    alphabet[letters[i]] = " " + (i).ToString();
                }
                else {
                    alphabet[letters[i]] = (i).ToString();
                }
            }
            // Create the encoded message.
            string encodedMessage = "";
            for (int j = 0; j < pText.Length; j++) {
                if (ModularExponentiation(Convert.ToInt32(alphabet[(pText[j])]), publicKey, num).ToString().Length == 1) {
                    encodedMessage += "0" + ModularExponentiation(Convert.ToInt32(alphabet[pText[j]]), publicKey, num).ToString();
                }
                else {
                    encodedMessage += ModularExponentiation(Convert.ToInt32(alphabet[pText[j]]), publicKey, num).ToString();
                }
            }
            // Finally, return the encoded message.
            return encodedMessage;
        }

        public string Decrypt(string cText) {
            // Find the decoded message.
            string decodedMessage = "";
            for (int i = 0; i < cText.Length; i += 2) {
                if (ModularExponentiation(Convert.ToInt32(cText.Substring(i, 2)), publicKey, num).ToString().Length == 1) {
                    decodedMessage += "0" + ModularExponentiation(Convert.ToInt32(cText.Substring(i, 2)), privateKey, num);
                }
                else {
                    decodedMessage += ModularExponentiation(Convert.ToInt32(cText.Substring(i, 2)), privateKey, num);
                }
            }
            // Next, we have to convert the integers into letters.
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string textMessage = "";
            for (int i = 0; i < decodedMessage.Length; i += 2) {
                int charValue = Convert.ToInt32(decodedMessage.Substring(i, 2));
                textMessage += letters[charValue];
            }
            // Finally, return the decoded message.
            return textMessage;
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

        public int GetModulus() {
            return num;
        }

        public int GetPublicKey() {
            return publicKey;
        }
    }
}
