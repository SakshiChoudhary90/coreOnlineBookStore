using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coreOnlineBookStore.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public float BookPrice { get; set; }
        [Required]
        public string BookType { get; set; }
        [Required]
        public string BookImage { get; set; }
        public Author Author { get; set; }
        public Publication Publication { get; set; }
        public BookCategory BookCategory { get; set; }
    }
}
