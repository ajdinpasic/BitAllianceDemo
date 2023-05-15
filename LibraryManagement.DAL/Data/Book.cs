using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Data
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; } // columns 
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public DateTime ReleaseYear { get; set; }
        // lazy loading
        public virtual List<Rental> Rentals { get; set; } = new List<Rental>(); // 1- M
    }
}
