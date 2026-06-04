using System.ComponentModel.DataAnnotations;

namespace KrishnaiWears.Shared
{
    public class Cloth
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name is Required.")]
        public string? PName { get; set; }
        public string? PDescription { get; set; }
        public int? PPrice { get; set; }
        public int? PCatagoryId { get; set; }
        public int? PQuantity { get; set; }
    }
}
