using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Limit_Order_Book.Entities
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Side { get; set; }
    }
}
