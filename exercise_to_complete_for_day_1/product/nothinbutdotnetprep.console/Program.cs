using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var movie_library = new MovieLibrary(new List<Movie>());
            Enumerable.Range(1, 100).ToList().ForEach(x => movie_library.add(new Movie {title = x.ToString("Movie 0")}));

            var all_movies= movie_library.all_movies();
            all_movies.Count();

            Console.ReadLine();
        }
    }
}