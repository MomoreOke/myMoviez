using System;
using System.Collections.Generic;

namespace myMoviez.Models
{
    public partial class Actor
    {
        public Actor()
        {
            Movies = new HashSet<Movie>();
        }

        public int ActorId { get; set; }
        public string? ActorName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
