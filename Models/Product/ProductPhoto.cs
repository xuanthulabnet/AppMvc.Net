using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Product {

    [Table("ProductPhoto")]
    public class ProductPhoto
    {
        [Key]
        public int Id { get; set; }

        // abc.png, 123.jpg ... 
        // => /contents/Products/abc.pgn, /contents/Products/123.jpg
        public string FileName { get; set; }

        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public ProductModel Product { get; set; }


    }
}