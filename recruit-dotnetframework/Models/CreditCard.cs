using System;
using System.ComponentModel.DataAnnotations;

namespace recruit_dotnetframework.Models
{
    public class CreditCard
    {
        
        [Required]
        [CreditCard]
        public string CreditCardNumber { get; set; }

        [Required]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "CVC must be 3 or 4 digits")]
        public string CVC { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
    }
}