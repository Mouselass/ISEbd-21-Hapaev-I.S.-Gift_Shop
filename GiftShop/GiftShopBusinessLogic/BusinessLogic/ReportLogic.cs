using System;
using System.Collections.Generic;
using System.Linq;
using GiftShopBusinessLogic.BindingModels;
using GiftShopBusinessLogic.HelperModels;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.ViewModels;

namespace GiftShopBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly IGiftStorage _giftStorage;
        private readonly IOrderStorage _orderStorage;

        public ReportLogic(IGiftStorage giftStorage, IComponentStorage componentStorage, IOrderStorage orderStorage)
        {
            _giftStorage = giftStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
        }

        public List<ReportGiftComponentViewModel> GetGiftComponent()
        {
            var components = _componentStorage.GetFullList();
            var gifts = _giftStorage.GetFullList();
            var list = new List<ReportGiftComponentViewModel>();
            foreach (var component in components)
            {
                var record = new ReportGiftComponentViewModel
                {
                    ComponentName = component.ComponentName,
                    Gifts = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var gift in gifts)
                {
                    if (gift.GiftComponents.ContainsKey(component.Id))
                    {
                        record.Gifts.Add(new Tuple<string, int>(gift.GiftName, gift.GiftComponents[component.Id].Item2));
                        record.TotalCount += gift.GiftComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportGiftComponentViewModel> GetComponentsGift()
        {
            var components = _componentStorage.GetFullList();
            var gifts = _giftStorage.GetFullList();
            var list = new List<ReportGiftComponentViewModel>();
            foreach (var gift in gifts)
            {
                var record = new ReportGiftComponentViewModel
                {
                    GiftName = gift.GiftName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };

                foreach (var component in components)
                {
                    if (gift.GiftComponents.ContainsKey(component.Id))
                    {
                        record.Components.Add(new Tuple<string, int>(component.ComponentName, gift.GiftComponents[component.Id].Item2));
                        record.TotalCount += gift.GiftComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel { DateFrom = model.DateFrom, DateTo = model.DateTo })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                GiftName = x.GiftName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
        }

        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Components = _componentStorage.GetFullList()
            });
        }

        public void SaveGiftsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Gifts = _giftStorage.GetFullList()
            });
        }

        public void SaveGiftComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                GiftComponents = GetGiftComponent()
            });
        }

        public void SaveComponentGiftToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                GiftComponents = GetComponentsGift()
            });
        }

        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
