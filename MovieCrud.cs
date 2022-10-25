using MovieDatabaseV2LabJT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace MovieDatabaseV2LabJT
{
    public class MovieCrud
    {
        public MovieContext db = new MovieContext(); //Call data from database,
        public List<Movie> movie = new List<Movie>();
        public void ConsoleStart()
        {
            bool start = true;
            while (start == true)
            {
                string input = GetUserInput("Hello. This program has information about some movies. What would you like to do? \n(1)Search by Genre, (2)Search by Title, (3)Display all movies, or (4)Exit: ");
                List<Movie> movie = db.Movies.ToList();

                if (input == "1" || input == "genre" || input == "g")
                {
                    SearchByGenre(movie);
                    Console.WriteLine();
                }
                else if (input == "2" || input == "title" || input == "t")
                {
                    SearchByTitle(movie);
                    Console.WriteLine();
                }
                else if (input == "3" || input == "display" || input == "d" || input == "all")
                {
                    PrintMovies(movie);//lists all movies from Movie SQL Database
                    Console.WriteLine();
                }
                else if (input == "4" || input == "exit" || input == "e" || input == "esc")
                {
                    if (start == Repeat())
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine($"Your input was not a valid number, please try again.");
                    Console.WriteLine();
                    continue;
                }
            }      
        }

        public void PrintMovies(List<Movie> movies)
        {
            Console.WriteLine("Printing Movie Titles: ");
            int i = 1;
            foreach (Movie mov in movies)
            {
                Console.WriteLine(i + ") " + mov.Title);
                i++;
            }
        }

        public void SearchByGenre(List<Movie> movies)
        {
            Movie mov = new Movie();

            Console.Write("Please enter a genre to search by. Enter (1) or 'genre' to display a list: ");
            string genre = Console.ReadLine().ToLower();
            int i = 1;
            List<Movie> MovieGenre = movies.Where(m => m.Genre.ToLower().Contains(genre)).ToList();
            if (genre == "1" || genre == "genre")
            {

                foreach (Movie gen in movies)
                {
                    Console.WriteLine(i + ") " + gen.Genre);
                    i++;
                }
            }
            //can place trycatch here
            Console.WriteLine($"Here is a list of {genre} Movies.\n");
            foreach (Movie m in MovieGenre)
            {
                Console.WriteLine($"{i}) Title: {m.Title}\nGenre: { m.Genre}\nRunetime: {m.Runtime} minutes");
                Console.WriteLine();
                i++;
            }             
        }

        public void SearchByTitle(List<Movie> movies)
        {
            Console.WriteLine("Which movie are you looking for?");
            string title = Console.ReadLine().ToLower(); //also place for trycatch
            
            List<Movie> MovieTitle = movies.Where(m => m.Title.ToLower().Contains(title)).ToList();
            Console.WriteLine($"Here is a list of {title} Movies.\n");

            int index = 1;
            foreach (Movie movie in MovieTitle)
            {
                Console.WriteLine($"{index}) Title: {movie.Title}\nGenre: {movie.Genre}\nRunetime: {movie.Runtime} minutes");
                Console.WriteLine();
                index++;
            }
        }

        public static string GetUserInput(string message)
        {
            string input = String.Empty;
            try
            {
                Console.Write(message);
                input = Console.ReadLine().ToLower();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please try again.");
                GetUserInput(message);
            }
            if (input == null)
            {
                Console.WriteLine("No input was detected. Please try again.");
                GetUserInput(message);
            }
            return input;
        }

        public bool Repeat()
        {
            Console.Write("Do you want to exit the program? Y/N: ");
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    Console.WriteLine("Goodbye!");
                    Console.WriteLine();
                    return true;
                }
                else if (input == "n")
                {
                    Console.WriteLine("Welcome back!");
                    Console.WriteLine();
                    return false;
                }
                else
                {
                    Console.WriteLine("Please only enter Y or N:");
                }
            }
        }

        /*        public void PrintOneMovie()
        {
            MovieCrud sc = new MovieCrud();
            Console.WriteLine("Please select the Index to learn about that movie");
            int pick = int.Parse(Console.ReadLine());

            Movie s = sc.GetOneMovie(pick);

            Console.WriteLine($"Title: {s.Title}");
            Console.WriteLine($"Genre: {s.Genre}");
            Console.WriteLine($"Runetime: {s.Runtime} minutes");
        }*/

        /*public List<Movie> GetMovies()
        {
            return db.Movies.ToList();
        }

        public Movie GetOneMovie(int id)
        {
            Movie output = db.Movies.Find(id);
            return output;
        }

        public void Update(Movie newValues)
        {
            db.Movies.Update(newValues);
            db.SaveChanges();
        }*/
    }
}
