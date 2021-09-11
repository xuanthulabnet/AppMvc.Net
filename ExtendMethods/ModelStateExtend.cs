using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Identity;

namespace App.ExtendMethods
{
    public static class ModelStateExtend
    {
        public static void AddModelError(this ModelStateDictionary ModelState, string mgs)
        {
            ModelState.AddModelError(string.Empty, mgs);
        }
        public static void AddModelError(this ModelStateDictionary ModelState, IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Description);
            }
        }
    }
}