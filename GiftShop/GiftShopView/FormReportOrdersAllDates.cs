﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using GiftShopBusinessLogic.BindingModels;
using GiftShopBusinessLogic.BusinessLogic;
using GiftShopBusinessLogic.ViewModels;
using Unity;
using System.Reflection;

namespace GiftShopView
{
    public partial class FormReportOrdersAllDates : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;

        public FormReportOrdersAllDates(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            try
            {
                MethodInfo method = logic.GetType().GetMethod("GetOrdersForAllDates");
                List<ReportOrdersAllDatesViewModel> dataSource = (List<ReportOrdersAllDatesViewModel>)method.Invoke(logic, new object[] { });

                ReportDataSource source = new ReportDataSource("DataSetOrdersAllDate", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonToPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo method = logic.GetType().GetMethod("SaveOrdersAllDatesToPdfFile");
                        method.Invoke(logic, new object[] { new ReportBindingModel { FileName = dialog.FileName } });

                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                }
            }
        }
    }
}
