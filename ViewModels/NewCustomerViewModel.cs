using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Caliburn.Models;

namespace Caliburn.ViewModels
{
    public class NewCustomerViewModel
    {
        //IEnumerable over List because we don't need all the functionality of List (ie. add, remove, accessing via index, etc)
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}