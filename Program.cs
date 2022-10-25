using MovieDatabaseV2LabJT.Models;

namespace MovieDatabaseV2LabJT
{
    public class Program
    {
        public static void Main(string[] args)
        {  
            MovieCrud mc = new MovieCrud(); //call methods from MovieCrud.cs

            mc.ConsoleStart();
        }

        

       
    }
}