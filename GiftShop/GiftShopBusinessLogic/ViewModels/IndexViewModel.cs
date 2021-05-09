using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopBusinessLogic.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<MessageInfoViewModel> Messages { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
