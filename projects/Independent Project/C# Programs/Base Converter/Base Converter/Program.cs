using System;

namespace Base_Converter{
    class Program{
        static void Main(string[] args){
            /** 
             *  Base Conveter:
             *  This program is for converting to binary, octal, decimal, 
             *  or hexadecimal to binary, octal, decimal, or hexadecimal
             *  and vice versa. The program follows the following examples
             *  below (visual):
             *  * You are able to convert to and from any of the bases with the
             *    following example.
             *  * {# (?)  ->  # (10)  ->  # (?)} <- Works for any base conversion
             *                                      -----------------------------
             *  
             *  Ex: 101011 (2)
             *      = 1*2^(5) + 1*2^(3) + 1*2^(1) + 1*2^(0)
             *      = 32 + 8 + 2 + 1
             *      = 43 (10)
             *      
             *  Ex: 43 (10)
             *      = 43/2 r1
             *        21/2 r1
             *        10/2 r0
             *        5/2  r1
             *        2/2  r0
             *        1/2  r1
             *        0/2  Done!
             *      = 101011 (2)
             *        
             *  Ex: 53 (8)
             *      = 5*8^(1) + 3*8^(0)
             *      = 40 + 3
             *      = 43 (10)
             *      
             *  Ex: 43 (10)
             *      = 43/8 r3
             *      = 5/8  r5
             *      = 0/8  Done!
             *      = 53 (8)
             *      
             *  Ex: 2B (16)
             *      = 2*16^(1) + 11*16^(0)
             *      = 32 + 11
             *      = 43 (10)
             *      
             *  Ex: 43 (10)
             *      = 43/16 r11 = B
             *      = 2/16  r2
             *      = 0/16  Done!
             *      = 2B (16)
             */

        }

        static public void BaseConverter() {
            int programCond = 1;
            do {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Binary: 2 | Octal: 8 | Decimal: 10 | Hexa: 16");
                Console.WriteLine("Pick which base you want to convert from: ");
                int baseOne = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Now, type a value for base " + baseOne + ":");
                string value = (Console.ReadLine()).ToString();

                Console.WriteLine("Pick which base you want to convert to: ");
                int baseTwo = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Output: ");
                Console.Write(value + " (" + baseOne + ") --> ");
                switch (baseOne) {
                    case 2:
                        switch (baseTwo) {
                            case 2:
                                Console.WriteLine(value + " (2)");
                                break;
                            case 8:
                                Console.WriteLine(DecimalToOctal(BinaryToDecimal(value)) + " (8)");
                                break;
                            case 10:
                                Console.WriteLine(BinaryToDecimal(value) + " (10)");
                                break;
                            case 16:
                                Console.WriteLine(DecimalToHexadecimal(BinaryToDecimal(value)) + " (16)");
                                break;
                        }
                        break;
                    case 8:
                        switch (baseTwo) {
                            case 2:
                                Console.WriteLine(DecimalToBinary(OctalToDecimal(value)) + " (2)");
                                break;
                            case 8:
                                Console.WriteLine(value + " (8)");
                                break;
                            case 10:
                                Console.WriteLine(OctalToDecimal(value) + " (10)");
                                break;
                            case 16:
                                Console.WriteLine(DecimalToHexadecimal(OctalToDecimal(value)) + " (16)");
                                break;
                        }
                        break;
                    case 10:
                        switch (baseTwo) {
                            case 2:
                                Console.WriteLine(DecimalToBinary(value) + " (2)");
                                break;
                            case 8:
                                Console.WriteLine(DecimalToOctal(value) + " (8)");
                                break;
                            case 10:
                                Console.WriteLine(value + " (10)");
                                break;
                            case 16:
                                Console.WriteLine(DecimalToHexadecimal(value) + " (16)");
                                break;
                        }
                        break;
                    case 16:
                        switch (baseTwo) {
                            case 2:
                                Console.WriteLine(DecimalToBinary(HexadecimalToDecimal(value)) + " (2)");
                                break;
                            case 8:
                                Console.WriteLine(DecimalToOctal(HexadecimalToDecimal(value)) + " (8)");
                                break;
                            case 10:
                                Console.WriteLine(HexadecimalToDecimal(value) + " (10)");
                                break;
                            case 16:
                                Console.WriteLine(value + " (16)");
                                break;
                        }
                        break;
                }

                Console.WriteLine("Want to continue with the program, 1 - Yes or 0 - No:");
                programCond = Int32.Parse(Console.ReadLine());
                Console.WriteLine("----------------------------------------------");
            }
            while (programCond != 0);
        }

        static public string DecimalToBinary(string decimalValue) {
            string bV = "";
            int dV = Int32.Parse(decimalValue);
            while (dV != 0) {
                if ((dV % 2) == 1) {
                    bV = "1" + bV;
                }
                else {
                    bV = "0" + bV;
                }
                dV = (int)(dV / 2);
            }
            return bV;
        }

        static public string BinaryToDecimal(string binaryValue) {
            int dV = 0;
            int powerCnt = 0;
            for (int i = (binaryValue.Length - 1); i >= 0; i--) {
                dV = (int)((Int32.Parse(binaryValue[i].ToString()) * Math.Pow(2, powerCnt)) + dV);
                powerCnt++;
            }
            return dV.ToString();
        }

        static public string DecimalToOctal(string decimalValue){
            string oV = "";
            int dV = Int32.Parse(decimalValue);
            while (dV != 0) {
                int remainder = (int)(dV % 8);
                if (0 <= remainder && remainder <= 7) {
                    oV = remainder.ToString() + oV;
                }
                dV = (int)(dV / 8);
            }
            return oV;
        }

        static public string OctalToDecimal(string octalValue){
            int dV = 0;
            int powerCnt = 0;
            for (int i = (octalValue.Length - 1); i >= 0; i--) {
                dV = (int)((Int32.Parse(octalValue[i].ToString()) * Math.Pow(8, powerCnt)) + dV);
                powerCnt++;
            }
            return dV.ToString();
        }

        static public string DecimalToHexadecimal(string decimalValue) {
            string hV = "";
            int dV = Int32.Parse(decimalValue);
            while (dV != 0) {
                int remainder = (int)(dV % 16);
                if (0 <= remainder && remainder <= 9) {
                    hV = remainder.ToString() + hV;
                }
                else {
                    switch (remainder) {
                        case 10:
                            hV = "A" + hV;
                            break;
                        case 11:
                            hV = "B" + hV;
                            break;
                        case 12:
                            hV = "C" + hV;
                            break;
                        case 13:
                            hV = "D" + hV;
                            break;
                        case 14:
                            hV = "E" + hV;
                            break;
                        case 15:
                            hV = "F" + hV;
                            break;
                    }
                }
                dV = (int)(dV / 16);
            }
            return hV;
        }

        static public string HexadecimalToDecimal(string hexadecimalValue) {
            int dV = 0;
            int powerCnt = 0;
            for (int i = (hexadecimalValue.Length - 1); i >= 0; i--) {
                if (Char.IsDigit(hexadecimalValue[i])) {
                    dV = (int)((Int32.Parse(hexadecimalValue[i].ToString()) * Math.Pow(16, powerCnt)) + dV);
                }
                else {
                    switch (hexadecimalValue[i]) {
                        case 'A':
                            dV = (int)((10 * Math.Pow(16, powerCnt)) + dV);
                            break;
                        case 'B':
                            dV = (int)((11 * Math.Pow(16, powerCnt)) + dV);
                            break;
                        case 'C':
                            dV = (int)((12 * Math.Pow(16, powerCnt)) + dV);
                            break;
                        case 'D':
                            dV = (int)((13 * Math.Pow(16, powerCnt)) + dV);
                            break;
                        case 'E':
                            dV = (int)((14 * Math.Pow(16, powerCnt)) + dV);
                            break;
                        case 'F':
                            dV = (int)((15 * Math.Pow(16, powerCnt)) + dV);
                            break;
                    }
                }
                powerCnt++;
            }
            return dV.ToString();
        }
    }
}
