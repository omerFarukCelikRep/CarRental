using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        public int RentalID { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public int CarID { get; set; }
        public virtual Car Car { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
