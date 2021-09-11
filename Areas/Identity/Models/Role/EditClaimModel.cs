using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace App.Areas.Identity.Models.RoleViewModels
{
  public class EditClaimModel
  {
    [Display(Name = "Kiểu (tên) claim")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
    public string ClaimType { get; set; }

    [Display(Name = "Giá trị")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
    public string ClaimValue { get; set; }

    public IdentityRole role { get; set; }


  }
}
