using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab1
{
    class Program
    {
        private static List<string> words = new List<string>();
        static void Main(string[] args)

        {

            bool showMenu = true;

            while (showMenu)
            {
                showMenu = mainMenu();
            }

        }
        private static void printMenu()
        {
            //print a header 
            Console.WriteLine("***********************************");
            Console.WriteLine("*******An Introduction to C#*********");
            Console.WriteLine("************Choices****************");
            Console.WriteLine("***********************************");


            //print the menu
            Console.WriteLine(" 1 - Import Words from File\n 2 - Bubble Sort words\n 3 - LINQ / Lambda sort words\n 4 - Count the Distinct Words\n 5 - Take the first 10 words\n 6 - Get the number of words that start with 'j' and display the count\n 7 - Get and display of words that end with 'd' and display the count\n 8 - Get and display of words that are greater than 4 characters long and display the count\n 9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count\n x – Exit");
            Console.WriteLine("***********************************");

            
            Console.WriteLine("Enter your choice: ");
 
        }

        private static bool mainMenu()
        {
            printMenu();
            string line = Console.ReadLine();
            Console.WriteLine("***********************************");
            Console.Clear();

            if (line == "1")
            {
                importWordsFromFile();
            }
            else if (line == "2")
            {
                
                BubbleSort(words);
            }
            else if (line == "3")
            {
                LINQLAMBDASortWords(words);

            }
            else if (line == "4")
            {
                distinctWord(words);
            }
            else if (line == "5")
            {
                takeTheFirst10Word(words);
            }
            else if (line == "6")
            {
                startsWithJ(words);
            }
            else if (line == "7")
            {
                endsWithD(words);
            }
            else if (line == "8")
            {
                fourChars(words);
            }
            else if (line == "9")
            {
                threeChars(words);
            }
            else if (line == "x")
            {
                Console.WriteLine("Exit");
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();

            }

            return true;
        }

        //this method takes the word from text file/ store them in a list
        private static void importWordsFromFile()
        {
            
            string w;//word in the file
            int counter = 0;//counting the words

            //read a text file 
            StreamReader read = new StreamReader("Words.txt");

            Console.WriteLine("Reading Words");
            
            //each word is taken from the file
            //w = import.ReadLine();
            while ((w = read.ReadLine()) != null)
            {
                words.Add(w); //each word is added to the list
                counter++;
            }

            Console.WriteLine("Reading Words Complete");
            Console.WriteLine("Number of words found: {0}", counter);
            
        }


        /*
         * this method accepts a list of strings and 
         * provides a bubble sort on the collection
         */
        private static IList<string> BubbleSort(IList<string> words)
        {

            //Stopwatch measures time elapsed

            Stopwatch time = Stopwatch.StartNew();

            string temp;

            for (int i = 0; i < (words.Count - 1); i++)
            {
                for (int j = i + 1; j < words.Count; j++)
                {
                    if (words[j].CompareTo(words[i]) < 0)
                    {
                        temp = words[j];
                        words[j] = words[i];
                        words[i] = temp;
                    }
                }
            }
            time.Stop();
            Console.WriteLine("Elapsed Time: {0} ms", time.ElapsedMilliseconds);
            Console.WriteLine();
            return words;
        }

        /*
         * iii.	LINQ/Lambda sort words
         */
        private static List<string> LINQLAMBDASortWords(List<string> words)
        {

            //Stopwatch measures time elapsed
            Stopwatch time = Stopwatch.StartNew();

            var q = words.OrderBy(str => str).ToList();
            words = q;

            time.Stop(); // time stops
            Console.WriteLine("Elapsed Time: {0} ms", time.ElapsedMilliseconds);
            return words;
        }

        /*
         * it counts the Distinct words
         */
        private static void distinctWord(List<string> words)
        {
            int distinctWords = (from x in words select x).Distinct().Count();
            Console.WriteLine("The number of distinct words is: {0}", distinctWords);
            Console.WriteLine();
        }

        /*
         * this method takes the first 10 words
         */
        private static void takeTheFirst10Word(List<string> words)
        {
            var firstTenWord = words.Take(10).ToList();
            foreach (var word in firstTenWord)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
        }

        /*
         * this method counts the words that start with j
         */
        private static void startsWithJ(List<string> words)
        {

            //counting the words
            int startJwords = 0;
            var q = from x in words where x.StartsWith("j") select x;

            foreach (var word in q)
            {
                Console.WriteLine(word);
                startJwords++;
            }

            //print the words that start with j
            Console.WriteLine("The number of words that start with 'j': {0}", startJwords);
            Console.WriteLine();


        }

        /*
         * this method counts and shows the words that has charecters greater than 4
         */
        private static void fourChars(List<string> words)
        {
            var q = from x in words where x.Length > 4 select x;
            int wordsWithFourChar = 0;

            foreach (var word in q)
            {
                Console.WriteLine(word);
                wordsWithFourChar++;
            }

            Console.WriteLine("The number of words longer than 4 characters: {0}", wordsWithFourChar);
            Console.WriteLine();

        }

        /*
         * this method counts and shows the words that end with D
         */
        private static void endsWithD(List<string> words)
        {

            //Use a LINQ queryto find all the words that end with ‘d’
            var q = from x in words where x.EndsWith("d") select x;
            int wordEndD = 0;

            foreach (var word in q)
            {
                Console.WriteLine(word);
                wordEndD++;
            }

            Console.WriteLine("The number of words that end with 'd': {0}", wordEndD);
            Console.WriteLine();
        }


        /*
         * this method get and display the words 
         * that are less than 3 characters long 
         * and start with the letter ‘a’.
         */

        private static void threeChars(List<string> words)
        {

            var q = from x in words where x.Length < 3 && x.StartsWith("a") select x;
            int threecharsW = 0;


            foreach (var word in q)
            {
                Console.WriteLine(word);
                threecharsW++;
            }

            Console.WriteLine("The number of words less than 3 characters and starts with 'a': {0}", threecharsW);
            Console.WriteLine();
        }



    }
}





    
   


        
