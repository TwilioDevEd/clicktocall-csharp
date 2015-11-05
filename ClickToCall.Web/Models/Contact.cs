using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RestSharp.Validation;

namespace ClickToCall.Web.Models
{
    public class Contact
    {
        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}