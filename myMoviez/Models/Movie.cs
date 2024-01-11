using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace myMoviez.Models
{
    public partial class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; } = null!;
        public string? Plot { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Duration { get; set; }
        public int? RnRid { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public int ActorId { get; set; }
        public int ProducerId { get; set; }
        public int? DistributorId { get; set; }

        public virtual Actor Actor { get; set; } = null!;
        public virtual Director Director { get; set; } = null!;
        public virtual Distributor? Distributor { get; set; }
        public virtual Genre Genre { get; set; } = null!;
        public virtual Producer Producer { get; set; } = null!;
        public virtual RatingAndReview? RnR { get; set; }
    }
}
