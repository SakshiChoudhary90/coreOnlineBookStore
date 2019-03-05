using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coreOnlineBookStore.Models
{
    public class Publication
    {
        
        public int PublicationId { get; set; }
        [Required]
        public string PublicationName { get; set; }
        [Required]
        public string PublicationDescription { get; set; }
        public List<Book> Books { get; set; }

    }
}
