using System;
using System.Collections.Generic;
using System.Text;
using GiftShopBusinessLogic.BindingModels;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.ViewModels;

namespace GiftShopBusinessLogic.BusinessLogic
{
    public class GiftLogic
    {
        private readonly IGiftStorage _giftStorage;

        public GiftLogic(IGiftStorage giftStorage)
        {
            _giftStorage = giftStorage;
        }
        public List<GiftViewModel> Read(GiftBindingModel model)
        {
            if (model == null)
            {
                return _giftStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<GiftViewModel> { _giftStorage.GetElement(model) };
            }
            return _giftStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(GiftBindingModel model)
        {
            var element = _giftStorage.GetElement(new GiftBindingModel { GiftName = model.GiftName });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть подарок с таким названием");
            }
            if (model.Id.HasValue)
            {
                _giftStorage.Update(model);
            }
            else
            {
                _giftStorage.Insert(model);
            }
        }

        public void Delete(GiftBindingModel model)
        {
            var element = _giftStorage.GetElement(new GiftBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _giftStorage.Delete(model);
        }
    }
}
