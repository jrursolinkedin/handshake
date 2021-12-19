using System;
using System.Collections.Generic;
using System.Text;

namespace PrefixPostfixConverter{
    class Program{
        static void Main(string[] args){
            /** 
             *  Prefix/Postfix Converter:
             *  Because computers have trouble understanding infix expressions,
             *  computers must put the expression either into prefix or postfix
             *  expressions. Each expression has two operands and an operator, such
             *  as '+', '*', and '^'.
             *  > Different Notations:
             *    1.) Infix: (operand1 operator operand2)
             *    2.) Prefix: (operator operand1 operand2)
             *    3.) Postfix: (operand1 operand2 operator)
             *  > Priorities (Low->High):
             *    1.) -,+
             *    2.) *,/
             *    3.) ^
             *    4.) (,)
             *    
             *  Ex: A*B+C/D (infix) -> ? (prefix)
             *      *AB+/CD
             *      +*AB/CD
             *      ? = +*AB/CD
             * 
             *  Ex: A*B+C/D (infix) -> ? (postfix)
             *      AB*+CD/
             *      AB*CD/+
             *      ? = AB*CD/+
             *  
             *  Ex: +*AB/CD (prefix) -> ? (infix)
             *      +(A*B)(C/D)
             *      ((A*B)+(C/D))
             *      ? = ((A*B)+(C/D))
             *      
             *  Ex: AB*CD/+ (postfix) -> ? (infix)
             *      (A*B)(C/D)+
             *      ((A*B)+(C/D))
             *      ? = ((A*B)+(C/D))
             */
        }

        static public string InfixToPostfix(string infix) {
            // Setup the expression and stack data structure.
            infix = "(" + infix + ")";
            Stack<char> stck = new Stack<char>();
            string postfix = "";
            // Go through the expression, one character at a time,
            // and populate the postfix expression.
            for (int i = 0; i < infix.Length; i++) {
                // When character is not an operator (operand)...
                if (Char.IsLetter(infix[i]) || char.IsDigit(infix[i])) {
                    postfix += infix[i].ToString();
                }
                // When character is '('...
                else if (infix[i] == '(') {
                    stck.Push(infix[i]);
                }
                // When character is ')'...
                else if (infix[i] == ')') {
                    while (stck.Peek() != '(') {
                        postfix += stck.Pop().ToString();
                    }
                    stck.Pop();
                }
                // When character is an operator...
                else if ((!Char.IsLetter(stck.Peek()) && !char.IsDigit(stck.Peek()))) {
                    while (GetPriority(infix[i]) <= GetPriority(stck.Peek())) {
                        postfix += stck.Pop().ToString();
                    }
                    stck.Push(infix[i]);
                
                }
            }
            return postfix;
        }

        static public string InfixToPrefix(string infix) {
            // Reverse the "infix" string.
            char[] array = infix.ToCharArray();
            Array.Reverse(array);
            infix = new string(array);
            // Store "infix" into "infixSB" to be able to 
            // modify the string.
            StringBuilder infixSB = new StringBuilder(infix);
            for (int i = 0; i < infixSB.Length; i++) {
                if (infixSB[i] == '(') {
                    infixSB[i] = ')';
                    i++;
                    
                }
                else if (infixSB[i] == ')') {
                    infixSB[i] = '(';
                    i++;
                }
            }
            // Get postfix expression.
            string prefix = InfixToPostfix(infixSB.ToString());
            // Reverse the "prefix" string.
            array = prefix.ToCharArray();
            Array.Reverse(array);
            prefix = new String(array);

            return prefix;
        }

        static public string PrefixToInfix(string prefix) {
            // Instantiate a stack to organize operands and expressions.
            Stack<string> stck = new Stack<string>();
            // Read "prefix" string from right to left.
            for (int i = (prefix.Length - 1); i >= 0; i-- ) {
                // When character is an operator...
                if ((!Char.IsLetter(prefix[i]) && !char.IsDigit(prefix[i]))) {
                    string operandOne = stck.Peek().ToString();
                    stck.Pop();
                    string operandTwo = stck.Peek().ToString();
                    stck.Pop();

                    stck.Push("(" + operandOne + prefix[i] + operandTwo + ")");
                }
                // When character is operand...
                else {
                    stck.Push(prefix[i].ToString());
                }
            }
            return stck.Peek().ToString();
        }

        static public string PostfixToInfix(string postfix) {
            // Instantiate a stack to organize operands and expressions.
            Stack<string> stck = new Stack<string>();
            // Read "postfix" string from left to right.
            for (int i = 0; i < postfix.Length; i++) {
                // When character is an operator...
                if ((!Char.IsLetter(postfix[i]) && !char.IsDigit(postfix[i]))) {
                    string operandOne = stck.Peek().ToString();
                    stck.Pop();
                    string operandTwo = stck.Peek().ToString();
                    stck.Pop();

                    stck.Push("(" + operandTwo + postfix[i] + operandOne + ")");
                }
                // When character is operand...
                else {
                    stck.Push(postfix[i].ToString());
                }
            }
            return stck.Peek().ToString();
        }

        static private int GetPriority(char character) {
            // Lowest Priority.
            if (character == '-' || character == '+') {
                return 1;
            }
            // Medium Priority.
            else if (character == '*' || character == '/') {
                return 2;
            }
            // Highest Priority.
            else if (character == '^') {
                return 3;
            }
            else {
                // Default.
                return 0;
            }
        }
    }
}
