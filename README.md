# Kirati_challenge_oldPhone

## A simple static class method  to solve old phone keypad with unit testcases

This project is a simple C# class method I created to solve the old phone keypad challenge. It demonstrates how I approach problem-solving by carefully designing, structuring, and implementing a solution step by step.
* Gathering the requirements.
* Create Validating method for the method's input.
* Split the process into two parts, by loop through the input and compare the current char and the next char.
* Part1 : the chars are the same
   * Increse the counter to keep track on dupliacated chars.
   * Modula the counter based on how many times it can be pressed.
* Part2 : the chars are not the same
   * Do Push and Pop the char based on the input and counter.
     * Push : convert the input into int and convert it to char based and push into answer stack.
     	- using this formular for basecase :(char)(int)a + (((int)input * 3) + counter )
     	- using this formular for 1,7,8,9 cases :(char)((int)(first_input) + counter)
     * Pop : Pop the last char of the stack (counter) times.  
* Convert Stack into Array then reverse and return the Array as one string
* Create an simple demo console app to demo the method.
* Create xunit testcases for the classs method
   * testcase1 : Examples from the prompt
   * testcase2 : Input invalid input (1. no sharp sign, 2. input is not in 0-9," ",#,*)
   * testcase3 : Input only #
   * testcase4 : Input '2' button 4 times
   * testcase5 : Inout '0' or space word
   * testcase6 : Delete more than the lenght of the word
   * testcase7 : Input '7' and '9' button 4 times 

## How to Install and Run This Project
1. Clone the repository
- ```git clone https://github.com/boki127/C-Kriati-challenge-oldPhone.git```
2. To run the test project
- ```cd ./TestOldPhone```
- ```dotnet test```
3. To run the demo
- ```cd ./Kirati_challenge_oldPhone```
- ```dotnet restore```
- ```dotnet run```
- input ex.: ```4433555 555666#```
## Technologies
| Category            | Tool         |
| ------------------- | ------------ |
| **Language**        | C#           |
| **Framework**       | .NET 8.0     |
| **Testing**         | xUnit        |
| **Version Control** | Git + GitHub |

note: This is my first time implementing something c# language, I hope that it will be comprehenable to whom visted. If there is any flaw in my work, I wish you can point out to help me improve my self. 
