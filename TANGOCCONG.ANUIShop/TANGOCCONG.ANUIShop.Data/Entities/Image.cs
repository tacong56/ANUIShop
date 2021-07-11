using System;
using System.Collections.Generic;
using System.Text;

namespace TANGOCCONG.ANUIShop.Data.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
