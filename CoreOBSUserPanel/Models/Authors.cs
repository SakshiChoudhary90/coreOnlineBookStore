using System;
using System.Collections.Generic;

namespace CoreOBSUserPanel.Models
{
    public partial class Authors
    {
        public Authors()
        {
            Books = new HashSet<Books>();
        }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public string AuthorBiography { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
