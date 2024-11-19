using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beer_app_management.Dtos.Beer
{
    public class BeweryBeerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Alcohol { get; set; }
        public decimal Price { get; set; }
    }
}