using System.ComponentModel.DataAnnotations;

namespace ClickToCall.Web.Models
{
    public class CallViewModel
    {
        [Required(ErrorMessage = "The user number is required"), Phone]
        public string UserNumber { get; set; }

        [Required(ErrorMessage = "The sales number is required"), Phone]
        public string SalesNumber { get; set; }
    }
}
