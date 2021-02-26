using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace GiftShopBusinessLogic.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }

        [DisplayName("Склад")]
        public string WarehouseName { get; set; }

        [DisplayName("Ответственный")]
        public string Responsible { get; set; }

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        

        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
