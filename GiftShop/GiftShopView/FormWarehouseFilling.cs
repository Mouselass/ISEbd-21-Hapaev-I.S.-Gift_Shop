using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiftShopBusinessLogic.ViewModels;
using GiftShopBusinessLogic.BindingModels;
using GiftShopBusinessLogic.BusinessLogic;
using Unity;

namespace GiftShopView
{
    public partial class FormWarehouseFilling : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int ComponentId { get { return Convert.ToInt32(comboBoxComponent.SelectedValue); } set { comboBoxComponent.SelectedValue = value; } }
        public int WarehouseId { get { return Convert.ToInt32(comboBoxWarehouse.SelectedValue); } set { comboBoxWarehouse.SelectedValue = value; } }
        public int Count { get { return Convert.ToInt32(textBoxCount.Text); } set { textBoxCount.Text = value.ToString(); } }

        public string ComponentName { get { return comboBoxComponent.Text; } }

        WarehouseLogic Wlogic;

        WarehouseBindingModel warehouseBindingModel = new WarehouseBindingModel();

        public FormWarehouseFilling(ComponentLogic logicC, WarehouseLogic logicW)
        {
            InitializeComponent();
            List<ComponentViewModel> listComponent = logicC.Read(null);
            List<WarehouseViewModel> listWarehouse = logicW.Read(null);
            Wlogic = logicW;
            if (listComponent != null)
            {
                comboBoxComponent.DisplayMember = "ComponentName";
                comboBoxComponent.ValueMember = "Id";
                comboBoxComponent.DataSource = listComponent;
                comboBoxComponent.SelectedItem = null;
            }
            if (listWarehouse != null)
            {
                comboBoxWarehouse.DisplayMember = "WarehouseName";
                comboBoxWarehouse.ValueMember = "Id";
                comboBoxWarehouse.DataSource = listWarehouse;
                comboBoxWarehouse.SelectedItem = null;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            WarehouseViewModel view = Wlogic.Read(new WarehouseBindingModel
            {
                Id = WarehouseId
            })?[0];

            if (view != null)
            {
                warehouseBindingModel.WarehouseComponents = view.WarehouseComponents;
                warehouseBindingModel.DateCreate = view.DateCreate;
                warehouseBindingModel.Id = view.Id;
                warehouseBindingModel.Responsible = view.Responsible;
                warehouseBindingModel.WarehouseName = view.WarehouseName;
            }

            if (warehouseBindingModel.WarehouseComponents.ContainsKey(ComponentId))
            {
                int count = warehouseBindingModel.WarehouseComponents[ComponentId].Item2;
                warehouseBindingModel.WarehouseComponents[ComponentId] = (ComponentName, count + Count);
            }
            else
            {
                warehouseBindingModel.WarehouseComponents.Add(ComponentId, (ComponentName, Count));
            }
            Wlogic.CreateOrUpdate(warehouseBindingModel);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
