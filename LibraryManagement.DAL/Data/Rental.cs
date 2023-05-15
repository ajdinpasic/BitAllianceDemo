using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Data
{
    public class Rental
    {
        [Key]
        public Guid RentalId { get; set; }

       // public virtual Book Book { get; set; } // kontra strana 1-M veze
    }
}
