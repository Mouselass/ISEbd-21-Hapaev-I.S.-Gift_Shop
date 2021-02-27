using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftShopDatabaseImplement.Models
{
    public class Gift
    {
        public int Id { get; set; }

        [Required]
        public string GiftName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("GiftId")]
        public virtual List<GiftComponent> GiftComponents { get; set; }

        [ForeignKey("GiftId")]
        public virtual List<Order> Order { get; set; }
    }
}
