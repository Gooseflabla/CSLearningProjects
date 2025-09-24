// See https://aka.ms/new-console-template for more information
using System;

namespace StringSearching
{
    class Program
    {
        static void Main(string[] args)
        {

            string script = "Laura finds herself unemployed again. For the last three years, she has been" +
             "\r\nworking as an accountant, but the company went bankrupt. The company" +
             "\r\nshe was with before has outsourced all the accounting to a company in" +
             "\r\nIndia. Over the last decade or so, Laura has been employed on and off," +
             "\r\nsometimes with many jobless months in between. Nevertheless, Laura" +
             "\r\nthinks of herself as a reliable, punctual, and trustworthy person and with a" +
             "\r\nlittle luck, she thinks, she soon will be employed again. Every day she" +
             "\r\nsearches the classified employment websites and also the local newspapers" +
             "\r\nfor job openings. She sends out her resume to every company she can think" +
             "\r\nof in the hope for work since unemployment diminishes her savings. One of" +
             "\r\nher most important principles is to never give up. Her dream job is still" +
             "\r\nbeing an accountant, but she knows times have changed. She is flexible, as" +
             "\r\nfinding work as a secretary would serve her as well.";
            Console.WriteLine("Here is the script we are working with:\r\n" + script);


            bool isValid = true;

            while (isValid)
            {

                //string _entry1 = GetEntry("Please enter the script");
                string _searchTerm = GetEntry("Please enter the word or letter you are looking for.");
                int _searchPosition = script.IndexOf(_searchTerm);

                if (_searchPosition != -1)
                {
                    int termFirst = script.LastIndexOf(' ', _searchPosition); //Scan backwords from position to find a ' ' (space)
                    if (termFirst == -1) termFirst = 0;                       // If no word found, words start at start of string
                    else termFirst += 1;                                    //If word found, move character after the space

                    int termLast = script.IndexOf(' ', _searchPosition); //scan to next space
                    if (termLast == -1) termLast = script.Length;

                    string theWord = script.Substring(termFirst, termLast - termFirst);

                    Console.WriteLine("The first " + _searchTerm + " appears at index: " + _searchPosition);
                    Console.WriteLine("The first word containing " + _searchTerm + " is : " + theWord);
                }
                else
                {
                    Console.WriteLine("There are 0 results for: " + _searchTerm);
                }
                Console.WriteLine("Would you like to try a new search (y/n)? or press ENTER to quit.");
                if (Console.ReadLine().ToLower() == "y") isValid = true;
                else isValid = false;
            }
        }

        static string GetEntry(string prompt)
        {
            string input = "";

            while (string.IsNullOrEmpty(input)) //keep looping until valid
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Error, an empty input is not valid");
                }
            }
            return input;
        }

        /*static string GetEntry(string prompt)     //this version can cause stack overflow
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Error, a blank input is not acceptible");
                return GetEntry(prompt);
            }
            return input;
        }*/
    }
}