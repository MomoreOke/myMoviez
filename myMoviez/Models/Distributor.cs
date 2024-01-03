using System;
using System.Collections.Generic;

namespace myMoviez.Models
{
    public partial class Distributor
    {
        public Distributor()
        {
            Movies = new HashSet<Movie>();
        }

        public int DistributorId { get; set; }
        public string DistributerName { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
