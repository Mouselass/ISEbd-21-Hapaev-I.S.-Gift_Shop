using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiftShopBusinessLogic.BusinessLogic;
using GiftShopBusinessLogic.ViewModels;
using GiftShopBusinessLogic.BindingModels;

namespace GiftShopView
{
    public partial class FormMails : Form
    {
        private readonly MailLogic logic;

        private PageViewModel pageViewModel;

        public FormMails(MailLogic mailLogic)
        {
            logic = mailLogic;
            InitializeComponent();
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData(int page = 1)
        {
            int pageSize = 7;

            var list = logic.GetMessagesForPage(new MessageInfoBindingModel
            {
                Page = page,
                PageSize = pageSize
            });

            if (list != null)
            {
                pageViewModel = new PageViewModel(logic.Count(), page, pageSize, list);

                Program.ConfigGrid(pageViewModel.Messages, dataGridView);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (pageViewModel.HasNextPage)
            {
                LoadData(pageViewModel.PageNumber + 1);
            }
            else
            {
                MessageBox.Show("Это последняя страница", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (pageViewModel.HasPreviousPage)
            {
                LoadData(pageViewModel.PageNumber - 1);
            }
            else
            {
                MessageBox.Show("Это первая страница", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
