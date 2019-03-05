using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coreOnlineBookStore.Models
{
    public class Author
    {
       
        public int AuthorId { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string AuthorImage { get; set; }
        [Required]
        public string AuthorBiography { get; set; }
        public List<Book> Books { get; set; }
       
      
       

    }
}
