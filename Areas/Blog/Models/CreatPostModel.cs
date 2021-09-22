using System.ComponentModel.DataAnnotations;
using App.Models.Blog;

namespace AppMvc.Areas.Blog.Models {
    public class CreatePostModel : Post {
        [Display(Name = "Chuyên mục")]
        public int[] CategoryIDs { get; set; }
    }
}