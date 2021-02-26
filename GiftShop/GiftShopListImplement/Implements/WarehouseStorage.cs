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
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly DataListSingleton source;

        public WarehouseStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<WarehouseViewModel> GetFullList()
        {
            List<WarehouseViewModel> result = new List<WarehouseViewModel>();
            foreach (var component in source.Warehouses)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<WarehouseViewModel> result = new List<WarehouseViewModel>();
            foreach (var gift in source.Warehouses)
            {
                if (gift.WarehouseName.Contains(model.WarehouseName))
                {
                    result.Add(CreateModel(gift));
                }
            }
            return result;
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var gift in source.Warehouses)
            {
                if (gift.Id == model.Id || gift.WarehouseName.Equals(model.WarehouseName))
                {
                    return CreateModel(gift);
                }
            }
            return null;
        }

        public void Insert(WarehouseBindingModel model)
        {
            Warehouse tempGift = new Warehouse { Id = 1, WarehouseComponents = new Dictionary<int, int>() };
            foreach (var gift in source.Warehouses)
            {
                if (gift.Id >= tempGift.Id)
                {
                    tempGift.Id = gift.Id + 1;
                }
            }
            source.Warehouses.Add(CreateModel(model, tempGift));
        }

        public void Update(WarehouseBindingModel model)
        {
            Warehouse tempGift = null;
            foreach (var gift in source.Warehouses)
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

        public void Delete(WarehouseBindingModel model)
        {
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    source.Warehouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse gift)
        {
            gift.WarehouseName = model.WarehouseName;
            gift.Responsible = model.Responsible;
            gift.DateCreate = model.DateCreate;

            // удаляем убранные
            foreach (var key in gift.WarehouseComponents.Keys.ToList())
            {
                if (!model.WarehouseComponents.ContainsKey(key))
                {
                    gift.WarehouseComponents.Remove(key);
                }
            }

            // обновляем существуюущие и добавляем новые
            foreach (var component in model.WarehouseComponents)
            {
                if (gift.WarehouseComponents.ContainsKey(component.Key))
                {
                    gift.WarehouseComponents[component.Key] = model.WarehouseComponents[component.Key].Item2;
                }
                else
                {
                    gift.WarehouseComponents.Add(component.Key, model.WarehouseComponents[component.Key].Item2);
                }
            }
            return gift;
        }

        private WarehouseViewModel CreateModel(Warehouse gift)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            Dictionary<int, (string, int)> giftComponents = new Dictionary<int, (string, int)>();

            foreach (var pc in gift.WarehouseComponents)
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

            return new WarehouseViewModel
            {
                Id = gift.Id,
                WarehouseName = gift.WarehouseName,
                Responsible = gift.Responsible,
                DateCreate = gift.DateCreate,
                WarehouseComponents = giftComponents
            };
        }
    }
}
