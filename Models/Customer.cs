using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Caliburn.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's full name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscriberToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        //EntityFramework recognizes blahblahblahId convention and treats it as a foreign key.
        //Implicitly required because byte may not be NULL. If this was byte?, this would not work.
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } 
        
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}