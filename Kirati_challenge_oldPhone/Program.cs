using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using Xunit;

namespace Domain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // params
            Boolean playAgain = true;
            string userInput;
            Boolean isValid;
            string displayAnswer;

            while (playAgain)
            {
                // simple input reciever
                Console.Write("Input your OldPhonePad : ");
                userInput = Console.ReadLine();

                // decription the word
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
    public static class OldPhone
    {
        public static String OldPhonePad(string input)
        {
            string problem = input;
            int counter = 0;
            Stack<char> ansStack = new Stack<char>();
            string result;

            // case1 : valid normal input
            if (Regex.IsMatch(problem, @"^[0-9* ]+#$"))
            {
            }
            // case2 : valid blank input
            else if (problem == "#")
            {
                return "";
            }
            // case3 : the input not valid go into loop
            else
            {
                return "you input is not valid";
            }

            for (int i = 0; i < problem.Length - 1; i++)
            {
                // counting-part
                if (problem[i] == problem[i + 1])
                {
                    // increae counter to count the dup
                    counter++;

                    // '*' and '0' case : do nothing
                    if (problem[i] == '*' || problem[i] == '0')
                    {
                        //do nothing 
                    }
                    // ' ' case do nothing and reset counter
                    else if (problem[i] == ' ')
                    {
                        counter = 0;
                    }
                    // have 4 looop case : 1, 2, 3, 4, 1(5), 2(6), 3(7)
                    else if (problem[i] is '7' or '9')
                    {
                        counter %= 4;
                    }
                    // have 3 looop case : 1, 2, 3, 1(4), 2(5), 3(6)
                    else
                    {
                        counter %= 3;
                    }
                }
                // pushing-poping-part
                else if (problem[i] != problem[i + 1])
                {
                    switch (problem[i])
                    {
                        case '*':

                            for (int j = 0; j < counter + 1; j++)
                            {
                                if (ansStack.Count > 0)
                                {
                                    ansStack.Pop();
                                }
                            }
                            break;
                        case '0':
                            for (int j = 0; j < counter + 1; j++)
                            {
                                ansStack.Push(' ');
                            }
                            break;
                        case ' ':
                            //do nothing
                            break;
                        case '1':
                            ansStack.Push((char)(38 + counter));
                            break;
                        case '7':
                            ansStack.Push((char)(80 + counter));
                            break;
                        case '8':
                            ansStack.Push((char)(84 + counter));
                            break;
                        case '9':
                            ansStack.Push((char)(87 + counter));
                            break;
                        default:
                            // basecase = a + ((char * 3) + counter )
                            ansStack.Push((char)(65 + ((Convert.ToInt32(problem[i]) - 50) * 3) + counter));
                            break;
                    }
                    // reset-counter
                    counter = 0;

                }

            }

            // prep result
            char[] chararray = ansStack.ToArray();
            Array.Reverse(chararray);
            result = string.Join("", chararray);
            //Console.WriteLine(result + " : ans test");
            return result;
        }

 

    }

}