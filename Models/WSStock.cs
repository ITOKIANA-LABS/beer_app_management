
namespace beer_app_management.Models
{
    public class WSStock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int? BeerId { get; set; }
        public Beer? Beer { get; set; }
    }
}