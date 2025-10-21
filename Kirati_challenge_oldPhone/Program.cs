using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using Xunit;

namespace Domain
{
    // class for demo
    internal class Program
    {
        static void Main(string[] args)
        {
            // params
            Boolean playAgain = true;
            string userInput;
            string displayAnswer;

            while (playAgain)
            {
                // simple reciever to input with problem
                Console.Write("Input your OldPhonePad : ");
                userInput = Console.ReadLine();

                // call class method to solve the problem
                displayAnswer = OldPhone.OldPhonePad(userInput);
                Console.WriteLine("Output : " + displayAnswer);

                // end condition to exit the program
                Console.Write("Do you want to exit (Y/N): ");
                userInput = Console.ReadLine().ToUpper();
                if (userInput == "Y")
                {
                    playAgain = false;
                    Console.WriteLine("Thank you for your time.");
                }

            }

        }

    }
    
    // class for OldPhonePad() method
    public static class OldPhone
    {
        // ## Example
        // String answer = OldPhone.OldPhonePad("222 2 8#"); -- answer = "CAT"
        public static String OldPhonePad(string input)
        {
            // params
            int counter = 0;
            Stack<char> ansStack = new Stack<char>();
            string result;

            // validate the input
            if (!inputIsValid(input))
            {
                // force return Not valid
                return "you input is not valid";
            }

            // loop to compare current char and the next char
            for (int i = 0; i < input.Length - 1; i++)
            {
                // chars are same : counting-part
                if (input[i] == input[i + 1])
                {
                    // every case increae counter to count the dup
                    counter++;

                    // case : '*' and '0' do nothing
                    if (input[i] == '*' || input[i] == '0')
                    {
                        //do nothing 
                    }
                    // case : ' ' do nothing and reset counter
                    else if (input[i] == ' ')
                    {
                        counter = 0;
                    }
                    // case : can press 4 times, ex: 1, 2, 3, 4, 1(5), 2(6), 3(7)
                    else if (input[i] is '7' or '9')
                    {
                        counter %= 4;
                    }
                    // case : can press 3 times, ex: 1, 2, 3, 1(4), 2(5), 3(6)
                    else
                    {
                        counter %= 3;
                    }
                }
                // chars are not the same : pushing-poping-part
                else if (input[i] != input[i + 1])
                {
                    switch (input[i])
                    {
                        // case : '*' Pop() (counter) times 
                        case '*':
                            for (int j = 0; j < counter + 1; j++)
                            {
                                if (ansStack.Count > 0)
                                {
                                    ansStack.Pop();
                                }
                            }
                            break;
                        // case : '0' Push(' ') (counter) times
                        case '0':
                            for (int j = 0; j < counter + 1; j++)
                            {
                                ansStack.Push(' ');
                            }
                            break;
                        // case : ' ' do nothing
                        case ' ':
                            break;
                        // case : '1' Push() &, ', (
                        case '1':
                            ansStack.Push((char)(38 + counter));
                            break;
                        // case : '7', '8', and '9' have a different number of letters compared to others,
                        // so I handle them separately (hardcoded) for correct mapping.
                        case '7':
                            ansStack.Push((char)(80 + counter));
                            break;
                        case '8':
                            ansStack.Push((char)(84 + counter));
                            break;
                        case '9':
                            ansStack.Push((char)(87 + counter));
                            break;
                        // basecase : use this formular to decript the code, (char)(int)a + (((int)input * 3) + counter )
                        default: 
                            ansStack.Push((char)(65 + ((Convert.ToInt32(input[i]) - 50) * 3) + counter));
                            break;
                    }
                    // reset the counter after any action
                    counter = 0;

                }

            }

            // prep result
            // Stack to Array
            char[] chararray = ansStack.ToArray();
            // reverse the Array
            Array.Reverse(chararray);
            // join to string
            result = string.Join("", chararray);
           
            return result;
        }

        // to validate the input of OldPhonePad()
        // ## Example
        // Bool return = inputIsValid("222 2 8#"); -- answer = true
        // Bool return = inputIsValid("222"); -- answer = false, missing # at the end

        public static Boolean inputIsValid(String input) {
            bool result = false;
            // case1 : valid normal input
            if (Regex.IsMatch(input, @"^[0-9* ]+#$"))
            {
                result = true;
            }
            // case2 : valid blank input
            else if (input == "#")
            {
                result = true;
            }
            // case3 : the input is not valid
            else
            {
                result = false;
            }
            return result;
        }

    }

}