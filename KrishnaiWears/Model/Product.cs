using System.ComponentModel.DataAnnotations;

namespace KrishnaiWears.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name is Required.")]
        public string? PName { get; set; }
        public string? PDescription { get; set; }
        public decimal? PPrice { get; set; }
        public int? PCatagoryId { get; set; }
    }
}
