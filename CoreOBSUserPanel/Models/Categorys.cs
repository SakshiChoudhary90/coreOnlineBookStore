using System;
using System.Collections.Generic;

namespace CoreOBSUserPanel.Models
{
    public partial class Categorys
    {
        public Categorys()
        {
            Books = new HashSet<Books>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
