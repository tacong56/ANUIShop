using System;
using System.Collections.Generic;
using System.Text;

namespace TANGOCCONG.ANUIShop.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
