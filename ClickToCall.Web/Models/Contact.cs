using System.ComponentModel.DataAnnotations;

namespace ClickToCall.Web.Models
{
    public class Contact
    {
        [Required, Phone]
        public string Phone { get; set; }
    }
}