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
            return source.Products.Select(CreateModel).ToList();
        }

        public List<GiftViewModel> GetFilteredList(GiftBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Products.Where(rec => rec.ProductName.Contains(model.ProductName))
            .Select(CreateModel).ToList();
        }

        public GiftViewModel GetElement(GiftBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var product = source.Products
            .FirstOrDefault(rec => rec.ProductName == model.ProductName || rec.Id == model.Id);
            return product != null ? CreateModel(product) : null;
        }

        public void Insert(GiftBindingModel model)
        {
            int maxId = source.Products.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Gift { Id = maxId + 1, ProductComponents = new Dictionary<int, int>() };
            source.Products.Add(CreateModel(model, element));
        }

        public void Update(GiftBindingModel model)
        {
            var element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(GiftBindingModel model)
        {
            Gift element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Products.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Gift CreateModel(GiftBindingModel model, Gift product)
        {
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            // удаляем убранные
            foreach (var key in product.ProductComponents.Keys.ToList())
            {
                if (!model.ProductComponents.ContainsKey(key))
                {
                    product.ProductComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.ProductComponents)
            {
                if (product.ProductComponents.ContainsKey(component.Key))
                {
                    product.ProductComponents[component.Key] = model.ProductComponents[component.Key].Item2;
                }
                else
                {
                    product.ProductComponents.Add(component.Key, model.ProductComponents[component.Key].Item2);
                }
            }
            return product;
        }

        private GiftViewModel CreateModel(Gift product)
        {
            return new GiftViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                ProductComponents = product.ProductComponents.ToDictionary(recPC => recPC.Key, recPC =>
                    (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}
