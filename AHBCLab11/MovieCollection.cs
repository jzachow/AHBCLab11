using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace AHBCLab11
{
    class MovieCollection
    {
        private List<Movie> movieLibrary;
        private List<string> genreList = new List<string>();

        public MovieCollection()
        {
            InitlializeMovies();
            InitializeCategories();
        }


        
        private void InitializeCategories()
        {
            foreach (Movie movie in movieLibrary)
            {
                string[] genres = SplitCategories(movie.Category);

                AddCategory(genres);

            }
        }


        private void InitlializeMovies()
        {
            movieLibrary = new List<Movie>
            {
                new Movie("Spirited Away", "Animated, Adventure"),
                new Movie("The Godfather", "Crime, Drama"),
                new Movie("Psycho", "Horror, Mystery, Thriller"),
                new Movie("12 Angry Men", "Crime, Drama"),
                new Movie("Schindler's List", "Biography, Drama, History"),
                new Movie("The Lord of the Rings: The Return of the King", "Action, Adventure, Drama"),
                new Movie("The Matrix", "Action, Scifi"),
                new Movie("The Good, the Bad, and the Ugly", "Western"),
                new Movie("Fight Club", "Drama"),
                new Movie("Inception", "Action, Adventure, Scifi")
            };
            movieLibrary.Sort();
        }

        private string[] SplitCategories(string categories)
        {
            string[] differentGenres = categories.Split(',');

            return differentGenres;
        }


        private void AddCategory(string[] categories)
        {

            foreach (string genre in categories)
            {
                var tempString = genre.ToLower().Trim();

                var formattedCategory = Char.ToUpper(tempString[0]) + tempString.Substring(1).ToLower();

                if (!genreList.Contains(formattedCategory))
                {
                    genreList.Add(formattedCategory);
                    genreList.Sort();
                }
            }
        }

        public void AddMovie(string title, string category)
        {
            Movie userMovie = new Movie(title, category);

            if (movieLibrary.Contains(userMovie))
            {
                Console.WriteLine($"{title} already exists in collection.");
            }
            else
            {
                movieLibrary.Add(userMovie);
                AddCategory(SplitCategories(userMovie.Category));
                movieLibrary.Sort();
                Console.WriteLine("\n\n------------------------------------------------------------");
                Console.WriteLine($"{userMovie.Title} added to collection.");
                Console.WriteLine("------------------------------------------------------------");
            }
        }

        public string GetCategoryFromIndex(int index)
        {
            return genreList.ElementAt(index - 1);
        }

        public void SearchByCategory(string category)
        {
            var matches = new List<Movie>();

            foreach (Movie movie in movieLibrary)
            {
                if (movie.Category.Contains(category, StringComparison.InvariantCultureIgnoreCase))
                {
                    matches.Add(movie);
                }
            }

            Console.WriteLine("\n\n------------------------------------------------------------");
            Console.WriteLine($"\t\tMatches for {category.ToLower()} movies");
            Console.WriteLine("------------------------------------------------------------");
            foreach (Movie movie in matches)
            {
                Console.WriteLine($"*{movie.Title}");
            }
        }

        public int NumberOfMovies()
        {
            return movieLibrary.Count();
        }

        public int NumberOfGenres()
        {
            return genreList.Count();
        }

        public void PrintCategories()
        {
            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine("\t\t\tCategories");
            Console.WriteLine("------------------------------------------------------------");

            string tabs = "\t\t";
            
            for (int i = 0; i < genreList.Count(); i++)
            {
                string category = genreList.ElementAt(i);

                //Set 3 columns for console display
                if ((i % 3) == 0)
                    Console.Write($"\n{i + 1:00}. {category}");
                else
                    Console.Write($"{tabs}{i + 1:00}. {category}");

                //Adjust number of prepended tabs for next genre based on current genre word length
                if (category.Length < 5)
                    tabs = "\t\t\t";
                else if (category.Length > 9)
                    tabs = "\t";
                else
                    tabs = "\t\t";
            }
        }

        public void PrintMovieList()
        {
            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine("\t\tCurrent Movie List");
            Console.WriteLine("------------------------------------------------------------");

            foreach (Movie movie in movieLibrary)
            {
                Console.WriteLine($"{movie.Title} - ({movie.Category})");

            }
        }
    }
}
