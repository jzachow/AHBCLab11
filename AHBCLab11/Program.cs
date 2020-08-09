using System;
using System.Collections.Generic;

namespace AHBCLab11
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieCollection library = new MovieCollection();
            bool userContinue = true;


            Console.WriteLine("Welcome to Justin's Movie List Application!");


            while (userContinue)
            {
                Console.WriteLine("\nPlease select one of the following options: ");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("1 - View all movies in the collection. " +
                    "\n2 - Search movies by genre. " +
                    "\n3 - Add a new movie to the collection. " +
                    "\nAny other key to quit the application.");

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        library.PrintMovieList();
                        break;

                    case "2":
                        ProcessSearchByGenre(library);
                        break;

                    case "3":
                        ProcessAddNewMovie(library);
                        break;
                    default:
                        userContinue = false;
                        break;
                }
            }

        }

        private static void ProcessAddNewMovie(MovieCollection library)
        {
            Console.WriteLine("Please enter the new movie's title: ");
            var userTitle = Console.ReadLine();
            Console.WriteLine("\nPlease enter the new movie's genre. Separate multiple genres with a comma.");
            Console.WriteLine("For example: Drama, Crime, Musical");
            var userGenres = Console.ReadLine();
            library.AddMovie(userTitle, userGenres);
        }

        private static void ProcessSearchByGenre(MovieCollection library)
        {
            library.PrintCategories();
            Console.WriteLine("\n\nWhich genre are you interested in?");
            var userChoice = Console.ReadLine();
            bool isValidInput = int.TryParse(userChoice, out int userGenre);

            while(!isValidInput || userGenre < 1 || userGenre > library.NumberOfGenres())
            {
                Console.WriteLine("Invalid entry. Please try again.");
                Console.WriteLine("\nWhich genre are you interested in?");
                userChoice = Console.ReadLine();
                isValidInput = int.TryParse(userChoice, out userGenre);
            }

            library.SearchByCategory(library.GetCategoryFromIndex(userGenre));
        }
    }
}
