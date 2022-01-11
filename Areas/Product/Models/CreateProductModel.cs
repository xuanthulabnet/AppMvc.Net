using System.ComponentModel.DataAnnotations;
using App.Models.Product;

namespace AppMvc.Areas.Product.Models {
    public class CreateProductModel : ProductModel {
        [Display(Name = "Chuyên mục")]
        public int[] CategoryIDs { get; set; }
    }
}
