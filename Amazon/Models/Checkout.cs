using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Amazon.Models
{
    public class Checkout
    {
        [Key]
        [BindNever]
        public int CheckoutID { get; set; }

        [BindNever]
        public ICollection<LineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter first address line")]
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string AdressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter state")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter zip")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter country")]
        public string Country { get; set; }

        [ BindNever ]
        public bool PaymentReceived { get; set; }
    }
}
