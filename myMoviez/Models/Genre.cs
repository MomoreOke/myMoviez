using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace myMoviez.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
