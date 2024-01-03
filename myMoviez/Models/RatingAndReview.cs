using System;
using System.Collections.Generic;

namespace myMoviez.Models
{
    public partial class RatingAndReview
    {
        public RatingAndReview()
        {
            Movies = new HashSet<Movie>();
        }

        public int RnRid { get; set; }
        public int? Rating { get; set; }
        public string Review { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
