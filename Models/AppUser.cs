using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace App.Models 
{
    public class AppUser: IdentityUser 
    {
          [Column(TypeName = "nvarchar")]
          [StringLength(400)]  
          public string HomeAdress { get; set; }

          // [Required]       
          [DataType(DataType.Date)]
          public DateTime? BirthDate { get; set; }
    }
}
