using System;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace MyApp
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
                // init params default value
                isValid = false;
                // validate user input
                do {
                    // recieve user input
                    Console.Write("Input your OldPhonePad : ");
                    userInput = Console.ReadLine();

                    // case1 : valid normal input
                    if (Regex.IsMatch(userInput, @"^[0-9* ]+#$")) {
                        //Console.WriteLine("valid");
                        isValid = true;
                    } 
                    // case2 : valid blank input
                    else if (userInput == "#") {
                        //Console.WriteLine("valid");
                        isValid = true;
                    }
                    // case3 : the input not valid go into loop
                    if (!isValid)
                    {
                        Console.WriteLine("you problem is not valid");
                    }
                } while (!isValid);

                // decription the word
                displayAnswer = OldPhone.OldPhonePad(userInput);
                Console.WriteLine("Your actual word is : " + displayAnswer);

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
            char currText;
            string result;


            for (int i = 0; i < problem.Length - 1; i++)
            {
                if (problem[i] == problem[i + 1])
                {
                    // increae counter to count the dup
                    counter++;

                    // '*' case Pop() 
                    if (problem[i] == '*' && ansStack.Count > 0)
                    {
                        ansStack.Pop();
                        counter = 0;
                    }
                    // '0' case push space
                    else if (problem[i] == '0')
                    {
                        ansStack.Push(' ');
                        counter = 0;
                    }
                    // ' ' case donothing and reset counter
                    else if (problem[i] == ' ')
                    {
                        counter = 0;
                    }
                    else if (problem[i] is '7' or '9')
                    {
                        counter %= 4;
                    }
                    else
                    {
                        counter %= 3;
                    }
                }
                else if (problem[i] != problem[i + 1])
                {
                    switch (problem[i])
                    {
                        case '*':
                            if (ansStack.Count > 0)
                            {
                                ansStack.Pop();
                                //Console.WriteLine("Poping ");
                            }
                            break;
                        case '0':
                            ansStack.Push(' ');
                            break;
                        case ' ':
                            //do nothing
                            break;
                        case '1':
                            currText = (char)(38 + counter);
                            ansStack.Push(currText);
                            //Console.WriteLine("push " + currText);
                            break;
                        case '7':
                            currText = (char)(80 + counter);
                            ansStack.Push(currText);
                            //Console.WriteLine("push " + currText);
                            break;
                        case '8':
                            currText = (char)(84 + counter);
                            ansStack.Push(currText);
                            //Console.WriteLine("push " + currText);
                            break;
                        case '9':
                            currText = (char)(87 + counter);
                            ansStack.Push(currText);
                            Console.WriteLine("push " + currText);
                            break;
                        default:
                            // basecase = a + ((char * 3) + counter )
                            currText = (char)(65 + ((Convert.ToInt32(problem[i]) - 50) * 3) + counter);
                            ansStack.Push(currText);
                            //Console.WriteLine("push " + currText);
                            break;
                    }
                    counter = 0;

                }

            }

            char[] chararray = ansStack.ToArray();
            Array.Reverse(chararray);
            result = string.Join("", chararray);
            //Console.WriteLine(result + " : ans test");
            return result;
        }

    }
}