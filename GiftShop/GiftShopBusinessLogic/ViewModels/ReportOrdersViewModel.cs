using System;
using System.Collections.Generic;
using System.Text;
using GiftShopBusinessLogic.Enums;

namespace GiftShopBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }
        public string GiftName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
    }
}
