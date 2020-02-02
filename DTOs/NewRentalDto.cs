using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caliburn.DTOs
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}