using System.ComponentModel.DataAnnotations.Schema;

namespace beer_app_management.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Alcohol { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public List<WSStock> WSStocks { get; set; } = new List<WSStock>();
    }
}