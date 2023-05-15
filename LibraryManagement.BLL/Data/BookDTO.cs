using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.BLL.Data
{
    public class BookDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime ReleaseYear { get; set; }

        public List<RentalDTO> Rentals { get; set; } = new List<RentalDTO>();

    }
}
