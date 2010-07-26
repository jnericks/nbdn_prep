using System;

namespace nothinbutdotnetprep.collections
{
    public class Movie  : IEquatable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public bool Equals(Movie other)
        {
            if (other == null) return false;

            return ReferenceEquals(this,other) || 
                is_equal_to_non_null_instance_of(other);
        }

        bool is_equal_to_non_null_instance_of(Movie other)
        {
            return this.title == other.title;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Movie);
        }

        public override string ToString()
        {
            return title;
        }

        public static CriteriaFor<Movie> is_published_by_pixar_or_disney
        {
            get
            {
                return item => is_published_by(ProductionStudio.Pixar)(item) ||
                    is_published_by(ProductionStudio.Disney)(item);
            }
        }

        public static CriteriaFor<Movie> is_published_by(ProductionStudio studio)
        {
            return item => item.production_studio == studio;
        }
    }
}