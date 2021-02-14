using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GiftShopBusinessLogic.BindingModels;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.ViewModels;
using GiftShopListImplement.Models;

namespace GiftShopListImplement.Implements
{
    public class GiftStorage : IGiftStorage
    {
        private readonly DataListSingleton source;
        public GiftStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<GiftViewModel> GetFullList()
        {
            List<GiftViewModel> result = new List<GiftViewModel>();
            foreach (var component in source.Gifts)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }

        public List<GiftViewModel> GetFilteredList(GiftBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<GiftViewModel> result = new List<GiftViewModel>();
            foreach (var gift in source.Gifts)
            {
                if (gift.GiftName.Contains(model.GiftName))
                {
                    result.Add(CreateModel(gift));
                }
            }
            return result;
        }
        public GiftViewModel GetElement(GiftBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var gift in source.Gifts)
            {
                if (gift.Id == model.Id || gift.GiftName == model.GiftName)
                {
                    return CreateModel(gift);
                }
            }
            return null;
        }
        public void Insert(GiftBindingModel model)
        {
            Gift tempGift = new Gift { Id = 1, GiftComponents = new Dictionary<int, int>() };
            foreach (var gift in source.Gifts)
            {
                if (gift.Id >= tempGift.Id)
                {
                    tempGift.Id = gift.Id + 1;
                }
            }
            source.Gifts.Add(CreateModel(model, tempGift));
        }
        public void Update(GiftBindingModel model)
        {
            Gift tempGift = null;
            foreach (var gift in source.Gifts)
            {
                if (gift.Id == model.Id)
                {
                    tempGift = gift;
                }
            }
            if (tempGift == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempGift);
        }
        public void Delete(GiftBindingModel model)
        {
            for (int i = 0; i < source.Gifts.Count; ++i)
            {
                if (source.Gifts[i].Id == model.Id)
                {
                    source.Gifts.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Gift CreateModel(GiftBindingModel model, Gift gift)
        {
            gift.GiftName = model.GiftName;
            gift.Price = model.Price;
            // удаляем убранные
            foreach (var key in gift.GiftComponents.Keys.ToList())
            {
                if (!model.GiftComponents.ContainsKey(key))
                {
                    gift.GiftComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.GiftComponents)
            {
                if (gift.GiftComponents.ContainsKey(component.Key))
                {
                    gift.GiftComponents[component.Key] = model.GiftComponents[component.Key].Item2;
                }
                else
                {
                    gift.GiftComponents.Add(component.Key, model.GiftComponents[component.Key].Item2);
                }
            }
            return gift;
        }
        private GiftViewModel CreateModel(Gift gift)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            Dictionary<int, (string, int)> giftComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in gift.GiftComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                giftComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new GiftViewModel
            {
                Id = gift.Id,
                GiftName = gift.GiftName,
                Price = gift.Price,
                GiftComponents = giftComponents
            };
        }
    }
}
