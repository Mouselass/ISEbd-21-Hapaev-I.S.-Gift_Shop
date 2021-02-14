using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopFileImplement.Models
{
    public class Gift
    {
        public int Id { get; set; }

        public string GiftName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, int> GiftComponents { get; set; }
    }
}
