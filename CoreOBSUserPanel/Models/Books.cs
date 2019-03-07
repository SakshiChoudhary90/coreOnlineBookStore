using System;
using System.Collections.Generic;

namespace CoreOBSUserPanel.Models
{
    public partial class Books
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public float BookPrice { get; set; }
        public string BookType { get; set; }
        public string BookImage { get; set; }
        public int? AuthorId { get; set; }
        public int? PublicationId { get; set; }
        public int? BookCategoryCategoryId { get; set; }

        public Authors Author { get; set; }
        public Categorys BookCategoryCategory { get; set; }
        public Publications Publication { get; set; }
    }
}
