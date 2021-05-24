using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using GiftShopBusinessLogic.Attributes;

namespace GiftShopBusinessLogic.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }

        [Column(title: "Склад", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string WarehouseName { get; set; }

        [Column(title: "Ответственный", width: 150)]
        public string Responsible { get; set; }

        [Column(title: "Дата создания", width: 100, dateFormat: "D")]
        public DateTime DateCreate { get; set; }
        

        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
