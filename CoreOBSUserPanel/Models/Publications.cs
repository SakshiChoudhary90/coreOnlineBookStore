using System;
using System.Collections.Generic;

namespace CoreOBSUserPanel.Models
{
    public partial class Publications
    {
        public Publications()
        {
            Books = new HashSet<Books>();
        }

        public int PublicationId { get; set; }
        public string PublicationName { get; set; }
        public string PublicationDescription { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
