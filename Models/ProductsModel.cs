using System.ComponentModel.DataAnnotations;

namespace Qhrm.Models
{
    public class ProductsModel
    {
        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        
    }
}
