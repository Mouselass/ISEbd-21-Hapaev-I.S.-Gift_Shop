using System;
using System.Collections.Generic;
using System.Linq;
using GiftShopBusinessLogic.BindingModels;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.ViewModels;
using GiftShopFileImplement.Models;

namespace GiftShopFileImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly FileDataListSingleton source;

        public WarehouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<WarehouseViewModel> GetFullList()
        {
            return source.Warehouses.Select(CreateModel).ToList();
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Warehouses.Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
            .Select(CreateModel).ToList();
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var warehouse = source.Warehouses
            .FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName || rec.Id == model.Id);
            return warehouse != null ? CreateModel(warehouse) : null;
        }

        public void Insert(WarehouseBindingModel model)
        {
            int maxId = source.Warehouses.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Warehouse { Id = maxId + 1, WarehouseComponents = new Dictionary<int, int>() };
            source.Warehouses.Add(CreateModel(model, element));
        }

        public void Update(WarehouseBindingModel model)
        {
            var element = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(WarehouseBindingModel model)
        {
            Warehouse element = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Warehouses.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.Responsible = model.Responsible;
            warehouse.DateCreate = model.DateCreate;
            // удаляем убранные
            foreach (var key in warehouse.WarehouseComponents.Keys.ToList())
            {
                if (!model.WarehouseComponents.ContainsKey(key))
                {
                    warehouse.WarehouseComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.WarehouseComponents)
            {
                if (warehouse.WarehouseComponents.ContainsKey(component.Key))
                {
                    warehouse.WarehouseComponents[component.Key] = model.WarehouseComponents[component.Key].Item2;
                }
                else
                {
                    warehouse.WarehouseComponents.Add(component.Key, model.WarehouseComponents[component.Key].Item2);
                }
            }
            return warehouse;
        }

        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                Responsible = warehouse.Responsible,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouse.WarehouseComponents.ToDictionary(recPC => recPC.Key, recPC =>
                     (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }

        

        public bool WriteOff(int GiftCount, int GiftId)
        {
            var list = GetFullList();

            var DCount = source.Gifts.FirstOrDefault(rec => rec.Id == GiftId).GiftComponents;

            DCount = DCount.ToDictionary(rec => rec.Key, rec => rec.Value * GiftCount);

            Dictionary<int, int> Have = new Dictionary<int, int>();

            foreach (var view in list)
            {
                foreach (var d in view.WarehouseComponents)
                {
                    int key = d.Key;
                    if (DCount.ContainsKey(key))
                    {
                        if (Have.ContainsKey(key))
                        {
                            Have[key] += d.Value.Item2;
                        }
                        else
                        {
                            Have.Add(key, d.Value.Item2);
                        }
                    }
                }
            }

            foreach (var key in Have.Keys)
            {
                if (DCount[key] > Have[key])
                {
                    return false;
                }
            }

            foreach (var view in list)
            {
                var warehouseComponents = view.WarehouseComponents;
                foreach (var key in view.WarehouseComponents.Keys.ToArray())
                {
                    var value = view.WarehouseComponents[key];
                    if (DCount.ContainsKey(key))
                    {
                        if (value.Item2 > DCount[key])
                        {
                            warehouseComponents[key] = (value.Item1, value.Item2 - DCount[key]);
                            DCount[key] = 0;
                        }
                        else
                        {
                            warehouseComponents[key] = (value.Item1, 0);
                            DCount[key] -= value.Item2;
                        }
                        Update(new WarehouseBindingModel
                        {
                            Id = view.Id,
                            WarehouseName = view.WarehouseName,
                            Responsible = view.Responsible,
                            DateCreate = view.DateCreate,
                            WarehouseComponents = warehouseComponents
                        });
                    }
                }
            }
            return true;
        }
    }
}
