using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            foreach (var movie in movies)
            {
                yield return movie;
            }
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get { return get_sorted(new all_movies_by_title_descending()); }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar) yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (Movie movie in movies)
            {
                if (movie.production_studio ==ProductionStudio.Pixar ||
                    movie.production_studio == ProductionStudio.Disney)
                {
                    yield return movie;
                }
            }
        }

        delegate bool MovieCriteria(Movie movie);

        IEnumerable<Movie> select_movies(MovieCriteria criteria)
        {
            foreach (var movie in movies)
            {
                if (criteria(movie)) yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar) yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int starting_year, int ending_year)
        {
            foreach (Movie movie in movies)
            {
                if (movie.date_published.Year >= starting_year &&
                    movie.date_published.Year <= ending_year)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            foreach (Movie movie in movies)
            {
                if (movie.date_published.Year > year) yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get { return get_sorted(new all_movies_by_title_ascending()); }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            return get_sorted(new all_movies_by_movie_studio_and_year_published());
        }

        private IEnumerable<Movie> get_sorted(IComparer<Movie> comparer)
        {
            var sorted = (List<Movie>)movies;
            sorted.Sort(comparer);

            foreach (var movie in sorted)
            {
                yield return movie;
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            foreach (Movie movie in movies)
            {
                if (movie.genre == Genre.kids)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            foreach (Movie movie in movies)
            {
                if (movie.genre == Genre.action)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            return get_sorted(new all_movies_by_date_published_descending());
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            return get_sorted(new all_movies_by_date_published_ascending());
        }
    }

    public class all_movies_by_title_ascending : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.title.CompareTo(y.title);
        }
    }

    public class all_movies_by_title_descending : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return y.title.CompareTo(x.title);
        }
    }

    public class all_movies_by_movie_studio_and_year_published : IComparer<Movie>
    {
        private static Dictionary<ProductionStudio, int> rankings
            = new Dictionary<ProductionStudio, int>
              {
                  {ProductionStudio.MGM, 1},
                  {ProductionStudio.Pixar, 2},
                  {ProductionStudio.Dreamworks, 3},
                  {ProductionStudio.Universal, 4},
                  {ProductionStudio.Disney, 5},
                  {ProductionStudio.Paramount, 6},
              };

        public int Compare(Movie x, Movie y)
        {
            var rankX = (GetRank(x) * 10000) + x.date_published.Year;
            var rankY = (GetRank(y) * 10000) + y.date_published.Year;

            return rankX.CompareTo(rankY);
        }

        private int GetRank(Movie x)
        {
            return rankings.ContainsKey(x.production_studio)
                       ? rankings[x.production_studio]
                       : 1000;
        }
    }

    public class all_movies_by_date_published_ascending : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.date_published.CompareTo(y.date_published);
        }
    }

    public class all_movies_by_date_published_descending : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return y.date_published.CompareTo(x.date_published);
        }
    }
}