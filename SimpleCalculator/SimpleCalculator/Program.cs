using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int _exit = 1;
            float _yournum;
            float _yournum2;
            string _choice;
            float _answer = 0;
            bool _isvalid = false;

            while (_exit == 1)  //Keep the program running until _exit = true
            {
                Console.WriteLine("Welcome to the simple calculator, please enter your first number, " +
                    "choose whether to add, subtract, divide or multiply with a second number you will input");

                Console.WriteLine("Please enter your first number");

                _yournum = float.Parse(Console.ReadLine()); //Gets first nubmer input

                Console.WriteLine("Would you like to:");
                Console.WriteLine("Add? Enter \"+\"");
                Console.WriteLine("Subtract? Enter \"-\"");
                Console.WriteLine("Multiply? Enter \"*\"");
                Console.WriteLine("Divide? Enter \"/\"");
                _choice = Console.ReadLine();

                while (!_isvalid)   //Checks if entry is valid, if not, it repeats.
                {
                    if (_choice == "+" || _choice =="-" || _choice == "*" || _choice == "/")
                    {
                        _isvalid = true;
                    }
                    else
                    {
                        Console.WriteLine("Your input is invalid, please enter +, -, *, or /.");
                        _choice = Console.ReadLine();
                    }
                }

                _isvalid = false; //Resets the loops bool for the next loop

                Console.WriteLine("Lastly enter your second number to the function.");

                _yournum2 = float.Parse(Console.ReadLine()); //Gets second number input.
                Console.WriteLine("Calculating...");

                while (!_isvalid) //Loops the switch statment
                {
                    switch (_choice)
                    {
                        case "+":
                            _answer = _yournum + _yournum2;
                            _isvalid = true;
                            break;
                        case "-":
                            _answer = _yournum - _yournum2;
                            _isvalid = true;
                            break;
                        case "*":
                            _answer = _yournum * _yournum2;
                            _isvalid = true;
                            break;
                        case "/":
                            _answer = _yournum / _yournum2;
                            _isvalid = true;
                            break;
                        default:
                            Console.WriteLine("Sorry, your entry is invalid, try again");
                            break;
                    }
                }
                Console.WriteLine($"The answer to your calculation is: {_answer}");
                Console.WriteLine("If you would like to do another calculation, press \"1\", otherwise, the program will close." +
                    "Thanks for you using \"Hunter's Simple Calculator\"");
                _exit = int.Parse(Console.ReadLine());

                if (_exit != 1) //Triggers and exit program bool to exit the program.
                {
                    return;
                }

            }
        }
    }
}

/*
using System;

namespace NumberGuessing
{
    class Program
    {
        static void Main(string[] args)
        {
            int _exit = 1;

            while (_exit == 1)
            {
                Console.WriteLine("Welcome to Hunter's Simple Calculator!");

                double _yournum = GetNumber("Please enter your first number:");
                string _choice = GetOperator();
                double _yournum2 = GetNumber("Please enter your second number:");

                double _answer = 0;

                switch (_choice)
                {
                    case "+":
                        _answer = _yournum + _yournum2;
                        break;
                    case "-":
                        _answer = _yournum - _yournum2;
                        break;
                    case "*":
                        _answer = _yournum * _yournum2;
                        break;
                    case "/":
                        _answer = _yournum2 != 0 ? _yournum / _yournum2 : double.NaN;
                        break;
                }

                Console.WriteLine($"The answer to your calculation is: {_answer}");
                Console.WriteLine("Do another? Press \"1\" for yes, anything else to exit.");
                int.TryParse(Console.ReadLine(), out _exit); // if invalid, _exit becomes 0
            }
        }

        static double GetNumber(string prompt)
        {
            Console.WriteLine(prompt);
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double number))
                    return number;

                Console.WriteLine("Invalid input. Please enter a valid number:");
            }
        }

        static string GetOperator()
        {
            while (true)
            {
                Console.WriteLine("Choose an operator: +  -  *  /");
                string choice = Console.ReadLine();

                if (choice == "+" || choice == "-" || choice == "*" || choice == "/")
                    return choice;

                Console.WriteLine("Invalid operator. Try again.");
            }
        }
    }
}
*/