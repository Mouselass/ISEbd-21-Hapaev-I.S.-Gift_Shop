using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopBusinessLogic.ViewModels
{
    public class ReportGiftComponentViewModel
    {
        public string ComponentName { get; set; }
        public string GiftName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Gifts { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}
