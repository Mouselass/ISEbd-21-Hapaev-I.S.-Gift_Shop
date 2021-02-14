using System;
using System.Collections.Generic;
using System.Linq;
using GiftShopBusinessLogic.BindingModels;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.ViewModels;
using GiftShopFileImplement.Models;

namespace GiftShopFileImplement.Implements
{
    public class GiftStorage : IGiftStorage
    {
        private readonly FileDataListSingleton source;

        public GiftStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<GiftViewModel> GetFullList()
        {
            return source.Gifts.Select(CreateModel).ToList();
        }

        public List<GiftViewModel> GetFilteredList(GiftBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Gifts.Where(rec => rec.GiftName.Contains(model.GiftName))
            .Select(CreateModel).ToList();
        }

        public GiftViewModel GetElement(GiftBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var gift = source.Gifts
            .FirstOrDefault(rec => rec.GiftName == model.GiftName || rec.Id == model.Id);
            return gift != null ? CreateModel(gift) : null;
        }

        public void Insert(GiftBindingModel model)
        {
            int maxId = source.Gifts.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Gift { Id = maxId + 1, GiftComponents = new Dictionary<int, int>() };
            source.Gifts.Add(CreateModel(model, element));
        }

        public void Update(GiftBindingModel model)
        {
            var element = source.Gifts.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(GiftBindingModel model)
        {
            Gift element = source.Gifts.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Gifts.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
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
            return new GiftViewModel
            {
                Id = gift.Id,
                GiftName = gift.GiftName,
                Price = gift.Price,
                GiftComponents = gift.GiftComponents.ToDictionary(recPC => recPC.Key, recPC =>
                    (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}
