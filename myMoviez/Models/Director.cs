using System;
using System.Collections.Generic;

namespace myMoviez.Models
{
    public partial class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        public int DirectorId { get; set; }
        public string DirectorName { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
