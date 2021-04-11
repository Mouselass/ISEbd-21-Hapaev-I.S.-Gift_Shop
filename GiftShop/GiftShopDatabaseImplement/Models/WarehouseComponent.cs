using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GiftShopDatabaseImplement.Models
{
    public class WarehouseComponent
    {
        public int Id { get; set; }

        public int WarehouseId { get; set; }

        public int ComponentId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Component Component { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
