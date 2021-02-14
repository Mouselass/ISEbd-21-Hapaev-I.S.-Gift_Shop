using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace GiftShopBusinessLogic.ViewModels
{
    public class GiftViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]

        public string GiftName { get; set; }
        [DisplayName("Цена")]

        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> GiftComponents { get; set; }
    }
}
