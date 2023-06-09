using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace DemoWebapi.Models
{
    public class Passenger
    {
        [Key]
       public int PassengerId { get; set; }

        [Required]
        public string PassengerName { get; set; }

        [Required]
        public string PassengerLocation{ get; set; }

    }
}
