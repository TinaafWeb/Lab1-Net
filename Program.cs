using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {


        static void Main(string[] args)

        {

            int choice = 0;//the menu choices

            //print a header 
            Console.WriteLine("***********************************");
            Console.WriteLine("*******An Introduction to C#*********");
            Console.WriteLine("************Choices****************");
            Console.WriteLine("***********************************");

            while (choice < 10)
            {
               //print the menu
                Console.WriteLine(" 1 - Import Words from File\n 2 - Bubble Sort words\n 3 - LINQ / Lambda sort words\n 4 - Count the Distinct Words\n 5 - Take the first 10 words\n 6 - Get the number of words that start with 'j' and display the count\n 7 - Get and display of words that end with 'd' and display the count\n 8 - Get and display of words that are greater than 4 characters long and display the count\n 9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count\n x – Exit");
                Console.WriteLine("***********************************");

                //getting the user input
                Console.WriteLine("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("***********************************");


                //import words from file
                if (choice == 1)
                {
                    importFile();
                }


                else
                {

                }
            }


        }
        //this method takes the word from text file/ store them in a list
        static void importFile()
        {
            
            string w;//word in the file
            int c = 0;//counting the words

            //each word you find in the file will be added to a List 
            IList<string> words = new List<string>();

            //read a text file 
            StreamReader import = new StreamReader("Words.txt");

            Console.WriteLine("Reading Words");

            //each word is taken from the file
            w = import.ReadLine();

            do
            {
                words.Add(w); //each word is added to the list
                c++;
            }
            while (w != null);

            Console.WriteLine("Reading Words Complete");
            Console.WriteLine("Number of words found: {0}", c);
            
        }
    }
}
   


        
