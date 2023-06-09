using Microsoft.AspNetCore.Identity;
using MvcDemoPractice.Controllers;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace MvcDemoPractice.Models
{
	public class LoginRepo 
	{
		[Key]
		public string Name { get; set; }
		public string Password { get; set; }

	}
}
