using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftShopBusinessLogic.BindingModels;
using GiftShopBusinessLogic.BusinessLogic;
using GiftShopBusinessLogic.ViewModels;

namespace GiftShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : Controller
    {
        private readonly WarehouseLogic _warehouseLogic;

        private readonly ComponentLogic _componenLogic;

        public WarehouseController(WarehouseLogic warehouseLogic, ComponentLogic componentLogic)
        {
            _warehouseLogic = warehouseLogic;
            _componenLogic = componentLogic;
        }

        [HttpGet]
        public List<WarehouseViewModel> GetWarehouseList() => _warehouseLogic.Read(null)?.ToList();

        [HttpPost]
        public void CreateOrUpdateWarehouse(WarehouseBindingModel model) => _warehouseLogic.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteWarehouse(WarehouseBindingModel model) => _warehouseLogic.Delete(model);

        [HttpPost]
        public void Filling(WarehouseFillingBindingModel model) => _warehouseLogic.Filling(model);

        [HttpGet]
        public WarehouseViewModel GetWarehouse(int warehouseId) => _warehouseLogic.Read(new WarehouseBindingModel { Id = warehouseId })?[0];

        [HttpGet]
        public List<ComponentViewModel> GetComponentList() => _componenLogic.Read(null);
    }
}
